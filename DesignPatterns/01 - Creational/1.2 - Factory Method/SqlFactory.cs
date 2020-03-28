namespace DesignPatterns.FactoryMethod
{
    // Concrete Creator
    public class SqlFactory : DbFactory
    {
        // Factory Method
        public override DbConnector CreateConnector(string connectionString)
        {
            return new SqlServerConnector(connectionString);
        }
    }
}