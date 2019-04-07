namespace BowlingClasses.Core.Interfaces
{
    interface IPartieEquipe
    {
        IEquipe Equipe { get; }

        IPartie Partie { get; }

        bool AjouterLancers(params int[] lancer);

        bool AjouterLancer(int lancer);
    }
}
