using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ControleLoja.Classes
{
    public class CConexao
    {
        public static string GET_StringConexao()
        {
            string Host = "localhost";
            string Banco = "controle_loja";
            string Usuario = "root";
            string Senha = "1234";
            return "Data Source=" + Host + ";Initial Catalog=" + Banco + ";User Id=" + Usuario + ";Password=" + Senha + ";";
        }

        public class Config_Banco
        {
            public static string Host { get; set; }
            public static string Banco { get; set; }
            public static string Usuario { get; set; }
            public static string Senha { get; set; }
            public static string StringConexao { get; set; }

            public static void SetBanco()
            {
                StringConexao = "Data Source=" + Host + ";Initial Catalog=" + Banco + ";User Id=" + Usuario + ";Password=" + Senha + ";";
            }

        }

        public static string MSG_ERRO = "";

        public static MySqlConnection Cn = new MySqlConnection();
        public static Boolean ConectarDB(string StringConexao)
        {

            bool Valida = false;

            if (Cn.State == ConnectionState.Open)
            {
                Valida = true;
                MSG_ERRO = "";
            }

            else
            {
                try
                {
                    Cn.ConnectionString = StringConexao;
                    Cn.Open();
                    Valida = true;
                    MSG_ERRO = "";
                }
                catch (Exception e)
                {
                    Valida = false;
                    MSG_ERRO = e.Message.ToString();
                }

            }

            return Valida;

        }
        public static Boolean ExecutarSql(string Query_Sql, string StringConexao)
        {
            Config_Banco.SetBanco();

            bool Valida = false;

            try
            {
                using (MySqlConnection Cnn = new MySqlConnection(StringConexao))
                {
                    Cnn.Open();
                    MySqlCommand CMD = new MySqlCommand(Query_Sql, Cnn);
                    CMD.ExecuteNonQuery();
                    Valida = true;
                    MSG_ERRO = "";
                }
            }
            catch (Exception e)
            {
                Valida = false;
                MSG_ERRO = e.Message.ToString();
               // CMetodos_Banco.GravarLog(CMetodos_Banco.eTipoLog.Erro, e.Message);
            }

            return Valida;
        }
        public static Boolean ExecutarSql(MySqlCommand cmd, string StringConexao)
        {
            Config_Banco.SetBanco();

            bool Valida = false;

            try
            {
                using (MySqlConnection Cnn = new MySqlConnection(StringConexao))
                {
                    Cnn.Open();
                    MySqlCommand _CMD = cmd;
                    _CMD.Connection = Cnn;
                    _CMD.ExecuteNonQuery();
                    Valida = true;
                    MSG_ERRO = "";
                }
            }
            catch (Exception e)
            {
                Valida = false;
                MSG_ERRO = e.Message.ToString();
              //  CMetodos_Banco.GravarLog(CMetodos_Banco.eTipoLog.Erro, e.Message);
            }

            return Valida;
        }

        public static DataSet GET_DataSet(string Query_Sql, string StringConexao)
        {
            try
            {
                using (MySqlConnection Cnn = new MySqlConnection(StringConexao))
                {
                    DataSet DS = new DataSet();
                    MySqlDataAdapter DAP = new MySqlDataAdapter(Query_Sql, Cnn);
                    DAP.Fill(DS);
                    MSG_ERRO = "";
                    return DS;
                }
            }
            catch (Exception e)
            {
                MSG_ERRO = e.Message.ToString();
               // CMetodos_Banco.GravarLog(CMetodos_Banco.eTipoLog.Erro, e.Message);
            }
            return null;
        }

        public static DataSet GET_DataSet(MySqlCommand cmd, string StringConexao)
        {
            try
            {
                using (MySqlConnection Cnn = new MySqlConnection(StringConexao))
                {
                    DataSet DS = new DataSet();
                    Cnn.Open();
                    cmd.Connection = Cnn;
                    MySqlDataAdapter DAP = new MySqlDataAdapter(cmd);
                    DAP.Fill(DS);
                    MSG_ERRO = "";
                    return DS;
                }
            }
            catch (Exception e)
            {
                MSG_ERRO = e.Message.ToString();
               // CMetodos_Banco.GravarLog(CMetodos_Banco.eTipoLog.Erro, e.Message);
            }
            return null;
        }
        public static bool GravarRegistro(string sTabela, bool RegistroNovo, Hashtable ht, string sWhere_or_LastQuery, string StringConexao)
        {
            Config_Banco.SetBanco();

            try
            {
                using (MySqlConnection Cnn = new MySqlConnection(StringConexao))
                {

                    string sql1 = "";
                    string sql2 = "";
                    string sql3 = "";

                    MySqlCommand cmd = new MySqlCommand();

                    if (RegistroNovo == true)
                    {
                        sql1 = "INSERT INTO " + sTabela;

                        foreach (string v in ht.Keys)
                        {
                            sql2 += v + ",";
                            sql3 += "@" + v + ",";


                            cmd.Parameters.AddWithValue("@" + v, ht[v].ToString());
                        }

                        sql2 = sql2.Substring(0, sql2.Length - 1);
                        sql3 = sql3.Substring(0, sql3.Length - 1);

                        sql2 = "(" + sql2 + ")";
                        sql3 = "Values (" + sql3 + ")";

                        sql1 = sql1 + sql2 + sql3;

                    }

                    else
                    {
                        sql1 = "update " + sTabela + " set ";

                        foreach (string v in ht.Keys)
                        {
                            sql2 += v + "=@" + v + ",";
                            cmd.Parameters.AddWithValue("@" + v, ht[v].ToString());
                        }

                        sql2 = sql2.Substring(0, sql2.Length - 1);

                        sql1 = sql1 + " " + sql2 + " " + sWhere_or_LastQuery;

                    }

                    Cnn.Open();
                    cmd.Connection = Cnn;
                    cmd.CommandText = sql1;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception e)
            {
                string erro = e.Message;
               // CMetodos_Banco.GravarLog(CMetodos_Banco.eTipoLog.Erro, e.Message);

            }

            return false;

        }
        public static bool InsertRegistro<T>(List<T> ListaG, string Tabela, string StringConexao)
        {
            Config_Banco.SetBanco();

            try
            {
                using (MySqlConnection Cnn = new MySqlConnection(StringConexao))
                {

                    MySqlCommand _return = new MySqlCommand();
                    _return.CommandText = "Insert Into {0} ({1}) Values ({2})";

                    string tabela = Tabela;
                    string campos = "";
                    string valores = "";

                    foreach (PropertyInfo pro in typeof(T).GetProperties().ToList().Where(
                        p => p.GetCustomAttribute(typeof(DataObjectFieldAttribute)) != null))
                    {
                        campos += pro.Name + ", ";
                        valores += "@" + pro.Name + ",";

                        _return.Parameters.AddWithValue("@" + pro.Name, pro.GetValue(ListaG));
                    }

                    campos = campos.Substring(0, campos.Length - 2);
                    valores = valores.Substring(0, valores.Length - 1);

                    _return.CommandText = string.Format(_return.CommandText, tabela, campos, valores);

                    Cnn.Open();
                    _return.Connection = Cnn;
                    _return.ExecuteNonQuery();

                    return true;

                }
            }
            catch (Exception e)
            {
                string erro = e.Message;
                //CMetodos_Banco.GravarLog(CMetodos_Banco.eTipoLog.Erro, e.Message);

            }
            return false;

        }
        public static bool InsertRegistro<T>(T Class, string Tabela, string StringConexao, bool ValidKeys = true)
        {
            Config_Banco.SetBanco();

            try
            {
                using (MySqlConnection Cnn = new MySqlConnection(StringConexao))
                {

                    MySqlCommand _return = new MySqlCommand();
                    _return.CommandText = "Insert Into {0} ({1}) Values ({2})";

                    string tabela = Tabela;
                    string campos = "";
                    string valores = "";

                    foreach (PropertyInfo pro in typeof(T).GetProperties())
                    {
                        bool Valid = false;
                        if (ValidKeys)
                            Valid = pro.CustomAttributes.Where(a => a.AttributeType.Name == "KeyAttribute").FirstOrDefault() == null ? true : false;
                        else
                            Valid = true;

                        if (Valid)
                        {
                            try
                            {
                                campos += pro.Name + ", ";
                                valores += "@" + pro.Name + ",";

                                _return.Parameters.AddWithValue("@" + pro.Name, pro.GetValue(Class));

                            }
                            catch (Exception e)
                            {
                                string smg = e.Message;
                               // CMetodos_Banco.GravarLog(CMetodos_Banco.eTipoLog.Erro, e.Message);

                            }
                        }
                    }

                    campos = campos.Substring(0, campos.Length - 2);
                    valores = valores.Substring(0, valores.Length - 1);

                    _return.CommandText = string.Format(_return.CommandText, tabela, campos, valores);

                    Cnn.Open();
                    _return.Connection = Cnn;
                    _return.ExecuteNonQuery();

                    return true;

                }
            }
            catch (Exception e)
            {
                string erro = e.Message;

            }
            return false;

        }
        public static List<a> MontaModel<a>(DataSet Resp)
        {
            List<a> LstObj = new List<a>();
            if (Resp != null)
            {
                var properties = typeof(a).GetProperties();
                foreach (DataTable Tb in Resp.Tables)
                {
                    foreach (DataRow row in Tb.Rows)
                    {
                        var Obj = Activator.CreateInstance<a>();
                        Parallel.ForEach(properties, pro =>
                        {
                            try
                            {
                                if (row[pro.Name] != DBNull.Value)
                                {
                                    if (pro.PropertyType.FullName == "System.Boolean")
                                    {
                                        pro.SetValue(Obj, Convert.ToBoolean(row[pro.Name]));
                                    }
                                    else
                                    {
                                        pro.SetValue(Obj, row[pro.Name]);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                string err = e.Message;
                            }
                        });
                        LstObj.Add(Obj);
                    }
                }
            }
            return LstObj;
        }
        public static bool UpdateRegistro<T>(T Class, string Tabela, string sWhere_or_LastQuery, string StringCNX)
        {
            Config_Banco.SetBanco();

            try
            {
                using (MySqlConnection Cnn = new MySqlConnection(StringCNX))
                {
                    MySqlCommand _return = new MySqlCommand();
                    _return.CommandText = "Update {0} Set {1} {2} {3}";

                    string tabela = Tabela;
                    string campos = "";
                    string chave = "";

                    foreach (PropertyInfo pro in typeof(T).GetProperties())
                    {

                        if (pro.CustomAttributes.Where(a => a.AttributeType.Name == "KeyAttribute").FirstOrDefault() == null)
                        {
                            campos += pro.Name + "=@" + pro.Name + ",";

                            if (pro.GetValue(Class) != null)
                                _return.Parameters.AddWithValue("@" + pro.Name, pro.GetValue(Class));
                            else
                                _return.Parameters.AddWithValue("@" + pro.Name, DBNull.Value);
                        }

                    }
                    campos = campos.Substring(0, campos.Length - 1);
                    _return.CommandText = string.Format(_return.CommandText, tabela, campos, chave, sWhere_or_LastQuery);

                    Cnn.Open();
                    _return.Connection = Cnn;
                    _return.ExecuteNonQuery();

                    return true;

                }
            }
            catch (Exception e)
            {
                string erro = e.Message;
                //CMetodos_Banco.GravarLog(CMetodos_Banco.eTipoLog.Erro, e.Message);
            }
            return false;
        }

        public static bool UpdateRegistro<T>(T Class, string Tabela, MySqlCommand cmdWhere, string StringCNX)
        {
            Config_Banco.SetBanco();

            try
            {
                using (MySqlConnection Cnn = new MySqlConnection(StringCNX))
                {
                    MySqlCommand _return = new MySqlCommand();
                    _return.CommandText = "Update {0} Set {1} {2} {3}";

                    string tabela = Tabela;
                    string campos = "";
                    string chave = "";

                    foreach (PropertyInfo pro in typeof(T).GetProperties())
                    {

                        if (pro.CustomAttributes.Where(a => a.AttributeType.Name == "KeyAttribute").FirstOrDefault() == null)
                        {
                            campos += pro.Name + "=@" + pro.Name + ",";

                            if (pro.GetValue(Class) != null)
                                _return.Parameters.AddWithValue("@" + pro.Name, pro.GetValue(Class));
                            else
                                _return.Parameters.AddWithValue("@" + pro.Name, DBNull.Value);
                        }

                    }

                    foreach (var itensPar in cmdWhere.Parameters)
                    {
                        _return.Parameters.Add(itensPar);
                    }

                    campos = campos.Substring(0, campos.Length - 1);
                    _return.CommandText = string.Format(_return.CommandText, tabela, campos, chave, cmdWhere.CommandText);

                    Cnn.Open();
                    _return.Connection = Cnn;
                    _return.ExecuteNonQuery();

                    return true;

                }
            }
            catch (Exception e)
            {
                string erro = e.Message;
                //CMetodos_Banco.GravarLog(CMetodos_Banco.eTipoLog.Erro, e.Message);
            }
            return false;
        }

    }
}
