using Newtonsoft.Json;

namespace TCMBKur.Dtos;

public class ForeignCurrencyDto
{
    [JsonProperty("?xml")]
    public Xml xml { get; set; }

    [JsonProperty("?xml-stylesheet")]
    public string xmlstylesheet { get; set; }
    public TarihDate Tarih_Date { get; set; }
}

public class Currency
{
    [JsonProperty("@CrossOrder")]
    public string CrossOrder { get; set; }

    [JsonProperty("@Kod")]
    public string Kod { get; set; }

    [JsonProperty("@CurrencyCode")]
    public string CurrencyCode { get; set; }
    public string Unit { get; set; }
    public string Isim { get; set; }
    public string CurrencyName { get; set; }
    public string ForexBuying { get; set; }
    public string ForexSelling { get; set; }
    public string BanknoteBuying { get; set; }
    public string BanknoteSelling { get; set; }
    public string CrossRateUSD { get; set; }
    public string CrossRateOther { get; set; }
}



public class TarihDate
{
    [JsonProperty("@Tarih")]
    public string Tarih { get; set; }

    [JsonProperty("@Date")]
    public string Date { get; set; }

    [JsonProperty("@Bulten_No")]
    public string Bulten_No { get; set; }
    public List<Currency> Currency { get; set; }
}

public class Xml
{
    [JsonProperty("@version")]
    public string version { get; set; }

    [JsonProperty("@encoding")]
    public string encoding { get; set; }
}
