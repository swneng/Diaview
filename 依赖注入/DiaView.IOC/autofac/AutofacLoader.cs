using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Configuration;
using Autofac.Core;
using Autofac.Util;
namespace Ioc.Autofac
{
    public class AutofacLoader
    {
        public IContainer Container
        {
            get;set;
        }
        private static AutofacLoader _instance;
        public static AutofacLoader Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                else
                {
                    _instance = new AutofacLoader("autofac.json");
                    return _instance;
                }
            }
        }
        public AutofacLoader(string JsonFile)
        {
            ConfigFromJson(JsonFile);
        }
        public void ConfigFromJson(string JsonFile)
        {
            var config = new ConfigurationBuilder();
            config.SetBasePath("D:\\3.工作\\4.开发环境\\Source Code\\DiaView\\trunk\\DiaView\\后台解决方案\\IOC\\Ioc.Autofac\\");
            config.AddJsonFile(JsonFile);
            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);
            Container = builder.Build();
        }

    }
}
