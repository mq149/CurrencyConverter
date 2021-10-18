using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Controllers
{
    public class ConverterController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Convert(float amount, float exchangeRate)
        {
            Models.Converter converter = new Models.Converter(amount, exchangeRate);
            converter.convert();
            return View("Index", converter);
        }

        public string AjaxConvert(float amount, float exchangeRate)
        {
            Models.Converter converter = new Models.Converter(amount, exchangeRate);
            converter.convert();
            return converter.resultString;
        }
    }
}