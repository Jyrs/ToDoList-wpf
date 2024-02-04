using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace ToDoList.Core
{
    static class PasswordCryptography 
    {

        public static string GetHash(string input)
        {
            var Md5 = MD5.Create();
            var hash = Md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }

        public static string GetPasswordHash(string lgn, string pswrd)
        {
            //хэш(индивидуальная_соль + хэш(хэш(имя_пароль) + хэш(пароль_пользователя)))
            var hash = GetHash(lgn + GetHash(GetHash(pswrd) + GetHash(lgn)));
            return hash;
        }



    }
}
