using _0105CurrencyApp.Dtos;
using _0105CurrencyApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _0105CurrencyApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        [HttpPost]
        public IActionResult List(DateFormat date)
        {
            if (date.SelectedDate != null)
            {
                int currentDate = int.Parse(date.SelectedDate.ToString("yyyyMMdd"));
                int previousDate = int.Parse(date.SelectedDate.AddDays(-1).ToString("yyyyMMdd"));

                string url = "http://www.lb.lt//webservices/ExchangeRates/ExchangeRates.asmx/getExchangeRatesByDate?Date=" + currentDate;
                XElement source = XElement.Load(url);
                List<Currency> currencies = new List<Currency>();
                foreach (var item in source.Elements())
                {
                    Currency currency = new Currency();
                    currency.Name = item.Element("currency").Value;
                    currency.Rate = Convert.ToDouble(item.Element("rate").Value);
                    currency.Quantity = Convert.ToInt32(item.Element("quantity").Value);
                    currency.Unit = item.Element("unit").Value;
                    currencies.Add(currency);
                }

                string url2 = "http://www.lb.lt//webservices/ExchangeRates/ExchangeRates.asmx/getExchangeRatesByDate?Date=" + previousDate;
                XElement source2 = XElement.Load(url2);
                List<Currency> currencies2 = new List<Currency>();
                foreach (var item in source2.Elements())
                {
                    Currency currency = new Currency();
                    currency.Name = item.Element("currency").Value;
                    currency.Rate = Convert.ToDouble(item.Element("rate").Value);
                    //currency.Quantity = Convert.ToInt32(item.Element("quantity").Value);
                    //currency.Unit = item.Element("unit").Value;
                    currencies2.Add(currency);
                }

                List<RateDTO> rates = new List<RateDTO>();
                for (int i = 0; i < currencies.Count; i++)
                {
                    if (currencies[i].Name == currencies2[i].Name)
                    {
                        rates.Add(new RateDTO()
                        {
                            Name = currencies[i].Name,
                            Name2 = currencies2[i].Name,
                            CurrentRate = currencies[i].Rate,
                            PreviousRate = currencies2[i].Rate,
                            RateDifference = Math.Round(currencies[i].Rate - currencies2[i].Rate, 4),
                            Quantity = currencies[i].Quantity,
                            Unit = currencies[i].Unit
                        });
                    }
                    //else
                    //{
                    //    rates.Add(new RateDTO()
                    //    {
                    //        Mismatch = currencies[i].Name
                    //    });
                    //}
                }
                List<RateDTO> orderedRates = rates.OrderByDescending(x => x.RateDifference).ToList();

                return View(orderedRates);
            }
            else
            {
                
                return View();
            }
        }

        public IActionResult Index()
        {
            DateFormat startTime = new DateFormat();
            startTime.SelectedDate = DateTime.Parse("2014-09-01");
            return View(startTime);
        }

        [HttpPost]
        public IActionResult Index(DateFormat date)
        {

            return RedirectToAction("List", new { date = date });
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
