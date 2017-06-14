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

        public void Run(string[] args)
        {
            var argParser = new ArgumentParser(_exceptionService);
            
            var parserStatus = argParser.ParseArguments(args);

            if (parserStatus.HasError || parserStatus.ObjectValue != ARGUMENT_PARSER_STATUS.SUCCESS)
            {
                var stringResponse = argParser.GetStatusString(parserStatus.ObjectValue);

                if (!stringResponse.HasError)
                {
                   System.Console.WriteLine(stringResponse.ObjectValue);
                }

                return;
            }

            System.Console.ReadKey();
        }
    }
}