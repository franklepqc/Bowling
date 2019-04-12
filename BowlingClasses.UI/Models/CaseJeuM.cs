using BowlingClasses.Core.Interfaces;
using Prism.Mvvm;
using System.Linq;

namespace BowlingClasses.UI.Models
{
    public class CaseJeuM : BindableBase
    {
        /// <summary>
        /// Case de jeu (données).
        /// </summary>
        private ICase _caseJeu;

        /// <summary>
        /// Essais du joueur.
        /// </summary>
        public int?[] Essais => _caseJeu.Essais;

        /// <summary>
        /// Score à afficher.
        /// </summary>
        public int? Score => _caseJeu.Score;

        /// <summary>
        /// Détermine si c'est le dixième carreau.
        /// </summary>
        public bool EstDixiemeCarreau => _caseJeu.EstDixiemeCarreau;

        /// <summary>
        /// Index de la case.
        /// </summary>
        public int IndexCase { get; private set; }

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        /// <param name="caseJeu">Case de jeu.</param>
        /// <param name="indexCase">Index la case pour le positionnement.</param>
        public CaseJeuM(ICase caseJeu, int indexCase)
        {
            // Case de jeu.
            _caseJeu = caseJeu;
            IndexCase = indexCase;
        }

        /// <summary>
        /// Signaler à l'interface que les essais ont changé.
        /// </summary>
        public void SignalerChangement()
        {
            RaisePropertyChanged(nameof(Score));
            RaisePropertyChanged(nameof(Essais));
        }
    }
}
