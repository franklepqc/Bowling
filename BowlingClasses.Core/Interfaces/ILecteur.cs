using System.IO;

namespace BowlingClasses.Core.Interfaces
{
    public interface ILecteur
    {
        int[] Lire(Stream stream);
    }
}
