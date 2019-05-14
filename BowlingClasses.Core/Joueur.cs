namespace BowlingClasses.Core
{
    /// <summary>
    /// Joueur.
    /// </summary>
    public class Joueur : Interfaces.IJoueur
    {
        public Joueur(string nom)
        {
            Nom = nom;
        }

        /// <summary>
        /// Nom.
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Absent ou non.
        /// </summary>
        public bool EstAbsent { get; set; }
    }
}
