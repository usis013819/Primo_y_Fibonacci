﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//libreria DB
using System.Data;
//libreria DB con SQL Server
using System.Data.SqlClient;

namespace Primo_y_Fibonacci
{
    class ConexionClass
    {
        SqlConnection miConexion = new SqlConnection();
        SqlCommand comandosSQL = new SqlCommand();
        SqlDataAdapter miAdaptadorDatos = new SqlDataAdapter();

        DataSet ds = new DataSet();

        public ConexionClass()
        {
            String cadena = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Control.mdf;Integrated Security=True";
            miConexion.ConnectionString = cadena;
            miConexion.Open();
        }
        public DataSet obtener_datos()
        {

            ds.Clear();
            comandosSQL.Connection = miConexion;

            comandosSQL.CommandText = "select * from Cliente";
            miAdaptadorDatos.SelectCommand = comandosSQL;
            miAdaptadorDatos.Fill(ds, "Cliente");

            comandosSQL.CommandText = "select * from Empleado";
            miAdaptadorDatos.SelectCommand = comandosSQL;
            miAdaptadorDatos.Fill(ds, "Empleado");

            comandosSQL.CommandText = "select * from Productos";
            miAdaptadorDatos.SelectCommand = comandosSQL;
            miAdaptadorDatos.Fill(ds, "Productos");

            return ds;
        }


        public void mantenimiento_datos(String[] datos, String accion)
        {
            String sql = "";
            if (accion == "nuevo"){

                sql = "INSERT INTO Cliente (NombreCliente, EMail, Dirección) VALUES(" +
                    
                    "'" + datos[1] + "'," +
                    "'" + datos[2] + "'," +
                    "'" + datos[3] + "'" +
                    ")";

            }

            else if (accion == "modificar")  {

                sql = "UPDATE Cliente SET " +
                
                " NombreCliente       = '" + datos[1] + "'," +
                " EMail               = '" + datos[2] + "'," +
                " Dirección           = '" + datos[3] + "'" +
                " WHERE IdCliente     = '" + datos[0] + "'";


            } else if (accion == "eliminar") {
                sql = "DELETE Cliente FROM Cliente WHERE IdCliente='" + datos[0] + "'";

            }
            procesarSQL(sql);
        }

        public void manteni_datos(String[] datos, String accion)
        {
            String sql = "";
            if (accion == "nuevo")
            {

                sql = "INSERT INTO Empleado (codigo, NombreEmpleado, Dirección, EMail) VALUES(" +
                     "'" + datos[1] + "'," +
                     "'" + datos[2] + "'," +
                     "'" + datos[3] + "'," +
                     "'" + datos[4] + "'" +
                     ")";

            }

            else if (accion == "modificar")
            {

                sql = "UPDATE Empleado SET " +

               "codigo              = '" + datos[1] + "'," +
               "NombreEmpleado      = '" + datos[2] + "'," +
               "Dirección           = '" + datos[3] + "'," +
               "EMail               = '" + datos[4] + "'" +
               "WHERE IdEmpleado    = '" + datos[0] + "'";

            }
            else if (accion == "eliminar")
            {
            
            sql = "DELETE Empleado FROM Empleado WHERE IdEmpleado='" + datos[0] + "'";

            }
            procesSQL(sql);
        }

        void procesarSQL(String sql)
        {
            comandosSQL.Connection = miConexion;
            comandosSQL.CommandText = sql;
            comandosSQL.ExecuteNonQuery();
        }

        void procesSQL(String sql)
        {
            comandosSQL.Connection = miConexion;
            comandosSQL.CommandText = sql;
            comandosSQL.ExecuteNonQuery();
        }
    }
}