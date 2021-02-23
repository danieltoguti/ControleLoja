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

        string sCNX = CConexao.GET_StringConexao();



        public bool InserirDados(ProdutoModel obj)
        {
            try
            {
                /* string sSQL = "";
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
                 cmd.ExecuteNonQuery();*/

                return CConexao.InsertRegistro(obj, "produto", sCNX);

                
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
                /* string sSQL = "";
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
                 return true;*/
                
                //============================================================
                //AQUI ELE VAI FAZER UPDATE EM TODOS OS OBJETOS DA CLASSE
                //SE QUISER FAZER UPDATE EM APENAS UM CAMPO  FAÇA IGUAL A CIMA
                MySqlCommand cmd = new MySqlCommand();
                cmd.Parameters.AddWithValue("@id", obj.Id);
                return CConexao.UpdateRegistro(obj, "produto", cmd, sCNX);
                
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
                /*string sSQL = "";
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection cn = new MySqlConnection(CConexao.GET_StringConexao());
                cn.Open();

                sSQL = "delete from produto where id=@id";
                cmd.Parameters.AddWithValue("@id", id);

                cmd.CommandText = sSQL;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();*/

                MySqlCommand cmd = new MySqlCommand();
                string sSQL = "delete from produto where id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandText = sSQL;

                return CConexao.ExecutarSql(cmd,sCNX);
                
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
                /* string sSQL = "";
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
                 return Dr.HasRows;*/

                MySqlCommand cmd = new MySqlCommand();
                string sSQL = "select * from produto where nome=@nome and preco_custo=@preco_custo " +
                    "and preco_sugerido=@preco_sugerido and qtd=@qtd and validade=@validade " +
                    "and idCategoria=@idCategoria and idGenero=IdGenero";
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@preco_custo", obj.Preco_Custo);
                cmd.Parameters.AddWithValue("@preco_sugerido", obj.Preco_Sugerido);
                cmd.Parameters.AddWithValue("@qtd", obj.Qtd);
                cmd.Parameters.AddWithValue("@Validade", obj.Validade);
                cmd.Parameters.AddWithValue("@idCategoria", obj.idCategoria);
                cmd.Parameters.AddWithValue("@idGenero", obj.idGenero);
                cmd.CommandText = sSQL;

                var DS = CConexao.GET_DataSet(cmd, sCNX);

                return (DS.Tables[0].Rows.Count > 0 ? true : false);
                

            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }


        //ESSE AQUI EU MUDEI, AGORA ELE GERA UMA DATASET USANDO O MÉTODO  "GET_DataSet"
        public List<ProdutoModelVW> GetAll()
        {
            try
            {
                string sSQL = "";
                MySqlCommand cmd = new MySqlCommand();                                

                sSQL = "SELECT p.id ,p.idGenero,p.idCategoria, p.nome, p.preco_custo, p.preco_sugerido, p.qtd, p.validade, " +
                       "c.categoria,g.genero "+                        
                       "FROM produto AS p " +
                       "LEFT  JOIN categoria_produto AS c ON p.idCategoria = c.id " +
                       "LEFT JOIN genero_produto AS g ON p.idGenero = g.id";
                cmd.CommandText = sSQL;

                var Ds = CConexao.GET_DataSet(cmd, sCNX);

                var Lista = new List<ProdutoModelVW>();

                for (int i = 0; i <= Ds.Tables[0].Rows.Count - 1; i++) {
                    var item = new ProdutoModelVW
                    {
                        Id = Convert.ToInt32(Ds.Tables[0].Rows[i]["Id"]),
                        Nome = Ds.Tables[0].Rows[i]["Nome"].ToString(),
                        Preco_Custo = Convert.ToDouble(Ds.Tables[0].Rows[i]["preco_custo"]),
                        Preco_Sugerido = Convert.ToDouble(Ds.Tables[0].Rows[i]["preco_sugerido"]),
                        Qtd = Convert.ToInt32(Ds.Tables[0].Rows[i]["qtd"]),
                        idCategoria = Convert.ToInt32(Ds.Tables[0].Rows[i]["idCategoria"]),
                        idGenero = Convert.ToInt32(Ds.Tables[0].Rows[i]["idGenero"]),
                        Validade = (Ds.Tables[0].Rows[i]["Validade"].ToString() == "" ? new DateTime() : Convert.ToDateTime(Ds.Tables[0].Rows[i]["Validade"])),
                        Categoria = Ds.Tables[0].Rows[i]["categoria"].ToString(),
                        Genero = Ds.Tables[0].Rows[i]["genero"].ToString(),
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


        public List<ProdutoModelVW> GetAll_OLD()
        {
            try
            {
                string sSQL = "";
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection cn = new MySqlConnection(CConexao.GET_StringConexao());
                cn.Open();

                sSQL = "SELECT p.id ,p.idGenero,p.idCategoria, p.nome, p.preco_custo, p.preco_sugerido, p.qtd, p.validade, " +
                       "c.categoria,g.genero " +
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
                        Preco_Custo = Convert.ToDouble(Dr["preco_custo"]),
                        Preco_Sugerido = Convert.ToDouble(Dr["preco_sugerido"]),
                        Qtd = Convert.ToInt32(Dr["qtd"]),
                        idCategoria = Convert.ToInt32(Dr["idCategoria"]),
                        idGenero = Convert.ToInt32(Dr["idGenero"]),
                        Validade = (Dr["Validade"].ToString() == "" ? new DateTime() : Convert.ToDateTime(Dr["Validade"])),
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

      
    }


}
