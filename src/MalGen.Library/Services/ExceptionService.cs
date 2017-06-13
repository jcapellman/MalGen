using System;

using MalGen.Library.Interfaces;

namespace MalGen.Library.Services
{
    public class ExceptionService : IExceptionService
    {
        public void RecordException(Exception exception)
        {
            Console.WriteLine($"{DateTime.Now} - {exception.Message} | Inner: {exception.InnerException}");
        }
    }
}