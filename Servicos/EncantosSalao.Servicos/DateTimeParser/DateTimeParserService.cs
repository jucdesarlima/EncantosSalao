namespace EncantosSalao.Servicos.DateTimeParser
{
    using System;
    using System.Globalization;

    using EncantosSalao.Comum;

    public class DateTimeParserService : IDateTimeParserService
    {
        public DateTime ConvertStrings(string date, string time)
        {
            string dateString = date + " " + time;
            string format = ConstantesGlobais.FormatosDataHora.FormatoDataHora;

            DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);

            return dateTime;
        }
    }
}
