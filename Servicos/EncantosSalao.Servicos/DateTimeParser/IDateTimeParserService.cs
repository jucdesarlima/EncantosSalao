﻿namespace EncantosSalao.Servicos.DateTimeParser
{
    using System;

    public interface IDateTimeParserService
    {
        DateTime ConvertStrings(string date, string time);
    }
}
