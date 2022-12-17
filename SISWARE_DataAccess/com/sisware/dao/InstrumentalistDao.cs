using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlServerCe;
using com.sisware.bean;
using MySql.Data.MySqlClient;


namespace com.sisware.dao
{
    public class InstrumentalistDao
    {
        public void Insert(EInstrumentalist instrumentalist)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "INSERT INTO ss_instrumentalist (it_ci, it_name, it_surname,it_city, it_address, it_cell, it_email, it_date) VALUES (@ci, @name, @surname, @city, @address, @cell, @email, @date)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@ci", instrumentalist.ci);
                    cmd.Parameters.AddWithValue("@name", instrumentalist.name);
                    cmd.Parameters.AddWithValue("@surname", instrumentalist.surname);
                    cmd.Parameters.AddWithValue("@city", instrumentalist.city);
                    cmd.Parameters.AddWithValue("@address", instrumentalist.address);
                    cmd.Parameters.AddWithValue("@cell", instrumentalist.cell);
                    cmd.Parameters.AddWithValue("@email", instrumentalist.email);
                    cmd.Parameters.AddWithValue("@date", instrumentalist.date);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Devuelve una lista de Productos ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de productos</returns>
        /// <autor>José Luis García Bautista</autor>
        public List<EInstrumentalist> GetAll()
        {
            List<EInstrumentalist> instrumentalists = new List<EInstrumentalist>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM ss_instrumentalist ORDER BY it_id  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        EInstrumentalist instrumentalist = new EInstrumentalist
                        {
                            id = Convert.ToInt32(dataReader["it_id"]),
                            ci = Convert.ToString(dataReader["it_ci"]),
                            name = Convert.ToString(dataReader["it_name"]),
                            surname = Convert.ToString(dataReader["it_surname"]),
                            city = Convert.ToString(dataReader["it_city"]),
                            address = Convert.ToString(dataReader["it_address"]),
                            cell = Convert.ToString(dataReader["it_cell"]),
                            email = Convert.ToString(dataReader["it_email"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["it_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        instrumentalists.Add(instrumentalist);
                    }
                }
            }
            return instrumentalists;
        }

        public List<EInstrumentalist> SearchForName(string name)
        {
            List<EInstrumentalist> instrumentalists = new List<EInstrumentalist>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                string sqlQuery = "SELECT * FROM ss_instrumentalist WHERE it_name LIKE '" + name + "%'";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        EInstrumentalist instrumentalist = new EInstrumentalist
                        {
                            id = Convert.ToInt32(dataReader["it_id"]),
                            ci = Convert.ToString(dataReader["it_ci"]),
                            name = Convert.ToString(dataReader["it_name"]),
                            surname = Convert.ToString(dataReader["it_surname"]),
                            city = Convert.ToString(dataReader["it_surname"]),
                            address = Convert.ToString(dataReader["it_address"]),
                            cell = Convert.ToString(dataReader["it_cell"]),
                            email = Convert.ToString(dataReader["it_email"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["it_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        instrumentalists.Add(instrumentalist);
                    }
                }
            }
            return instrumentalists;
        }

        public List<EInstrumentalist> SearchForFirstName(string surname)
        {
            List<EInstrumentalist> instrumentalists = new List<EInstrumentalist>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                string sqlQuery = "SELECT * FROM ss_instrumentalist WHERE it_surname LIKE '" + surname + "%'";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        EInstrumentalist instrumentalist = new EInstrumentalist
                        {
                            id = Convert.ToInt32(dataReader["it_id"]),
                            ci = Convert.ToString(dataReader["it_ci"]),
                            name = Convert.ToString(dataReader["it_name"]),
                            surname = Convert.ToString(dataReader["it_surname"]),
                            city = Convert.ToString(dataReader["it_surname"]),
                            address = Convert.ToString(dataReader["it_address"]),
                            cell = Convert.ToString(dataReader["it_cell"]),
                            email = Convert.ToString(dataReader["it_email"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["it_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        instrumentalists.Add(instrumentalist);
                    }
                }
            }
            return instrumentalists;
        }

        

        public EInstrumentalist GetByid(int instrumentalistId)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM ss_instrumentalist WHERE it_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", instrumentalistId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EInstrumentalist instrumentalist = new EInstrumentalist
                        {
                            id = Convert.ToInt32(dataReader["it_id"]),
                            ci = Convert.ToString(dataReader["it_ci"]),
                            name = Convert.ToString(dataReader["it_name"]),
                            surname = Convert.ToString(dataReader["it_surname"]),
                            city = Convert.ToString(dataReader["it_surname"]),
                            address = Convert.ToString(dataReader["it_address"]),
                            cell = Convert.ToString(dataReader["it_cell"]),
                            email = Convert.ToString(dataReader["it_email"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["it_date"]))
                        };

                        return instrumentalist;
                    }
                }
            }

            return null;
        }

        public void Update(EInstrumentalist instrumentalist)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE ss_instrumentalist SET it_ci = @ci, it_name = @name, it_surname = @surName, it_city = @city, it_address = @address, it_cell = @cell, it_email = @email, it_date = @date WHERE it_id=@id;";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@ci", instrumentalist.ci);
                    cmd.Parameters.AddWithValue("@name", instrumentalist.name);
                    cmd.Parameters.AddWithValue("@surname", instrumentalist.surname);
                    cmd.Parameters.AddWithValue("@city", instrumentalist.city);
                    cmd.Parameters.AddWithValue("@address", instrumentalist.address);
                    cmd.Parameters.AddWithValue("@cell", instrumentalist.cell);
                    cmd.Parameters.AddWithValue("@email", instrumentalist.email);
                    cmd.Parameters.AddWithValue("@date", instrumentalist.date);
                    cmd.Parameters.AddWithValue("@id", instrumentalist.id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int instrumentalistId)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM ss_instrumentalist WHERE it_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", instrumentalistId);
                    cmd.ExecuteNonQuery();
                }
            }
        }      
    }
}
