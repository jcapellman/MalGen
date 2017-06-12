using System;

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

        public void Run()
        {
            Console.WriteLine("Testing");
            System.Console.ReadKey();
        }
    }
}