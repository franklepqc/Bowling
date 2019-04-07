namespace BowlingClasses.Core.Interfaces
{
    public interface IPartieEquipe
    {
        IEquipe Equipe { get; }

        IPartie Partie { get; }

        bool AjouterLancers(params int[] lancer);

        bool AjouterLancer(int lancer);
    }
}
