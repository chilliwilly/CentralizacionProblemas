using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace problema_bal
{
    public class codificar_pwd
    {
        public String cryptoPwd(String inpwd) 
        {
            String localPwd = "";

            System.Security.Cryptography.MD5CryptoServiceProvider pwd = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(inpwd);
            data = pwd.ComputeHash(data);
            //string localPwd = "";
            for (int i = 0; i < data.Length; i++)
            localPwd += data[i].ToString("x2").ToLower();
            
            return localPwd;
        }
    }
}
