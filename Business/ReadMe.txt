constants ---sabitler projedeki sabitler olarak kullnacağız


api ---- client 
JWT (jASON WEB TOKEN)    Client bir istekte bulunduğunda eğer bir yetkilendirme varsa o zaman http post dönecektir ve o bilgiyi göstemeyecektir.bunun için bir kullanıcı adı şife isteyebilir. eğer doğru giriş yaparsak jwt bi token verecek.
mesela product eklemesi yapcaz tokenla birlikte api ye gidebiliriz. veritabanına bakar bu arkadaşın yetkisi varsa ona cevap verir.


güvenlik ile ilgili kavramlar;
encryption,hashing bir datayı karşı taraf okuyamasın diye yapılan çalışmalar.
mesela kullanıcının parolasını hashing ile gizleriz o parolaları 
bir yerde tutarız başkaları görmesin diye. 123@12 gibi bir şifreyi MD5 ,SHA1  şifreleme algoritmaları vasıtasıyla geri dönüşü olmayacak şekilde şifrelenir. örneğin BDX3-5fjkjfdjfd-kdhfh gibi verilerle tutarız.
kullanıcı giriş yaparken şifrsine o an ine hash yapılır. ve o kullanıcının emailine sahip şifrenin hash karşılaştırması yapılır. eğer tutuyorsa giriş yapar.


salting-->kullanıcının  girdiği parolaya biz ekleme yapıp güçlendiriyoruz.


encryption--->geri dönüşü olan veridir.ilgili datamızı şifrelemiş oluruz.o şifreyi bilmeden ona giriş yapılamaz.şifrelemeyi key ile tutarız .bu sayede o key sayesinde giriş çıkış yaparız.
decryption --->çözme yapar

"Audience"------> bizim web adresimizin adı.Kitle demek
"Issuer"
"AccessTokenExpiration" --------->Token geçerlilik süremiz.biz 10 dakika verdik
"SecurityKey" -------->tokenı kullanacağımız anahtar. asp.net in kullanacağı anahtar.