using com.sisware.bean;
using com.sisware.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace com.sisware.logic
{
    public class InventoryLogic
    {
        //Instanciamos nuestra clase InventoryDao para poder utilizar sus miembros
        private InventoryDao inventoryDao = new InventoryDao();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Register(EInventory inventory)
        {
            if (isValid(inventory))
            {
                if (inventoryDao.GetByid(inventory.id) == null)
                {
                    inventoryDao.Insert(inventory);
                }
                else
                    inventoryDao.Update(inventory);

            }
        }

        public EInventory GetByCodeU(int code)
        {
            return inventoryDao.GetByid(code);
        }


        public List<EInventory> GetAll()
        {
            return inventoryDao.GetAll();
        }

        public EInventory GetForId(int idInventory)
        {
            stringBuilder.Clear();

            if (idInventory == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return inventoryDao.GetByid(idInventory);
            }
            return null;
        }

        public void UpdateResidue(int inventoryCode, double residue)
        {
            stringBuilder.Clear();

            if (inventoryCode == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                inventoryDao.UpdateResidue(inventoryCode, residue);
            }
        }

        public void Delete(int inventoryCode)
        {
            stringBuilder.Clear();

            if (inventoryCode == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                inventoryDao.Delete(inventoryCode);
            }
        }

        private bool isValid(EInventory inventory)
        {
            stringBuilder.Clear();

            //if (input.hour <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");
            if (inventory.lot <= 0) stringBuilder.Append("El campo mucho es obligatorio");
            if (inventory.quantity <= 0) stringBuilder.Append(Environment.NewLine + "El campo Cantidad es obligatorio");
            //if (inventory.bsUnitPrice <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");
            //if (string.IsNullOrEmpty(inventory.description)) stringBuilder.Append(Environment.NewLine + "El campo Descripcion es obligatorio");
            //if (inventory.residue <= 0) stringBuilder.Append(Environment.NewLine + "El campo Residuo es obligatorio");

            return stringBuilder.Length == 0;
        }


        public List<EInventory> GetByArticle(int idArticle)
        {
            stringBuilder.Clear();

            if (idArticle == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return inventoryDao.GetByArticle(idArticle);
            }
            return null;
        }


        public List<EInventory> GetByArticleInput(int idArticle, int idInput)
        {
            stringBuilder.Clear();

            if (idArticle == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return inventoryDao.GetByArticleInput(idArticle,idInput);
            }
            return null;
        }

        public List<EInventory> GetByInputCode(int inputCode)
        {
            stringBuilder.Clear();

            if (inputCode == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return inventoryDao.GetByInputCode(inputCode);
            }
            return null;
        }

        public List<EInventory> GetLot(int idArticle)
        {
            stringBuilder.Clear();

            if (idArticle == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return inventoryDao.GetLot(idArticle);
            }
            return null;
        }

        public List<EInventory> GetByCode(int idArticle, int inputCode)
        {
            stringBuilder.Clear();

            if (idArticle == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return inventoryDao.GetByCode(idArticle,inputCode);
            }
            return null;
        }

        public DataTable reportGeneralConsumption(string dateIni, string dateEnd)
        {
            return inventoryDao.ReportGetGeneralConsumption(dateIni, dateEnd);
        }

        public DataTable reportGeneralInventory()
        {
            return inventoryDao.ReportGeneralInventory();
        }

        public DataTable reportGeneralInventory1(Int32 codeArticle, string dateIni, string dateEnd)
        {
            return inventoryDao.ReportGeneralInventory1(codeArticle, dateIni, dateEnd);
        }

        public DataTable reportGeneralInventory2(Int32 codeArticle, string dateIni, string dateEnd)
        {
            return inventoryDao.ReportGeneralInventory2(codeArticle,dateIni, dateEnd);
        }

        public DataTable reportGeneralInventory3(Int32 codeArticle)
        {
            return inventoryDao.ReportGeneralInventory3(codeArticle);
        }

        public DataTable reportKardex(Int32 codeSubcategory)
        {
            return inventoryDao.ReportKardex(codeSubcategory);
        }


       

        public DataTable reportKardex1(Int32 codeSubcategory)
        {
            return inventoryDao.ReportKardex1(codeSubcategory);
        }
        public DataTable reportKardexInput(Int32 codeSubcategory)
        {
            return inventoryDao.ReportKardexInput(codeSubcategory);
        }

        public DataTable reportKardexOutput(Int32 codeSubcategory)
        {
            return inventoryDao.ReportKardexOutput(codeSubcategory);
        }

        public DataTable reportGeneralKardex()
        {
            return inventoryDao.ReportGeneralKardex();
        }


      public int getLastId()
        {
            EInventory inv = inventoryDao.getLastId();

            if (inv.id > 0)
            {

                return inv.id;
            }
            else
            {
                return 0;
            }
        }

        
    }
}
