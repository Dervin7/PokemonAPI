using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pokemon.Data;
using Pokemon.Models.TypesModels;

namespace Pokemon.Services
{
    public class PokemonTypeService : IPokemonTypeService
    {
        private readonly ApplicationDbContext _context;

        public PokemonTypeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TypesModels> UpdateTypeAsync(int id, TypesModels typeModel)
        {
            var typeEntity = await _context.Types.FindAsync(id);
            if (typeEntity == null)
            {
                return null;
            }

            typeEntity.Name = typeModel.Name;

            _context.Types.Update(typeEntity);
            await _context.SaveChangesAsync();

            return typeModel;
        }

        public async Task<bool> DeleteTypeAsync(int id)
        {
            var typeEntity = await _context.Types.FindAsync(id);
            if (typeEntity == null)
            {
                return false;
            }

            _context.Types.Remove(typeEntity);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}