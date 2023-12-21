using EpsiVal.BusinessLogic.Services;

namespace BinarySearch.Auth
{
    public class APIKeyMiddleware
    {
        private readonly CryptoService cryptoService;

        public APIKeyMiddleware(RequestDelegate next, CryptoService cryptoService)
        {
            // Другие настройки и инициализации

            this.cryptoService = cryptoService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Получение API-ключа из запроса
            string encryptedApiKey = context.Request.Headers["Api-Key"];
            string apiKey = cryptoService.Decrypt(encryptedApiKey);

            // Другие действия по обработке запроса

            await next(context);
        }
    }
}