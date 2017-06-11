using System.IO;

using MalGen.Library.Objects;

namespace MalGen.Library.Managers
{
    public class ScriptManager : BaseManager {
        public BaseScript LoadScript(string name)
        {
            if (!FileExists(Common.Constants.FOLDER_NAME_SCRIPTS, name))
            {
                return null;
            }

            return null;
        }
    }
}