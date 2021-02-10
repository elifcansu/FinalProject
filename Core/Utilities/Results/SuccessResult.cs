using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        //base dediğiniz result
        public SuccessResult(string message) : base(true, message) //productmanagerda direkt bu sınıfı gönderip true oldugunu kabul edip mesaj verdik.
        {

        }

        public SuccessResult():base(true) //bu hareketlerle true defualt vermiş olduk.
        {

        }
    }
}
