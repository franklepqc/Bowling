using System.IO;

namespace BowlingClasses.Core.Interfaces
{
    public interface IServicePreJoue
    {
        bool EntrerScore(Stream lecture, IPartie partie, int indexJoueur);
    }
}
