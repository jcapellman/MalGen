using System;
using System.IO;

using MalGen.Library.Interfaces;

namespace MalGen.Library.Managers
{
    public abstract class BaseManager
    {
        protected IExceptionService exceptionService;

        public bool FileExists(string baseDirectory, string fileName) => File.Exists(Path.Combine(AppContext.BaseDirectory, baseDirectory, fileName));
    }
}