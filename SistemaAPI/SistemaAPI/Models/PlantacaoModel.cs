using SistemaAPI.Enums;

namespace SistemaAPI.Models
{
    public class PlantacaoModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set;}

        public StatusPlantacao Status { get; set;}
        public int? ClimaId { get; set; }
        public virtual ClimaModel? Clima { get; set; }

    }
}
