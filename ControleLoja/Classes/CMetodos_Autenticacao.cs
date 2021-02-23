using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleLoja.Classes
{
    public class CMetodos_Autenticacao
    {
        public enum eDadosUser
        {
            Nome,
            Email,   
            Tipo,
        }


        public static string GET_DadosUser(object Context, eDadosUser Dados)
        {
            try
            {
                HttpContext hcont = null;
                try
                {
                    hcont = (HttpContext)Context;
                }
                catch
                {

                    hcont = ((IHttpContextAccessor)Context).HttpContext;
                }


                switch (Dados)
                {
                    case eDadosUser.Nome:
                        return hcont.User.Identities.FirstOrDefault().Claims.ToList().Where(a => a.Type == "Nome").FirstOrDefault().Value;

                    case eDadosUser.Email:
                        return hcont.User.Identities.FirstOrDefault().Claims.ToList().Where(a => a.Type == "Email").FirstOrDefault().Value;

                    case eDadosUser.Tipo:
                        return hcont.User.Identities.FirstOrDefault().Claims.ToList().Where(a => a.Type == "Tipo").FirstOrDefault().Value;

                }
            }
            catch { }

            return "";
        }
    }
}
