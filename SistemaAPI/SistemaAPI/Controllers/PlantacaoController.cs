using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaAPI.Models;
using SistemaAPI.Repositorios.Interfaces;

namespace SistemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantacaoController : ControllerBase
    {
        private readonly IPlantacaoRepositorio _plantacaoRepositorio;
        public PlantacaoController(IPlantacaoRepositorio plantacaoRepositorio)
        {
            _plantacaoRepositorio = plantacaoRepositorio;
        }

        /// <summary>
        /// Obter todas as plantacoes
        /// </summary>
        /// <returns>Colecao de plantacoes</returns>
        /// <response code="200">Sucess</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PlantacaoModel>>> ListarTodas()
        {
            List<PlantacaoModel> plantacoes = await _plantacaoRepositorio.BuscarTodasPlantacoes();
            return Ok(plantacoes);
        }

        /// <summary>
        /// Obter uma plantacao procurando pelo ID
        /// </summary>
        /// <param name="id">Identificador da plantacao</param>
        /// <returns>Dados da plantacao</returns>
        /// <response code="200">Sucess</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PlantacaoModel>> BuscarPorId(int id)
        {
            PlantacaoModel plantacao = await _plantacaoRepositorio.BuscarPorID(id);
            return Ok(plantacao);
        }


        /// <summary>
        /// Cadastrar uma plantcao no banco de dados
        /// </summary>
        /// <remarks>
        /// {"id": 0,"nome": "string","descricao": "string","status": 1,"climaId": 0,"clima": {"id": 0,"nome": "string","descricao": "string"
        /// </remarks>
        /// <param name="plantacaoModel">Dados da plantacao</param>
        /// <returns>Objeto Cadastrado</returns>
        /// <response code="200">Sucess</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<PlantacaoModel>> Cadastrar([FromBody] PlantacaoModel plantacaoModel)
        {
            PlantacaoModel plantacao = await _plantacaoRepositorio.Adicionar(plantacaoModel);
            return Ok(plantacao);
        }

        /// <summary>
        /// Alterar as informacoes de uma plantacao com base no ID
        /// </summary>
        /// <remarks>
        /// {"id": 0,"nome": "string","descricao": "string","status": 1,"climaId": 0,"clima": {"id": 0,"nome": "string","descricao": "string"
        /// </remarks>
        /// <param name="plantacaoModel">Identificador da plantacao</param>
        /// <param name="id">Dados da plantacao</param>
        /// <returns>Nada</returns>
        /// <response code="404">Nao encontrado</response>
        /// <response code="200">Sucess</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<PlantacaoModel>> Atualizar([FromBody] PlantacaoModel plantacaoModel, int id)
        {
            plantacaoModel.Id = id;
            PlantacaoModel plantacao = await _plantacaoRepositorio.Atualizar(plantacaoModel, id);
            return Ok(plantacao);
        }

        /// <summary>
        /// Deletar uma plantacao com base no ID
        /// </summary>
        /// <param name="id">Identificador da plantacao</param>
        /// <returns>Nada</returns>
        /// <response code="404">Nao encontrado</response>
        /// <response code="200">Sucess</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PlantacaoModel>> Apagar(int id)
        {
            bool apagado = await _plantacaoRepositorio.Apagar(id);
            return Ok(apagado);
        }

    }
}
