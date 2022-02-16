using System.Collections.Generic;
using System.Threading.Tasks;
using AlocaBack.Business.DTO;

namespace AlocaBack.Business.Interface
{
    public interface IAlocacaoService
    {
         Task CriarImovel(ImoveisDTO imovel);
         Task<IEnumerable<ImoveisDTO>> RetornarImoveisAtivos();
         Task DesativarImovel(string id);
         Task EditarImoveis(ImoveisDTO imovel);
         Task<IEnumerable<ImoveisDTO>> RetornarImoveisPorId(string id);

         
    }
}