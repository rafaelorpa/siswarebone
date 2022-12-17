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
    public class ArticleDao
    {
        public void Insert(EArticle article)
        {
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();
                const string sqlQuery = "INSERT INTO ss_article (  ar_description, ar_date, ar_user_id, ar_subcategory_id, ar_measure_id) VALUES (  @description, @date, @userId, @subCategoryId, @measureId)";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@description", article.description);
                    cmd.Parameters.AddWithValue("@date", article.date);
                    cmd.Parameters.AddWithValue("@userId", article.userId);
                    cmd.Parameters.AddWithValue("@subCategoryId", article.subCategoryId);
                    cmd.Parameters.AddWithValue("@measureId", article.measureId);                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Devuelve una lista de Articulos ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de Articulos</returns>
        /// <autor>Rafael Ortuno Paredes</autor>
        public List<EArticle> GetAll()
        {
            List<EArticle> articles = new List<EArticle>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT a.ar_id, a.ar_description,a.ar_date,a.ar_user_id,a.ar_subcategory_id,m.me_description FROM ss_article a INNER JOIN ss_measure m ON a.ar_measure_id=m.me_id ORDER BY ar_description ASC;";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    var dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto EArticulos para llenar sus propiedades
                        EArticle articless = new EArticle
                        {
                            //ar_control_code, ar_description, ar_date, ar_us_code, ar_subcategory, ar_measure_unit, ar_iv_code

                            id = Convert.ToInt32(dataReader["ar_id"]),
                            description = Convert.ToString(dataReader["ar_description"]),
                            date = Convert.ToDateTime(dataReader["ar_date"]),
                            userId = Convert.ToInt32(dataReader["ar_user_id"]),
                            subCategoryId = Convert.ToInt32(dataReader["ar_subcategory_id"]),
                            measure = Convert.ToString(dataReader["me_description"]),
                           
                        };
                        //
                        //Insertamos el objeto Articulo dentro de la lista Articulos
                        articles.Add(articless);
                    }
                }
            }
            return articles;
        }

        public List<EArticle> GetForSubCategory( int subcategory)
        {
            List<EArticle> articles = new List<EArticle>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT a.ar_id, a.ar_description,a.ar_date,a.ar_user_id,a.ar_subcategory_id,a.ar_measure_id, m.me_description FROM ss_article a INNER JOIN ss_measure m ON a.ar_measure_id=m.me_id WHERE ar_subcategory_id = @subcategory";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@subcategory", subcategory);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto EArticulos para llenar sus propiedades
                        EArticle articless = new EArticle
                        {
                            //ar_control_code, ar_description, ar_date, ar_us_code, ar_subcategory, ar_measure_unit, ar_iv_code

                            id = Convert.ToInt32(dataReader["ar_id"]),
                            description = Convert.ToString(dataReader["ar_description"]),
                            date = Convert.ToDateTime(dataReader["ar_date"]),
                            userId = Convert.ToInt32(dataReader["ar_user_id"]),
                            subCategoryId = Convert.ToInt32(dataReader["ar_subcategory_id"]),
                            measureId = Convert.ToInt32(dataReader["ar_measure_id"]),
                            measure = Convert.ToString(dataReader["me_description"]),
                        };
                        //
                        //Insertamos el objeto Articulo dentro de la lista Articulos
                        articles.Add(articless);
                    }
                }
            }
            return articles;
        }

        public List<ESearchArticle> GetAllArticle()
        {
            List<ESearchArticle> articles = new List<ESearchArticle>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT a.ar_id, a.ar_description, m.me_description FROM ss_article a INNER JOIN ss_measure m ON a.ar_measure_id=m.me_id ORDER BY a.ar_description ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto EArticulos para llenar sus propiedades
                        ESearchArticle article = new ESearchArticle
                        {
                            //ar_control_code, ar_description, ar_date, ar_us_code, ar_subcategory, ar_measure_unit, ar_iv_code

                            articleId = Convert.ToInt32(dataReader["ar_id"]),
                            articleDescription = Convert.ToString(dataReader["ar_description"]),
                            articleMeasureUnit = Convert.ToString(dataReader["me_description"]),
                           

                        };
                        //
                        //Insertamos el objeto Articulo dentro de la lista Articulos
                        articles.Add(article);
                    }
                }
            }
            return articles;
        }


        public List<ESearchArticle> GetByCodeArticle(int articleId)
        {
            List<ESearchArticle> articles = new List<ESearchArticle>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                const string sqlQuery = "SELECT a.ar_id, a.ar_description, m.me_description FROM ss_article a INNER JOIN ss_measure m ON (a.ar_measure_id=m.me_id)AND(a.ar_id = @articleId) ORDER BY a.ar_description ASC;";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@articleId", articleId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto EArticulos para llenar sus propiedades
                        ESearchArticle article = new ESearchArticle
                        {
                            //ar_control_code, ar_description, ar_date, ar_us_code, ar_subcategory, ar_measure_unit, ar_iv_code

                            articleId = Convert.ToInt32(dataReader["ar_code"]),
                            articleDescription = Convert.ToString(dataReader["ar_description"]),
                            articleMeasureUnit = Convert.ToString(dataReader["me_description"]),



                        };
                        //
                        //Insertamos el objeto Articulo dentro de la lista Articulos
                        articles.Add(article);
                    }
                }
            }
            return articles;
        }


        public List<ESearchArticle> SearchArticle(string description)
        {
            List<ESearchArticle> articles = new List<ESearchArticle>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                string sqlQuery = "SELECT a.ar_id, a.ar_description, m.me_description FROM ss_article a INNER JOIN ss_measure m ON a.ar_measure_id=m.me_id WHERE ar_description LIKE '" + description +"%' ORDER BY a.ar_description ASC";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                  // cmd.Parameters.AddWithValue("@description", description);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto EArticulos para llenar sus propiedades
                        ESearchArticle article = new ESearchArticle
                        {
                            //ar_control_code, ar_description, ar_date, ar_us_code, ar_subcategory, ar_measure_unit, ar_iv_code

                            articleId = Convert.ToInt32(dataReader["ar_id"]),
                            articleDescription = Convert.ToString(dataReader["ar_description"]),
                            articleMeasureUnit = Convert.ToString(dataReader["me_description"]),


                        };
                        //
                        //Insertamos el objeto Articulo dentro de la lista Articulos
                        articles.Add(article);
                    }
                }
            }
            return articles;
        }


        public EArticle GetByid(int articleId)
            {
                using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
                {
                    cnx.Open();

                    const string sqlGetById = "SELECT * FROM ss_article WHERE ar_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sqlGetById, cnx))
                    {
                        cmd.Parameters.AddWithValue("@Id", articleId);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        if (dataReader.Read())
                        {
                            EArticle articless = new EArticle

                            {
                                id = Convert.ToInt32(dataReader["ar_id"]),
                                description = Convert.ToString(dataReader["ar_description"]),
                                date = Convert.ToDateTime(dataReader["ar_date"]),
                                userId = Convert.ToInt32(dataReader["ar_user_id"]),
                                subCategoryId = Convert.ToInt32(dataReader["ar_subcategory_id"]),
                                measureId = Convert.ToInt32(dataReader["ar_measure_id"]),
                            };

                            return articless;
                        }
                    }
                }

                return null;
            }

            public void Update(EArticle article)
            {
                using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
                {
                    cnx.Open();
                    const string sqlQuery =
                        "UPDATE ss_article SET  ar_description = @description, ar_date = @date, ar_user_id = @userId, ar_subcategory_id = @subCategoryId, ar_measure_id  = @measureId WHERE ar_id = @id"; 

                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        cmd.Parameters.AddWithValue("@description", article.description);
                        cmd.Parameters.AddWithValue("@date", article.date);
                        cmd.Parameters.AddWithValue("@userId", article.userId);
                        cmd.Parameters.AddWithValue("@subCategoryId", article.subCategoryId);
                        cmd.Parameters.AddWithValue("@measureId", article.measureId);
                        cmd.Parameters.AddWithValue("@id", article.id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

        //
            public void Delete(int articleId)
            {
                using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
                {
                    cnx.Open();
                    const string sqlQuery = "DELETE FROM ss_article WHERE ar_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        cmd.Parameters.AddWithValue("@id", articleId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public List<EArticle> search(int subcategoryId, string description)
            {
                List<EArticle> articles = new List<EArticle>();
                using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
                {
                    cnx.Open();

                    string sqlQuery = "SELECT a.ar_id, a.ar_description, a.ar_date, a.ar_user_id, a.ar_subcategory_id, m.me_description FROM ss_article a INNER JOIN ss_measure m ON a.ar_measure_id=m.me_id WHERE ar_subcategory_id = @subcategoryId AND ar_description LIKE '" + description +"%'";
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                    {
                        cmd.Parameters.AddWithValue("@subcategoryId", subcategoryId);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        //
                        //Preguntamos si el DataReader fue devuelto con datos
                        while (dataReader.Read())
                        {
                            //
                            //Instanciamos al objeto EArticulos para llenar sus propiedades
                            EArticle articless = new EArticle
                            {
                                //ar_control_code, ar_description, ar_date, ar_us_code, ar_subcategory, ar_measure_unit, ar_iv_code

                                id = Convert.ToInt32(dataReader["ar_id"]),
                                description = Convert.ToString(dataReader["ar_description"]),
                                date = Convert.ToDateTime(dataReader["ar_date"]),
                                userId = Convert.ToInt32(dataReader["ar_user_id"]),
                                subCategoryId = Convert.ToInt32(dataReader["ar_subcategory_id"]),
                                measure = Convert.ToString(dataReader["me_description"]),
                                

                            };
                            //
                            //Insertamos el objeto Articulo dentro de la lista Articulos
                            articles.Add(articless);
                        }
                    }
                }
                return articles;
            }


        public List<EArticle> searchAll( string description)
        {
            List<EArticle> articles = new List<EArticle>();
            using (MySqlConnection cnx = new MySqlConnection(Conexion.LeerCC))
            {
                cnx.Open();

                string sqlQuery = "SELECT a.ar_id, a.ar_description, a.ar_date, a.ar_user_id, a.ar_subcategory_id, m.me_description FROM ss_article a INNER JOIN ss_measure m ON a.ar_measure_id=m.me_id WHERE ar_description LIKE '" + description + "%'";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, cnx))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto EArticulos para llenar sus propiedades
                        EArticle articless = new EArticle
                        {
                            //ar_control_code, ar_description, ar_date, ar_us_code, ar_subcategory, ar_measure_unit, ar_iv_code

                            id = Convert.ToInt32(dataReader["ar_id"]),
                            description = Convert.ToString(dataReader["ar_description"]),
                            date = Convert.ToDateTime(dataReader["ar_date"]),
                            userId = Convert.ToInt32(dataReader["ar_user_id"]),
                            subCategoryId = Convert.ToInt32(dataReader["ar_subcategory_id"]),
                            measure = Convert.ToString(dataReader["me_description"]),


                        };
                        //
                        //Insertamos el objeto Articulo dentro de la lista Articulos
                        articles.Add(articless);
                    }
                }
            }
            return articles;
        }
        public DataTable ReportGeneralArticle()
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                string sqlGetById = "SELECT c.ca_control_code, c.ca_name, s.sc_control_code, s.sc_name, a.ar_control_code, a.ar_description, a.ar_measure_unit FROM sw_article a INNER JOIN sw_subcategory s ON ( s.sc_code = a.ar_subcategory ) INNER JOIN sw_category c ON ( c.ca_code = s.sc_category_code ) ORDER BY (a.ar_code) ";
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

    }
}
