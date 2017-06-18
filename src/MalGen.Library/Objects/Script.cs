using System;
using System.Collections.Generic;
using System.IO;

using MalGen.Library.Objects.Containers;

namespace MalGen.Library.Objects
{
    public class Script
    {
        private string _scriptString;

        public SetResponse<List<byte>> CompileScript()
        {
            return new SetResponse<List<byte>>(new List<byte>());
        }

        public Script(string scriptString)
        {
            _scriptString = scriptString;
        }

        /// <summary>
        /// Loads Script, assumes file exists
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static SetResponse<Script> LoadScript(string fileName)
        {
            try
            {
                var text = File.ReadAllText(fileName);
                
                return new SetResponse<Script>(new Script(text));
            }
            catch (Exception ex)
            {
                return new SetResponse<Script>(ex);
            }
        }
    }
}