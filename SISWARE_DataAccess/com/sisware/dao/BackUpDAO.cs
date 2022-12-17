using System;
using MySql.Data.MySqlClient;

namespace com.sisware.dao
{
    public class BackUpDAO
    {
        public void Export(string file)
        {
           // string constring = "server=localhost;user=root;pwd=qwerty;database=test;";
            //string file = "C:\\backup.sql";

            using (MySqlConnection conn = new MySqlConnection(Conexion.LeerCC))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(file);
                        conn.Close();
                    }
                }
            }
        }

        public void Import(string file)
        {
           // string constring = "server=localhost;user=root;pwd=qwerty;database=test;";
           // string file = "C:\\backup.sql";

            using (MySqlConnection conn = new MySqlConnection(Conexion.LeerCC))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ImportFromFile(file);
                        conn.Close();
                    }
                }
            }
        }

        public bool TableClean(string tableName)
        {
            try
            {
                string trunk = "SET FOREIGN_KEY_CHECKS=0; TRUNCATE " + tableName;
                using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
                {
                    cnx.Open();
                    using (MySqlCommand cmd = new MySqlCommand(trunk, cnx))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CopyInventoryTable()
        {
            try
            {
                string trunk = "INSERT INTO sw_inventory_temp(iv_code, iv_lot, iv_quantity, iv_ufv_unit_price, iv_ufv_total_price, iv_bs_unit_price, iv_bs_total_price, iv_description, iv_residue,iv_ip_code,  iv_us_code, iv_ar_code, iv_pv_code, iv_ip_bill, iv_date) SELECT sw_inventory.iv_code, sw_inventory.iv_lot, sw_inventory.iv_quantity, sw_inventory.iv_ufv_unit_price, sw_inventory.iv_ufv_total_price, sw_inventory.iv_bs_unit_price, sw_inventory.iv_bs_total_price, sw_inventory.iv_description, sw_inventory.iv_residue,  sw_inventory.iv_ip_code, sw_inventory.iv_us_code,sw_inventory.iv_ar_code, sw_input.ip_pv_code, sw_input.ip_bill, sw_input.ip_date FROM sw_inventory INNER JOIN sw_input ON sw_input.ip_code = sw_inventory.iv_ip_code ";
                using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
                {
                    cnx.Open();
                    using (MySqlCommand cmd = new MySqlCommand(trunk, cnx))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
