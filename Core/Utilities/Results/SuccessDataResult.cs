using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,string message):base(data,true,message)//data ve mesaj ver
        {

        }

        public SuccessDataResult(T data):base(data,true)//data  ver
        {

        }

        public SuccessDataResult(string message):base(default,true,message) //default data var sadece mesaj veriyor //çok kullanılmaz
        {

        }

        public SuccessDataResult():base(default,true) //default data var hiç birşey vermiyor.//çok kullanılmaz
        {

        }
    }
}
