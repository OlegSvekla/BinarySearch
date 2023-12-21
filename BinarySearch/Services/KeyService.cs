using EpsiVal.BusinessLogic.Models.Auth;

namespace EpsiVal.BusinessLogic.Services
{
    public class ServiceService
    {
        private readonly YourDbContext _dbContext;

        public ServiceService(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Service GetServiceByApiKey(string apiKey)
        {
            return z.Services
                .Include(s => s.ApiKeys)
                .Include(s => s.Claims)
                .FirstOrDefault(s => s.ApiKeys.Any(k => k.EncryptedKey == apiKey));
        }
    }
}