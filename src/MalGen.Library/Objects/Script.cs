using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

using MalGen.Library.Fields;
using MalGen.Library.Objects.Containers;

namespace MalGen.Library.Objects
{
    public class Script
    {
        private readonly string _scriptString;

        public SetResponse<List<byte>> CompileScript()
        {
            return new SetResponse<List<byte>>(ParseText());
        }

        private List<byte> ParseText()
        {
            var data = new List<byte>();

            var regex = new Regex("\\{([^}]*)\\}");
            var matches = regex.Matches(_scriptString);

            var fields = Assembly.GetEntryAssembly().GetTypes().Select(t => (BaseField)Activator.CreateInstance(t)).ToList();

            foreach (Match match in matches)
            {
                var field = fields.FirstOrDefault(a => a.GetFieldName() == match.Value);

                if (field == null)
                {
                    continue;
                }

                data.AddRange(field.GetBytes());
            }

            return data;
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