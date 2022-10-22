using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MVCBilleteraVirtual.Models;

namespace MVCBilleteraVirtual.DatabaseHelper
{
    public class DatabaseHelper
    {
        const string servidor = @"DESKTOP-DLLS4QS";
        const string baseDatos = "BilleteraVirtual";
        const string strConexion = "Data Source=" + servidor + ";Initial Catalog=" + baseDatos + ";Integrated Security=True";

        public static List<Tarjetas> GetTarjetas()
        {
            DataTable ds = ExecuteStoreProcedure("spGetTarjetas", null);

            List<Tarjetas> tarjetas = new List<Tarjetas>();

            foreach (DataRow dr in ds.Rows)
            {
                tarjetas.Add(new Tarjetas()
                {
                    IDTarjeta = Convert.ToInt32(dr["IDTarjeta"]),
                    Dueño = dr["Dueño"].ToString(),
                    Banco = dr["Banco"].ToString(),
                    Emisor = dr["Emisor"].ToString(),
                    NumeroTarjeta = dr["NumeroTarjeta"].ToString(),
                    CodigoCVV = dr["CodigoCVV"].ToString(),
                    FechaExpiracion = dr["FechaExpiracion"].ToString(),
                    FotoBanco = dr["FotoBanco"].ToString(),
                    FotoEmisor = dr["FotoEmisor"].ToString()
                });
            }
            return tarjetas;

        }

        public static bool AgregarTarjeta(Tarjetas tarjetas)
        {
            try
            {
                List<SqlParameter> param = new List<SqlParameter>()
                {
                    new SqlParameter("@Dueño", tarjetas.Dueño),
                    new SqlParameter("@Banco", tarjetas.Banco),
                    new SqlParameter("@Emisor", tarjetas.Emisor),
                    new SqlParameter("@NumeroTarjeta", tarjetas.NumeroTarjeta),
                    new SqlParameter("@CodigoCVV", tarjetas.CodigoCVV),
                    new SqlParameter("@FechaExpiracion", tarjetas.FechaExpiracion),
                    new SqlParameter("@FotoBanco", tarjetas.FotoBanco),
                    new SqlParameter("@FotoEmisor", tarjetas.FotoEmisor)
                };

                ExecStoreProcedure("spAgregarTarjeta", param);

                return true;
            }
            catch
            {
                return false;
            }
        }




        //public static List<Movies> GetIDMovies(int IdMovie)
        //{
        //    List<SqlParameter> param = new List<SqlParameter>()
        //        {
        //            new SqlParameter("@IdMovie", IdMovie)
        //        };

        //    DataTable ds = ExecuteStoreProcedure("spGetIDMovie", param);

        //    List<Movies> movies = new List<Movies>();

        //    foreach (DataRow dr in ds.Rows)
        //    {
        //        movies.Add(new Movies()
        //        {
        //            IdMovie = Convert.ToInt32(dr["IdMovie"]),
        //            Name = dr["Name"].ToString(),
        //            Genere = dr["Genere"].ToString(),
        //            Date = dr["Date"].ToString(),
        //            Photo = dr["Photo"].ToString()
        //        });
        //    }
        //    return movies;

        //}


        //public static bool EditMovie(Movies movies)
        //{
        //    try
        //    {
        //        List<SqlParameter> param = new List<SqlParameter>()
        //        {
        //            new SqlParameter("@IdMovie", movies.IdMovie),
        //            new SqlParameter("@Name", movies.Name),
        //            new SqlParameter("@Genere", movies.Genere),
        //            new SqlParameter("@Date", movies.Date)
        //        };

        //        ExecStoreProcedure("spUpdateMovie", param);

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public static bool Delete(int IdMovie)
        //{
        //    try
        //    {
        //        List<SqlParameter> param = new List<SqlParameter>()
        //        {
        //            new SqlParameter("@IdMovie", IdMovie)
        //        };

        //        ExecStoreProcedure("spDeleteMovie", param);

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //Para select 
        public static DataTable ExecuteStoreProcedure(string procedure, List<SqlParameter> param)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConexion))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = procedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    if (param != null)
                    {
                        foreach (SqlParameter item in param)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }

                    cmd.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }

        public static void ExecStoreProcedure(string procedure, List<SqlParameter> param)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConexion))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = procedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    if (param != null)
                    {
                        foreach (SqlParameter item in param)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
