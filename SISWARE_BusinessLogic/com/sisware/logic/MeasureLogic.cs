using com.sisware.bean;
using com.sisware.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sisware.logic
{
    public class MeasureLogic
    {
        private MeasureDao measureDao = new MeasureDao();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Register(EMeasure measure)
        {
            if (isValid(measure))
            {
                if (measureDao.GetByid(measure.id) == null)
                {
                    measureDao.Insert(measure);
                }
                else
                    measureDao.Update(measure);

            }
        }

        public List<EMeasure> GetAll()
        {
            return measureDao.GetAll();
        }

        /* public List<ERole> search(string name)
         {
             return roleDao.search(name);
         }*/

        public EMeasure GetForId(int measureId)
        {
            stringBuilder.Clear();

            if (measureId == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return measureDao.GetByid(measureId);
            }
            return null;
        }

        public EMeasure GetForId1(string description)
        {
            stringBuilder.Clear();

            if (description == "") stringBuilder.Append("Por favor proporcione una descripcion valida");

            if (stringBuilder.Length == 0)
            {
                return measureDao.GetByid1(description);
            }
            return null;
        }

        public void Delete(int measureId)
        {
            stringBuilder.Clear();

            if (measureId == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                measureDao.Delete(measureId);
            }
        }

        private bool isValid(EMeasure measure)
        {
            stringBuilder.Clear();

            //if (string.IsNullOrEmpty(category.controlCode)) stringBuilder.Append("El campo Nombre es obligatorio");
            if (string.IsNullOrEmpty(measure.description)) stringBuilder.Append("El campo Nombre es obligatorio");

            return stringBuilder.Length == 0;
        }

        public List<EMeasure> GetAllDescription()
        {
            return measureDao.GetAllDescription();
        }

        /*public List<EMeasure> GetIdByDescription(string name)
        {
            return roleDao.GetIdByDescription(name);
        }*/
    }
}
