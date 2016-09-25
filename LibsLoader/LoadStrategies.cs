using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using InterfaceStrategyLib;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace LibsLoader
{
    public class LoadStrategies
    {
        public void Load()
        {
            Collection<IStrategy> Modules = new Collection<IStrategy>();

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
                            Type iface = type.GetInterface("IStrategy");
                            if (iface != null)
                            {
                                IStrategy module = (IStrategy)Activator.CreateInstance(type);
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
        }
    }
}
