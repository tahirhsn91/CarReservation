using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core
{
    public static class IoC
    {
        private static IUnityContainer _container;

        static IoC()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "unity.config");
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = filePath };
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");
            _container = new UnityContainer();
            _container.LoadConfiguration(unitySection);
        }

        public static T Resolve<T>()
        {
            return (T)_container.Resolve<T>();
        }

        public static bool Exists<T>()
        {
            return _container.IsRegistered<T>();
        }

        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
        }
    }
}
