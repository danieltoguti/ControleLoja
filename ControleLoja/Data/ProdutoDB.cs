using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleLoja.Classes;
using ControleLoja.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;

namespace ControleLoja.Data
{
    public class ProdutoDB
    {
        public bool InserirDados(ProdutoModel obj)
        {
            try
            {
                string sSQL = "";
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection cn = new MySqlConnection(CConexao.GET_StringConexao());
                cn.Open();

                sSQL = "insert into produto (nome, preco_custo, qtd, idCategoria, idGenero,preco_sugerido,validade) values (@nome, @preco_custo, @qtd, @idCategoria, @idGenero,@preco_sugerido,@validade)";
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@preco_custo", obj.PrecoCusto);
                cmd.Parameters.AddWithValue("@qtd", obj.Qtd);
                cmd.Parameters.AddWithValue("@idCategoria", obj.idCategoria);
                cmd.Parameters.AddWithValue("@idGenero", obj.idGenero);
                cmd.Parameters.AddWithValue("@preco_sugerido", obj.PrecoSugerido);
                cmd.Parameters.AddWithValue("@validade", obj.Validade);

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

        public bool UpdateDados(ProdutoModel obj)
        {

            try
            {
                string sSQL = "";
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection cn = new MySqlConnection(CConexao.GET_StringConexao());
                cn.Open();

                sSQL = "update produto set nome=@nome, preco_custo=@preco_custo, qtd=@qtd, idCategoria=@idCategoria, idGenero=IdGenero where id=@id";
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@preco_custo", obj.PrecoCusto);
                cmd.Parameters.AddWithValue("@qtd", obj.Qtd);
                cmd.Parameters.AddWithValue("@idCategoria", obj.idCategoria);
                cmd.Parameters.AddWithValue("@idGenero", obj.idGenero);
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

                sSQL = "delete from produto where id=@id";
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

        public bool ValidarNome(ProdutoModel obj)
        {
            try
            {
                string sSQL = "";
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection cn = new MySqlConnection(CConexao.GET_StringConexao());
                cn.Open();

                sSQL = "select * from produto where nome=@nome and preco_custo=@preco_custo " +
                    "and preco_sugerido=@preco_sugerido and qtd=@qtd and validade=@validade " +
                    "and idCategoria=@idCategoria and idGenero=IdGenero";
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@preco_custo", obj.PrecoCusto);
                cmd.Parameters.AddWithValue("@preco_sugerido", obj.PrecoSugerido);
                cmd.Parameters.AddWithValue("@qtd", obj.Qtd);
                cmd.Parameters.AddWithValue("@Validade", obj.Validade);
                cmd.Parameters.AddWithValue("@idCategoria", obj.idCategoria);
                cmd.Parameters.AddWithValue("@idGenero", obj.idGenero);

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

        public List<ProdutoModelVW> GetAll()
        {
            try
            {
                string sSQL = "";
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection cn = new MySqlConnection(CConexao.GET_StringConexao());
                cn.Open();

                sSQL = "SELECT p.id ,p.idGenero,p.idCategoria, p.nome, p.preco_custo, p.preco_sugerido, p.qtd, p.validade, " +
                       "c.categoria,g.genero "+                        
                       "FROM produto AS p " +
                       "LEFT  JOIN categoria_produto AS c ON p.idCategoria = c.id " +
                       "LEFT JOIN genero_produto AS g ON p.idGenero = g.id";
                cmd.CommandText = sSQL;
                cmd.Connection = cn;
                var Dr = cmd.ExecuteReader();

                var Lista = new List<ProdutoModelVW>();

                while (Dr.Read())
                {
                    var item = new ProdutoModelVW
                    {
                        Id = Convert.ToInt32(Dr["Id"]),
                        Nome = Dr["Nome"].ToString(),
                        PrecoCusto = Convert.ToDouble(Dr["preco_custo"]),
                        PrecoSugerido = Convert.ToDouble(Dr["preco_sugerido"]),
                        Qtd = Convert.ToInt32(Dr["qtd"]),
                        idCategoria = Convert.ToInt32(Dr["idCategoria"]),
                        idGenero= Convert.ToInt32(Dr["idGenero"]),
                        Validade =(Dr["Validade"].ToString()==""? new DateTime() : Convert.ToDateTime(Dr["Validade"])),
                        Categoria = Dr["categoria"].ToString(),
                        Genero = Dr["genero"].ToString(),
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

        public List<SelectListItem> GetCategoria()
        {
            try
            {
                string sSQL = "";
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection cn = new MySqlConnection(CConexao.GET_StringConexao());
                cn.Open();

                sSQL = "select * from categoria_produto";
                cmd.CommandText = sSQL;
                cmd.Connection = cn;
                var Dr = cmd.ExecuteReader();

                List<SelectListItem> LT = new List<SelectListItem>();

                while (Dr.Read())
                {
                    var item = new SelectListItem
                    {
                        Value = Dr["Id"].ToString(),
                        Text = Dr["Categoria"].ToString(),
                    };                  

                    LT.Add(item);
                }

                return LT;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }

        public List<SelectListItem> GetGenero()
        {
            try
            {
                string sSQL = "";
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection cn = new MySqlConnection(CConexao.GET_StringConexao());
                cn.Open();

                sSQL = "select * from genero_produto";
                cmd.CommandText = sSQL;
                cmd.Connection = cn;
                var Dr = cmd.ExecuteReader();

                List<SelectListItem> LT = new List<SelectListItem>();

                while (Dr.Read())
                {
                    var item = new SelectListItem
                    {
                        Value = Dr["Id"].ToString(),
                        Text = Dr["genero"].ToString(),
                    };

                    LT.Add(item);
                }

                return LT;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }
    }


}
