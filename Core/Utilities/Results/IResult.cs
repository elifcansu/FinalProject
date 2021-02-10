using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //temel voidler için başlangıç
    public interface IResult  //VOİDLER İÇİN YAZILDI.
    {
        //uygulamayı kullanacak kişileri doğru yönlendirmek amaç

        //get okunabilir demek.
        //set yazılabilir demek.
        bool Success { get; } //başarılı mı başarısız mı yapmaya çalıştığım mesela add ekleme başarılı  mı diye sorar?

        string Message { get; } //işlem sonucu mesaj döndürür.
    }
}
