using System;

namespace AlocaBack.Business.DTO
{
    public class ImoveisDTO
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public byte Disponivel { get; set; }
        public decimal Preco { get; set; }
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
    }
}