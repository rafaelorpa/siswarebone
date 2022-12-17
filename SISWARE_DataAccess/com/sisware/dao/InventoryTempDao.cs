using com.sisware.bean;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;

namespace com.sisware.dao
{
    public class InventoryTempDao
    {
        public void Insert(EInventoryTemp inventory)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "INSERT INTO sw_inventory_temp (iv_lot, iv_quantity, iv_ufv_unit_price, iv_ufv_total_price, iv_bs_unit_price, iv_bs_total_price, iv_description, iv_residue,  iv_us_code, iv_ar_code, iv_ip_code, iv_date) VALUES (@lot, @quantity, @ufvUnitPrice, @ufvTotalPrice, @bsUnitPrice, @bsTotalPrice, @description, @residue, @userCode, @articleCode, @inputCode, @date)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@lot", inventory.lot);
                    cmd.Parameters.AddWithValue("@quantity", inventory.quantity);
                    cmd.Parameters.AddWithValue("@ufvUnitPrice", inventory.ufvUnitPrice);
                    cmd.Parameters.AddWithValue("@ufvTotalPrice", inventory.ufvTotalPrice);
                    cmd.Parameters.AddWithValue("@bsUnitPrice", inventory.bsUnitPrice);
                    cmd.Parameters.AddWithValue("@bsTotalPrice", inventory.bsTotalPrice);
                    cmd.Parameters.AddWithValue("@description", inventory.description);
                    cmd.Parameters.AddWithValue("@residue", inventory.residue);
                    cmd.Parameters.AddWithValue("@userCode", inventory.userCode);
                    cmd.Parameters.AddWithValue("@articleCode", inventory.articleCode);
                    cmd.Parameters.AddWithValue("@inputCode", inventory.inputCode);
                    cmd.Parameters.AddWithValue("@date", inventory.date);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Devuelve una lista de Inventario ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de productos</returns>
        /// <autor>Rafel Ortuno Paredes</autor>
        public List<EInventoryTemp> GetAll()
        {
            List<EInventoryTemp> inventories = new List<EInventoryTemp>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM sw_inventory_temp ORDER BY iv_code  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Inventario para llenar sus propiedades
                        EInventoryTemp inventory = new EInventoryTemp
                        {
                            code = Convert.ToInt32(dataReader["iv_code"]),
                            lot = Convert.ToInt32(dataReader["iv_lot"]),
                            quantity = Convert.ToDouble(dataReader["iv_quantity"]),
                            ufvUnitPrice = Convert.ToDouble(dataReader["iv_ufv_unit_price"]),
                            ufvTotalPrice = Convert.ToDouble(dataReader["iv_ufv_total_price"]),
                            bsUnitPrice = Convert.ToDouble(dataReader["iv_bs_unit_price"]),
                            bsTotalPrice = Convert.ToDouble(dataReader["iv_bs_total_price"]),
                            description = Convert.ToString(dataReader["iv_description"]),
                            residue = Convert.ToDouble(dataReader["iv_residue"]),
                            userCode = Convert.ToInt32(dataReader["iv_us_code"]),
                            articleCode = Convert.ToInt32(dataReader["iv_ar_code"]),
                            inputCode = Convert.ToInt32(dataReader["iv_ip_code"]),
                            providerCode = Convert.ToInt32(dataReader["iv_pv_code"]),
                            inputBill = Convert.ToInt32(dataReader["iv_ip_bill"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["iv_date"]))
                        };
                        //
                        //Insertamos el objeto Inventario dentro de la lista Inventarios
                        inventories.Add(inventory);
                    }
                }
            }
            return inventories;
        }

        public void Update(EInventoryTemp inventory)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE sw_inventory_temp SET iv_lot = @lot, iv_quantity = @quantity, iv_ufv_unit_price =  @ufvUnitPrice, iv_ufv_total_price = @ufvTotalPrice, iv_bs_unit_price = @bsUnitPrice, iv_bs_total_price = @bsTotalPrice, iv_description = @description, iv_residue = @residue, iv_us_code = @userCode, iv_ar_code = @articleCode, iv_ip_code=@inputCode, iv_pv_code = @providerCode, iv_ip_bill = @inputBill, iv_date= @date WHERE iv_code = @code";

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@lot", inventory.lot);
                    cmd.Parameters.AddWithValue("@quantity", inventory.quantity);
                    cmd.Parameters.AddWithValue("@ufvUnitPrice", inventory.ufvUnitPrice);
                    cmd.Parameters.AddWithValue("@ufvTotalPrice", inventory.ufvTotalPrice);
                    cmd.Parameters.AddWithValue("@bsUnitPrice", inventory.bsUnitPrice);
                    cmd.Parameters.AddWithValue("@bsTotalPrice", inventory.bsTotalPrice);
                    cmd.Parameters.AddWithValue("@description", inventory.description);
                    cmd.Parameters.AddWithValue("@residue", inventory.residue);
                    cmd.Parameters.AddWithValue("@usercode", inventory.userCode);
                    cmd.Parameters.AddWithValue("@articleCode", inventory.articleCode);
                    cmd.Parameters.AddWithValue("@inputCode", inventory.inputCode);
                    cmd.Parameters.AddWithValue("@providerCode", inventory.providerCode);
                    cmd.Parameters.AddWithValue("@inputBill", inventory.inputBill);
                    cmd.Parameters.AddWithValue("@date", inventory.date);

                    cmd.Parameters.AddWithValue("@code", inventory.code);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int inventoryCode)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM sw_inventory_temp WHERE iv_code = @code";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@code", inventoryCode);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public EInventoryTemp GetByid(int inventoryCode)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM sw_inventory WHERE iv_code = @code";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@code", inventoryCode);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EInventoryTemp inventory = new EInventoryTemp
                        {
                            code = Convert.ToInt32(dataReader["iv_code"]),
                            lot = Convert.ToInt32(dataReader["iv_lot"]),
                            quantity = Convert.ToDouble(dataReader["iv_quantity"]),
                            ufvUnitPrice = Convert.ToDouble(dataReader["iv_ufv_unit_price"]),
                            ufvTotalPrice = Convert.ToDouble(dataReader["iv_ufv_total_price"]),
                            bsUnitPrice = Convert.ToDouble(dataReader["iv_bs_unit_price"]),
                            bsTotalPrice = Convert.ToDouble(dataReader["iv_bs_total_price"]),
                            description = Convert.ToString(dataReader["iv_description"]),
                            residue = Convert.ToDouble(dataReader["iv_residue"]),
                            userCode = Convert.ToInt32(dataReader["iv_us_code"]),
                            articleCode = Convert.ToInt32(dataReader["iv_ar_code"]),
                            inputCode = Convert.ToInt32(dataReader["iv_ip_code"])
                        };
                        return inventory;
                    }
                }
            }
            return null;
        }

    }
}
