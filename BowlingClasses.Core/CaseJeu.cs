namespace BowlingClasses.Core
{
    public class CaseJeu : Interfaces.ICase
    {
        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        /// <param name="nombreEssais">Nombre d'essai.</param>
        public CaseJeu(int nombreEssais)
        {
            Essais = new int?[nombreEssais];
        }

        /// <summary>
        /// Essais.
        /// </summary>
        public int?[] Essais { get; private set; }

        /// <summary>
        /// Score de la case.
        /// </summary>
        public int? Score { get; private set; }
    }
}
