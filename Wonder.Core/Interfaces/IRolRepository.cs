using Wonder.Core.Models;

namespace Wonder.Core.Interfaces
{
    public interface IRolRepository: IRepository<Rol>
    {
        Resultado<object> RegisterRol(Rol rol);      
    }
}
