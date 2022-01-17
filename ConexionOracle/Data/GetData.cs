using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConexionOracle.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Oracle.ManagedDataAccess.Types;

namespace ConexionOracle.Data
{
    public class GetData
    {
        private IEnumerable<Usuario> GetJson(int numberData, Usuario usuario)
        {
            return Enumerable.Range(1, numberData).Select(index => usuario).ToArray();
        }

        public string Conn1(string conString)
        {
            using (OracleConnection con = new OracleConnection(conString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.BindByName = true;

                        //Use the command to display employee names from 
                        // the EMPLOYEES table
                        cmd.CommandText = "select * from usuario";

                        // Assign id to the department number 50 
                        //OracleParameter id = new OracleParameter("id", 50);
                        //cmd.Parameters.Add(id);

                        //Execute the command and use DataReader to display the data
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine("Employee First Name: " + reader.GetString(1));
                        }

                        Console.WriteLine();
                        Console.WriteLine("Press 'Enter' to continue");

                        reader.Dispose();
                        return "Conexion Exitosa";

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return ex.Message;
                    }
                }
            }
        }
    
    
        public string Conn2(string conString)
        {
            try
            {
                OracleConnection con = null;
                OracleCommand cmd = null;
                OracleDataReader reader = null;

                string query = "select * from usuario";

                con = new OracleConnection(conString);
                con.Open();

                cmd = new OracleCommand(query, con)
                {
                    CommandType = CommandType.Text
                };
                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    
                    Console.WriteLine("{0} : {1} ", reader.GetName(1), reader.GetValue(1));
                    
                }

                return "Great!";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return ex.Message;
            }
        }
    
    
        public string Conn3(string conString)
        {
            string query = "select * from usuario";
            using(OracleConnection connection = new OracleConnection(conString))
            {
                OracleCommand command = new OracleCommand(query, connection);
                connection.Open();
                OracleDataReader reader = command.ExecuteReader();
                try
                {
                    reader.Read();
                    OracleString oracleString1 = reader.GetOracleString(3);
                    Console.WriteLine(oracleString1.ToString());
                    return "Great!";
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    return ex.Message;
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        public Usuario[] GetUsuarios(string conString)
        {
            try
            {
                string query = "select * from usuario";


                OracleConnection con = new OracleConnection(conString);
                con.Open();

                OracleCommand cmd = new OracleCommand(query, con)
                {
                    CommandType = CommandType.Text
                };
                OracleDataReader reader = cmd.ExecuteReader();


                List<dynamic> myData = new List<dynamic>() { "Hello", "World!" };
                myData.Add("Other");
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine("{0} : {1} ", reader.GetName(i), reader.GetValue(i));
                        myData.Add(reader.GetValue(i));
                    }
                            
                }
                
                
                foreach (string data in myData)
                {
                    Console.WriteLine(data);
                }

                

                //Console.WriteLine(myData);
               
                return new Usuario[1];
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
