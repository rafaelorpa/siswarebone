using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlServerCe;
using com.sisware.bean;
using MySql.Data.MySqlClient;
using com.snapsoft.util;

namespace com.sisware.dao
{
    public class EntityDao
    {
        private Utilities utilities = new Utilities();
        public void Insert(EEntity entity)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "INSERT INTO sw_entity (en_name, en_address, en_representative, en_place ,en_zone, en_phone, en_fax, en_email, en_web, en_logo) VALUES (@name, @address, @representative,@place, @zone, @phone, @fax, @email, @web, @logo)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@name", entity.name);
                    cmd.Parameters.AddWithValue("@address", entity.address);
                    cmd.Parameters.AddWithValue("@representative", entity.representative);
                    cmd.Parameters.AddWithValue("@place", entity.place);
                    cmd.Parameters.AddWithValue("@zone", entity.zone);
                    cmd.Parameters.AddWithValue("@phone", entity.phone);
                    cmd.Parameters.AddWithValue("@fax", entity.fax);
                    cmd.Parameters.AddWithValue("@email", entity.email);
                    cmd.Parameters.AddWithValue("@web", entity.web);
                    cmd.Parameters.AddWithValue("@logo", entity.logo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Devuelve una lista de Productos ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de productos</returns>
        /// <autor>José Luis García Bautista</autor>
        public List<EEntity> GetAll()
        {
            List<EEntity> entities = new List<EEntity>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM sw_entity ORDER BY en_code  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        EEntity entity = new EEntity
                        {
                            //en_name, en_address, en_representative, en_zone, en_phone, en_fax, en_email, en_web, en_logo

                            code = Convert.ToInt32(dataReader["en_code"]),
                            name = Convert.ToString(dataReader["en_name"]),
                            address = Convert.ToString(dataReader["en_address"]),
                            representative = Convert.ToString(dataReader["en_representative"]),
                            place = Convert.ToString(dataReader["en_place"]),
                            zone = Convert.ToString(dataReader["en_zone"]),
                            phone = Convert.ToString(dataReader["en_phone"]),
                            fax = Convert.ToString(dataReader["en_fax"]),
                            email = Convert.ToString(dataReader["en_email"]),
                            web = Convert.ToString(dataReader["en_web"]),
                            logo = (byte[])dataReader["en_logo"]
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        entities.Add(entity);
                    }
                }
            }
            return entities;
        }

        public EEntity GetByid(int entityCode)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM sw_entity WHERE en_code = @code";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@code", entityCode);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EEntity entity = new EEntity
                        {
                            code = Convert.ToInt32(dataReader["en_code"]),
                            name = Convert.ToString(dataReader["en_name"]),
                            address = Convert.ToString(dataReader["en_address"]),
                            representative = Convert.ToString(dataReader["en_representative"]),
                            zone = Convert.ToString(dataReader["en_zone"]),
                            place = Convert.ToString(dataReader["en_place"]),
                            phone = Convert.ToString(dataReader["en_phone"]),
                            fax = Convert.ToString(dataReader["en_fax"]),
                            email = Convert.ToString(dataReader["en_email"]),
                            web = Convert.ToString(dataReader["en_web"]),
                            logo = (byte[])dataReader["en_logo"]
                        };

                        return entity;
                    }
                }
            }

            return null;
        }

        public void Update(EEntity entity)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE sw_entity SET en_name = @name, en_address = @address, en_representative = @representative, en_place = @place, en_zone = @zone, en_phone = @phone, en_fax = @fax, en_email = @email, en_web = @web, en_logo = @logo WHERE en_code=@code";

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@code", entity.code);
                    cmd.Parameters.AddWithValue("@name", entity.name);
                    cmd.Parameters.AddWithValue("@address", entity.address);
                    cmd.Parameters.AddWithValue("@representative", entity.representative);
                    cmd.Parameters.AddWithValue("@place", entity.place);
                    cmd.Parameters.AddWithValue("@zone", entity.zone);
                    cmd.Parameters.AddWithValue("@phone", entity.phone);
                    cmd.Parameters.AddWithValue("@fax", entity.fax);
                    cmd.Parameters.AddWithValue("@email", entity.email);
                    cmd.Parameters.AddWithValue("@web", entity.web);
                    cmd.Parameters.AddWithValue("@logo", entity.logo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int entityCode)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM sw_entity WHERE en_code = @code";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@code", entityCode);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
