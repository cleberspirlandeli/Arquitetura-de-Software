namespace DesignPatterns
{
    // Client
    public class TransacaoService
    {
        private readonly ILogger _logger;

        public TransacaoService(ILogger logger)
        {
            _logger = logger;
        }

        public void RealizarTransacao()
        {
            // Transação
            _logger.Log("Transação realizada");
        }
    }
}