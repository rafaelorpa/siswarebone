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
    public class UserDao
    {

        public void Insert(EUser user)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "INSERT INTO ss_user (us_ci, us_first_name, us_last_name, us_names, us_user, us_password, us_trace, us_date, us_role) VALUES (@ci, @firstName, @lastName, @names, @user, @password, @trace, @date, @role)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@ci", user.ci);
                    cmd.Parameters.AddWithValue("@firstName", user.firstName);
                    cmd.Parameters.AddWithValue("@lastName", user.lastName);
                    cmd.Parameters.AddWithValue("@names", user.names);
                    cmd.Parameters.AddWithValue("@user", user.user);
                    cmd.Parameters.AddWithValue("@password", com.snapsoft.util.Segurity_.encrypt(user.password));
                    cmd.Parameters.AddWithValue("@trace", user.trace);
                    cmd.Parameters.AddWithValue("@date", user.date);
                    cmd.Parameters.AddWithValue("@role", user.role);
                    cmd.ExecuteNonQuery();
                }
            }


        }

        /// <summary>
        /// Devuelve una lista de Productos ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de productos</returns>
        /// <autor>Rafael Ortuño Paredes</autor>
        public List<EUser> GetAll()
        {
            List<EUser> users = new List<EUser>();



            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM ss_user ORDER BY us_id  ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {

                    var dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto EUser para llenar sus propiedades
                        EUser user = new EUser
                        {
                            id = Convert.ToInt32(dataReader["us_id"]),
                            ci = Convert.ToString(dataReader["us_ci"]),
                            firstName = Convert.ToString(dataReader["us_first_name"]),
                            lastName = Convert.ToString(dataReader["us_last_name"]),
                            names = Convert.ToString(dataReader["us_names"]),
                            user = Convert.ToString(dataReader["us_user"]),
                            password = com.snapsoft.util.Segurity_.decrypt(Convert.ToString(dataReader["us_password"])),
                            trace = Convert.ToString(dataReader["us_trace"]),
                            date = Convert.ToDateTime(dataReader["us_date"]),
                            role = Convert.ToString(dataReader["us_role"]),
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        users.Add(user);
                    }

                }
            }
            return users;

        }


        public EUser GetByid(int userId)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM ss_user WHERE us_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EUser user = new EUser
                        {
                            id = Convert.ToInt32(dataReader["us_id"]),
                            ci = Convert.ToString(dataReader["us_ci"]),
                            firstName = Convert.ToString(dataReader["us_first_name"]),
                            lastName = Convert.ToString(dataReader["us_last_name"]),
                            names = Convert.ToString(dataReader["us_names"]),
                            user = Convert.ToString(dataReader["us_user"]),
                            password = com.snapsoft.util.Segurity_.decrypt(Convert.ToString(dataReader["us_password"])),
                            trace = Convert.ToString(dataReader["us_trace"]),
                            date = DateTime.Parse(Convert.ToString(dataReader["us_date"])),
                            role = Convert.ToString(dataReader["us_role"]),
                        };

                        return user;
                    }
                }
            }

            return null;
        }

        public void Update(EUser user)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE ss_user SET us_ci = @ci, us_first_name = @firstName, us_last_name =  @lastName, us_names = @names, us_user = @user, us_password = @password, us_trace = @trace, us_date = @date, us_role = @role WHERE us_id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@ci", user.ci);
                    cmd.Parameters.AddWithValue("@firstName", user.firstName);
                    cmd.Parameters.AddWithValue("@lastName", user.lastName);
                    cmd.Parameters.AddWithValue("@names", user.names);
                    cmd.Parameters.AddWithValue("@user", user.user);
                    cmd.Parameters.AddWithValue("@password", com.snapsoft.util.Segurity_.encrypt(user.password));
                    cmd.Parameters.AddWithValue("@trace", user.trace);
                    cmd.Parameters.AddWithValue("@date", user.date);
                    cmd.Parameters.AddWithValue("@role", user.role);
                    cmd.Parameters.AddWithValue("@id", user.id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int userCode)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM ss_user WHERE us_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", userCode);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Procedimiento para obtener el usuario y el password de un Usuario Dado
        public List<EUser> CheckDateUser(string userName, string passwordUser)
        {
            List<EUser> users = new List<EUser>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string query = "SELECT us_id, us_user, us_password FROM ss_user WHERE (us_user=@userName) and (us_password=@passwordUser)";
                using (MySqlCommand cmd = new MySqlCommand(query, cnx))
                {
                    cmd.Parameters.AddWithValue("@userName", userName);
                    //cmd.Parameters.AddWithValue("@userName", com.snapsoft.util.Segurity_.encrypt( userName));
                    //cmd.Parameters.AddWithValue("@passwordUser", passwordUser);
                    cmd.Parameters.AddWithValue("@passwordUser", com.snapsoft.util.Segurity_.encrypt(passwordUser));
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        EUser user = new EUser
                        {
                            id = Convert.ToInt32(dataReader["us_id"]),
                            user = Convert.ToString(dataReader["us_user"]),
                            //user = com.snapsoft.util.Segurity_.decrypt(Convert.ToString(dataReader["us_user"])),
                            //password = Convert.ToString(dataReader["us_password"]),
                            password = com.snapsoft.util.Segurity_.decrypt(Convert.ToString(dataReader["us_password"])),
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        users.Add(user);
                    }
                }
            }

            return users;
        }

        public void UpdatePassword(string password, int userId)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE ss_user SET us_password = @password WHERE us_code = @code";

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@password",com.snapsoft.util.Segurity_.encrypt(password));
                    cmd.Parameters.AddWithValue("@id", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
