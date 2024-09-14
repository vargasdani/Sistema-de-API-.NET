using System.ComponentModel;

namespace SistemaAPI.Enums
{
    public enum StatusPlantacao
    {
        [Description("Favoravel")]
        Favoravel = 1,
        [Description("Nao Favoravel")]
        NaoFavoravel = 2,
        [Description("Ideal")]
        Ideal =3
    }
}
