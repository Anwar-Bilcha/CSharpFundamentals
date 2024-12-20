using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace OOPinCSharp
{
    public interface ICurrencyConvertor
    {
        public decimal currencyAmount { get; set; }
        public string currencyCode { get; set; }
        decimal ETB2USD(decimal amount);
        decimal USD2ETB(decimal amount);

    }
    public class CurrencyConvertor : ICurrencyConvertor
    {
        public decimal currencyAmount { get; set; }
        public string currencyCode { get; set; } = "ETB";

        public decimal ETB2USD(decimal amount)
        {
            return amount / 128;
        }

        public decimal USD2ETB(decimal amount)
        {
            return amount * 128;        }
        public static void Main22(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<ICurrencyConvertor, CurrencyConvertor>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var currencyConvertorService = serviceProvider.GetRequiredService<ICurrencyConvertor>();
            Console.WriteLine($"{259} USD is : {currencyConvertorService.USD2ETB(259)}");
            Console.WriteLine($"{12259} ETB is : {currencyConvertorService.ETB2USD(12259)}");

        }
    }
}
