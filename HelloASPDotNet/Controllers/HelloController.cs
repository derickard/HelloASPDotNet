using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloASPDotNet.Controllers
{
    [Route("/helloworld")]
    public class HelloController : Controller
    {
      
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post' action='/helloworld/'>" + 
                "<input type='text' name='name'>" +
                "<select name='lang' >" +
                    "<option value='english' selected>EN</option>" +
                    "<option value='chinese'>ZH</option>" +
                    "<option value='german'>DE</option>" +
                    "<option value='russian'>RU</option>" +
                    "<option value='spanish'>ES</option>" +
                "</select>" +
                "<input type='submit' value='Greet me!' />" +
                "</form>";
            return Content(html,"text/html");
        }

        // GET: /hello/welcome
        //[HttpGet]
        //[Route("/helloworld/welcome/{name?}")]
        [HttpGet("welcome/{lang}/{name?}")]
        [HttpPost]
        public IActionResult Welcome(string lang = "english", string name = "World")
        {
            return Content($"<h1>{CreateMessage(lang,name)}</h1>", "text/html", Encoding.UTF8);
        }

        public static string CreateMessage(string lang, string name)
        {
            Dictionary<string, string> langGreeting = new Dictionary<string, string>();
            langGreeting["english"] = "Welcome";
            langGreeting["chinese"] = "欢迎";
            langGreeting["german"] = "willkommen heißen";
            langGreeting["russian"] = "добро пожаловать";
            langGreeting["spanish"] = "Bienvenido";

            return new string($"{langGreeting[lang]}, {name}!");
        }


    }
}
