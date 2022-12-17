using com.sisware.bean;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sisware.dao
{
    public class PatientDao
    {
        public void Insert(EPatient patient)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "INSERT INTO ss_patient (pa_ci, pa_name, pa_surname, pa_city, pa_address,  pa_email, pa_cell, pa_date) VALUES (@ci, @name, @surname, @city, @address, @email, @cell, @date)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@ci", patient.ci);
                    cmd.Parameters.AddWithValue("@name", patient.name);
                    cmd.Parameters.AddWithValue("@surname", patient.surname);
                    cmd.Parameters.AddWithValue("@city", patient.city);
                    cmd.Parameters.AddWithValue("@address", patient.address);
                    cmd.Parameters.AddWithValue("@email", patient.cell);
                    cmd.Parameters.AddWithValue("@cell", patient.email);
                    cmd.Parameters.AddWithValue("@date", patient.date);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Devuelve una lista de Productos ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de productos</returns>
        /// <autor>José Luis García Bautista</autor>
        public List<EPatient> GetAll()
        {
            List<EPatient> patients = new List<EPatient>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM ss_patient ORDER BY pa_id  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        EPatient patient = new EPatient
                        {
                            id = Convert.ToInt32(dataReader["pa_id"]),
                            ci = Convert.ToString(dataReader["pa_ci"]),
                            name = Convert.ToString(dataReader["pa_name"]),
                            surname = Convert.ToString(dataReader["pa_surname"]),
                            city = Convert.ToString(dataReader["pa_city"]),
                            address = Convert.ToString(dataReader["pa_address"]),
                            email = Convert.ToString(dataReader["pa_email"]),
                            cell = Convert.ToString(dataReader["pa_cell"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["pa_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        patients.Add(patient);
                    }
                }
            }
            return patients;
        }

        public List<EPatient> SearchForName(string name)
        {
            List<EPatient> patients = new List<EPatient>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                string sqlQuery = "SELECT * FROM ss_patient WHERE pa_name LIKE '" + name + "%'";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        EPatient patient = new EPatient
                        {
                            id = Convert.ToInt32(dataReader["pa_id"]),
                            ci = Convert.ToString(dataReader["pa_ci"]),
                            name = Convert.ToString(dataReader["pa_name"]),
                            surname = Convert.ToString(dataReader["pa_surname"]),
                            city = Convert.ToString(dataReader["pa_city"]),
                            address = Convert.ToString(dataReader["pa_address"]),
                            email = Convert.ToString(dataReader["pa_email"]),
                            cell = Convert.ToString(dataReader["pa_cell"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["pa_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        patients.Add(patient);
                    }
                }
            }
            return patients;
        }

        public List<EPatient> SearchForFirstName(string surname)
        {
            List<EPatient> patients = new List<EPatient>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                string sqlQuery = "SELECT * FROM ss_patient WHERE pa_surname LIKE '" + surname + "%'";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        EPatient patient = new EPatient
                        {
                            id = Convert.ToInt32(dataReader["pa_id"]),
                            ci = Convert.ToString(dataReader["pa_ci"]),
                            name = Convert.ToString(dataReader["pa_name"]),
                            surname = Convert.ToString(dataReader["pa_surname"]),
                            city = Convert.ToString(dataReader["pa_city"]),
                            address = Convert.ToString(dataReader["pa_address"]),
                            email = Convert.ToString(dataReader["pa_email"]),
                            cell = Convert.ToString(dataReader["pa_cell"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["pa_date"]))
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        patients.Add(patient);
                    }
                }
            }
            return patients;
        }



        public EPatient GetByid(int patientId)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM ss_patient WHERE pa_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", patientId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EPatient patient = new EPatient
                        {
                            id = Convert.ToInt32(dataReader["pa_id"]),
                            ci = Convert.ToString(dataReader["pa_ci"]),
                            name = Convert.ToString(dataReader["pa_name"]),
                            surname = Convert.ToString(dataReader["pa_surname"]),
                            city = Convert.ToString(dataReader["pa_city"]),
                            address = Convert.ToString(dataReader["pa_address"]),
                            email = Convert.ToString(dataReader["pa_email"]),
                            cell = Convert.ToString(dataReader["pa_cell"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["pa_date"]))
                        };

                        return patient;
                    }
                }
            }

            return null;
        }

        public void Update(EPatient patient)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE ss_patient SET it_ci = @ci, it_name = @name, it_surname = @surName, it_city = @city, it_address = @address, it_cell = @cell, it_email = @email, it_date = @date WHERE it_id=@id;";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@ci", patient.ci);
                    cmd.Parameters.AddWithValue("@name", patient.name);
                    cmd.Parameters.AddWithValue("@surname", patient.surname);
                    cmd.Parameters.AddWithValue("@city", patient.city);
                    cmd.Parameters.AddWithValue("@address", patient.address);
                    cmd.Parameters.AddWithValue("@cell", patient.cell);
                    cmd.Parameters.AddWithValue("@email", patient.email);
                    cmd.Parameters.AddWithValue("@date", patient.date);
                    cmd.Parameters.AddWithValue("@id", patient.id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int patientId)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM ss_patient WHERE pa_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", patientId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
