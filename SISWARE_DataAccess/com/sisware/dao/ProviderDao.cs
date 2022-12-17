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
    public class ProviderDao
    {
        public void Insert(EProvider provider)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "INSERT INTO ss_provider (pv_nit, pv_name, pv_category, pv_address, pv_telephone, pv_city, pv_country, pv_contact_name, pv_phone, pv_email, pv_date) VALUES (@nit, @name, @category, @address, @telephone, @city, @country, @contactName,  @phone, @email, @date)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@nit", provider.nit);
                    cmd.Parameters.AddWithValue("@name", provider.name);
                    cmd.Parameters.AddWithValue("@category", provider.category);
                    cmd.Parameters.AddWithValue("@address", provider.address);
                    cmd.Parameters.AddWithValue("@telephone", provider.telephone);
                    cmd.Parameters.AddWithValue("@city", provider.city);
                    cmd.Parameters.AddWithValue("@country", provider.country);
                    cmd.Parameters.AddWithValue("@contactName", provider.contactName);
                    cmd.Parameters.AddWithValue("@phone", provider.phone);
                    cmd.Parameters.AddWithValue("@email", provider.email);
                    cmd.Parameters.AddWithValue("@date", provider.date);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Devuelve una lista de Productos ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de productos</returns>
        /// <autor>José Luis García Bautista</autor>
        public List<EProvider> GetAll()
        {
            List<EProvider> providers = new List<EProvider>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM ss_provider ORDER BY pv_id  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        EProvider provider = new EProvider
                        {
                            id = Convert.ToInt32(dataReader["pv_id"]),
                            nit = Convert.ToString(dataReader["pv_nit"]),
                            name = Convert.ToString(dataReader["pv_name"]),
                            category = Convert.ToString(dataReader["pv_category"]),
                            address = Convert.ToString(dataReader["pv_address"]),
                            telephone = Convert.ToString(dataReader["pv_telephone"]),
                            city = Convert.ToString(dataReader["pv_city"]),
                            country = Convert.ToString(dataReader["pv_country"]),
                            contactName = Convert.ToString(dataReader["pv_contact_name"]),
                            phone = Convert.ToString(dataReader["pv_phone"]),
                            email = Convert.ToString(dataReader["pv_email"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["pv_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        providers.Add(provider);
                    }
                }
            }
            return providers;
        }

        public List<EProvider> Search(string name)
        {
            List<EProvider> providers = new List<EProvider>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                string sqlQuery = "SELECT * FROM ss_provider WHERE pv_name LIKE '"+ name +"%'";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        EProvider provider = new EProvider
                        {
                            id = Convert.ToInt32(dataReader["pv_id"]),
                            nit = Convert.ToString(dataReader["pv_nit"]),
                            name = Convert.ToString(dataReader["pv_name"]),
                            category = Convert.ToString(dataReader["pv_category"]),
                            address = Convert.ToString(dataReader["pv_address"]),
                            telephone = Convert.ToString(dataReader["pv_telephone"]),
                            city = Convert.ToString(dataReader["pv_city"]),
                            country = Convert.ToString(dataReader["pv_country"]),
                            contactName = Convert.ToString(dataReader["pv_contact_name"]),
                            phone = Convert.ToString(dataReader["pv_phone"]),
                            email = Convert.ToString(dataReader["pv_email"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["pv_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        providers.Add(provider);
                    }
                }
            }
            return providers;
        }

        public EProvider GetByid(int providerId)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM ss_provider WHERE pv_id = @Id";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@Id", providerId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EProvider provider = new EProvider
                        {
                            id = Convert.ToInt32(dataReader["pv_id"]),
                            nit = Convert.ToString(dataReader["pv_nit"]),
                            name = Convert.ToString(dataReader["pv_name"]),
                            category = Convert.ToString(dataReader["pv_category"]),
                            address = Convert.ToString(dataReader["pv_address"]),
                            telephone = Convert.ToString(dataReader["pv_telephone"]),
                            city = Convert.ToString(dataReader["pv_city"]),
                            country = Convert.ToString(dataReader["pv_country"]),
                            contactName = Convert.ToString(dataReader["pv_contact_name"]),
                            phone = Convert.ToString(dataReader["pv_phone"]),
                            email = Convert.ToString(dataReader["pv_email"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["pv_date"]))
                        };

                        return provider;
                    }
                }
            }

            return null;
        }

        public void Update(EProvider provider)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE ss_provider SET pv_nit = @nit, pv_name = @name, pv_category = @category, pv_address = @address, pv_telephone = @telephone, pv_city = @city, pv_country = @country, pv_contact_name = @contactName, pv_phone = @phone, pv_email = @email, pv_date = @date WHERE pv_id=@id";

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@nit", provider.nit);
                    cmd.Parameters.AddWithValue("@name", provider.name);
                    cmd.Parameters.AddWithValue("@category", provider.category);
                    cmd.Parameters.AddWithValue("@address", provider.address);
                    cmd.Parameters.AddWithValue("@telephone", provider.address);
                    cmd.Parameters.AddWithValue("@city", provider.city);
                    cmd.Parameters.AddWithValue("@country", provider.country);
                    cmd.Parameters.AddWithValue("@contactName", provider.contactName);
                    cmd.Parameters.AddWithValue("@phone", provider.phone);
                    cmd.Parameters.AddWithValue("@email", provider.email);
                    cmd.Parameters.AddWithValue("@date", provider.date);
                    cmd.Parameters.AddWithValue("@id", provider.id);

                    cmd.ExecuteNonQuery();


                    

                }
            }
        }

        public void Delete(int providerId)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM ss_provider WHERE pv_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", providerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EProvider> GetByCode(int providerId)
        {
            List<EProvider> providers = new List<EProvider>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT pv_name FROM ss_provider WHERE pv_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", providerId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        EProvider provider = new EProvider
                        {
                            name = Convert.ToString(dataReader["pv_name"]),
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        providers.Add(provider);
                    }
                }
            }

            return providers;
        }
    }
}
