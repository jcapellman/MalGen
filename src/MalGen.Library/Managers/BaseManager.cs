using System;
using System.IO;

using MalGen.Library.Interfaces;

namespace MalGen.Library.Managers
{
    public abstract class BaseManager
    {
        protected IExceptionService exceptionService;

        public string GenerateFilePath(string baseDirectory, string fileName) => Path.Combine(AppContext.BaseDirectory,
            baseDirectory, fileName);

        public bool FileExists(string baseDirectory, string fileName) => File.Exists(GenerateFilePath(baseDirectory, fileName));
    }
}