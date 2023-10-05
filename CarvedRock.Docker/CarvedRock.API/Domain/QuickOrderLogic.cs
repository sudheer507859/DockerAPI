using CarvedRock.API.APIModels;
using CarvedRock.API.Interfaces;

namespace CarvedRock.API.Domain
{
    public class QuickOrderLogic : IQuickOrder
    {
        private readonly ILogger<QuickOrderLogic> logger;
        
        public QuickOrderLogic(ILogger<QuickOrderLogic> logger)
        {
            this.logger = logger;
        }

        public int CreateOrder(QuickOrder request, int customeID)
        {
            this.logger.LogInformation("Placing an order and sending update for inventory.");

            return new Random().Next();
        }
    }
}
