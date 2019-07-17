using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desafio.Models
{
    public class LoginModal
    {
        private readonly DESAFIOEntities _data = new DESAFIOEntities();

        public Tbl_Login Login(string login, string senha)

        {
            var dadoslogin = _data.Tbl_Login.Where(p => (p.Login.Trim() == login.Trim()) && p.Senha == senha.Trim()).FirstOrDefault();
            if (dadoslogin != null)
            {

                return dadoslogin;
            }

            else
            {
                return null;

            }

        }

    }
}