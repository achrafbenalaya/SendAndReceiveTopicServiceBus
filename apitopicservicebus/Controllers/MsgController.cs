using apitopicservicebus.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apitopicservicebus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MsgController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Send([FromBody] SendMessageDto mesaage)
        {
            try
            {
                var topicClent = ServiceBusHelper.GetTopicClient();
                await topicClent.SendAsync(new Message(Encoding.UTF8.GetBytes(mesaage.Value)));

                return StatusCode(200);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }

    public class SendMessageDto
    {
        public string Value { get; set; }
    }
}

