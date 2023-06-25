using HoursCalculatorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HoursCalculatorWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(object sender, EventArgs e, CalculatorModel cal)
        {
            int sH, sM, eH, eM;
            int eleventhHour = 11;//11th hour
            string AP1,AP2;
            sH = cal.StartHour;
            sM = cal.StartMinute;
            eH = cal.EndHour;
            eM = cal.EndMinute;
            AP1 = cal.AmPM1;
            AP2 = cal.AmPM2;
     

            if(cal.calculate == "Submit") //When the user presses the submit button
            {
                if (AP1 == "PM" && AP2 == "PM")
                {
                    if (sH == eH && sM == eM)
                    {
                        cal.Hour_result = 0;
                        cal.Minute_result = 0;
                    }
                    if (sH > eH && sM > eM)
                    {
                        sH += 12;
                        eH += 11;
                        eM += 60;

                        cal.Hour_result = (eH) + (eleventhHour - sH);
                        cal.Minute_result = (eM - sM);
                    }
                    if (sH > eH && sM == eM)
                    {
                        eleventhHour += 12;
                        sH += 12;
                        eH += 12;

                        cal.Hour_result = (eH + 1) + (eleventhHour - sH);
                        cal.Minute_result = eM - sM;
                    }
                    if (sH > eH && sM < eM)
                    {
                        eleventhHour += 12;
                        sH += 12;
                        eH += 12;

                        cal.Hour_result = (eH + 1) + (eleventhHour - sH);
                        cal.Minute_result = eM - sM;
                    }
                    if (sH < eH && sM > eM) 
                    {
                        eM += 60;
                        eH -= 1;
                        cal.Hour_result = eH - sH;
                        cal.Minute_result = eM - sM;
                    }
                    if (sH < eH && sM == eM)
                    {
                        cal.Hour_result = eH - sH;
                        cal.Minute_result = eM - sM;
                    }
                    if (sH < eH && sM < eM)
                    {
                        cal.Hour_result = eH - sH;
                        cal.Minute_result = eM - sM;
                    }
                    if (sH == eH && sM < eM)
                    {
                        cal.Hour_result = sH - eH;
                        cal.Minute_result = eM - sM;
                    }
                    if (sH == eH && sM > eM)
                    {
                        eleventhHour += 12;
                        eM += 60;
                        sH += 12;
                        eH += 12;
                        cal.Hour_result = eH + (eleventhHour - sH);
                        cal.Minute_result = eM - sM;
                    }

                } //GOOD
                else if (AP1 == "AM" && AP2 == "AM")
                {                  
                    if (sH == eH && sM == eM)
                    {
                        cal.Hour_result = 0;
                        cal.Minute_result = 0;
                    }
                    if (sH > eH && sM > eM) 
                    {
                     
                        eH += 12;
                        eM += 60;

                        cal.Hour_result = eH + (eleventhHour - sH);
                        cal.Minute_result = eM - sM;
                    }
                    if (sH > eH && sM == eM) 
                    {
                        eleventhHour += 12;
                        sH += 12;
                        eH += 12;

                        cal.Hour_result = (eH + 1) + (eleventhHour - sH);
                        cal.Minute_result = eM - sM;
                    }
                    if (sH > eH && sM < eM) 
                    {
                        eleventhHour += 12;
                        sH += 12;
                        eH += 12;

                        cal.Hour_result = (eH + 1) + (eleventhHour - sH);
                        cal.Minute_result = eM - sM;
                    }
                    if (sH < eH && sM > eM) 
                    {
                        eM += 60;
                        eH -= 1;
                        cal.Hour_result = eH - sH;
                        cal.Minute_result = eM - sM;
                    }
                    if (sH < eH && sM == eM) 
                    {
                        cal.Hour_result = eH - sH;
                        cal.Minute_result = eM - sM;
                    }
                    if (sH < eH && sM < eM)
                    {
                        cal.Hour_result = eH - sH;
                        cal.Minute_result = eM - sM;
                    }
                    if (sH == eH && sM < eM)
                    {
                        cal.Hour_result = sH - eH;
                        cal.Minute_result = eM - sM;
                    }
                    if (sH == eH && sM > eM) 
                    {
                        eleventhHour += 12;
                        eM += 60;
                        sH += 12;
                        eH += 12;
                        cal.Hour_result = eH + (eleventhHour - sH);
                        cal.Minute_result = eM - sM;
                    }
                }
                else if (AP1 == "AM" && AP2 == "PM")
                {
                    if (sH == eH && sM == eM)
                    {
                        cal.Hour_result = 12;
                        cal.Minute_result = 0;
                    }
                    if (sH > eH && sM == eM || sH < eH && sM == eM)
                    {

                        cal.Hour_result = (eH - sH);
                        cal.Minute_result = (sM - eM);

                    }
                    if (sH < eH && sM < eM)
                    {
                        eH += 12;
                        cal.Hour_result = (eH - sH);
                        cal.Minute_result = (eM - sM);

                    }
                    if (sH < eH && sM > eM)
                    {
                        eH += 12;
                        eM += 60;
                        eH -= 1;

                        cal.Hour_result = (eH - sH);
                        cal.Minute_result = (eM - sM);
                    }
                    if (sH > eH && sM < eM)
                    {
                        eH += 12;
                        cal.Hour_result = eH - sH;
                        cal.Minute_result = (eM - sM);

                    }
                    if (sH > eH && sM > eM)
                    {
                        eH += 12;
                        eM += 60;
                        eH -= 1;

                        cal.Hour_result = (eH - sH);
                        cal.Minute_result = (eM - sM);
                    }
                    if (sH == eH && sM > eM)
                    {
                        eH += 12;
                        eM += 60;
                        cal.Hour_result = (eH - sH) - 1;
                        cal.Minute_result = (eM - sM);

                    }
                    if (sH == eH && sM < eM)
                    {
                        eH += 12;
                        cal.Hour_result = (eH - sH);
                        cal.Minute_result = (eM - sM);
                    }

                }
                else if (AP1 == "PM" && AP2 == "AM")
                {
                    
                    if (sH == eH && sM == eM)
                    {
                        cal.Hour_result = 12;
                        cal.Minute_result = 0;
                    }
                    if (sH > eH && sM > eM) 
                    {
                        eleventhHour += 12;
                        sH += 12;
                        cal.Hour_result = ((eleventhHour + eH) - sH);
                        cal.Minute_result = ((60 + eM) - sM);
                    }
                    if (sH > eH && sM < eM)
                    {
                        eleventhHour += 12;
                        sH += 12;
                        cal.Hour_result = ((eleventhHour + eH) - sH) + 1;
                        cal.Minute_result = (eM - sM);
                    }
                    if (sH < eH && sM > eM)
                    {
                        eleventhHour += 12;
                        sH += 12;
                        cal.Hour_result = ((eleventhHour + eH) - sH);
                        cal.Minute_result = ((60 + eM) - sM);
                    }
                    if (sH < eH && sM < eM)
                    {
                        eleventhHour += 12;
                        sH += 12;
                        cal.Hour_result = ((eleventhHour + eH) - sH) + 1;
                        cal.Minute_result = (eM - sM);
                    }
                    if (sH == eH && sM > eM)
                    {
                        sH += 12;
                        eM += 60;
                        cal.Hour_result = (sH - eH) - 1;
                        cal.Minute_result = (eM - sM);


                    }
                    if (sH == eH && sM < eM)
                    {
                        sH += 12;
                        cal.Hour_result = sH - eH;
                        cal.Minute_result = eM - sM;
                    }
                    if (sH > eH && sM == eM )
                    {

                        cal.Hour_result = (sH - eH);
                        cal.Minute_result = (sM - eM);

                    }
                    if (sH < eH && sM == eM)
                    {
                        cal.Hour_result = (eH - sH);
                        cal.Minute_result = (sM - eM);

                    }

                }

            } 
            //if(cal.Resetting == "Reset") //trying to add a reset button to the Form,not sure how
            //{
            //    cal.StartHour = 0;
            //    cal.StartMinute = 0;
            //    cal.EndHour = 0;
            //    cal.EndMinute = 0;
            //    cal.AmPM1 = string.Empty;
            //    cal.AmPM2 = "";
            //    cal.Hour_result = 0;
            //    cal.Minute_result = 0;
            //}

            ViewData["Hour_result"] = cal.Hour_result;
            ViewData["Minute_result"] = cal.Minute_result;

            return View();
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