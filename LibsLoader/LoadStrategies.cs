using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using IInterfaces;

namespace LibsLoader
{
    public static class LoadStrategies
    {
        private static Collection<IPattern> _patterns = new Collection<IPattern>();
        private static Collection<IStrategy> _strategies = new Collection<IStrategy>();

        public static Collection<IPattern> GetPatterns => _patterns;
        public static Collection<IStrategy> GetStrategies => _strategies;

        public static void Load()
        {
            

            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"lib");

            string[] files = Directory.GetFiles(folder, "*.dll");

            if (files.Length > 0)
            {
                foreach (string file in files)
                {
                    try
                    {
                        Assembly assembly = Assembly.LoadFrom(file);
                        foreach (Type type in assembly.GetTypes())
                        {
                            //TODO Switch?

                            Type iPattern = type.GetInterface("IPattern");
                            if (iPattern != null)
                            {
                                IPattern module = (IPattern)Activator.CreateInstance(type);
                                _patterns.Add(module);
                            }

                            Type iStrategy = type.GetInterface("IStrategy");
                            if (iStrategy != null)
                            {
                                IStrategy module = (IStrategy) Activator.CreateInstance(type);
                                _strategies.Add(module);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Ошибка загрузки библиотек\n" + ex.Message);
                    }
                }
            }
            //return _patterns;
        }
    }
}
