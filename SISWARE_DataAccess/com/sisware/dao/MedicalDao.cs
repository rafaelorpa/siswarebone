using com.sisware.bean;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sisware.dao
{
    public class MedicalDao
    {
        public void Insert(EMedical medical)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "INSERT INTO ss_medical (md_name, md_surname,md_specialty, md_city, md_address, md_cell, md_email,  m_date) VALUES ( @name, @surname, @specialty @city, @address, @cell, @email, @date)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@name", medical.name);
                    cmd.Parameters.AddWithValue("@surname", medical.surname);
                    cmd.Parameters.AddWithValue("@specialty", medical.speciality);
                    cmd.Parameters.AddWithValue("@city", medical.city);
                    cmd.Parameters.AddWithValue("@address", medical.address);
                    cmd.Parameters.AddWithValue("@cell", medical.cell);
                    cmd.Parameters.AddWithValue("@email", medical.email);
                    cmd.Parameters.AddWithValue("@date", medical.date);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Devuelve una lista de Productos ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de productos</returns>
        /// <autor>José Luis García Bautista</autor>
        public List<EMedical> GetAll()
        {
            List<EMedical> medicals = new List<EMedical>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM ss_medical ORDER BY md_id  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        EMedical medical = new EMedical
                        {
                            id = Convert.ToInt32(dataReader["md_id"]),
                            name = Convert.ToString(dataReader["md_name"]),
                            surname = Convert.ToString(dataReader["md_surname"]),
                            speciality = Convert.ToString(dataReader["md_specialty"]),
                            city = Convert.ToString(dataReader["md_city"]),
                            address = Convert.ToString(dataReader["md_address"]),
                            cell = Convert.ToString(dataReader["md_cell"]),
                            email = Convert.ToString(dataReader["md_email"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["it_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        medicals.Add(medical);
                    }
                }
            }
            return medicals;
        }

        public List<EMedical> SearchForName(string name)
        {
            List<EMedical> medicals = new List<EMedical>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                string sqlQuery = "SELECT * FROM ss_medical WHERE md_name LIKE '" + name + "%'";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        EMedical medical = new EMedical
                        {
                            id = Convert.ToInt32(dataReader["md_id"]),
                            name = Convert.ToString(dataReader["md_name"]),
                            surname = Convert.ToString(dataReader["md_surname"]),
                            speciality = Convert.ToString(dataReader["md_specialty"]),
                            city = Convert.ToString(dataReader["md_city"]),
                            address = Convert.ToString(dataReader["md_address"]),
                            cell = Convert.ToString(dataReader["md_cell"]),
                            email = Convert.ToString(dataReader["md_email"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["it_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        medicals.Add(medical);
                    }
                }
            }
            return medicals;
        }

        public List<EMedical> SearchForFirstName(string surname)
        {
            List<EMedical> medicals = new List<EMedical>();
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
                        EMedical medical = new EMedical
                        {
                            id = Convert.ToInt32(dataReader["md_id"]),
                            name = Convert.ToString(dataReader["md_name"]),
                            surname = Convert.ToString(dataReader["md_surname"]),
                            speciality = Convert.ToString(dataReader["md_specialty"]),
                            city = Convert.ToString(dataReader["md_city"]),
                            address = Convert.ToString(dataReader["md_address"]),
                            cell = Convert.ToString(dataReader["md_cell"]),
                            email = Convert.ToString(dataReader["md_email"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["it_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        medicals.Add(medical);
                    }
                }
            }
            return medicals;
        }



        public EMedical GetByid(int medicalId)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM ss_medical WHERE md_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", medicalId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EMedical medical = new EMedical
                        {
                            id = Convert.ToInt32(dataReader["md_id"]),
                            name = Convert.ToString(dataReader["md_name"]),
                            surname = Convert.ToString(dataReader["md_surname"]),
                            speciality = Convert.ToString(dataReader["md_specialty"]),
                            city = Convert.ToString(dataReader["md_city"]),
                            address = Convert.ToString(dataReader["md_address"]),
                            cell = Convert.ToString(dataReader["md_cell"]),
                            email = Convert.ToString(dataReader["md_email"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["it_date"]))
                        };
                        
                        return medical;
                    }
                }
            }

            return null;
        }

        public void Update(EMedical medical)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE ss_medical SET  md_name = @name, md_surname = @surName, md_specialty = @speciality, md_city = @city, md_address = @address, md_cell = @cell, md_email = @email, md_date = @date WHERE md_id=@id";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    
                    cmd.Parameters.AddWithValue("@name", medical.name);
                    cmd.Parameters.AddWithValue("@surname", medical.surname);
                    cmd.Parameters.AddWithValue("@speciality", medical.speciality);
                    cmd.Parameters.AddWithValue("@city", medical.city);
                    cmd.Parameters.AddWithValue("@address", medical.address);
                    cmd.Parameters.AddWithValue("@cell", medical.cell);
                    cmd.Parameters.AddWithValue("@email", medical.email);
                    cmd.Parameters.AddWithValue("@date", medical.date);
                    cmd.Parameters.AddWithValue("@id", medical.id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
