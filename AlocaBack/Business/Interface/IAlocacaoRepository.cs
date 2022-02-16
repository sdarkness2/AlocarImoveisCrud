using System.Collections.Generic;
using System.Threading.Tasks;
using AlocaBack.Business.DTO;

namespace AlocaBack.Business.Interface
{
    public interface IAlocacaoRepository
    {
        Task<IEnumerable<ImoveisDTO>> VerTodos();
        Task AdicionarImovel(ImoveisDTO imovel);
        Task<IEnumerable<ImoveisDTO>> ImovelExiste(ImoveisDTO imovel);
        Task DesativarImovel(string id); 
        Task EditarImovel(ImoveisDTO imovel);
    }
}