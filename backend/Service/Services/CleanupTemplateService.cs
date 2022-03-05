using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Service.Services
{
    public class CleanupTemplateService : IHostedService, IDisposable
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IConfiguration _config;
        private readonly TimeSpan _period = new(6, 0, 0);
        
        private Timer _timer = null!;
        private TimeSpan Lifetime => _config.GetValue<TimeSpan>("Template:Lifetime");

        public CleanupTemplateService(IServiceScopeFactory scopeFactory, IConfiguration config)
        {
            _scopeFactory = scopeFactory;
            _config = config;
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, _period);
            return Task.CompletedTask;
        }

        private async void DoWork(object? state)
        {
            using var scope = _scopeFactory.CreateScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            
            var currentDate = DateTime.UtcNow;

            var outdatedTemplatesIds =  await unitOfWork.Templates
                .Get()
                .Where(t => currentDate - t.UploadDate > Lifetime)
                .Select(t => t.Id)
                .ToListAsync();

            unitOfWork.Templates.DeleteRange(outdatedTemplatesIds);
            
            await unitOfWork.Save();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    } 
}