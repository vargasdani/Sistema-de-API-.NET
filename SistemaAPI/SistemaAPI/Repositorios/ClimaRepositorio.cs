using Microsoft.EntityFrameworkCore;
using SistemaAPI.Data;
using SistemaAPI.Models;
using SistemaAPI.Repositorios.Interfaces;

namespace SistemaAPI.Repositorios
{
    public class ClimaRepositorio : IClimaRepositorio
    {
        private readonly SistemaPlantacoesDBContext _dbContext;
        public ClimaRepositorio(SistemaPlantacoesDBContext sistemaPlantacoesDBContext)
        {
            _dbContext = sistemaPlantacoesDBContext;
        }
        public async Task<ClimaModel> BuscarPorID(int id)
        {
            return await _dbContext.Climas.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<List<ClimaModel>> BuscarTodosClimas()
        {
            return await _dbContext.Climas.ToListAsync();
        }
        public async Task<ClimaModel> Adicionar(ClimaModel clima)
        {
            await _dbContext.Climas.AddAsync(clima);
            await _dbContext.SaveChangesAsync();

            return clima;
        }

        public async Task<ClimaModel> Atualizar(ClimaModel clima, int id)
        {
            ClimaModel climaPorId = await  BuscarPorID(id);
            
            if(climaPorId == null) 
            {
                throw new Exception($"Clima para o ID: {id} nao foi encontrado no banco de dados");
            }

            climaPorId.Nome = clima.Nome;
            climaPorId.Descricao = clima.Descricao;

            _dbContext.Climas.Update(climaPorId);
            await _dbContext.SaveChangesAsync();

            return climaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            ClimaModel climaPorId = await BuscarPorID(id);

            if (climaPorId == null)
            {
                throw new Exception($"Clima para o ID: {id} nao foi encontrado no banco de dados");
            }

            _dbContext.Climas.Remove(climaPorId);
            await _dbContext.SaveChangesAsync();
            return true;

        }


    }
}
