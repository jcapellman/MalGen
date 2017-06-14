using System;

namespace MalGen.Library.Objects.Containers
{
    public class SetResponse<T>
    {
        public T ObjectValue { get; set; }

        public string ExceptionString => ExceptionObject.ToString();

        public Exception ExceptionObject { get; internal set; }

        public bool HasError => ExceptionObject != null;

        public SetResponse(T objectValue)
        {
            ObjectValue = objectValue;
        }

        public SetResponse(Exception ex)
        {
            ExceptionObject = ex;
        }
    }
}