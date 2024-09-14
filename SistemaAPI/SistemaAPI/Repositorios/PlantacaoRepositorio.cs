using Microsoft.EntityFrameworkCore;
using SistemaAPI.Data;
using SistemaAPI.Models;
using SistemaAPI.Repositorios.Interfaces;

namespace SistemaAPI.Repositorios
{
    public class PlantacaoRepositorio : IPlantacaoRepositorio
    {
        private readonly SistemaPlantacoesDBContext _dbContext;
        public PlantacaoRepositorio(SistemaPlantacoesDBContext sistemaPlantacoesDBContext)
        {
            _dbContext = sistemaPlantacoesDBContext;
        }
        public async Task<PlantacaoModel> BuscarPorID(int id)
        {
            return await _dbContext.Plantacoes.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<List<PlantacaoModel>> BuscarTodasPlantacoes()
        {
            return await _dbContext.Plantacoes.ToListAsync();
        }
        public async Task<PlantacaoModel> Adicionar(PlantacaoModel plantacao)
        {
            await _dbContext.Plantacoes.AddAsync(plantacao);
            await _dbContext.SaveChangesAsync();

            return plantacao;
        }

        public async Task<PlantacaoModel> Atualizar(PlantacaoModel plantacao, int id)
        {
            PlantacaoModel plantacaoPorId = await  BuscarPorID(id);
            
            if(plantacaoPorId == null) 
            {
                throw new Exception($"Plantacao para o ID: {id} nao foi encontrado no banco de dados");
            }

            plantacaoPorId.Nome = plantacao.Nome;
            plantacaoPorId.Descricao = plantacao.Descricao;
            plantacaoPorId.Status = plantacao.Status;
            plantacaoPorId.ClimaId = plantacao.ClimaId;

            _dbContext.Plantacoes.Update(plantacaoPorId);
            await _dbContext.SaveChangesAsync();

            return plantacaoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            PlantacaoModel plantacaoModel = await BuscarPorID(id);

            if (plantacaoModel == null)
            {
                throw new Exception($"Plantacao para o ID: {id} nao foi encontrado no banco de dados");
            }

            _dbContext.Plantacoes.Remove(plantacaoModel);
            await _dbContext.SaveChangesAsync();
            return true;

        }


    }
}
