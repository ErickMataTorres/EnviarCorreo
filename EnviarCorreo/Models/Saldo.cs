using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EnviarCorreo.Models;
using FirebirdSql.Data.FirebirdClient;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EnviarCorreo.Models
{
   
    public class Saldo
    {
        public int Cliente { get; set; }
        public string Mes { get; set; }
        public decimal Cargos { get; set; }
        public decimal Abonos { get; set; }
        public string Inivigencia { get; set; }
        public string Finvigencia { get; set; }

        //llenar  tabla
        public static List<Saldo> ListaClientes(string cliente)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand comando = new SqlCommand("splistamndrsaldos", conx);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Cliente", cliente);
            SqlDataReader dr;
            List<Saldo> lista = new List<Saldo>();
            Saldo c;
            conx.Open();
            dr = comando.ExecuteReader();
            while (dr.Read())
            {
                c = new Saldo();
                c.Cliente = dr.GetInt32(0);
                c.Mes = dr.GetString(1);
                c.Cargos = dr.GetDecimal(2);
                c.Abonos = dr.GetDecimal(3);
                c.Inivigencia = dr.GetString(4);
                c.Finvigencia = dr.GetString(5);
             
                lista.Add(c);
            }

            dr.Close();
            conx.Close();
            return lista;
        }


        //llenar formulario cuando sea editado
        public static List<Saldo> Cargar(int cliente)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spmndrsaldos", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Cliente", cliente);
            SqlDataReader dr;
            List<Saldo> lista = new List<Saldo>();
            Saldo c;
            conx.Open();
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                c = new Saldo();
                c.Cliente = dr.GetInt32(0);
                c.Mes = dr.GetString(1);
                c.Cargos = dr.GetDecimal(2);
                c.Abonos = dr.GetDecimal(3);
                c.Inivigencia = dr.GetString(4);
                c.Finvigencia = dr.GetString(5);

                lista.Add(c);
            }
            dr.Close();
            conx.Close();
            return lista;
        }

    }
}