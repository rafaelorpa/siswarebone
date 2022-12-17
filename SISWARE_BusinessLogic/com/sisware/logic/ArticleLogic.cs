using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.sisware.bean;
using com.sisware.dao;
using System.Data;

namespace com.sisware.logic
{
    public class ArticleLogic
    {
        //Instanciamos nuestra clase ProductoDal para poder utilizar sus miembros
        private ArticleDao articleDao = new ArticleDao();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Register(EArticle article)
        {
            if (isValid(article))
            {
                if (articleDao.GetByid(article.id) == null)
                {
                    articleDao.Insert(article);
                }
                else
                    articleDao.Update(article);

            }
        }

        public List<EArticle> GetAll()
        {
            return articleDao.GetAll();
        }

        public EArticle GetForId(int idArticle)
        {
            stringBuilder.Clear();

            if (idArticle == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return articleDao.GetByid(idArticle);
            }
            return null;
        }

        public List<EArticle> GetForSubCategory(int idSubCategory)
        {
            stringBuilder.Clear();

            if (idSubCategory == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return articleDao.GetForSubCategory(idSubCategory);
            }
            return null;
        }

        public List<EArticle> search(int idSubCategory, string description)
        {
            return articleDao.search(idSubCategory, description);
        }

        public List<EArticle> searchAll( string description)
        {
            return articleDao.searchAll(description);
        }

        //Enlista todos los Articulos deribados de su categoria y subcategoria
        public List<ESearchArticle> GetAllArticles()
        {
            return articleDao.GetAllArticle();
        }

        public List<ESearchArticle> GetByCodeArticle(int articleCode)
        {
            stringBuilder.Clear();

            if (articleCode == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return articleDao.GetByCodeArticle(articleCode);
            }
            return null;
        }

        public void Delete(int articleCode)
        {
            stringBuilder.Clear();

            if (articleCode == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                articleDao.Delete(articleCode);
            }
        }

        private bool isValid(EArticle article)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(article.description)) stringBuilder.Append("El campo descripcion es obligatorio");
            //if (string.IsNullOrEmpty(article.measureId)) stringBuilder.Append( "El campo unidad de medida es obligatorio");

            return stringBuilder.Length == 0;
        }

        public DataTable reportGeneralArticle()
        {
            return articleDao.ReportGeneralArticle();
        }

        public List<ESearchArticle> SearchArticle(string description)
        {
            return articleDao.SearchArticle(description);
        }
    }
}
