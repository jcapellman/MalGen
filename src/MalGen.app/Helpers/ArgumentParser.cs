using System;

using MalGen.app.Enums;
using MalGen.Library.Interfaces;
using MalGen.Library.Objects.Containers;

namespace MalGen.app.Helpers
{
    public class ArgumentParser
    {
        private readonly IExceptionService _exceptionService;

        public ArgumentParser(IExceptionService exceptionService)
        {
            _exceptionService = exceptionService;
        }

        public SetResponse<ARGUMENT_PARSER_STATUS> ParseArguments(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                return new SetResponse<ARGUMENT_PARSER_STATUS>(ARGUMENT_PARSER_STATUS.NO_ARGUMENTS);
            }

            if (args.Length < 2)
            {
                return new SetResponse<ARGUMENT_PARSER_STATUS>(ARGUMENT_PARSER_STATUS.MISSING_ARGUMENTS);
            }

            return new SetResponse<ARGUMENT_PARSER_STATUS>(ARGUMENT_PARSER_STATUS.SUCCESS);
        }

        public SetResponse<string> GetStatusString(ARGUMENT_PARSER_STATUS argParserStatus)
        {
            try
            {
                switch (argParserStatus)
                {
                    case ARGUMENT_PARSER_STATUS.NO_ARGUMENTS:
                        return new SetResponse<string>("No arguments provided");
                    case ARGUMENT_PARSER_STATUS.MISSING_ARGUMENTS:
                        return new SetResponse<string>("-s (Script Template) and -o (Output File) are required arguments");
                }

                throw new Exception($"{argParserStatus} was not handled");
            }
            catch (Exception ex)
            {
                _exceptionService.RecordException(ex);
                return new SetResponse<string>(ex);
            }
        }
    }
}