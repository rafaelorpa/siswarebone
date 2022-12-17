using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.sisware.bean;
using com.sisware.dao;

namespace com.sisware.logic
{
    public class SubCategoryLogic
    {
        //Instanciamos nuestra clase CategoryDao para poder utilizar sus miembros
        private SubCategoryDao subCategoryDao = new SubCategoryDao();
        //subCategoryDao
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Register(ESubCategory subCategory)
        {
            if (isValid(subCategory))
            {
                if (subCategoryDao.GetByid(subCategory.id) == null)
                {
                    subCategoryDao.Insert(subCategory);
                }
                else
                    subCategoryDao.Update(subCategory);
            }
        }

        public List<ESubCategory> GetAll()
        {
            return subCategoryDao.GetAll();
        }

        /*public List<ESubCategory> SearchToControlCode(string digitoalpha, int code_Category)
        {
            //return subCategoryDao.SearchToControlCode(digitoalpha, code_Category);
        }*/

        public ESubCategory GetForId(int idCategory)
        {
            stringBuilder.Clear();

            if (idCategory == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return subCategoryDao.GetByid(idCategory);
            }
            return null;
        }

        public List<ESubCategory> GetForCategory(int idCategory)
        {
            stringBuilder.Clear();

            if (idCategory == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return subCategoryDao.GetByCategory(idCategory);
            }
            return null;
        }

        public List<ESubCategory> search(int idCategory, string name)
        {
            stringBuilder.Clear();

            if (stringBuilder.Length == 0)
            {
                return subCategoryDao.search(idCategory, name);
            }
            return null;
        }

        public List<ESubCategory> searchAll( string name)
        {
            stringBuilder.Clear();

            if (stringBuilder.Length == 0)
            {
                return subCategoryDao.searchAll(name);
            }
            return null;
        }

        public void Delete(int categoryCode)
        {
            stringBuilder.Clear();

            if (categoryCode == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                subCategoryDao.Delete(categoryCode);
            }
        }

        private bool isValid(ESubCategory subCategory)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(subCategory.name)) stringBuilder.Append("El campo Nombre es obligatorio");

            return stringBuilder.Length == 0;
        }

        public List<ESubCategory> GetIdByDescription(string name)
        {
            
             return subCategoryDao.GetIdByDescription(name);

        }

    }
}
