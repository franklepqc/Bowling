namespace BowlingClasses.Core.Interfaces
{
    public interface IPartie
    {
        ICase[] Cases { get; }

        IEquipe Equipe { get; }

        int NoCaseCourante { get; }

        int ObtenirScore();

        bool AjouterLancer(int lancer);

        void AjouterLancers(params int[] lancers);
    }
}
