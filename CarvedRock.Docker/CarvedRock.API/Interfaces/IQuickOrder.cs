using CarvedRock.API.APIModels;

namespace CarvedRock.API.Interfaces
{
    public interface IQuickOrder
    {
        int CreateOrder(QuickOrder request, int customeID);
    }
}
