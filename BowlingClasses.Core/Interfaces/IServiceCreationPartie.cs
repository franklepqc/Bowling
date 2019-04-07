namespace BowlingClasses.Core.Interfaces
{
    public interface IServiceCreationPartie
    {
        /// <summary>
        /// Créer une partie et préparer le nombre des joueurs.
        /// </summary>
        /// <param name="nombreJoueurs">Nombre de joueurs.</param>
        /// <returns>Partie.</returns>
        IPartie Creer(int nombreJoueurs);

        /// <summary>
        /// Créer une partie et préparer via l'équipe.
        /// </summary>
        /// <param name="equipe">Équipe.</param>
        /// <returns>Partie.</returns>
        IPartie Creer(IEquipe equipe);

        /// <summary>
        /// Créer une partie selon le nom de joueurs.
        /// </summary>
        /// <param name="nomsJoueurs">Noms.</param>
        /// <returns>Partie.</returns>
        IPartie Creer(params string[] nomsJoueurs);
    }
}
