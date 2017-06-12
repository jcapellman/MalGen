using System;

namespace MalGen.Library.Objects.Containers
{
    public class SetResponse<T>
    {
        public T ObjectValue { get; set; }

        public string ExceptionString { get; set; }

        public bool HasError => !string.IsNullOrEmpty(ExceptionString);

        public SetResponse(T objectValue)
        {
            ObjectValue = objectValue;
        }

        public SetResponse(Exception ex)
        {
            ExceptionString = ex.ToString();
        }
    }
}