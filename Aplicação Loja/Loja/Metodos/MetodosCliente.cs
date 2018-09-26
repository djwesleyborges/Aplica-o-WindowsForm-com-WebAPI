using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public static class MetodosExtensao
{
    public static int Metade(this int Valor) 
    {
        return Valor / 2;
    }
    public static double Juros(this double Valor)
    {
        return Valor + 20;
    }
    public static string PrimeiraMaiuscula(this string Valor)
    {
        return Valor.Substring(0, 1).ToUpper() + Valor.Substring(1, Valor.Length - 1).ToLower();
    }
    public static string PrimeiraMaiuscula(this string Valor, bool UltimasMinusculas)
    {
        if (UltimasMinusculas == true)
        {
            return Valor.Substring(0, 1).ToUpper() + Valor.Substring(1, Valor.Length - 1).ToLower();
        }
        else 
        {
            return Valor.Substring(0, 1).ToUpper() + Valor.Substring(1, Valor.Length - 1);
        }
        
    }
}

namespace Loja.Classes
{
    public partial class Cliente : IDisposable // IDisposable destrutor da classe
    {
        public void Insert() 
        {

            {


                using (SqlConnection cn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Loja;Data Source=.\\"))
                {
                    try
                    {
                        cn.Open();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "Insert into Cliente (Codigo, Nome, Tipo, DataCadastro) values (@codigo, @nome, @tipo, @datacadastro)";
                        cmd.Connection = cn;

                        cmd.Parameters.AddWithValue("@codigo", this._codigo);
                        cmd.Parameters.AddWithValue("@nome", this._nome);
                        cmd.Parameters.AddWithValue("@tipo", this._tipo);
                        cmd.Parameters.AddWithValue("@datacadastro", this._dataCadastro);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            this._isNew = false;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
            }
        }
        public void Update() 
        {

            {


                using (SqlConnection cn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Loja;Data Source=.\\"))
                {
                    try
                    {
                        cn.Open();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "update Cliente set nome = @nome, Tipo = @tipo, DataCadastro = @datacadastro where codigo = @codigo";
                        cmd.Connection = cn;

                        cmd.Parameters.AddWithValue("@codigo", this._codigo);
                        cmd.Parameters.AddWithValue("@nome", this._nome);
                        cmd.Parameters.AddWithValue("@tipo", this._tipo);
                        cmd.Parameters.AddWithValue("@datacadastro", this._dataCadastro);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            this._isModified = false;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
            }
        }
        public void Gravar()  // Metodo
        {
            if (this._isNew)
                Insert();
            else if (this._isModified)
                Update();
        }
        public static Int32 Proximo() 
        {
            Int32 _return = 0;

            using (SqlConnection cn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Loja;Data Source=.\\"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {
                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "select max(codigo) +1 from Cliente";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            _return = dr.GetInt32(0);
                        }
                    }
                }
            }
            return _return;
        }
        public void Apagar() // Metodo
        {
            {


                using (SqlConnection cn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Loja;Data Source=.\\"))
                {
                    try
                    {
                        cn.Open();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "delete from Cliente where codigo = @codigo";
                        cmd.Connection = cn;

                        cmd.Parameters.AddWithValue("@codigo", this._codigo);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
            }
        }
        public Cliente() // Contrutor
        {
            this._codigo = Proximo();
            this._isNew = true;
            this._isModified = false;
        }
        public Cliente(int Codigo)
        {
            using (SqlConnection cn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Loja;Data Source=.\\")) 
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {
                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "select * from Cliente where codigo = @codigo";
                    cmd.Parameters.AddWithValue("@codigo", Codigo);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            this._codigo = dr.GetInt32(dr.GetOrdinal("Codigo"));
                            this._nome = dr.GetString(dr.GetOrdinal("Nome"));
                            this._tipo = dr.GetInt32(dr.GetOrdinal("Tipo"));
                            this._dataCadastro = dr.GetDateTime(dr.GetOrdinal("DataCadastro"));
                        }
                    }
                    this._isNew = false;
                    this._isModified = false;
                }
            }
        }
        public static List<Cliente> Todos() 
        {
            List<Cliente> _return = null;

            using (SqlConnection cn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Loja;Data Source=.\\"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {
                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "select * from Cliente";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Cliente cli = new Cliente();

                                cli._codigo = dr.GetInt32(dr.GetOrdinal("Codigo"));
                                cli._nome = dr.GetString(dr.GetOrdinal("Nome"));
                                cli._tipo = dr.GetInt32(dr.GetOrdinal("Tipo"));
                                cli._dataCadastro = dr.GetDateTime(dr.GetOrdinal("DataCadastro"));

                                cli.Contatos = Contato.Todos(cli._codigo);

                                if (_return == null)
                                    _return = new List<Cliente>();

                                cli._isNew = false;
                                _return.Add(cli);
                            }
                        }
                    }
                }
            }

            return _return;
        }
        public void Dispose() // IDisposable destrutor da classe
        {
            this.Gravar();
        }
    }
}