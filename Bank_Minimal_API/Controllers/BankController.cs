using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Minimal_API.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class BankController : ControllerBase
    {
        [HttpGet]
        public double TVA(int price, string country)
        {
            switch (country)
            {
                case "BE":
                    return price * 1.21;
                    break;
                case "FR":
                    return price * 1.20;
                    break;
                default: return 0;
            }
        }
    }
}

