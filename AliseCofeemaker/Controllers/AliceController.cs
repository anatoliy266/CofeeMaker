using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using StranzitOnline.Common.Models;
using System.Linq;
//using StranzitOnline.Common.Models.Settings.Base;
//using System.Web.Http;

namespace AliseCofeemaker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AliceController : ControllerBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //private IBaseWebServiceSettings Settings { get; set; }

        //public AliceController(IBaseWebServiceSettings settings)
        public AliceController()
        {
            //Settings = settings;
        }

        [HttpPost]
        //api/Alice
        public AliceResponse CofeeRequest([FromBody] AliceRequest aliceRequest)
        {
            logger.Debug("Получен запрос от Алисы: " + JsonConvert.SerializeObject(aliceRequest));
            switch (aliceRequest.Session.SkillId)
            {
                case "CoffeskillID":
                    {
                        if (aliceRequest.Request.OriginalUtterance.Contains("Сделай кофе"))
                        {

                        }
                        else if (aliceRequest.Request.OriginalUtterance.Contains("Долго еще?"))
                        {

                        }
                        else return aliceRequest.Reply("Непонятно, повторите", "Непон+ятно, повтор+ите");
                    }
                default:
                    {
                        return aliceRequest.Reply("Неизвестная команда", "Неизв+естная ком+анда", true);
                        //break;
                    }
            }
            //var response = aliceRequest.Reply(aliceRequest.Request.OriginalUtterance, true);
            //logger.Debug("Отправляю ответ: " + JsonConvert.SerializeObject(response));
            //return response;
        }

        
    }
}