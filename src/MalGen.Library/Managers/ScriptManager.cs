using System;

using MalGen.Library.Objects;
using MalGen.Library.Objects.Containers;

namespace MalGen.Library.Managers
{
    public class ScriptManager : BaseManager {
        public SetResponse<BaseScript> LoadScript(string name)
        {
            try
            {
                if (!FileExists(Common.Constants.FOLDER_NAME_SCRIPTS, name))
                {
                    throw new Exception($"{Common.Constants.FOLDER_NAME_SCRIPTS}{name} does not exist");
                }

                return null;
            }
            catch (Exception ex)
            {
                return new SetResponse<BaseScript>(ex);
            }
        }
    }
}