using App.MinhaCDN.Interfaces;
using App.MinhaCDN.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace App.MinhaCDN
{
    public class Program
    {
        private static ILog LogInstance;
        private static string PathDocsLogs = "../../../../../logs/Logs.txt";
        private static string PathResultLogs = "../../../../../logs/ResultadLogs.txt";
        static void Main(string[] args)
        {
            //CONFIGURANDO INJEÇÃO DE DEPDENNCIAS
            InjecaoDepdencia();

            //PEGANDO O ARQUIVO DE LOG
            string Logs = File.ReadAllText(PathDocsLogs);

            //FAZENDO A CONVERÇÃO DOS LOGS
            string ResultadLogs = LogInstance.ConverterLog(Logs);
            File.WriteAllText(PathResultLogs, ResultadLogs);
            Console.WriteLine(ResultadLogs);
            Console.ReadKey();
        }
        public static ILog InjecaoDepdencia()
        { 
            //FAZENDO INJEÇÃO DE DEPENDENCIAS
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<IResolve, Resolve>();
            serviceCollection.AddScoped<IValidation, Validation>();
            serviceCollection.AddScoped<ILog, Log>();

            var provider = serviceCollection.BuildServiceProvider();
            LogInstance = provider.GetService<ILog>();
            return LogInstance;
        }
    }
}
