using System.Collections.Generic;

namespace BowlingClasses.Core.Interfaces
{
    public interface IPartie
    {
        ICase[][] Cases { get; }

        IEquipe Equipe { get; }
        Dictionary<int, int> IndexCaseParJoueur { get; }
        int IndexJoueur { get; }

        bool AjouterLancer(int lancer, int? ixJoueur = null);
    }
}
