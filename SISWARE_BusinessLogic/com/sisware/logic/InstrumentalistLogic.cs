using com.sisware.bean;
using com.sisware.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sisware.logic
{
    public class InstrumentalistLogic
    {
        //Instanciamos nuestra clase ProductoDal para poder utilizar sus miembros
        private InstrumentalistDao instrumentalistDao = new InstrumentalistDao();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Register(EInstrumentalist instrumentalist)
        {
            if (isValid(instrumentalist))
            {
                if (instrumentalistDao.GetByid(instrumentalist.id) == null)
                {
                    instrumentalistDao.Insert(instrumentalist);
                }
                else
                    instrumentalistDao.Update(instrumentalist);

            }
        }

        public List<EInstrumentalist> GetAll()
        {
            return instrumentalistDao.GetAll();
        }

        /*public List<EInstrumentalist> SearchForLastName(string lastName)
        {
            return employeeDao.SearchForLastName(lastName);
        }*/

        public List<EInstrumentalist> SearchForFirstName(string fistName)
        {
            return instrumentalistDao.SearchForFirstName(fistName);
        }

        public List<EInstrumentalist> SearchForName(string name)
        {
            return instrumentalistDao.SearchForName(name);
        }

        public EInstrumentalist GetForId(int instrumentalistId)
        {
            stringBuilder.Clear();

            if (instrumentalistId == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return instrumentalistDao.GetByid(instrumentalistId);
            }
            return null;
        }

        public void Delete(int instrumentalistId)
        {
            stringBuilder.Clear();

            if (instrumentalistId == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                instrumentalistDao.Delete(instrumentalistId);
            }
        }

        private bool isValid(EInstrumentalist instrumentalist)
        {
            stringBuilder.Clear();

            if (Convert.ToInt32(instrumentalist.ci) <= 0) stringBuilder.Append( "El campo CI es obligatorio");
            if (string.IsNullOrEmpty(instrumentalist.name)) stringBuilder.Append(Environment.NewLine +"El campo Nombre es obligatorio");
            if (string.IsNullOrEmpty(instrumentalist.surname)) stringBuilder.Append(Environment.NewLine + "El campo Apellidos es obligatorio");
            if (string.IsNullOrEmpty(instrumentalist.city)) stringBuilder.Append(Environment.NewLine + "El campo Ciudad es obligatorio");
            if (string.IsNullOrEmpty(instrumentalist.address)) stringBuilder.Append(Environment.NewLine + "El campo Direccion es obligatorio");
            if (string.IsNullOrEmpty(instrumentalist.cell)) stringBuilder.Append(Environment.NewLine + "El campo Celular es obligatorio");
            if (string.IsNullOrEmpty(instrumentalist.email)) stringBuilder.Append(Environment.NewLine + "el campo email es obligatorio");

            return stringBuilder.Length == 0;
        }
    }
}
