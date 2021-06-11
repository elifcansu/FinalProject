using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    { /*ona verdiğimiz bir passwordun hashini oluşturcak.anı şekilde saltını da oluşturacak apıyı içeiyor olacak.
        out dışarıya verilecek değeri belirtir.
            bizim verdiimize şifeye özel hash ve salt oluşturucak
       */
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) //algoritma oluşturuyoruz
            {
                passwordSalt = hmac.Key; //algoritmanın keyi bu .her algoritma için bir key oluşturur.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //gönderilen passwordun byte değerini alıyoruz.
            }
        }

        //sonradan sisteme girmek için verdiği passwordun bizim veri kaynağımızdaki passwordHash ile ilgili passwordSalt göre eşlenip eşleşmediğini verdiğimiz yer.
        //password hashini doğrula demek.burada yukarıda gönderilen hash değei veritabanındaki ile aynı mı diye kontrol edip doğrulama yapıyoruz.o yücden biz gimiş oluyoruz dışardan almıyoruz.out o üzden yok.
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) //saltı buraa kullandııyoruz.anahtarı verdik yani
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //eşitleme yapıyor
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i]) //gönderilen computedhash ile veitabanındaki hash aynı değilse false dön
                    {
                        return false;
                    }
                }

                return true;
            }

        }
    }
}