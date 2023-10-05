using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EnviarCorreo.Models
{
    public class Conexion
    {
        public static SqlConnection Conectar()
        {
           //string cs = "Data Source=A;Initial Catalog=Gyms;Integrated Security=True";
          // var cs = "SERVER = webtienda.mssql.somee.com; DATABASE = xamarin; USER ID = JMRB_SQLLogin_1; PWD = qmdmb9ntoq;";
            //string cs = "DATA SOURCE = A; INITIAL CATALOG = xamarin; INTEGRATED SECURITY = YES;";
           // SqlConnection conx = new SqlConnection(cs);
            //return conx;

            SqlConnection conx;
            conx = new SqlConnection("Server = xamarin.mssql.somee.com; DataBase = xamarin; user id = xamarin_SQLLogin_1; pwd = uqb4yf7cl4");
            return conx;
        }
    }
}