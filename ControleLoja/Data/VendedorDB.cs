using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ControleLoja.Classes;
using ControleLoja.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;

namespace ControleLoja.Data
{
    public class VendedorDB
    {
        public bool InserirDados(VendedorModel obj)
        {
            try
            {
                string sSQL = "";
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection cn = new MySqlConnection(CConexao.GET_StringConexao());
                cn.Open();

                sSQL = "insert into vendedor (nome, email, senha) values (@nome, @email, @senha)";
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@email", obj.Email);
                cmd.Parameters.AddWithValue("@senha", obj.Senha);

                cmd.CommandText = sSQL;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }

        public bool UpdateDados(VendedorModel obj)
        {

            try
            {
                string sSQL = "";
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection cn = new MySqlConnection(CConexao.GET_StringConexao());
                cn.Open();

                sSQL = "update vendedor set nome=@nome, email=@email, @senha=senha where id=@id";
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@email", obj.Email);
                cmd.Parameters.AddWithValue("@senha", obj.Senha);
                cmd.Parameters.AddWithValue("@id", obj.Id);

                cmd.CommandText = sSQL;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }

        public bool ExcluirDados(int id)
        {
            try
            {
                string sSQL = "";
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection cn = new MySqlConnection(CConexao.GET_StringConexao());
                cn.Open();

                sSQL = "delete from vendedor where id=@id";
                cmd.Parameters.AddWithValue("@id", id);

                cmd.CommandText = sSQL;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }

        public bool ValidarNome(VendedorModel obj)
        {
            try
            {
                string sSQL = "";
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection cn = new MySqlConnection(CConexao.GET_StringConexao());
                cn.Open();

                sSQL = "select * from vendedor where nome=@nome and email=@email";
                cmd.Parameters.AddWithValue("@nome", obj.Nome);

                cmd.CommandText = sSQL;
                cmd.Connection = cn;
                var Dr = cmd.ExecuteReader();
                return Dr.HasRows;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }

        public async Task<bool> ValidarNomeLoginAsync(VendedorModel obj, IHttpContextAccessor hcont)
        {
            try
            {
                string sSQL = "";
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection cn = new MySqlConnection(CConexao.GET_StringConexao());
                cn.Open();

                sSQL = "select * from vendedor where email=@email and senha=@senha";

                cmd.Parameters.AddWithValue("@email", obj.Email);
                cmd.Parameters.AddWithValue("@senha", obj.Senha);
                cmd.Parameters.AddWithValue("@tipo", obj.Tipo);

                cmd.CommandText = sSQL;
                cmd.Connection = cn;
                var Dr = cmd.ExecuteReader();

                if (Dr.HasRows)
                {
                    Dr.Read();
                    var claims1 = new[]
                                               {
                                new Claim("Nome",Dr["Nome"].ToString()),
                                new Claim("Email",Dr["Email"].ToString()),
                                new Claim("Tipo",Dr["Tipo"].ToString()),
                                new Claim(ClaimTypes.Role, "Logado"),
                                new Claim(ClaimTypes.Role, Dr["Tipo"].ToString()),
                    }.ToList();


                    var identity1 = new ClaimsIdentity(claims1, CookieAuthenticationDefaults.AuthenticationScheme);
                    await hcont.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity1));
                }


                return Dr.HasRows;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }

        public List<VendedorModel> GetAll()
        {
            try
            {
                string sSQL = "";
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection cn = new MySqlConnection(CConexao.GET_StringConexao());
                cn.Open();

                sSQL = "select * from vendedor order by nome";
                cmd.CommandText = sSQL;
                cmd.Connection = cn;
                var Dr = cmd.ExecuteReader();

                var Lista = new List<VendedorModel>();

                while (Dr.Read())
                {
                    var item = new VendedorModel
                    {
                        Id = Convert.ToInt32(Dr["Id"]),
                        Nome = Dr["Nome"].ToString(),
                        Email = Dr["Email"].ToString()
                    };

                    Lista.Add(item);
                }

                return Lista;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }

    }
}
