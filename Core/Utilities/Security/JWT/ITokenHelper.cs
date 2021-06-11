using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
        /*kullanıcı değerlerini yazıp giriş yaptıgında .eğer doğruysa bilgileri bu operasyon çalışacak .ve ilgili kullanıcı için veritabanına gidecek veritabnından bu 
          kullanıcının claimlerini bulacak.orada bir jwt üretecek ve onları tekrar kullanıcının giriş yaptğı o ekrana verecek
          
        */

    }
}
