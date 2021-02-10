using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        

        public Result(bool success, string message):this(success) //set etmeyi ctor ile yapıyoruz .bu sayede standart bir yapı oluşur.yazılımcı sınırlanmış olur. ctor yazarken get leri set etsin diye. this demek bu class demek yani result demek.bunu inherit yaptığımızda bu klasın tek parametreli ctoru da çalışır.çünkü bu ctor aşağıdakini kapsar.
        {
            Message = message;
            
        }

        public Result(bool success) //sadece true veya false dönsün mesaj versin istemiyorum overloading. success set etme işini buraya verdim
        {
           
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
