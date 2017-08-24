namespace Imposto.Core.Data.Connection
{
    public static class ConnectionManager
    {
        /// <summary>
        /// String de Conexão para acesso ao Banco de Dados SQL Server
        /// </summary>
        public static string GetConnectionString
        {
            get
            {
                return "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Teste;User ID=UserTest; Password=teste1234;Integrated Security=true;";
            }
        }        
    }
}
