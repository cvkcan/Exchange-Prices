using System.Xml;
XmlDocument doc1 = new XmlDocument();
doc1.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
XmlElement root = doc1.DocumentElement;
XmlNodeList nodes = root.SelectNodes("Currency");
foreach (XmlNode node in nodes)
{
    Exchange exchange = new Exchange();
    exchange.CurrencyCode = node.Attributes["CurrencyCode"].Value;
    exchange.Unit = Int16.Parse(node["Unit"].InnerText);
    exchange.Currency = node["CurrencyName"].InnerText;
    if (decimal.TryParse(node["ForexBuying"].InnerText.Replace(".", ","), out decimal forexBuying))
    {
        exchange.ForexBuying = forexBuying;
    }
    if (decimal.TryParse(node["ForexSelling"].InnerText.Replace(".", ","), out decimal forexSelling))
    {
        exchange.ForexSelling = forexSelling;
    }
    if (decimal.TryParse(node["BanknoteBuying"].InnerText.Replace(".", ","), out decimal banknoteBuying))
    {
        exchange.ForexBuying = forexBuying;
    }
    if (decimal.TryParse(node["BanknoteSelling"].InnerText.Replace(".", ","), out decimal banknoteSelling))
    {
        exchange.ForexSelling = forexSelling;
    }
    Console.WriteLine($"{exchange.Currency.Trim()} ({exchange.CurrencyCode}):");
    Console.WriteLine($"( {exchange.CurrencyCode} / TRY )");
    Console.WriteLine($"Unit: {exchange.Unit}");
    Console.WriteLine($"Forex Buying: {exchange.ForexBuying}");
    Console.WriteLine($"Forex Selling: {exchange.ForexSelling}");
    Console.WriteLine($"Banknote Buying: {exchange.ForexSelling}");
    Console.WriteLine($"Banknote Selling: {exchange.ForexSelling}");
    Console.WriteLine();
}
public class Exchange
{
    public string CurrencyCode { get; set; }
    public Int16 Unit { get; set; }
    public string Currency { get; set; }
    public decimal ForexBuying { get; set; }
    public decimal ForexSelling { get; set; }
    public decimal BanknoteBuying { get; set; }
    public decimal BanknoteSelling { get; set; }
}
