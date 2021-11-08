namespace EncantosSalao.Web.VisaoModelos
{
    public class ErroVisaoModelo
    {
        public string IdRequisicao { get; set; }

        public bool MostraIdReuisicao => !string.IsNullOrEmpty(this.IdRequisicao);
    }
}
