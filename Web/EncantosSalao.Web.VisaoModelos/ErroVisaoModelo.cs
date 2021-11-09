namespace EncantosSalao.Web.VisaoModelos
{
    public class ErroVisaoModelo
    {
        public string IdRequisicao { get; set; }

        public bool MostraIdRequisicao => !string.IsNullOrEmpty(this.IdRequisicao);
    }
}
