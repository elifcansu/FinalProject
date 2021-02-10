using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {

        public ErrorDataResult(T data, string message) : base(data, false, message)//data ve mesaj ver
        {

        }

        public ErrorDataResult(T data) : base(data, false)//data  ver
        {

        }

        public ErrorDataResult(string message) : base(default, false, message) //default data var sadece mesaj veriyor //çok kullanılmaz
        {

        }

        public ErrorDataResult() : base(default, false) //default data var hiç birşey vermiyor.//çok kullanılmaz
        {

        }

    }
}
