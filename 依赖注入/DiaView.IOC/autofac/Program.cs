using System;
using Autofac;
using Ioc.Autofac.Test;

namespace Ioc.Autofac
{
    class Program
    {
        static void Main(string[] args)
        {
           var test =  AutofacLoader.Instance.Container.BeginLifetimeScope().Resolve<IAutofacLoaderTest>();
            Console.Write(test.Write());
        }
    }
}
