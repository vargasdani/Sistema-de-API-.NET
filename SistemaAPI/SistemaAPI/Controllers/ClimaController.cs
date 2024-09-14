using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaAPI.Models;
using SistemaAPI.Repositorios.Interfaces;

namespace SistemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimaController : ControllerBase
    {
        private readonly IClimaRepositorio _climaRepositorio;
        public ClimaController(IClimaRepositorio climaRepositorio)
        {
            _climaRepositorio = climaRepositorio;
        }

        /// <summary>
        /// Obter todos os climas
        /// </summary>
        /// <returns>Colecao de climas</returns>
        /// <response code="200">Sucess</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ClimaModel>>> BuscarTodosClimas()
        {
            List<ClimaModel> climas = await _climaRepositorio.BuscarTodosClimas();
            return Ok(climas);
        }


        /// <summary>
        /// Obter um clima procurando pelo ID
        /// </summary>
        /// <param name="id">Identificador do clima</param>
        /// <returns>Dados do clima</returns>
        /// <response code="200">Sucess</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ClimaModel>> BuscarPorId(int id)
        {
            ClimaModel clima = await _climaRepositorio.BuscarPorID(id);
            return Ok(clima);
        }

        /// <summary>
        /// Cadastrar um clima no banco de dados
        /// </summary>
        /// <remarks>
        /// {"id": 0,"nome": "string","descricao": "string"}
        /// </remarks>
        /// <param name="climaModel">Dados do clima</param>
        /// <returns>Objeto Cadastrado</returns>
        /// <response code="200">Sucess</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<ClimaModel>> Cadastrar([FromBody] ClimaModel climaModel)
        {
            ClimaModel clima = await _climaRepositorio.Adicionar(climaModel);
            return Ok(clima);
        }

        /// <summary>
        /// Alterar as informacoes de um clima com base no ID
        /// </summary>
        /// <remarks>
        /// {"id": 0,"nome": "string","descricao": "string"}
        /// </remarks>
        /// <param name="climaModel">Identificador do clima</param>
        /// <param name="id">Dados do clima</param>
        /// <returns>Nada</returns>
        /// <response code="404">Nao encontrado</response>
        /// <response code="200">Sucess</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]


        public async Task<ActionResult<ClimaModel>> Atualizar([FromBody] ClimaModel climaModel, int id)
        {
            climaModel.Id = id;
            ClimaModel clima = await _climaRepositorio.Atualizar(climaModel, id);
            return Ok(clima);
        }

        /// <summary>
        /// Deletar um clima com base no ID
        /// </summary>
        /// <param name="id">Identificador do clima</param>
        /// <returns>Nada</returns>
        /// <response code="404">Nao encontrado</response>
        /// <response code="200">Sucess</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ClimaModel>> Apagar(int id)
        {
            bool apagado = await _climaRepositorio.Apagar(id);
            return Ok(apagado);
        }

    }
}
