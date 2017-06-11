using System;
using System.IO;

namespace MalGen.Library.Managers
{
    public abstract class BaseManager
    {
        public bool FileExists(string baseDirectory, string fileName) => File.Exists(Path.Combine(AppContext.BaseDirectory, baseDirectory, fileName));
    }
}