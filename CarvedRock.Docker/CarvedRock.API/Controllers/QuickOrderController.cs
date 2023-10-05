using CarvedRock.API.APIModels;
using CarvedRock.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarvedRock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuickOrderController : ControllerBase
    {
        private readonly IQuickOrder quickOrder;
        private readonly ILogger<QuickOrderController> logger;  

        public QuickOrderController(IQuickOrder quickOrder, ILogger<QuickOrderController> logger)
        {
            this.quickOrder = quickOrder;
            this.logger = logger;
        }


        [HttpPost]
        public int CreateQuickOrder(QuickOrder quickOrderRequest)
        {
            this.logger.LogInformation("Starting controller action to createquickorder.");
            return this.quickOrder.CreateOrder(quickOrderRequest, 123);
        }
    }
}
