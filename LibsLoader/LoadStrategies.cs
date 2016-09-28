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
        public static Collection<IPattern> Load()
        {
            Collection<IPattern> Modules = new Collection<IPattern>();

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
                            Type iface = type.GetInterface("IPattern");
                            if (iface != null)
                            {
                                IPattern module = (IPattern)Activator.CreateInstance(type);
                                Modules.Add(module);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Ошибка загрузки библиотек\n" + ex.Message);
                    }
                }
            }
            return Modules;
        }
    }
}
