using com.sisware.bean;
using com.sisware.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sisware.logic
{
    public class UserLogic
    {
        //Instanciamos nuestra clase ProductoDal para poder utilizar sus miembros
        private UserDao userDao = new UserDao();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Register(EUser user)
        {
            if (isValid(user))
            {
                if (userDao.GetByid(user.id) == null)
                {
                    userDao.Insert(user);
                }
                else
                    userDao.Update(user);

            }
        }

        public List<EUser> GetAll()
        {
            return userDao.GetAll();
        }

        public EUser GetForId(int idUser)
        {
            stringBuilder.Clear();

            if (idUser == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return userDao.GetByid(idUser);
            }
            return null;
        }

        public void Delete(int userId)
        {
            stringBuilder.Clear();

            if (userId == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                userDao.Delete(userId);
            }
        }

        public void UpdatePassword(string password, int userCode)
        {
            stringBuilder.Clear();

            if (userCode == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                userDao.UpdatePassword(password, userCode);
            }
        }

        public List<EUser> CheckDateUser(string userName, string passwordUser)
        {
            return userDao.CheckDateUser(userName, passwordUser);
        }


        private bool isValid(EUser user)
        {
            stringBuilder.Clear();

            //if (input.hour <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");
            if (user.ci.Trim().Length < 7 | user.ci.Trim().Length > 7)
                throw new Exception("El numero de C. I. debera ser de 7 caracteres");
            if (string.IsNullOrEmpty(user.firstName)) stringBuilder.Append(Environment.NewLine + "El campo Primer Apellido es obligatorio");
            if (string.IsNullOrEmpty(user.lastName)) stringBuilder.Append(Environment.NewLine + "El campo Segundo Apellido es obligatorio");
            if (string.IsNullOrEmpty(user.names)) stringBuilder.Append(Environment.NewLine + "El campo Nombres es obligatorio");
            if (string.IsNullOrEmpty(user.user)) stringBuilder.Append(Environment.NewLine + "El campo Nombre de usuario es obligatorio");
            if (string.IsNullOrEmpty(user.password)) stringBuilder.Append(Environment.NewLine + "El campo Contraseña es obligatorio");
            if (string.IsNullOrEmpty(user.trace)) stringBuilder.Append(Environment.NewLine + "El campo Indicio es obligatorio");
            if (string.IsNullOrEmpty(user.role)) stringBuilder.Append(Environment.NewLine + "El campo Permisos es obligatorio");

            return stringBuilder.Length == 0;
        }
    }
}
