using com.sisware.bean;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;

using System.Data;


namespace com.sisware.dao
{
    public class OutputDao
    {
        /*public void Insert(EOutput output)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "INSERT INTO sw_output (op_date, op_hour, op_output_number, op_quantity, op_ufv_unit_price, op_ufv_total_price, op_bs_unit_price, op_bs_total_price, op_observation, op_us_code, op_ep_code, op_ar_code, op_iv_code) VALUES (@date, @hour, @outputNumber, @quantity, @ufvUnitPrice, @ufvTotalPrice, @bsUnitPrice, @bsTotalPrice, @observation, @userCode, @employeeCode, @articleCode, @inventaryCode)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@date", output.date);
                    cmd.Parameters.AddWithValue("@hour", output.hour);
                    cmd.Parameters.AddWithValue("@outputNumber", output.outputNumber);
                    cmd.Parameters.AddWithValue("@quantity", output.quantity);
                    cmd.Parameters.AddWithValue("@ufvUnitPrice", output.ufvUnitPrice);
                    cmd.Parameters.AddWithValue("@ufvTotalPrice", output.ufvTotalPrice);
                    cmd.Parameters.AddWithValue("@bsUnitPrice", output.bsUnitPrice);
                    cmd.Parameters.AddWithValue("@bsTotalPrice", output.bsTotalPrice);
                    cmd.Parameters.AddWithValue("@observation", output.observation);
                    cmd.Parameters.AddWithValue("@userCode", output.userCode);
                    cmd.Parameters.AddWithValue("@employeeCode", output.employeeCode);
                    cmd.Parameters.AddWithValue("@inventaryCode", output.inventaryCode);
                    cmd.Parameters.AddWithValue("@articleCode", output.articleCode);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Devuelve una lista de Salida  ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de productos</returns>
        /// <autor>Rafael Ortuno Paredes</autor>
        public List<EOutput> GetAll()
        {
            List<EOutput> outputs = new List<EOutput>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM sw_output ORDER BY op_code  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto EInput para llenar sus propiedades
                        EOutput output = new EOutput
                        {
                            code = Convert.ToInt32(dataReader["op_code"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["op_date"])),
                            hour = Convert.ToString(dataReader["op_hour"]),
                            outputNumber = Convert.ToString(dataReader["op_output_number"]),
                            quantity = Convert.ToDouble(dataReader["op_quantity"]),
                            ufvUnitPrice = Convert.ToDouble(dataReader["op_ufv_unit_price"]),
                            ufvTotalPrice = Convert.ToDouble(dataReader["op_ufv_total_price"]),
                            bsUnitPrice = Convert.ToDouble(dataReader["op_bs_unit_price"]),
                            bsTotalPrice = Convert.ToDouble(dataReader["op_bs_total_price"]),
                            observation = Convert.ToString(dataReader["op_observation"]),
                            userCode = Convert.ToInt32(dataReader["op_us_code"]),
                            employeeCode = Convert.ToInt32(dataReader["op_ep_code"]),
                            articleCode = Convert.ToInt32(dataReader["op_ar_code"]),
                            inventaryCode = Convert.ToInt32(dataReader["op_iv_code"])
                        };
                        //
                        //Insertamos el objeto Input dentro de la lista Inputs
                        outputs.Add(output);
                    }
                }
            }
            return outputs;
        }
        public List<EOutput> Search(string name)
        {
            List<EOutput> outputs = new List<EOutput>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                 string sqlQuery = "SELECT * FROM sw_output WHERE op_output_number LIKE '" + name + "%'";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto EInput para llenar sus propiedades
                        EOutput output = new EOutput
                        {
                            code = Convert.ToInt32(dataReader["op_code"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["op_date"])),
                            hour = Convert.ToString(dataReader["op_hour"]),
                            outputNumber = Convert.ToString(dataReader["op_output_number"]),
                            quantity = Convert.ToDouble(dataReader["op_quantity"]),
                            ufvUnitPrice = Convert.ToDouble(dataReader["op_ufv_unit_price"]),
                            ufvTotalPrice = Convert.ToDouble(dataReader["op_ufv_total_price"]),
                            bsUnitPrice = Convert.ToDouble(dataReader["op_bs_unit_price"]),
                            bsTotalPrice = Convert.ToDouble(dataReader["op_bs_total_price"]),
                            observation = Convert.ToString(dataReader["op_observation"]),
                            userCode = Convert.ToInt32(dataReader["op_us_code"]),
                            employeeCode = Convert.ToInt32(dataReader["op_ep_code"]),
                            articleCode = Convert.ToInt32(dataReader["op_ar_code"]),
                            inventaryCode = Convert.ToInt32(dataReader["op_iv_code"])
                        };
                        //
                        //Insertamos el objeto Input dentro de la lista Inputs
                        outputs.Add(output);
                    }
                }
            }
            return outputs;
        }
        public EOutput GetByid(int outputCode)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM sw_output WHERE op_code = @code";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@code", outputCode);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EOutput output = new EOutput
                        {
                            code = Convert.ToInt32(dataReader["op_code"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["op_date"])),
                            hour = Convert.ToString(dataReader["op_hour"]),
                            outputNumber = Convert.ToString(dataReader["op_output_number"]),
                            quantity = Convert.ToDouble(dataReader["op_quantity"]),
                            ufvUnitPrice = Convert.ToDouble(dataReader["op_ufv_unit_price"]),
                            ufvTotalPrice = Convert.ToDouble(dataReader["op_ufv_total_price"]),
                            bsUnitPrice = Convert.ToDouble(dataReader["op_bs_unit_price"]),
                            bsTotalPrice = Convert.ToDouble(dataReader["op_bs_total_pric"]),
                            observation = Convert.ToString(dataReader["op_observation"]),
                            userCode = Convert.ToInt32(dataReader["op_us_code"]),
                            employeeCode = Convert.ToInt32(dataReader["op_ep_code"]),
                            articleCode = Convert.ToInt32(dataReader["op_ar_code"]),
                            inventaryCode = Convert.ToInt32(dataReader["op_iv_code"])
                        };

                        return output;
                    }
                }
            }

            return null;
        }
        public List<EOutput> GetLastDateOutput()
        {
            List<EOutput> outputs = new List<EOutput>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT DISTINCT op_date FROM sw_output";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {

                        //
                        //Instanciamos al objeto EInput para llenar sus propiedades
                        EOutput output = new EOutput
                        {
                            date = Convert.ToDateTime(dataReader["op_date"]),

                        };
                        //
                        //Insertamos el objeto Input dentro de la lista Inputs
                        outputs.Add(output);
                    }
                }
            }
            return outputs;
        }
        public List<EOutput> GetIdNumberId()
        {
            List<EOutput> outputs = new List<EOutput>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                //const string sqlQuery = "SELECT op_code, op_output_number FROM sw_output ORDER BY op_code DESC LIMIT 1";

                const string sqlQuery = "SELECT op_code , op_output_number FROM sw_output WHERE op_output_number <>  '000000' ORDER BY op_code DESC  LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {

                        //
                        //Instanciamos al objeto EInput para llenar sus propiedades
                        EOutput output = new EOutput
                        {
                            code = Convert.ToInt32(dataReader["op_code"]),
                            outputNumber = Convert.ToString(dataReader["op_output_number"]),
                        };
                        //
                        //Insertamos el objeto Input dentro de la lista Inputs
                        outputs.Add(output);
                    }
                }
            }
            return outputs;
        }
        public List<EOutput> GetOutputNumber(string outputNumber)
        {
            List<EOutput> outputs = new List<EOutput>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT op_code, op_output_number, op_iv_code, op_quantity FROM sw_output WHERE (op_output_number=@outputNumber and op_output_number <> '000000') ORDER BY op_code";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@outputNumber", outputNumber);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {

                        //
                        //Instanciamos al objeto EInput para llenar sus propiedades
                        EOutput output = new EOutput
                        {
                            code = Convert.ToInt32(dataReader["op_code"]),
                            quantity = Convert.ToDouble(dataReader["op_quantity"]),
                            outputNumber = Convert.ToString(dataReader["op_output_number"]),
                            inventaryCode = Convert.ToInt32(dataReader["op_iv_code"]),
                        };
                        //
                        //Insertamos el objeto Input dentro de la lista Inputs
                        outputs.Add(output);
                    }
                }
            }
            return outputs;
        }
        public void Update(EOutput output)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE sw_output SET op_date = @date, op_hour = @hour, op_output_number = @outputNumber, op_quantity = @quantity, op_ufv_unit_price = @ufvUnitPrice, op_ufv_total_price = @ufvTotalPrice, op_bs_unit_price = @bsUnitPrice, op_bs_total_price = @bsTotalPrice, op_observation = @observation, op_us_code = @userCode, op_ep_code = @employeeCode, op_ar_code = @articleCode WHERE op_code = @code";

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@date", output.date);
                    cmd.Parameters.AddWithValue("@hour", output.hour);
                    cmd.Parameters.AddWithValue("@outputNumber", output.outputNumber);
                    cmd.Parameters.AddWithValue("@quantity", output.quantity);
                    cmd.Parameters.AddWithValue("@ufvUnitPrice", output.ufvUnitPrice);
                    cmd.Parameters.AddWithValue("@ufvTotalPrice", output.ufvTotalPrice);
                    cmd.Parameters.AddWithValue("@bsUnitPrice", output.bsUnitPrice);
                    cmd.Parameters.AddWithValue("@bsTotalPrice", output.bsTotalPrice);
                    cmd.Parameters.AddWithValue("@observation", output.observation);
                    cmd.Parameters.AddWithValue("@userCode", output.userCode);
                    cmd.Parameters.AddWithValue("@employeeCode", output.employeeCode);
                    cmd.Parameters.AddWithValue("@articleCode", output.articleCode);
                    cmd.Parameters.AddWithValue("@inventaryCode", output.inventaryCode);
                    cmd.Parameters.AddWithValue("@code", output.code);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(string outputNumber)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM sw_output WHERE op_output_number = @outputNumber";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@outputNumber", outputNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public DataTable ReportGetById(string outputNumber)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sqlGetById = "SELECT * FROM sw_output WHERE op_output_number = " + outputNumber + "and op_output_number <> '000000'";
          
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
        public DataTable ReportGetAll()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

           // string sqlGetById = "SELECT  sw_category.ca_control_code, sw_subcategory.sc_control_code, sw_article.ar_control_code, sw_article.ar_description, sw_article.ar_measure_unit, sw_inventory.iv_lot,sw_output.op_quantity, sw_output.op_ufv_unit_price, sw_output.op_bs_unit_price, sw_output.op_ufv_total_price, sw_output.op_bs_total_price, sw_output.op_output_number, sw_output.op_date, sw_output.op_hour,sw_output.op_observation, sw_employee.ep_first_name, sw_employee.ep_last_name, sw_employee.ep_names, sw_employee.ep_item, sw_employee.ep_position, sw_employee.ep_area, sw_employee.ep_unity, sw_user.us_first_name, sw_user.us_last_name, sw_user.us_names,sw_user.us_ci, sw_user.us_position FROM sw_output INNER JOIN sw_article ON sw_output.op_ar_code = sw_article.ar_code INNER JOIN sw_subcategory ON sw_article.ar_subcategory = sw_subcategory.sc_code INNER JOIN sw_category ON sw_category.ca_code = sw_subcategory.sc_category_code INNER JOIN sw_employee ON sw_output.op_ep_code = sw_employee.ep_code INNER JOIN sw_user ON sw_output.op_us_code = sw_user.us_code INNER JOIN sw_inventory ON  sw_output.op_iv_code = sw_inventory.iv_code ORDER BY sw_output.op_output_number  ASC";
            string sqlGetById = "SELECT  sw_category.ca_control_code, sw_subcategory.sc_control_code, sw_article.ar_control_code, sw_article.ar_description, sw_article.ar_measure_unit, sw_inventory.iv_lot,sw_output.op_quantity, sw_output.op_ufv_unit_price, sw_output.op_bs_unit_price, sw_output.op_ufv_total_price, sw_output.op_bs_total_price, sw_output.op_output_number, sw_output.op_date, sw_output.op_hour,sw_output.op_observation, sw_employee.ep_first_name, sw_employee.ep_last_name, sw_employee.ep_names, sw_employee.ep_item, sw_employee.ep_position, sw_employee.ep_area, sw_employee.ep_unity, sw_user.us_first_name, sw_user.us_last_name, sw_user.us_names,sw_user.us_ci, sw_user.us_position FROM sw_output INNER JOIN sw_article ON sw_output.op_ar_code = sw_article.ar_code INNER JOIN sw_subcategory ON sw_article.ar_subcategory = sw_subcategory.sc_code INNER JOIN sw_category ON sw_category.ca_code = sw_subcategory.sc_category_code INNER JOIN sw_employee ON sw_output.op_ep_code = sw_employee.ep_code INNER JOIN sw_user ON sw_output.op_us_code = sw_user.us_code INNER JOIN sw_inventory ON  sw_output.op_iv_code = sw_inventory.iv_code  WHERE sw_output.op_output_number <>  '000000' ORDER BY sw_output.op_output_number  ASC";


           
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
        public DataTable ReportGetByEmployee(string outputNumber)
        {
            DataTable dt = new DataTable();
            string sqlGetById = "SELECT  sw_category.ca_control_code, sw_subcategory.sc_control_code, sw_article.ar_control_code, sw_article.ar_description, sw_article.ar_measure_unit, sw_inventory.iv_lot,sw_output.op_quantity, sw_output.op_ufv_unit_price, sw_output.op_bs_unit_price, sw_output.op_ufv_total_price, sw_output.op_bs_total_price, sw_output.op_output_number, sw_output.op_date, sw_output.op_hour,sw_output.op_observation, sw_employee.ep_first_name, sw_employee.ep_last_name, sw_employee.ep_names, sw_employee.ep_item, sw_employee.ep_position, sw_employee.ep_area, sw_employee.ep_unity, sw_user.us_first_name, sw_user.us_last_name, sw_user.us_names,sw_user.us_ci, sw_user.us_position FROM sw_output INNER JOIN sw_article ON sw_output.op_ar_code = sw_article.ar_code INNER JOIN sw_subcategory ON sw_article.ar_subcategory = sw_subcategory.sc_code INNER JOIN sw_category ON sw_category.ca_code = sw_subcategory.sc_category_code INNER JOIN sw_employee ON sw_output.op_ep_code = sw_employee.ep_code INNER JOIN sw_user ON sw_output.op_us_code = sw_user.us_code INNER JOIN sw_inventory ON  sw_output.op_iv_code = sw_inventory.iv_code WHERE sw_output.op_output_number = " + outputNumber + "  ORDER BY sw_output.op_output_number  ASC";

            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx);
                MySqlDataAdapter nda = new MySqlDataAdapter(cmd);
                nda.Fill(dt);
            }
            return dt;
        }
        public DataTable ReportGeneralOutput()
        {
            DataTable dt = new DataTable();
            string sqlGetById = "SELECT c.ca_control_code, s.sc_control_code, a.ar_control_code, a.ar_description, inv.iv_lot, o.op_quantity, o.op_date, o.op_ufv_unit_price, o.op_bs_unit_price, o.op_bs_total_price, o.op_output_number FROM sw_inventory inv INNER JOIN sw_article a ON ( a.ar_code = inv.iv_ar_code ) INNER JOIN sw_subcategory s ON ( s.sc_code = a.ar_subcategory ) INNER JOIN sw_category c ON ( c.ca_code = s.sc_category_code ) INNER JOIN sw_output o ON ( o.op_iv_code = inv.iv_code ) WHERE o.op_output_number <>  '000000' ORDER BY (o.op_iv_code)";

            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx);
                MySqlDataAdapter nda = new MySqlDataAdapter(cmd);
                nda.Fill(dt);
            }
            return dt;
        }

        public DataTable ReportOutputArticle(Int32 codeArticle)
        {
            DataTable dt = new DataTable();
            string sqlGetById = "SELECT c.ca_control_code, s.sc_control_code, a.ar_control_code, a.ar_description, inv.iv_lot, inv.iv_quantity, inv.iv_residue, o.op_quantity, o.op_bs_unit_price, o.op_output_number, o.op_date FROM sw_inventory inv INNER JOIN sw_article a ON ( a.ar_code = inv.iv_ar_code ) INNER JOIN sw_subcategory s ON ( s.sc_code = a.ar_subcategory ) INNER JOIN sw_category c ON ( c.ca_code = s.sc_category_code ) INNER JOIN sw_output o ON ( o.op_iv_code = inv.iv_code ) WHERE (o.op_ar_code = @codeArticle and o.op_output_number <> '000000' )";

            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx);
                cmd.Parameters.AddWithValue("@codeArticle", codeArticle);
                MySqlDataAdapter nda = new MySqlDataAdapter(cmd);
                nda.Fill(dt);
            }
            return dt;
        }*/

    }
}
