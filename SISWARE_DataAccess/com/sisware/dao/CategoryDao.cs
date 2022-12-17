using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Threading.Tasks;
using System.Configuration;
using com.sisware.bean;
using com.sisware.dao;
using MySql.Data.MySqlClient;


namespace com.sisware.dao
{
    public class CategoryDao
    {
        public void Insert(ECategory category)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "INSERT INTO ss_category ( ca_name, ca_date) VALUES ( @name, @date)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@name", category.name);
                    cmd.Parameters.AddWithValue("@date", category.date);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ECategory> GetAll()
        {
            List<ECategory> categories = new List<ECategory>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM ss_category ORDER BY ca_id  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        ECategory entity = new ECategory
                        {
                            id = Convert.ToInt32(dataReader["ca_id"]),
                            name = Convert.ToString(dataReader["ca_name"]),    
                            date = DateTime.Parse(Convert.ToString(dataReader["ca_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        categories.Add(entity);
                    }
                }
            }
            return categories;
        }

        public List<ECategory> search(string name)
        {
            List<ECategory> categories = new List<ECategory>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                string sqlQuery = "SELECT * FROM ss_category WHERE ca_name LIKE '"+ name +"%'";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        ECategory entity = new ECategory
                        {
                            id = Convert.ToInt32(dataReader["ca_id"]),
                            name = Convert.ToString(dataReader["ca_name"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["ca_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        categories.Add(entity);
                    }
                }
            }
            return categories;
        }

        public ECategory GetByid(int categoryId)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM ss_category WHERE ca_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", categoryId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        ECategory category = new ECategory
                        {
                            id = Convert.ToInt32(dataReader["ca_id"]),
                            name = Convert.ToString(dataReader["ca_name"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["ca_date"]))
                        };
                        return category;
                    }
                }
            }
            return null;
        }

        public void Update(ECategory category)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE ss_category SET  ca_name = @name , ca_date = @date WHERE ca_id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", category.id);
                    cmd.Parameters.AddWithValue("@name", category.name);
                    cmd.Parameters.AddWithValue("@date", category.date);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int categoryId)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM ss_category WHERE ca_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", categoryId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Get list of description the category
        public List<ECategory> GetAllDescription()
        {
            List<ECategory> categories = new List<ECategory>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT ca_name FROM ss_category ORDER BY ca_id  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        ECategory category = new ECategory
                        {
                            name = Convert.ToString(dataReader["ca_name"]),
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        categories.Add(category);
                    }
                }
            }
            return categories;
        }


        public List<ECategory> GetIdByDescription(string name)
        {
            List<ECategory> categories = new List<ECategory>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT ca_id FROM ss_category WHERE ca_name = @nameCategory";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@nameCategory", name);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        ECategory entity = new ECategory
                        {
                            id = Convert.ToInt32(dataReader["ca_id"]),
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        categories.Add(entity);
                    }
                }
            }
            return categories;
        }

    }
}
