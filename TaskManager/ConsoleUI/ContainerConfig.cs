using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TaskManager;
using TaskManager.DataAccess;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileDataAccess>().As<IDataGateway>();
                     
            return builder.Build();
        }
    }
}
