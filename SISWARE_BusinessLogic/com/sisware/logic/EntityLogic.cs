using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.sisware.bean;
using com.sisware.dao;

namespace com.sisware.logic
{
    public class EntityLogic
    {
        //Instanciamos nuestra clase ProductoDal para poder utilizar sus miembros
        private EntityDao entityDao = new EntityDao();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Register(EEntity entity)
        {
            if (isValid(entity))
            {
                if (entityDao.GetByid(entity.code) == null)
                {
                    entityDao.Insert(entity);
                }
                else
                    entityDao.Update(entity);

            }
        }

        public List<EEntity> GetAll()
        {
            return entityDao.GetAll();
        }

        public EEntity GetForId(int idProduct)
        {
            stringBuilder.Clear();

            if (idProduct == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return entityDao.GetByid(idProduct);
            }
            return null;
        }

        public void Delete(int entityCode)
        {
            stringBuilder.Clear();

            if (entityCode == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                entityDao.Delete(entityCode);
            }
        }

        private bool isValid(EEntity entity)
        {
            stringBuilder.Clear();
            if (string.IsNullOrEmpty(entity.name)) stringBuilder.Append("El campo Nombre es obligatorio");
            if (string.IsNullOrEmpty(entity.address)) stringBuilder.Append(Environment.NewLine + "El campo Dirección es obligatorio");
            if (string.IsNullOrEmpty(entity.representative)) stringBuilder.Append("El campo Representación es obligatorio");
            if (string.IsNullOrEmpty(entity.zone)) stringBuilder.Append("El campo Zona es obligatorio");
            if (string.IsNullOrEmpty(entity.phone)) stringBuilder.Append("El campo Teléfono es obligatorio");
            if (string.IsNullOrEmpty(entity.logo.ToString())) stringBuilder.Append("El campo Logotipo es obligatorio");
            return stringBuilder.Length == 0;
        }
    }
}
