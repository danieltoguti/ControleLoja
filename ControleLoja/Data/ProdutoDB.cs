using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleLoja.Classes;
using ControleLoja.Models;
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

                sSQL = "insert into produto (nome, preco_custo, qtd, idCategoria, idGenero) values (@nome, @preco_custo, @qtd, @idCategoria, @idGenero)";
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@preco_custo", obj.PrecoCusto);
                cmd.Parameters.AddWithValue("@qtd", obj.Qtd);
                cmd.Parameters.AddWithValue("@idCategoria", obj.Categoria);
                cmd.Parameters.AddWithValue("@idGenero", obj.Genero);

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
                cmd.Parameters.AddWithValue("@idCategoria", obj.Categoria);
                cmd.Parameters.AddWithValue("@idGenero", obj.Genero);
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
                cmd.Parameters.AddWithValue("@idCategoria", obj.Categoria);
                cmd.Parameters.AddWithValue("@idGenero", obj.Genero);

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

        public List<ProdutoModel> GetAll()
        {
            try
            {
                string sSQL = "";
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection cn = new MySqlConnection(CConexao.GET_StringConexao());
                cn.Open();

                sSQL = "SELECT p.nome, p.preco_custo, p.preco_sugerido, p.qtd, p.validade, c.categoria FROM produto AS p " +
                    "LEFT  JOIN categoria_produto AS c ON p.idCategoria = c.id " +
                    "LEFT JOIN genero_produto AS g ON p.idGenero = g.id";
                cmd.CommandText = sSQL;
                cmd.Connection = cn;
                var Dr = cmd.ExecuteReader();

                var Lista = new List<ProdutoModel>();

                while (Dr.Read())
                {
                    var item = new ProdutoModel
                    {
                        Id = Convert.ToInt32(Dr["Id"]),
                        Nome = Dr["Nome"].ToString(),
                        PrecoCusto = Convert.ToDouble(Dr["preco_custo"]),
                        PrecoSugerido = Convert.ToDouble(Dr["preco_sugerido"]),
                        Qtd = Convert.ToInt32(Dr["qtd"]),
                        Categoria = Dr["categoria_produto"].ToString(),
                        Genero = Dr["genero_produto"].ToString(),
                        Validade = Convert.ToDateTime(Dr["Validade"])
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

        public List<CategoriaProdutoModel> GetCategoria()
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

                var Lista = new List<CategoriaProdutoModel>();

                while (Dr.Read())
                {
                    var item = new CategoriaProdutoModel
                    {
                        Id = Convert.ToInt32(Dr["Id"]),
                        Categoria = Dr["Categoria"].ToString(),
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

        public List<GeneroProdutoModel> GetGenero()
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

                var Lista = new List<GeneroProdutoModel>();

                while (Dr.Read())
                {
                    var item = new GeneroProdutoModel
                    {
                        Id = Convert.ToInt32(Dr["Id"]),
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
