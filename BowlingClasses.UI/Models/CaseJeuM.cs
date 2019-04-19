using BowlingClasses.Core.Interfaces;
using Prism.Mvvm;
using System;
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
        /// Premier essai.
        /// </summary>
        public string PremierEssai =>
            (_caseJeu.Essais[0] == 10 ? "X" : _caseJeu.Essais[0].ToString());

        /// <summary>
        /// Deuxième essai.
        /// </summary>
        public string DeuxiemeEssai => ObtenirCaractere(1);

        /// <summary>
        /// Troisième essai.
        /// </summary>
        public string TroisiemeEssai => ObtenirCaractere(2);

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
            RaisePropertyChanged(nameof(PremierEssai));
            RaisePropertyChanged(nameof(DeuxiemeEssai));
            RaisePropertyChanged(nameof(TroisiemeEssai));
        }

        /// <summary>
        /// Obtenir le caractère selon l'index.
        /// </summary>
        /// <param name="indexActuel">Index actuel.</param>
        /// <returns>Caractère à afficher.</returns>
        private string ObtenirCaractere(int indexActuel)
        {
            if (indexActuel >= _caseJeu.Essais.Length) return string.Empty;

            int indexPrecedent = indexActuel - 1;
            var actuel = _caseJeu.Essais[indexActuel];
            var precedent = _caseJeu.Essais[indexPrecedent];

            if (EstDixiemeCarreau && actuel == 10)
            {
                return "X";
            }
            else if (!EstDixiemeCarreau && (actuel + precedent) == 10)
            {
                return "/";
            }
            else if (EstDixiemeCarreau && indexActuel == 1 && (actuel + precedent) == 10)
            {
                return "/";
            }
            else if (EstDixiemeCarreau && indexActuel == 2 && (actuel + precedent + _caseJeu.Essais[indexActuel - 2]) == 20)
            {
                return "/";
            }
            else
            {
                return actuel.ToString();
            }
        }
    }
}
