using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool success,string message):base(success,message) //base'e sonuç ve mesaj gönder
        {
            Data = data;
        }

        public DataResult(T data,bool success):base(success) //base'e sonuç gönder
        {
            Data = data;
        }
        public T Data { get; }
    }
}
