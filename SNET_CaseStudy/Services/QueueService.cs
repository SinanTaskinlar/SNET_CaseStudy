namespace SNET_CaseStudy.Services
{
    public class QueueService : BackgroundService
    {
        //.net içerisinde diğer teknoloilere alternatif bir queue yapısı
        //birden fazla istek geldiği senaryoda Business classlardaki listelerden tek tek okuma yapılıp kullanılabilir.

        private readonly ILogger<QueueService> _logger;
        public QueueService(ILogger<QueueService> logger)
        {
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(2000);
                _logger.LogInformation("Queue worked!");
            }
            throw new NotImplementedException();
        }
    }
}
