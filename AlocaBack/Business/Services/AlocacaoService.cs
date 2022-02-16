using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlocaBack.Business.DTO;
using AlocaBack.Business.Interface;
using AlocaBack.Business.Repository;

namespace AlocaBack.Business.Services
{
    public class AlocacaoService: IAlocacaoService
    {
        private AlocacaoRepository _ar = new AlocacaoRepository();

        public async Task CriarImovel(ImoveisDTO imovel)
        {
            try
            {
                var imovelExiste = await _ar.ImovelExiste(imovel);
                var list = imovelExiste.ToList();
                if (list.Count == 0)
                {
                    await _ar.AdicionarImovel(imovel);
                }
                else
                {
                    throw new NullReferenceException("Esse endereço já está cadastrado.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task DesativarImovel(string id)
        {
            try
            {
                await _ar.DesativarImovel(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ImoveisDTO>> RetornarImoveisAtivos()
        {
            try
            {
                return await _ar.VerImoveisAtivos();
            }
            catch
            {
                throw;
            }
        }

        public async Task EditarImoveis(ImoveisDTO imovel)
        {
            try
            {
                var imovelExiste = await _ar.ImovelExiste(imovel);
                var list = imovelExiste.ToList();
                if(list.Count == 0)
                {
                    await _ar.EditarImovel(imovel);
                }
                else
                {
                    throw new NullReferenceException("Esse endereço já está cadastrado.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ImoveisDTO>> RetornarImoveisPorId(string id)
        {
            try
            {
                return await _ar.VerImoveisPorId(id);
            }
            catch
            {
                throw;
            }
        }
    }
}