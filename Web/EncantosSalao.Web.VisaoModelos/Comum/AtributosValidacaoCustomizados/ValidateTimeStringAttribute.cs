namespace EncantosSalao.Web.VisaoModelos.Comum.AtributosValidacaoCustomizados
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    using EncantosSalao.Comum;

    public class ValidateTimeStringAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var timeString = value as string;

            if (string.IsNullOrEmpty(timeString))
            {
                return false;
            }

            bool parsed = DateTime.TryParseExact(
                            timeString,
                            ConstantesGlobais.FormatosDataHora.FormatoHora,
                            CultureInfo.InvariantCulture,
                            style: DateTimeStyles.AssumeUniversal,
                            result: out _);
            if (!parsed)
            {
                return false;
            }

            return true;
        }
    }
}
