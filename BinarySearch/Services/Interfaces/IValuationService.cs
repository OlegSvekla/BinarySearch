using EpsiVal.BusinessLogic.Models.Requests;
using EpsiVal.BusinessLogic.Models.Responses;

namespace EpsiVal.BusinessLogic.Services.Interfaces;

public interface IValuationService
{
    Task<GetShopifyPartnersMetricsResponse> GetShopifyPartnersMetricsAsync(GetShopifyPartnersMetricsRequest request);
    Task<GetShopifyPartnersMRRsResponse> GetShopifyPartnersMRRsAsync(GetShopifyPartnersMRRsRequest request);
    Task<GetShopifyPartnersRetentionsResponse> GetShopifyPartnersRetentionsAsync(GetShopifyPartnersRetentionsRequest request);
    GetMultipliersValuationResponse GetMultipliersValuation(GetMultipliersValuationRequest request);
    Task<GetMultipliersValuationResponse> GetShopifyPartnersMultipliersValuationAsync(GetShopifyPartnersMultipliersValuationRequest request);
    Task<GetMultipliersValuationResponse> GetCsvMultipliersValuationAsync(GetCsvMultipliersValuationRequest request);
    GetRiskRatingResponse GetRiskRating(GetRiskRatingRequest request);
}