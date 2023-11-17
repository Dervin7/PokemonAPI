using System.Threading.Tasks;
using Pokemon.Models.TypesModels;


namespace Pokemon.Services
{
    public interface IPokemonTypeService
    {
        Task<PokemonTypesModels> UpdateTypeAsync(int id, PokemonTypesModels typeModel);
        Task<bool> DeleteTypeAsync(int id);
        //ADD CR METHODS
     
    }
}
