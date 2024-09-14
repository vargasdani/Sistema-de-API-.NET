using SistemaAPI.Models;

namespace SistemaAPI.Repositorios.Interfaces
{
    public interface IPlantacaoRepositorio
    {
        Task<List<PlantacaoModel>> BuscarTodasPlantacoes();
        Task<PlantacaoModel> BuscarPorID(int id);
        Task<PlantacaoModel> Adicionar(PlantacaoModel plantacao);
        Task<PlantacaoModel> Atualizar(PlantacaoModel plantacao, int id);
        Task<bool> Apagar(int id);
    }
}
