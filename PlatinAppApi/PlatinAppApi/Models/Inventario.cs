using System;

namespace PlatinAppApi.Models
{
    public class Inventario
    {
        public int ContagemCodigo { get; set; }

        public int InvId { get; set; }

        public string InvCodigo { get; set; }

        public int ProId { get; set; }

        public string ProNome { get; set; }

        public string ProDescricacao { get; set; }

        public decimal? ProValor { get; set; }

        public string ProCodigo { get; set; }

        public decimal? ProQuantidade { get; set; }

        public int? CatId { get; set; }

        public int? ProEstoque { get; set; }

        public string ProUnidade { get; set; }

        public int? ProStatus { get; set; }

        public Byte[] ProImagem { get; set; }

        public string ProNcm { get; set; }

        public int? MarId { get; set; }

        public string ProAliquota { get; set; }

        public string ProCfop { get; set; }

        public decimal ProPorcentagemTributo { get; set; }

        public int? ProOrigem { get; set; }

        public string ProCsosn { get; set; }

        public string ProCst { get; set; }

        public string ProCest { get; set; }

        public decimal? ProCustMedio { get; set; }

        public decimal? ProUltimoCust { get; set; }
    }
}
