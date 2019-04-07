using BowlingClasses.Core.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BowlingClasses.UI.Models
{
    public class PartieJoueurM
    {
        /// <summary>
        /// Joueur.
        /// </summary>
        private readonly IJoueur _joueur;

        /// <summary>
        /// Nom du joueur.
        /// </summary>
        public string Nom => _joueur.Nom;

        /// <summary>
        /// Cases du jeu.
        /// </summary>
        public ObservableCollection<CaseJeuM> CasesJeu { get; private set; } = new ObservableCollection<CaseJeuM>();

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public PartieJoueurM(IJoueur joueur, IEnumerable<ICase> casesJeu)
        {
            // Initialisation.
            _joueur = joueur;
            casesJeu.ToList()
                .ForEach(caseJeu => CasesJeu.Add(new CaseJeuM(caseJeu)));
        }
    }
}
