using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; } //jwt tokenın ta kendisi.kullanıcı api üzerinden yani postmanden kullanıcı adı ve parolasını verecek bizde ona bir tane token vereceğiz . 
        public DateTime Expiration { get; set; } //tokenın bitiş zamanı .
    }
}
