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
        public string PremierEssai => ObtenirCaracterePremierEssai();

        /// <summary>
        /// Deuxième essai.
        /// </summary>
        public string DeuxiemeEssai => ObtenirCaractereDeuxiemeEssai(_caseJeu.Essais[1], _caseJeu.Essais[0]);

        /// <summary>
        /// Troisième essai.
        /// </summary>
        public string TroisiemeEssai => ObtenirCaractereTroisiemeEssai();

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
        private string ObtenirCaracterePremierEssai()
        {
            var lancer = _caseJeu.Essais[0];

            // Variables de travail.
            if (!lancer.HasValue)
            {
                return string.Empty;
            }
            else if (lancer.Value == 0)
            {
                return "-";
            }
            else if (lancer.Value == 10)
            {
                return "X";
            }
            else
            {
                return lancer.Value.ToString();
            }
        }

        /// <summary>
        /// Obtenir le caractère selon l'index.
        /// </summary>
        /// <param name="indexActuel">Index actuel.</param>
        /// <returns>Caractère à afficher.</returns>
        private string ObtenirCaractereDeuxiemeEssai(int? lancer, int? lancerPrecedent)
        {
            // Variables de travail.
            if (!(lancer.HasValue && lancerPrecedent.HasValue))
            {
                return string.Empty;
            }
            else if (lancer.Value == 0)
            {
                return "-";
            }
            else if (EstDixiemeCarreau && lancer.Value == 10 && lancerPrecedent.Value != 0)
            {
                return "X";
            }
            else if (lancer.Value + lancerPrecedent.Value == 10)
            {
                return "/";
            }
            else
            {
                return lancer.Value.ToString();
            }
        }

        /// <summary>
        /// Obtenir le caractère selon l'index.
        /// </summary>
        /// <param name="indexActuel">Index actuel.</param>
        /// <returns>Caractère à afficher.</returns>
        private string ObtenirCaractereTroisiemeEssai()
        {
            // Variables de travail.
            if (EstDixiemeCarreau)
            {
                if (_caseJeu.Essais[0].HasValue && 
                    _caseJeu.Essais[2].HasValue &&
                    _caseJeu.Essais[0].Value != 10 &&
                    _caseJeu.Essais[0].Value == _caseJeu.Essais[2].Value)
                {
                    return _caseJeu.Essais[2].Value.ToString();
                }
                else
                {
                    return ObtenirCaractereDeuxiemeEssai(_caseJeu.Essais[2], _caseJeu.Essais[1]);
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
