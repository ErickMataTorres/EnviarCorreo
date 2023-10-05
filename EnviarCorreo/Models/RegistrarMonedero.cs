using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EnviarCorreo.Models
{
    public class RegistrarMonedero
    {
       
        public int Id { get; set; }
        public int IdRegistrar { get; set; }
     
        public int NumeroMonedero { get; set; }
        public string Telefono { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }

        public string Guardar()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand comando = new SqlCommand("spRegistrarMonedero", conx);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@IdRegistrar", IdRegistrar);
           
            comando.Parameters.AddWithValue("@NumeroMonedero", NumeroMonedero);
            comando.Parameters.AddWithValue("@Telefono", Telefono);
            comando.Parameters.AddWithValue("@Pais", Pais);
            comando.Parameters.AddWithValue("@Estado", Estado);
            comando.Parameters.AddWithValue("@Ciudad", Ciudad);
            try
            {
                conx.Open();
                comando.ExecuteNonQuery();
                conx.Close();
            }
            catch (Exception error)
            {
                respuesta = error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    conx.Close();
                }
            }
            return respuesta;

        }

        //public static List<RegistrarMonedero> CargarId(int id)
        //{
        //    SqlConnection conx = Models.Conexion.Conectar();
        //    SqlCommand command = new SqlCommand("SpCargaId", conx);
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.Parameters.AddWithValue("@Id", id);
        //    SqlDataReader dr;
        //    List<RegistrarMonedero> lista = new List<RegistrarMonedero>();
        //    RegistrarMonedero c;
        //    conx.Open();
        //    dr = command.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        c = new RegistrarMonedero();
        //        c.Id = dr.GetInt32(0);
        //        lista.Add(c);
        //    }
        //    dr.Close();
        //    conx.Close();
        //    return lista;
        //}

    }
}