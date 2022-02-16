using System.Collections.Generic;
using System.Threading.Tasks;
using AlocaBack.Business.DTO;
using AlocaBack.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlocaBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlocacaoController: ControllerBase
    {
        private AlocacaoService _as = new AlocacaoService();

        [HttpGet]
        [Route("v1/imoveisativos")]
        public async Task<IEnumerable<ImoveisDTO>> GetAll()
        {
            try
            {
                return await this._as.RetornarImoveisAtivos();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("v1/imoveisporid")]
        public async Task<IEnumerable<ImoveisDTO>> GetAllById(string id)
        {
            try
            {
                return await this._as.RetornarImoveisPorId(id);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut]
        [Route("v1/editarimovel")]
        public async Task EditarImovel(ImoveisDTO imovel)
        {
            try
            {
                await _as.EditarImoveis(imovel);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut]
        [Route("v1/desativarimovel")]
        public async Task DesativarImovel(string id)
        {
            try
            {
                await _as.DesativarImovel(id);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        [Route("v1/adicionarimovel")]
        public async Task AdicionarImovel(ImoveisDTO imovel)
        {
            try
            {
                await _as.CriarImovel(imovel);
            }
            catch
            {
                throw;
            }
        }
    }
}