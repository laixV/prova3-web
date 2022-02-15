using System.Threading.Tasks;

namespace Super_Market.Domain.Repositories
{
    public interface IUnityOfWork
    {
        Task CompleteAsync();
    }
}