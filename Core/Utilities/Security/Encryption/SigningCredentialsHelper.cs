﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper //credential dediğimiz bizim anahtarımız yani kullanıcı bilgilerimiz.jwt nın ihtiyaç duyduğu yapılar bunlar.
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature); //hangi anahtar ve hangi algoritma kullanacagını veriyoruz burada.
        }
    }
}
