namespace BowlingClasses.Core.Interfaces
{
    public interface IPartie
    {
        ICase[] Cases { get; }

        IEquipe Equipe { get; }

        int NoCaseCourante { get; }

        bool AjouterLancer(int lancer);
    }
}
