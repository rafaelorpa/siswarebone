using com.sisware.bean;
using com.sisware.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace com.sisware.logic
{
    public class OutputLogic
    {/*
        //Instanciamos nuestra clase SalidaDao para poder utilizar sus miembros
        private OutputDao outputDao = new OutputDao();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Register(EOutput output)
        {
            if (isValid(output))
            {
                if (outputDao.GetByid(output.id) == null)
                {
                    outputDao.Insert(output);
                }
                else
                    outputDao.Update(output);

            }
        }

        public List<EOutput> GetAll()
        {
            return outputDao.GetAll();
        }

        public List<EOutput> Search(string name)
        {
            return outputDao.Search(name);
        }

        public List<EOutput> GetIdNumberId()
        {
            return outputDao.GetIdNumberId();
        }

        public List<EOutput> GetOutputNumber(string outputNumber)
        {
            return outputDao.GetOutputNumber(outputNumber);
        }

        public List<EOutput> GetLasDateOutput()
        {
            return outputDao.GetLastDateOutput();
        }

        public EOutput GetForId(int idOutput)
        {
            stringBuilder.Clear();

            if (idOutput == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return outputDao.GetByid(idOutput);
            }
            return null;
        }

        public void Delete(string outputNumber)
        {

                outputDao.Delete(outputNumber);
        }

        private bool isValid(EOutput output)
        {
            stringBuilder.Clear();
            if (string.IsNullOrEmpty(output.hour)) stringBuilder.Append("El campo Hora es obligatorio");
            if (string.IsNullOrEmpty(output.outputNumber)) stringBuilder.Append("No se ha generado el numero de Salida, cierre y vuelva a abrir");
            if (output.quantity < 0) stringBuilder.Append(Environment.NewLine + "El campo Cantidad es obligatorio");
            if (output.bsUnitPrice <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio Unitario  es obligatorio");

            return stringBuilder.Length == 0;
        }

        public DataTable reportGetByOutputNumber(string outputNumber)
        {
           return  outputDao.ReportGetById(outputNumber);
        }

        public DataTable reportGetAll()
        {
            return outputDao.ReportGetAll();
        }

        public DataTable ReportGetByEmployee(string outputNumber)
        {
            return outputDao.ReportGetByEmployee(outputNumber);
        }

        public DataTable ReportGeneralOutput()
        {
            return outputDao.ReportGeneralOutput();
        }

        public DataTable ReportOutputArticle(Int32 codeArticle)
        {
            return outputDao.ReportOutputArticle(codeArticle);
        }*/ 
    }
}
