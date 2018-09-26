using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Loja.Classes
{
    public partial class Contato : IDisposable // IDisposable destrutor da classe
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
                        cmd.CommandText = "Insert into Cliente (Codigo, Nome, Tipo, DadosContato) values (@codigo, @nome, @tipo, @dadosContato)";
                        cmd.Connection = cn;

                        cmd.Parameters.AddWithValue("@codigo", this._codigo);
                        cmd.Parameters.AddWithValue("@tipo", this._tipo);
                        cmd.Parameters.AddWithValue("@@dadosContato", this._dadosContato);

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
        } // Metodo
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
                        cmd.CommandText = "update Contato set Tipo = @tipo, DadosContato = @dadosContato where codigo = @codigo";
                        cmd.Connection = cn;

                        cmd.Parameters.AddWithValue("@tipo", this._tipo);
                        cmd.Parameters.AddWithValue("@codigo", this._codigo);
                        cmd.Parameters.AddWithValue("@dadosContato", this._dadosContato);

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
        } // Metodo
        public void Gravar() 
        {
            if (this._isNew)
                Insert();
            else if (this._isModified)
                Update();
        } // Metodo
        public void Apagar() 
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
        } // Metodo

        public Contato() // Contrutor
        {
            this._codigo = Proximo();
            this._isNew = true;
            this._isModified = false;
        }
        public Contato(int Codigo)
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
                            this._tipo = dr.GetInt32(dr.GetOrdinal("Tipo"));
                        }
                    }
                    this._isNew = false;
                    this._isModified = false;
                }
            }
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
        }  // Metodo
        
        public static List<Contato> Todos(int Cliente) 
        {
            List<Contato> _return = null;

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
                    cmd.CommandText = "select * from Contato where cliente = @cliente";

                    cmd.Parameters.AddWithValue("@cliente", Cliente);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Contato con = new Contato();
                                
                                con._codigo = dr.GetInt32(dr.GetOrdinal("Codigo"));
                                con._dadosContato = dr.GetString(dr.GetOrdinal("DadosContato"));
                                con._tipo = Convert.ToInt32(dr["Tipo"]);
                                con._cliente = dr.GetInt32(dr.GetOrdinal("Cliente"));

                                
                                if (_return == null)
                                    _return = new List<Contato>();

                                _return.Add(con);
                                con._isNew = false;
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