using DotNetTemplate.Domain.Interfaces.Services;
using DotNetTemplate.Domain.Model.ViewModels.Team;
using DotNetTemplate.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetTemplate.WebApi.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class TeamController : BaseController {

        private readonly ITeamApplicationService _teamApplicationService;

        public TeamController(ITeamApplicationService teamApplicationService) {
            _teamApplicationService = teamApplicationService;
        }

        /// <summary>
        ///     Pega todos os times cadastrados no sistema
        /// </summary>
        /// <returns>Lista dos times</returns>
        /// <response code="200">Resumo do que foi encontrado</response>
        /// <response code="400">Processo nao foi concluido com sucesso</response>
        /// <response code="404">Nada foi encontrado</response>
        /// <response code="500">Erro durante o processo</response> 
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<TeamResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<TeamResponse>>> GetAll() {

            var teams = await _teamApplicationService.GetAll();

            return ProcessResponse(teams);
        }

        /// <summary>
        ///     Pega o time do determinado ID do sistema
        /// </summary>
        /// <param name="idTeam">Identificador unico do time</param>
        /// <returns>Time encontrado</returns>
        /// <response code="200">Resumo do que foi encontrado</response>
        /// <response code="400">Processo nao foi concluido com sucesso</response>
        /// <response code="404">Nada foi encontrado</response>
        /// <response code="500">Erro durante o processo</response> 
        [HttpGet]
        [ProducesResponseType(typeof(TeamResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TeamResponse>> Get(Guid idTeam) {

            var team = await _teamApplicationService.GetById(idTeam);

            return ProcessResponse(team);
        }

    }
}
