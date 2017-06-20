using System;

namespace MalGen.Library.Fields
{
    public class BaseExeField : BaseField
    {
        public override string GetFieldName() => "BASE_EXE";

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }
    }
}