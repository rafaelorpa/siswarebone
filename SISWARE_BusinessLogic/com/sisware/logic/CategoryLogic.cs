using com.sisware.bean;
using com.sisware.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sisware.logic
{
    public class CategoryLogic
    {
        //Instanciamos nuestra clase CategoryDao para poder utilizar sus miembros
        private CategoryDao categoryDao = new CategoryDao();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Register(ECategory category)
        {
            if (isValid(category))
            {
                if (categoryDao.GetByid(category.id) == null)
                {
                    categoryDao.Insert(category);
                }
                else
                    categoryDao.Update(category);

            }
        }

        public List<ECategory> GetAll()
        {
            return categoryDao.GetAll();
        }

        public List<ECategory> search(string name)
        {
            return categoryDao.search(name);
        }

        public ECategory GetForId(int idCategory)
        {
            stringBuilder.Clear();

            if (idCategory == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return categoryDao.GetByid(idCategory);
            }
            return null;
        }

        public void Delete(int categoryCode )
        {
            stringBuilder.Clear();

            if (categoryCode == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                categoryDao.Delete(categoryCode);
            }
        }

        private bool isValid(ECategory category)
        {
            stringBuilder.Clear();

            //if (string.IsNullOrEmpty(category.controlCode)) stringBuilder.Append("El campo Nombre es obligatorio");
            if (string.IsNullOrEmpty(category.name)) stringBuilder.Append("El campo Nombre es obligatorio");

            return stringBuilder.Length == 0;
        }

        public List<ECategory> GetAllDescription()
        {
            return categoryDao.GetAllDescription();
        }

        public List<ECategory> GetIdByDescription(string name)
        {
              return categoryDao.GetIdByDescription(name);
        }
    }
}
