using com.sisware.bean;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;

namespace com.sisware.dao
{
   
    public class InputDao
    {
        public void Insert(EInput input)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "INSERT INTO ss_input (ip_date, ip_hour, ip_code, ip_input_number, ip_quantity, ip_observacion, ip_us_id, ip_pv_id, ip_ar_id) VALUES (@date, @hour, @code, @inputNumber, @quantity, @observation,  @userId, @providerId, @articleId)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@date", input.date);
                    cmd.Parameters.AddWithValue("@hour", input.hour);
                    cmd.Parameters.AddWithValue("@code", input.code);
                    cmd.Parameters.AddWithValue("@inputNumber", input.inputNumber);
                    cmd.Parameters.AddWithValue("@quantity", input.quantity);
                    cmd.Parameters.AddWithValue("@observation", input.observation);
                    cmd.Parameters.AddWithValue("@userId", input.userId);
                    cmd.Parameters.AddWithValue("@providerId", input.providerId);
                    cmd.Parameters.AddWithValue("@articleId", input.articleId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Devuelve una lista de Salida de Productos ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de productos</returns>
        /// <autor>Rafael Ortuno Paredes</autor>
        public List<EInput> GetAll()
        {
            List<EInput> inputs = new List<EInput>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM ss_input ORDER BY ip_id  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto EInput para llenar sus propiedades
                        EInput input = new EInput
                        {
                            id = Convert.ToInt32(dataReader["ip_id"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["ip_date"])),
                            hour = Convert.ToString(dataReader["ip_hour"]),
                            code = Convert.ToString(dataReader["ip_code"]),
                            inputNumber = Convert.ToString(dataReader["ip_input_number"]),
                            quantity = Convert.ToDouble(dataReader["ip_quantity"]),
                            observation = Convert.ToString(dataReader["ip_observacion"]),
                            userId = Convert.ToInt32(dataReader["ip_us_id"]),
                            providerId = Convert.ToInt32(dataReader["ip_pv_id"]),
                            articleId = Convert.ToInt32(dataReader["ip_ar_id"])
                        };
                        //
                        //Insertamos el objeto Input dentro de la lista Inputs
                        inputs.Add(input);
                    }
                }
            }
            return inputs;
        }


        public List<EInput> Search(string name)
        {
            List<EInput> inputs = new List<EInput>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                string sqlQuery = "SELECT DISTINCT ip_input_number, ip_pv_id FROM ss_input WHERE ip_input_number LIKE '" + name + "%'";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {

                        //
                        //Instanciamos al objeto EInput para llenar sus propiedades
                        EInput input = new EInput
                        {
                            inputNumber = Convert.ToString(dataReader["ip_input_number"]),
                            providerId = Convert.ToInt32(dataReader["ip_pv_id"]),

                        };
                        //
                        //Insertamos el objeto Input dentro de la lista Inputs
                        inputs.Add(input);
                    }
                }
            }
            return inputs;
        }

        public List<EInput> GetIdNumberId()
        {
            List<EInput> inputs = new List<EInput>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT ip_id, ip_input_number FROM ss_input ORDER BY ip_id DESC LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                     
                        //
                        //Instanciamos al objeto EInput para llenar sus propiedades
                        EInput input = new EInput
                        {
                            id = Convert.ToInt32(dataReader["ip_id"]),
                            inputNumber = Convert.ToString(dataReader["ip_input_number"]),
                        };
                        //
                        //Insertamos el objeto Input dentro de la lista Inputs
                        inputs.Add(input);
                    }
                }
            }
            return inputs;
        }


        public List<EInput> GetCodeInput()
        {
            List<EInput> inputs = new List<EInput>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT ip_id FROM ss_input ORDER BY ip_id DESC LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {

                        //
                        //Instanciamos al objeto EInput para llenar sus propiedades
                        EInput input = new EInput
                        {
                            id = Convert.ToInt32(dataReader["ip_id"]),
                        };
                        //
                        //Insertamos el objeto Input dentro de la lista Inputs
                        inputs.Add(input);
                    }
                }
            }
            return inputs;
        }

        public List<EInput> GetNumberInput()
        {
            List<EInput> inputs = new List<EInput>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT DISTINCT ip_input_number, ip_pv_id FROM ss_input";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {

                        //
                        //Instanciamos al objeto EInput para llenar sus propiedades
                        EInput input = new EInput
                        {
                            inputNumber = Convert.ToString(dataReader["ip_input_number"]),
                            providerId = Convert.ToInt32(dataReader["ip_pv_id"]),

                        };
                        //
                        //Insertamos el objeto Input dentro de la lista Inputs
                        inputs.Add(input);
                    }
                }
            }
            return inputs;
        }

        public List<EInput> GetLastDateInput()
        {
            List<EInput> inputs = new List<EInput>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT DISTINCT ip_date FROM ss_input";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {

                        //
                        //Instanciamos al objeto EInput para llenar sus propiedades
                        EInput input = new EInput
                        {
                            date = Convert.ToDateTime(dataReader["ip_date"]),

                        };
                        //
                        //Insertamos el objeto Input dentro de la lista Inputs
                        inputs.Add(input);
                    }
                }
            }
            return inputs;
        }

        public List<EInput> GetByNumberInput(string numberInput)
        {
            List<EInput> inputs = new List<EInput>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT ip_id, ip_date, ip_hour, ip_code, ip_input_number, ip_quantity, ip_observacion, ip_pv_id, ip_us_id, ip_ar_id FROM ss_input WHERE ip_input_number = @numberInput";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@numberInput", numberInput);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto EInput para llenar sus propiedades
                        EInput input = new EInput
                        {
                            id = Convert.ToInt32(dataReader["ip_id"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["ip_date"])),
                            hour = Convert.ToString(dataReader["ip_hour"]),
                            code = Convert.ToString(dataReader["ip_code"]),
                            inputNumber = Convert.ToString(dataReader["ip_input_number"]),
                            quantity = Convert.ToDouble(dataReader["ip_quantity"]),
                            observation = Convert.ToString(dataReader["ip_observacion"]),
                            userId = Convert.ToInt32(dataReader["ip_us_id"]),
                            providerId = Convert.ToInt32(dataReader["ip_pv_id"]),
                            articleId = Convert.ToInt32(dataReader["ip_ar_id"])

                        };
                        //
                        //Insertamos el objeto Input dentro de la lista Inputs
                        inputs.Add(input);
                    }
                }
            }
            return inputs;
        }

        public EInput GetByid(int inputId)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM ss_input WHERE ip_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", inputId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EInput input= new EInput
                        {
                            id = Convert.ToInt32(dataReader["ip_id"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["ip_date"])),
                            hour = Convert.ToString(dataReader["ip_hour"]),
                            code = Convert.ToString(dataReader["ip_code"]),
                            inputNumber = Convert.ToString(dataReader["ip_input_number"]),
                            quantity = Convert.ToDouble(dataReader["ip_quantity"]),
                            observation = Convert.ToString(dataReader["ip_observacion"]),
                            userId = Convert.ToInt32(dataReader["ip_us_id"]),
                            providerId = Convert.ToInt32(dataReader["ip_pv_id"]),
                            articleId = Convert.ToInt32(dataReader["ip_ar_id"])
                        };

                        return input;
                    }
                }
            }

            return null;
        }

        public void Update(EInput input)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE ss_input SET ip_date = @date, ip_hour = @hour, ip_code = @code, ip_input_number=@inputNumber, ip_quantity = @quantity, ip_observacion = @observation, ip_us_id = @userId, ip_pv_id = @providerId, ip_ar_id = @articleId WHERE ip_id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@date", input.date);
                    cmd.Parameters.AddWithValue("@hour", input.hour);
                    cmd.Parameters.AddWithValue("@code", input.code);
                    cmd.Parameters.AddWithValue("@inputNumber", input.inputNumber);
                    cmd.Parameters.AddWithValue("@quantity", input.quantity);
                    cmd.Parameters.AddWithValue("@observation", input.observation);
                    cmd.Parameters.AddWithValue("@userId", input.userId);
                    cmd.Parameters.AddWithValue("@providerId", input.providerId);
                    cmd.Parameters.AddWithValue("@articleId", input.articleId);
                    cmd.Parameters.AddWithValue("@id", input.id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(string inputNumber)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM ss_input WHERE ip_input_number = @inputNumber";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@inputNumber", inputNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ReportGetByNumberInput(string inputNumber)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sqlGetById = "SELECT inv.iv_id, a.ar_description, m.me_description, i.ip_quantity, i.ip_input_number, i.ip_observacion, i.ip_date, i.ip_hour, p.pv_name, p.pv_nit, u.us_ci, u.us_first_name, u.us_last_name, inv.iv_lot FROM ss_article a INNER JOIN ss_measure m ON (m.me_id = a.ar_measure_id) INNER JOIN ss_input i ON ( i.ip_ar_id = a.ar_id ) INNER JOIN ss_subcategory s ON ( s.sc_id = a.ar_subcategory_id ) INNER JOIN ss_category c ON ( c.ca_id = s.sc_category_id ) INNER JOIN ss_provider p ON ( p.pv_id = i.ip_pv_id ) INNER JOIN ss_user u ON ( u.us_id = i.ip_us_id ) INNER JOIN ss_inventory inv ON ( inv.iv_ip_id = i.ip_id ) WHERE (i.ip_input_number =" + inputNumber+")" ;

            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx);
                MySqlDataAdapter nda = new MySqlDataAdapter(cmd);

                nda.Fill(ds);
                nda.Fill(dt);
            }
            //  return ds;
            return dt;
        }


        public DataTable ReportGeneralInput()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sqlGetById = "SELECT inv.iv_code, a.ar_description, inv.iv_lot, i.ip_quantity, i.ip_date, i.ip_input_number FROM ss_inventory inv INNER JOIN ss_article a ON ( a.ar_id = inv.iv_ar_id ) INNER JOIN ss_subcategory s ON ( s.sc_id = a.ar_subcategory_id ) INNER JOIN ss_category c ON ( c.ca_id = s.sc_category_id ) INNER JOIN ss_input i ON ( i.ip_id = inv.iv_ip_id ) ORDER BY (i.ip_ar_id)";

            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx);
                MySqlDataAdapter nda = new MySqlDataAdapter(cmd);

                nda.Fill(ds);
                nda.Fill(dt);
            }
            //  return ds;
            return dt;
        }

        public DataTable ReportInputArticle(Int32 articleId)
        {
            DataTable dt = new DataTable();
            string sqlGetById = "SELECT inv.iv_code, a.ar_description, inv.iv_lot, inv.iv_quantity, inv.iv_residue, i.ip_quantity, i.ip_input_number, i.ip_date FROM ss_inventory inv INNER JOIN ss_article a ON ( a.ar_id = inv.iv_ar_id ) INNER JOIN ss_subcategory s ON ( s.sc_id = a.ar_subcategory_id ) INNER JOIN ss_category c ON ( c.ca_id = s.sc_category_id) INNER JOIN ss_input i ON ( i.ip_id = inv.iv_ip_id ) WHERE (i.ip_ar_id = @articleId)";

            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx);
                cmd.Parameters.AddWithValue("@articleId", articleId);
                MySqlDataAdapter nda = new MySqlDataAdapter(cmd);
                nda.Fill(dt);
            }
            return dt;
        }
    }
}
