using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnviarCorreo.Models
{
    public class Cliente
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Verificador { get; set; }
        public string Verificado { get; set; }


        public string Guardar()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spRegistrarUsuario", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@Correo", Correo);
            command.Parameters.AddWithValue("@Contraseña", Contraseña);
            command.Parameters.AddWithValue("@Verificador", Verificador);
            command.Parameters.AddWithValue("@Verificado", Verificado);
            try
            {
                conx.Open();
                command.ExecuteNonQuery();
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


        public static Cliente ValidarCorreo(string correo, string contraseña)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spValidarUsuario", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Correo", correo);
            command.Parameters.AddWithValue("@Contraseña", contraseña);
            SqlDataReader dr;
            Cliente c = new Cliente();
            conx.Open();
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                c.Correo = dr.GetString(0);
                c.Contraseña = dr.GetString(1);
                c.Verificador = dr.GetString(2);
                c.Verificado = dr.GetString(3);
                c.Nombre = dr.GetString(4);
                c.Id = dr.GetInt32(5);
            }
            dr.Close();
            conx.Close();
            return c;
        }

        //Este método es cuando le das al boton registrar consulta un uniqueidentifier,
        //y lo asigna a la variable Verificador, se guarda en la tabla, se guarda con una N cuando no esta verificado
        //al mismo tiempo te manda el mensaje, cuando le das click en aquí se verificado y se modifica la N por una S
        public static string ConsultarVerificador()
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spConsultarVerificador", conx);
            command.CommandType = CommandType.StoredProcedure;
            conx.Open();
            string verificador = command.ExecuteScalar().ToString();
            conx.Close();
            return verificador;
        }

        //Este método es cuando te registras
        public string RegistrarUsuario()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spRegistrarUsuario", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@Correo", Correo);
            command.Parameters.AddWithValue("@Contraseña", Contraseña);
            command.Parameters.AddWithValue("@Verificador", Verificador);
            command.Parameters.AddWithValue("@Verificado", Verificado);
            try
            {
                conx.Open();
                command.ExecuteNonQuery();
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

        public string VerificarUsuario()
        {
            //string respuesta = "<script>location.href='http://xamarin.somee.com/Home/Index'</script>";//Con esta línea te manda a esta página
            string respuesta = "<script>location.href='https://xamarin.somee.com/Registro/CorreoVerficado'</script>";//Con esta línea te manda a esta página
            //pero se ejecute el otro método que modifica la N por la S
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spVerificarUsuario", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Verificador", Verificador);
            try
            {
                conx.Open();
                command.ExecuteNonQuery();
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
    }
}