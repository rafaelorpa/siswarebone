using com.sisware.bean;
using com.sisware.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sisware.logic
{
    public  class RoleLogic
    {
        private RolDao roleDao = new RolDao();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Register(ERole role)
        {
            if (isValid(role))
            {
                if (roleDao.GetByid(role.id) == null)
                {
                    roleDao.Insert(role);
                }
                else
                    roleDao.Update(role);

            }
        }

        public List<ERole> GetAll()
        {
            return roleDao.GetAll();
        }

       /* public List<ERole> search(string name)
        {
            return roleDao.search(name);
        }*/

        public ERole GetForId(int roleId)
        {
            stringBuilder.Clear();

            if (roleId == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return roleDao.GetByid(roleId);
            }
            return null;
        }

        public void Delete(int roleId)
        {
            stringBuilder.Clear();

            if (roleId == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                roleDao.Delete(roleId);
            }
        }

        private bool isValid(ERole role)
        {
            stringBuilder.Clear();

            //if (string.IsNullOrEmpty(category.controlCode)) stringBuilder.Append("El campo Nombre es obligatorio");
            if (string.IsNullOrEmpty(role.name)) stringBuilder.Append("El campo Nombre es obligatorio");

            return stringBuilder.Length == 0;
        }

        public List<ERole> GetAllDescription()
        {
            return roleDao.GetAllDescription();
        }

        public List<ERole> GetIdByDescription(string name)
        {
            return roleDao.GetIdByDescription(name);
        }

        public List<ERole> GetDescriptionById(int idRole)
        {
            return roleDao.GetDescriptionById(idRole);
        }
    }
}
