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
    public class InventoryDao
    {
        public void Insert(EInventory inventory)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "INSERT INTO ss_inventory (iv_code, iv_lot, iv_quantity, iv_description, iv_residue, iv_ar_id, iv_ip_id) VALUES (@code, @lot, @quantity, @description, @residue, @articleId, @inputId)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@code", inventory.code);
                    cmd.Parameters.AddWithValue("@lot", inventory.lot);
                    cmd.Parameters.AddWithValue("@quantity", inventory.quantity);
                    cmd.Parameters.AddWithValue("@description", inventory.description);
                    cmd.Parameters.AddWithValue("@residue", inventory.residue);
                    cmd.Parameters.AddWithValue("@articleId", inventory.articleId);
                    cmd.Parameters.AddWithValue("@inputId", inventory.inputId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Devuelve una lista de Inventario ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de productos</returns>
        /// <autor>Rafel Ortuno Paredes</autor>
        public List<EInventory> GetAll()
        {
            List<EInventory> inventories = new List<EInventory>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM ss_inventory ORDER BY iv_id  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Inventario para llenar sus propiedades
                        EInventory inventory = new EInventory
                        {
                            id = Convert.ToInt32(dataReader["iv_id"]),
                            code = Convert.ToString(dataReader["iv_code"]),
                            lot = Convert.ToInt32(dataReader["iv_lot"]),
                            quantity = Convert.ToDouble(dataReader["iv_quantity"]),
                            description = Convert.ToString(dataReader["iv_description"]),
                            residue = Convert.ToDouble(dataReader["iv_residue"]),                           
                            articleId = Convert.ToInt32(dataReader["iv_ar_id"]),
                            inputId = Convert.ToInt32(dataReader["iv_ip_id"])
                        };
                        //
                        //Insertamos el objeto Inventario dentro de la lista Inventarios
                        inventories.Add(inventory);
                    }
                }
            }
            return inventories;
        }

        public EInventory GetByid(int inventoryId)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM ss_inventory WHERE iv_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", inventoryId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EInventory inventory = new EInventory
                        {
                            id = Convert.ToInt32(dataReader["iv_id"]),
                            code = Convert.ToString(dataReader["iv_code"]),
                            lot = Convert.ToInt32(dataReader["iv_lot"]),
                            quantity = Convert.ToDouble(dataReader["iv_quantity"]),
                            description = Convert.ToString(dataReader["iv_description"]),
                            residue = Convert.ToDouble(dataReader["iv_residue"]),
                            articleId = Convert.ToInt32(dataReader["iv_ar_id"]),
                            inputId = Convert.ToInt32(dataReader["iv_ip_id"])
                        };
                        return inventory;
                    }
                }
            }
            return null;
        }

        public void Update(EInventory inventory)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE ss_inventory SET iv_code=@code, iv_lot = @lot, iv_quantity = @quantity, iv_description = @description, iv_residue = @residue, iv_ar_id = @articleId, iv_ip_id=@inputId WHERE iv_id= @id";

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@code", inventory.code);
                    cmd.Parameters.AddWithValue("@lot", inventory.lot);
                    cmd.Parameters.AddWithValue("@quantity", inventory.quantity);
                    cmd.Parameters.AddWithValue("@description", inventory.description);
                    cmd.Parameters.AddWithValue("@residue", inventory.residue);
                    cmd.Parameters.AddWithValue("@articleCode", inventory.articleId);
                    cmd.Parameters.AddWithValue("@inputCode", inventory.inputId);
                    cmd.Parameters.AddWithValue("@id", inventory.id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateResidue(int inventoryId, double residue)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE sw_inventory SET  iv_residue = @residue WHERE iv_id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@residue", residue);
                    cmd.Parameters.AddWithValue("@id", inventoryId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int inventoryId)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM ss_inventory WHERE iv_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", inventoryId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EInventory> GetByArticle(int articleId)
        {
            List<EInventory> inventories = new List<EInventory>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM ss_inventory where iv_ar_id = @articleId ORDER BY iv_lot";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {

                    cmd.Parameters.AddWithValue("@articleId", articleId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Inventario para llenar sus propiedades
                        EInventory inventory = new EInventory
                        {
                            id = Convert.ToInt32(dataReader["iv_id"]),
                            code = Convert.ToString(dataReader["iv_code"]),
                            lot = Convert.ToInt32(dataReader["iv_lot"]),
                            quantity = Convert.ToDouble(dataReader["iv_quantity"]),
                            description = Convert.ToString(dataReader["iv_description"]),
                            residue = Convert.ToDouble(dataReader["iv_residue"]),
                            articleId = Convert.ToInt32(dataReader["iv_ar_id"]),
                            inputId = Convert.ToInt32(dataReader["iv_ip_id"])
                        };
                        //
                        //Insertamos el objeto Inventario dentro de la lista Inventarios
                        inventories.Add(inventory);
                    }
                }
            }
            return inventories;
        }

        public List<EInventory> GetByArticleInput(int articleId, int inputId)
        {
            List<EInventory> inventories = new List<EInventory>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM ss_inventory where (iv_ar_id = @articleId) and (iv_ip_id=@inputId) ORDER BY iv_lot";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {

                    cmd.Parameters.AddWithValue("@articleId", articleId);
                    cmd.Parameters.AddWithValue("@inputId", inputId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Inventario para llenar sus propiedades
                        EInventory inventory = new EInventory
                        {
                            id = Convert.ToInt32(dataReader["iv_id"]),
                            code = Convert.ToString(dataReader["iv_code"]),
                            lot = Convert.ToInt32(dataReader["iv_lot"]),
                            quantity = Convert.ToDouble(dataReader["iv_quantity"]),
                            description = Convert.ToString(dataReader["iv_description"]),
                            residue = Convert.ToDouble(dataReader["iv_residue"]),
                            articleId = Convert.ToInt32(dataReader["iv_ar_id"]),
                            inputId = Convert.ToInt32(dataReader["iv_ip_id"])
                        };
                        //
                        //Insertamos el objeto Inventario dentro de la lista Inventarios
                        inventories.Add(inventory);
                    }
                }
            }
            return inventories;
        }

        public List<EInventory> GetByInputCode(int inputId)
        {
            List<EInventory> inventories = new List<EInventory>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM ss_inventory where iv_ip_id = @inputId ORDER BY iv_lot";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {

                    cmd.Parameters.AddWithValue("@inputId", inputId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Inventario para llenar sus propiedades
                        EInventory inventory = new EInventory
                        {
                            id = Convert.ToInt32(dataReader["iv_id"]),
                            code = Convert.ToString(dataReader["iv_code"]),
                            lot = Convert.ToInt32(dataReader["iv_lot"]),
                            quantity = Convert.ToDouble(dataReader["iv_quantity"]),
                            description = Convert.ToString(dataReader["iv_description"]),
                            residue = Convert.ToDouble(dataReader["iv_residue"]),
                            articleId = Convert.ToInt32(dataReader["iv_ar_id"]),
                            inputId = Convert.ToInt32(dataReader["iv_ip_id"])
                        };
                        //
                        //Insertamos el objeto Inventario dentro de la lista Inventarios
                        inventories.Add(inventory);
                    }
                }
            }
            return inventories;
        }

        public List<EInventory> GetLot(int articleId)
        {
            List<EInventory> inventories = new List<EInventory>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT iv_id, iv_lot FROM ss_inventory WHERE iv_ar_id= @articleId ORDER BY iv_lot DESC LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {

                    cmd.Parameters.AddWithValue("@articleId", articleId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Inventario para llenar sus propiedades
                        EInventory inventory = new EInventory
                        {
                            id = Convert.ToInt32(dataReader["iv_id"]),
                            lot = Convert.ToInt32(dataReader["iv_lot"]),

                        };
                        //
                        //Insertamos el objeto Inventario dentro de la lista Inventarios
                        inventories.Add(inventory);
                    }
                }
            }
            return inventories;
        }

        public List<EInventory> GetByCode(int articleId, int inputId)
        {
            List<EInventory> inventories = new List<EInventory>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT iv_id FROM ss_inventory WHERE (iv_ar_id= @articleId)and(iv_ip_id= @inputId) ORDER BY iv_id DESC LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {

                    cmd.Parameters.AddWithValue("@articleId", articleId);
                    cmd.Parameters.AddWithValue("@inputId", inputId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Inventario para llenar sus propiedades
                        EInventory inventory = new EInventory
                        {
                            id = Convert.ToInt32(dataReader["iv_id"]),

                        };
                        //
                        //Insertamos el objeto Inventario dentro de la lista Inventarios
                        inventories.Add(inventory);
                    }
                }
            }
            return inventories;
        }

        public DataTable ReportGetGeneralConsumption(string dateIni, string dateEnd)
        {
            DataTable dt = new DataTable();

            string sqlGetById = "SELECT inv.iv_id, a.ar_description, inv.iv_lot, inv.iv_quantity, inv.iv_residue, i.ip_date, i.ip_quantity, SUM( o.op_quantity ) AS o_quantity FROM ss_category c INNER JOIN ss_subcategory s ON ( s.sc_category_id = c.ca_id ) INNER JOIN ss_article a ON ( a.ar_subcategory_id = s.sc_id ) INNER JOIN ss_inventory inv ON ( inv.iv_ar_id = a.ar_id ) INNER JOIN ss_input i ON ( i.ip_id = inv.iv_ip_id ) INNER JOIN ss_output o ON ( o.op_iv_id = inv.iv_id ) WHERE (i.ip_date >= @dateIni) AND ( i.ip_date <= @dateEnd ) GROUP BY a.ar_id, inv.iv_lot";
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx);
                cmd.Parameters.AddWithValue("@dateIni", dateIni);
                cmd.Parameters.AddWithValue("@dateEnd", dateEnd);
                MySqlDataAdapter nda = new MySqlDataAdapter(cmd);
                nda.Fill(dt);
            }
            return dt;
        }

        public DataTable ReportGeneralInventory()
        {
            DataTable dt = new DataTable();

            string sqlGetById = "SELECT c.ca_id, c.ca_name, a.ar_id, i.iv_code, a.ar_description, m.me_description FROM ss_inventory i INNER JOIN ss_article a ON ( a.ar_id = i.iv_ar_id ) INNER JOIN ss_measure m ON (m.me_id = a.ar_measure_id) INNER JOIN ss_subcategory s ON ( s.sc_id = a.ar_subcategory_id ) INNER JOIN ss_category c ON ( c.ca_id = s.sc_category_id) GROUP BY a.ar_description ORDER BY s.sc_name ASC";
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx);
                /*cmd.Parameters.AddWithValue("@dateIni", dateIni);
                cmd.Parameters.AddWithValue("@dateEnd", dateEnd);*/
                MySqlDataAdapter nda = new MySqlDataAdapter(cmd);

                nda.Fill(dt);
            }
            return dt;
        }

        public DataTable ReportGeneralInventory1(Int32 codeId, string dateIni, string dateEnd)
        {
            DataTable dt = new DataTable();

            string sqlGetById = "SELECT SUM(i.iv_quantity) AS iv_quantitys, SUM(i.iv_residue) AS iv_residues FROM ss_input ip INNER JOIN ss_inventory i ON (ip.ip_id = i.iv_ip_id) WHERE i.iv_ar_id= @codeId AND (ip.ip_date BETWEEN @dateIni AND @dateEnd)";
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx);
                cmd.Parameters.AddWithValue("@codeId", codeId);
                cmd.Parameters.AddWithValue("@dateIni", dateIni);
                cmd.Parameters.AddWithValue("@dateEnd", dateEnd);
                MySqlDataAdapter nda = new MySqlDataAdapter(cmd);

                nda.Fill(dt);
            }
            return dt;
        }

        public DataTable ReportGeneralInventory2(Int32 articleId,string dateIni, string dateEnd)
        {
            DataTable dt = new DataTable();

            string sqlGetById = "SELECT SUM(op.op_quantity) AS op_quantitys FROM ss_output op WHERE (op.op_ar_id= @articleID) AND (op.op_date BETWEEN @dateIni AND @dateEnd)";
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx);
                cmd.Parameters.AddWithValue("@articleId", articleId);
                cmd.Parameters.AddWithValue("@dateIni", dateIni);
                cmd.Parameters.AddWithValue("@dateEnd", dateEnd);
                MySqlDataAdapter nda = new MySqlDataAdapter(cmd);

                nda.Fill(dt);
            }
            return dt;
        }

        public DataTable ReportGeneralInventory3(Int32 articleId)
        {
            DataTable dt = new DataTable();

            string sqlGetById = "SELECT ip.ip_date FROM ss_input ip WHERE ip.ip_ar_id= @articleId GROUP BY ip.ip_ar_id";
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

        public DataTable ReportKardex(Int32 articleId)
        {
            DataTable dt = new DataTable();

            string sqlGetById = "SELECT inv.iv_id, a.ar_description, inv.iv_lot, inv.iv_quantity, inv.iv_residue, i.ip_date, i.ip_hour, i.ip_quantity as i_quantity, i.ip_observacion, o.op_date, o.op_hour_entry, o.op_quantity AS o_quantity, o. op_observation FROM ss_category c INNER JOIN ss_subcategory s ON ( s.sc_category_id = c.ca_id ) INNER JOIN ss_article a ON ( a.ar_subcategory_id = s.sc_id ) INNER JOIN ss_inventory inv ON ( inv.iv_ar_id = a.ar_id ) INNER JOIN ss_input i ON ( i.ip_id = inv.iv_ip_id ) INNER JOIN ss_output o ON ( o.op_iv_id = inv.iv_id ) WHERE ( a.ar_id = @articleId) ORDER BY i.ip_date, o.op_date, inv.iv_lot;";
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

        public DataTable ReportKardex1(Int32 codeArticle)
        {
            DataTable dt = new DataTable();

            string sqlGetById = "SELECT c.ca_control_code, s.sc_control_code, a.ar_control_code, a.ar_description FROM sw_category c INNER JOIN sw_subcategory s ON ( s.sc_category_code = c.ca_code ) INNER JOIN sw_article a ON ( a.ar_subcategory = s.sc_code ) WHERE (a.ar_code = @codeArticle) ";
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx);
                cmd.Parameters.AddWithValue("@codeArticle", codeArticle);
                MySqlDataAdapter nda = new MySqlDataAdapter(cmd);

                nda.Fill(dt);
            }
            return dt;
        }

        public DataTable ReportKardexInput(Int32 codeArticle)
        {
            DataTable dt = new DataTable();

            string sqlGetById = "SELECT i.ip_date, i.ip_hour, i.ip_quantity AS i_quantity, i.ip_observation, inv.iv_lot, inv.iv_quantity,  inv.iv_ufv_unit_price, inv.iv_bs_unit_price, i.ip_input_number  FROM sw_input i INNER JOIN sw_inventory inv ON ( i.ip_code = inv.iv_ip_code ) WHERE (i.ip_ar_code = @codeArticle) ORDER BY inv.iv_lot, i.ip_date";
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx);
                cmd.Parameters.AddWithValue("@codeArticle", codeArticle);
                MySqlDataAdapter nda = new MySqlDataAdapter(cmd);

                nda.Fill(dt);
            }
            return dt;
        }

        public DataTable ReportKardexOutput(Int32 codeArticle)
        {
            DataTable dt = new DataTable();

            string sqlGetById = "SELECT o.op_date, o.op_hour, o.op_quantity, o.op_observation, inv.iv_lot, inv.iv_quantity, inv.iv_ufv_unit_price, inv.iv_bs_unit_price, o. op_output_number  FROM sw_output o INNER JOIN sw_inventory inv ON ( o.op_iv_code = inv.iv_code )  WHERE (o.op_ar_code = @codeArticle) ORDER BY inv.iv_lot, o.op_date";
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx);
                cmd.Parameters.AddWithValue("@codeArticle", codeArticle);
                MySqlDataAdapter nda = new MySqlDataAdapter(cmd);

                nda.Fill(dt);
            }
            return dt;
        }

       

        public DataTable ReportGeneralKardex()
        {
            DataTable dt = new DataTable();

            string sqlGetById = "SELECT c.ca_control_code, s.sc_control_code, a.ar_control_code, a.ar_description, inv.iv_lot, inv.iv_ufv_unit_price, inv.iv_bs_unit_price, inv.iv_quantity, inv.iv_residue, inv.iv_bs_total_price, i.ip_date, i.ip_quantity as i_quantity, SUM( o.op_quantity ) AS o_quantity FROM sw_category c INNER JOIN sw_subcategory s ON ( s.sc_category_code = c.ca_code ) INNER JOIN sw_article a ON ( a.ar_subcategory = s.sc_code ) INNER JOIN sw_inventory inv ON ( inv.iv_ar_code = a.ar_code ) INNER JOIN sw_input i ON ( i.ip_code = inv.iv_ip_code ) INNER JOIN sw_output o ON ( o.op_iv_code = inv.iv_code ) GROUP BY a.ar_code, inv.iv_lot ORDER BY a.ar_description , inv.iv_lot";
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx);
                //cmd.Parameters.AddWithValue("@codeSubcategory", codeSubcategory);
                MySqlDataAdapter nda = new MySqlDataAdapter(cmd);

                nda.Fill(dt);
            }
            return dt;
        }

         public EInventory getLastId()
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT max(iv_id) as iv_id  FROM ss_inventory";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EInventory inventory = new EInventory
                        {
                            id = Convert.ToInt32(dataReader["iv_id"])
                        };
                        return inventory;
                    }
                }
            }
            return null;
        }


        

    }
}
