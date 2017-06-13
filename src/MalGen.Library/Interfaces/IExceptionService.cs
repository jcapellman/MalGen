using System;

namespace MalGen.Library.Interfaces
{
    public interface IExceptionService
    {
        void RecordException(Exception exception);
    }
}