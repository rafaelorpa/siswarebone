using com.sisware.bean;
using com.sisware.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sisware.logic
{
    public class InventoryTempLogic
    {
        //Instanciamos nuestra clase InventoryDao para poder utilizar sus miembros
        private InventoryTempDao inventoryDao = new InventoryTempDao();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Register(EInventoryTemp inventory)
        {
            if (isValid(inventory))
            {
                if (inventoryDao.GetByid(inventory.code) == null)
                {
                    inventoryDao.Insert(inventory);
                }
                else
                    inventoryDao.Update(inventory);

            }
        }

        public List<EInventoryTemp> GetAll()
        {
            return inventoryDao.GetAll();
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

        private bool isValid(EInventoryTemp inventory)
        {
            stringBuilder.Clear();

            //if (input.hour <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");
            if (inventory.lot <= 0) stringBuilder.Append("El campo mucho es obligatorio");
            if (inventory.quantity <= 0) stringBuilder.Append(Environment.NewLine + "El campo Cantidad es obligatorio");
            if (inventory.bsUnitPrice <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");
            //if (string.IsNullOrEmpty(inventory.description)) stringBuilder.Append(Environment.NewLine + "El campo Descripcion es obligatorio");
            //if (inventory.residue <= 0) stringBuilder.Append(Environment.NewLine + "El campo Residuo es obligatorio");

            return stringBuilder.Length == 0;
        }
    }
}
