using System;

using MalGen.app.Enums;
using MalGen.app.Helpers;
using MalGen.Library.Interfaces;

namespace MalGen.app
{
    public class App
    {
        private readonly IExceptionService _exceptionService;

        public App(IExceptionService exceptionService)
        {
            _exceptionService = exceptionService;
        }

        private void Init()
        {
            Console.WriteLine($"{Library.Common.Constants.APP_NAME} {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version} - (Running on {System.Environment.OSVersion})");
            Console.WriteLine($"(C)2017 Jarred Capellman - use this respnsibly");
            Console.WriteLine("-----------------------------------------------");
        }

        public void Run(string[] args)
        {
            Init();
            
            var argParser = new ArgumentParser(_exceptionService);
            
            var parserStatus = argParser.ParseArguments(args);

            if (parserStatus.HasError || parserStatus.ObjectValue != ARGUMENT_PARSER_STATUS.SUCCESS)
            {
                var stringResponse = argParser.GetStatusString(parserStatus.ObjectValue);

                if (!stringResponse.HasError)
                {
                   System.Console.WriteLine($"{stringResponse.ObjectValue}{System.Environment.NewLine}");
                }

                return;
            }

            System.Console.ReadKey();
        }
    }
}