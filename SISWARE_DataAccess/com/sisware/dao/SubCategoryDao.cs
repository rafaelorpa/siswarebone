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
    public class SubCategoryDao
    {
        public void Insert(ESubCategory subCategory)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "INSERT INTO ss_subcategory ( sc_name, sc_category_id, sc_date) VALUES ( @name, @categoryId, @date)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@name", subCategory.name);
                    cmd.Parameters.AddWithValue("@categoryId", subCategory.categoryId);
                    cmd.Parameters.AddWithValue("@date", subCategory.date);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Devuelve una lista de Productos ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de productos</returns>
        /// <autor>Rafael Ortuño Paredes</autor>
        public List<ESubCategory> GetAll()
        {
            List<ESubCategory> subCategorys = new List<ESubCategory>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM ss_subcategory ORDER BY sc_name  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        ESubCategory subCategory = new ESubCategory
                        {
                            id = Convert.ToInt32(dataReader["sc_id"]),
                            name = Convert.ToString(dataReader["sc_name"]),
                            categoryId = int.Parse(Convert.ToString(dataReader["sc_category_id"])),
                            date = DateTime.Parse(Convert.ToString(dataReader["sc_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        subCategorys.Add(subCategory);
                    }
                }
            }
            return subCategorys;
        }

        public ESubCategory GetByid(int subCategoryid)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM ss_subcategory WHERE sc_id = @id ORDER BY sc_name  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", subCategoryid);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        ESubCategory subCategory = new ESubCategory
                        {
                            id = Convert.ToInt32(dataReader["sc_id"]),
                            name = Convert.ToString(dataReader["sc_name"]),
                            categoryId = int.Parse(Convert.ToString(dataReader["sc_category_id"])),
                            date = DateTime.Parse(Convert.ToString(dataReader["sc_date"]))
                        };

                        return subCategory;
                    }
                }
            }

            return null;
        }


       /* public List<ESubCategory> SearchToControlCode(string digitoalpha , int code_Category)
        {
            List<ESubCategory> subCategorys = new List<ESubCategory>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                string query= "SELECT sc_control_code FROM sw_subcategory WHERE (sc_control_code LIKE  '%"+digitoalpha+"%') AND (sc_category_code ="+code_Category+") ORDER BY sc_code  ASC";
                //const string sqlQuery = "SELECT * FROM sw_subcategory WHERE sc_control_code LIKE  '%A%' ORDER BY sc_code  ASC";
                using (MySqlCommand cmd = new MySqlCommand(query, cnx))
                {
                    //cmd.Parameters.AddWithValue("@controlCode", controlCode);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        ESubCategory subCategory = new ESubCategory
                        {
                            //code = Convert.ToInt32(dataReader["sc_code"]),
                            controlCode = Convert.ToString(dataReader["sc_control_code"]),
                            //name = Convert.ToString(dataReader["sc_name"]),
                            //categoryCode = int.Parse(Convert.ToString(dataReader["sc_category_code"])),
                            //date = DateTime.Parse(Convert.ToString(dataReader["sc_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        subCategorys.Add(subCategory);
                    }
                }
            }

            return subCategorys;
        }*/

        public List<ESubCategory> GetByCategory(int categoryId)
        {
            List<ESubCategory> subCategories = new List<ESubCategory>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetByCategory = "SELECT * FROM ss_subcategory WHERE sc_category_id = @categoryId ORDER BY sc_name ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetByCategory, cnx))
                {
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        ESubCategory subCategory = new ESubCategory
                        {
                            id = Convert.ToInt32(dataReader["sc_id"]),
                            name = Convert.ToString(dataReader["sc_name"]),
                            categoryId = int.Parse(Convert.ToString(dataReader["sc_category_id"])),
                            date = DateTime.Parse(Convert.ToString(dataReader["sc_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        subCategories.Add(subCategory);
                    }
                }
            }

            return subCategories;
        }

        public List<ESubCategory> search(int categoryCode, string name)
        {
            List<ESubCategory> subCategories = new List<ESubCategory>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                string sqlGetByCategory = "SELECT * FROM ss_subcategory WHERE sc_category_id = @categoryId AND sc_name LIKE '" + name + "%'";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetByCategory, cnx))
                {
                    cmd.Parameters.AddWithValue("@categoryId", categoryCode);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        ESubCategory subCategory = new ESubCategory
                        {
                            id = Convert.ToInt32(dataReader["sc_id"]),
                            name = Convert.ToString(dataReader["sc_name"]),
                            categoryId = int.Parse(Convert.ToString(dataReader["sc_category_id"])),
                            date = DateTime.Parse(Convert.ToString(dataReader["sc_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        subCategories.Add(subCategory);
                    }
                }
            }

            return subCategories;
        }

        public List<ESubCategory> searchAll( string name)
        {
            List<ESubCategory> subCategories = new List<ESubCategory>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                string sqlGetByCategory = "SELECT * FROM ss_subcategory WHERE  sc_name LIKE '" + name + "%'";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetByCategory, cnx))
                {
                   
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        ESubCategory subCategory = new ESubCategory
                        {
                            id = Convert.ToInt32(dataReader["sc_id"]),
                            name = Convert.ToString(dataReader["sc_name"]),
                            categoryId = int.Parse(Convert.ToString(dataReader["sc_category_id"])),
                            date = DateTime.Parse(Convert.ToString(dataReader["sc_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        subCategories.Add(subCategory);
                    }
                }
            }

            return subCategories;
        }

        public void Update(ESubCategory subCategory)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE ss_subcategory SET sc_name = @name, sc_category_id = @categoryId, sc_date = @date WHERE sc_id=@id";

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@name", subCategory.name);
                    cmd.Parameters.AddWithValue("@categoryId", subCategory.categoryId);
                    cmd.Parameters.AddWithValue("@date", subCategory.date);
                    cmd.Parameters.AddWithValue("@id", subCategory.id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int subCategoryId)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM ss_subcategory WHERE sc_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", subCategoryId);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<ESubCategory> GetIdByDescription(string name)
        {
            List<ESubCategory> subCategories = new List<ESubCategory>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT sc_id FROM ss_subcategory WHERE sc_name = @nameSubCategory ORDER BY sc_name  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@nameSubCategory", name);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        ESubCategory subCategory = new ESubCategory
                        {
                            id = Convert.ToInt32(dataReader["sc_id"]),
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        subCategories.Add(subCategory);
                    }
                }
            }

            return subCategories;
        }
    }
}
