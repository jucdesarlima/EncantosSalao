namespace EncantosSalao.Dado.Comum
{
    using System;
    using System.Threading.Tasks;

    public interface IDbExecutorConsulta : IDisposable
    {
        Task RunQueryAsync(string query, params object[] parameters);
    }
}
