using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagingController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly ICounter _counter;
        private readonly IAnotherService _anotherService;

        public MessagingController(IMessageService messageService,
            ICounter counter,
            IAnotherService anotherService)
        {
            _messageService = messageService;
            _counter = counter;
            _anotherService = anotherService;
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            _messageService.SendMessage("some message");
            _anotherService.DoSomeWork();

            var value = _counter.GetValue();

            return Ok(value);
        }
    }
}