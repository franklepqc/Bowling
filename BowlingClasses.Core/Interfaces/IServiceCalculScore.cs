using System.Threading.Tasks;

namespace BowlingClasses.Core.Interfaces
{
    public interface IServiceCalculScore
    {
        int Calculer(int[] lancers, int noCaseCourante = 10);
    }
}
