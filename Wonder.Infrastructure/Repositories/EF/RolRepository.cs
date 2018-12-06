using System;
using Wonder.Core.Interfaces;
using Wonder.Core.Models;
using Wonder.Infrastructure.EF;

namespace Wonder.Infrastructure.Repositories.EF
{
    public class RolRepository : RepositoryBase<WonderMoonContext, Rol>, IRolRepository
    {
        public Resultado<object> RegisterRol(Rol rol)
        {
            var respuesta = new Resultado<object>();
            try
            {
                Add(rol);
                Save();
            }
            catch (Exception ex)
            {
                respuesta = Resultado<object>.GenerarError(ex.Message);
            }

            return respuesta;
        }

    }
}
