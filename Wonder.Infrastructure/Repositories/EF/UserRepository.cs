using System;
using Wonder.Core.Interfaces;
using Wonder.Core.Models;
using System.Linq;
using System.Collections.Generic;
using Wonder.Infrastructure.EF;
using System.Data.Entity;

namespace Wonder.Infrastructure.Repositories.EF
{
    public class UserRepository : RepositoryBase<WonderMoonContext, User>, IUserRepository
    {

        public Resultado<User> DeleteUser(int id)
        {
            var respuesta = new Resultado<User>();
            try
            {
                var user = FindBy(x => x.UserId == id).FirstOrDefault();
                Delete(user);
                Save();
                respuesta.Data = null;
            }
            catch (Exception ex)
            {
                respuesta = Resultado<User>.GenerarError(ex.Message);
            }

            return respuesta;
        }

        public Resultado<User> EditUser(User user)
        {
            var respuesta = new Resultado<User>();
            try
            {
                Edit(user);
                Save();
                respuesta.Data = user;
            }
            catch (Exception ex)
            {
                respuesta = Resultado<User>.GenerarError(ex.Message);
            }

            return respuesta;
        }

        public Resultado<List<User>> FullSearch(string query)
        {
            var respuesta = new Resultado<List<User>>();
            try
            {
                respuesta.Data = Context.Users.Include(x => x.Rol).Where(
                    x => x.EmailAddress.Contains(query) ||
                    x.FirstName.Contains(query) ||
                    x.SecondName.Contains(query) ||
                    x.HomePhone.Contains(query) ||
                    x.MobilePhone.Contains(query) ||
                    x.PrimaryAddress.Contains(query) ||
                    x.Rol.Name.Contains(query) 
                ).ToList();
            }
            catch (Exception ex)
            {
                respuesta = Resultado<List<User>>.GenerarError(ex.Message);
            }

            return respuesta;

        }

        public Resultado<List<User>> GetAllUser()
        {
            var respuesta = new Resultado<List<User>>();
            try
            {
                respuesta.Data = GetAll().Include(x => x.Rol).ToList();
            }
            catch (Exception ex)
            {
                respuesta = Resultado<List<User>>.GenerarError(ex.Message);
            }

            return respuesta;
       
        }

        public Resultado<User> GetUser(int id)
        {
            var respuesta = new Resultado<User>();
            try
            {
                respuesta.Data = FindBy(x => x.UserId == id).Include(x=>x.Rol).FirstOrDefault();
            }
            catch (Exception ex)
            {
                respuesta = Resultado<User>.GenerarError(ex.Message);
            }

            return respuesta;
        }

        public Resultado<User> RegisterUser(User user)
        {
            var respuesta = new Resultado<User>();
            try
            {
                Add(user);
                Save();
                respuesta.Data = user;
            }
            catch (Exception ex)
            {
                respuesta = Resultado<User>.GenerarError(ex.Message);
            }

            return respuesta;
        }

    }
}
