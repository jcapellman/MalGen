using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

using MalGen.Library.Enums;
using MalGen.Library.Objects.Containers;

namespace MalGen.Library.Objects
{
    public class Script
    {
        private readonly string _scriptString;

        public SetResponse<List<byte>> CompileScript()
        {
            return new SetResponse<List<byte>>(parseText());
        }

        private List<byte> parseText()
        {
            var regex = new Regex("\\{([^}]*)\\}");
            var matches = regex.Matches(_scriptString);

            foreach (Match match in matches)
            {
                if (!Enum.TryParse(match.Value, true, out SCRIPT_FIELDS fieldType))
                {
                    continue;
                }

                switch (fieldType)
                {
                    case SCRIPT_FIELDS.BASE_EXE:
                        break;
                }
            }

            return new List<byte>();
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