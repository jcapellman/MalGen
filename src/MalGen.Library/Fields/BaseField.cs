namespace MalGen.Library.Fields
{
    public abstract class BaseField
    {
        public abstract string GetFieldName();

        public abstract byte[] GetBytes();
    }
}