using System.Collections.ObjectModel;

namespace BowlingClasses.UI.Models
{
    public class PartieJoueurM
    {
        /// <summary>
        /// Indexs pour les calculs.
        /// </summary>
        private int _indexEssai = 1;
        private int _indexCase = 1;
        private int _indexScoreCase = 1;

        /// <summary>
        /// Nom du joueur.
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Cases du jeu.
        /// </summary>
        public ObservableCollection<CaseJeuM> CasesJeu { get; private set; } = new ObservableCollection<CaseJeuM>();

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public PartieJoueurM()
        {
            // Initialisation des cases.
            for (int i = 0; i < 10; i++) CasesJeu.Add(new CaseJeuM((i == 9)));
        }
    }
}
