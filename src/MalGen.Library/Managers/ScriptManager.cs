using System;

using MalGen.Library.Interfaces;
using MalGen.Library.Objects;
using MalGen.Library.Objects.Containers;

namespace MalGen.Library.Managers
{
    public class ScriptManager : BaseManager {
        public ScriptManager(IExceptionService exceptionService)
        {
            this.exceptionService = exceptionService;
        }

        public SetResponse<Script> LoadScript(string name)
        {
            try
            {
                if (!FileExists(Common.Constants.FOLDER_NAME_SCRIPTS, name))
                {
                    throw new Exception($"{Common.Constants.FOLDER_NAME_SCRIPTS}{name} does not exist");
                }

                return new SetResponse<Script>(Script.LoadScript(GenerateFilePath(Common.Constants.FOLDER_NAME_SCRIPTS, name)));
            }
            catch (Exception ex)
            {
                exceptionService.RecordException(ex);

                return new SetResponse<Script>(ex);
            }
        }
    }
}