using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.sisware.bean;
using com.sisware.dao;

namespace com.sisware.logic
{
    public class ProviderLogic
    {
        //Instanciamos nuestra clase ProductoDal para poder utilizar sus miembros
        private ProviderDao providerDao = new ProviderDao();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Register(EProvider provider)
        {
            if (isValid(provider))
            {
                if (providerDao.GetByid(provider.id) == null)
                {
                    providerDao.Insert(provider);
                }
                else
                    providerDao.Update(provider);
            }
        }

        public List<EProvider> GetAll()
        {
            return providerDao.GetAll();
        }

        public List<EProvider> Search(string name)
        {
            return providerDao.Search(name);
        }



        public EProvider GetForId(int idProvider)
        {
            stringBuilder.Clear();

            if (idProvider == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return providerDao.GetByid(idProvider);
            }
            return null;
        }

        public void Delete(int providerCode)
        {
            stringBuilder.Clear();

            if (providerCode == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                providerDao.Delete(providerCode);
            }
        }

        private bool isValid(EProvider provider)
        {
            stringBuilder.Clear();
            if (string.IsNullOrEmpty(provider.nit)) stringBuilder.Append(Environment.NewLine + "El campo Segundo Apellido es obligatorio");
            if (string.IsNullOrEmpty(provider.name)) stringBuilder.Append(Environment.NewLine + "El campo Nombres es obligatorio");
            return stringBuilder.Length == 0;
        }

        public List<EProvider> GetByCode(int idProvider)
        {
            stringBuilder.Clear();

            if (idProvider == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return providerDao.GetByCode(idProvider);
            }
            return null;
        }
    }
}
