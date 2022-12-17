using com.sisware.bean;
using com.sisware.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace com.sisware.logic
{
    public class InputLogic
    {
        //Instanciamos nuestra clase EntradaDao para poder utilizar sus miembros
        private InputDao inputDao = new InputDao();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Register(EInput input)
        {
            if (isValid(input))
            {
                if (inputDao.GetByid(input.id) == null)
                {
                    inputDao.Insert(input);
                }
                else
                    inputDao.Update(input);

            }
        }

        public List<EInput> GetAll()
        {
            return inputDao.GetAll();
        }


        public List<EInput> Search(string name)
        {
            return inputDao.Search(name);
        }

        public List<EInput> GetIdNumberId()
        {
            return inputDao.GetIdNumberId();
        }

        public List<EInput> GetNumberInput()
        {
            return inputDao.GetNumberInput();
        }

        public List<EInput> GetByNumberInput(string numberInput)
        {
            return inputDao.GetByNumberInput(numberInput);
        }

        public List<EInput> GetLastDateInput()
        {
            return inputDao.GetLastDateInput();
        }

        public EInput GetForId(int idInput)
        {
            stringBuilder.Clear();

            if (idInput == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return inputDao.GetByid(idInput);
            }
            return null;
        }

        public void Delete(string inputNumber)
        {

                inputDao.Delete(inputNumber);
        }

        private bool isValid(EInput input)
        {
            stringBuilder.Clear();

            //if (input.hour <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");
            if (string.IsNullOrEmpty(input.hour)) stringBuilder.Append("El campo Hora es obligatorio");
            if (string.IsNullOrEmpty(input.inputNumber)) stringBuilder.Append("No se ha generado el numero de Entrada, cierre y vuelva a abrir");
            if (input.quantity <= 0) stringBuilder.Append(Environment.NewLine + "El campo Cantidad es obligatorio");
            //if (input.bill <= 0) stringBuilder.Append(Environment.NewLine + "El campo cuenta es obligatorio");

            

            return stringBuilder.Length == 0;
        }

        public List<EInput> GetCodeInput()
        {
            return inputDao.GetCodeInput();
        }

        public DataTable reportGetByInputNumber(string inputNumber)
        {
            return inputDao.ReportGetByNumberInput(inputNumber);
        }

        public DataTable reportGeneralInput()
        {
            return inputDao.ReportGeneralInput();
        }

        public DataTable ReportInputArticle(Int32 codeArticle)
        {
            return inputDao.ReportInputArticle(codeArticle);
        }
    }


}
