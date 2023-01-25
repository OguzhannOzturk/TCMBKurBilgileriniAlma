using System.Runtime.InteropServices;
using System.Xml;
using Newtonsoft.Json;
using TCMBKur.Dtos;

namespace TCMBKur.Business.Repository;

public class GeneralRepository : IGeneralRepository
{
    private readonly IConfiguration _configuration;

    public GeneralRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<ForeignCurrencyDto> GetForeignCurrency()
    {
        ForeignCurrencyDto foreignCurrencyDto;
        var centralBankSettings = _configuration.GetSection(nameof(CentralBankSettings)).Get<CentralBankSettings>();
        if (!centralBankSettings.Use)
            throw new ExternalException("Service off.");
        try
        {
            var handler = new HttpClientHandler();
            handler.UseCookies = false;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"{centralBankSettings.BaseUrl}{centralBankSettings.ApiUrl}"))
                {
                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        foreignCurrencyDto = await ConvertXmlToDto(response);
                    }
                    else
                    {
                        throw new ExternalException("An unknown error has occurred, try again.");
                    }
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception($" {e.Message}");
        }
        return foreignCurrencyDto;
    }

    private async Task<ForeignCurrencyDto> ConvertXmlToDto(HttpResponseMessage responseMessage)
    {
        var json = await responseMessage.Content.ReadAsStringAsync();
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(json);
        var result = JsonConvert.SerializeXmlNode(doc);
        return JsonConvert.DeserializeObject<ForeignCurrencyDto>(result)!;
    }
}