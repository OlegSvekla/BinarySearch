using EpsiVal.BusinessLogic.Models.Requests.Plaid;
using EpsiVal.BusinessLogic.Models.Responses;
using Going.Plaid.Entity;

namespace EpsiVal.BusinessLogic.Services.Interfaces;

public interface IPlaidService
{
     Task<GetPlaidMetricsResponse> GetMetrics(GetPlaidMetricsRequest request);
     Task<IEnumerable<Transaction>> GetTransactionsAsync(GetPlaidMetricsRequest request);
}