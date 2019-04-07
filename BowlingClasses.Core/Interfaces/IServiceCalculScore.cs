using System.Threading.Tasks;

namespace BowlingClasses.Core.Interfaces
{
    public interface IServiceCalculScore
    {
        Task<int> CalculerAsync(int[] lancers);
    }
}
