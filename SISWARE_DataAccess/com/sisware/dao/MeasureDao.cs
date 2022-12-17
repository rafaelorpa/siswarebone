using com.sisware.bean;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sisware.dao
{
    public class MeasureDao
    {
        public void Insert(EMeasure measure)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "INSERT INTO ss_measure (me_description, sc_date) VALUES (@description, @date)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@description", measure.description);
                    cmd.Parameters.AddWithValue("@date", measure.date);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Devuelve una lista de Unidades de medida ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de productos</returns>
        /// <autor>Rafael Ortuño Paredes</autor>
        public List<EMeasure> GetAll()
        {
            List<EMeasure> measures = new List<EMeasure>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM ss_measure ORDER BY me_description  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        EMeasure measure = new EMeasure
                        {
                            id = Convert.ToInt32(dataReader["me_id"]),
                            description = Convert.ToString(dataReader["me_description"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["me_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        measures.Add(measure);
                    }
                }
            }
            return measures;
        }

        public EMeasure GetByid1(string description)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT me_id FROM ss_measure WHERE me_description = @description ";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@description", description);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EMeasure measure = new EMeasure
                        {
                            id = Convert.ToInt32(dataReader["me_id"]),

                        };

                        return measure;
                    }
                }
            }
            return null;
        }

            public EMeasure GetByid(int measureId)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM ss_measure WHERE me_id = @id ORDER BY me_description  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", measureId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EMeasure measure = new EMeasure
                        {
                            id = Convert.ToInt32(dataReader["me_id"]),
                            description = Convert.ToString(dataReader["me_description"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["me_date"]))
                        };

                        return measure;
                    }
                }
            }

            return null;
        }


        

      

       /* public List<EMeasure> search(int , string name)
        {
            List<ESubCategory> subCategories = new List<ESubCategory>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                string sqlGetByCategory = "SELECT * FROM sw_subcategory WHERE sc_category_code = @categoryCode AND sc_name LIKE '" + name + "%'";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetByCategory, cnx))
                {
                    cmd.Parameters.AddWithValue("@categoryCode", categoryCode);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        ESubCategory subCategory = new ESubCategory
                        {
                            code = Convert.ToInt32(dataReader["sc_code"]),
                            controlCode = Convert.ToString(dataReader["sc_control_code"]),
                            name = Convert.ToString(dataReader["sc_name"]),
                            categoryCode = int.Parse(Convert.ToString(dataReader["sc_category_code"])),
                            date = DateTime.Parse(Convert.ToString(dataReader["sc_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        subCategories.Add(subCategory);
                    }
                }
            }

            return subCategories;
        }*/

        public void Update(EMeasure measure)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE ss_measure SET me_description = @description, me_date = @date WHERE me_id=@id";

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@description", measure.description);
                    cmd.Parameters.AddWithValue("@date", measure.date);
                    cmd.Parameters.AddWithValue("@id", measure.id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int measureId)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM ss_measure WHERE me_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", measureId);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<EMeasure> GetAllDescription()
        {
            List<EMeasure> measures = new List<EMeasure>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT me_description FROM ss_measure ORDER BY me_description  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        EMeasure measure = new EMeasure
                        {
                            description = Convert.ToString(dataReader["me_description"]),
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        measures.Add(measure);
                    }
                }
            }

            return measures;
        }
    }
}
