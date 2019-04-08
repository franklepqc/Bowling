namespace BowlingClasses.Core.Interfaces
{
    public interface IPartie
    {
        ICase[][] Cases { get; }

        IEquipe Equipe { get; }
        int IndexCase { get; }
        int IndexJoueur { get; }

        bool AjouterLancer(int lancer, int? ixJoueur = null, int? ixCase = null);
    }
}
