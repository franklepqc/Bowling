using BowlingClasses.Core.Interfaces;
using BowlingClasses.UI.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BowlingClasses.UI.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// Services à injecter.
        /// </summary>
        private readonly IServiceCreationPartie _serviceCreationPartie;
        private readonly IServiceCalculScore _serviceCalculScore;

        /// <summary>
        /// Partie en cours.
        /// </summary>
        private IPartie _partie;

        /// <summary>
        /// Commande pour ajouter un lancer.
        /// </summary>
        public DelegateCommandBase CommandeAjouterLancer { get; private set; }

        /// <summary>
        /// Liste des cases de jeu.
        /// </summary>
        public ObservableCollection<PartieJoueurM> PartieJoueurs { get; private set; } = new ObservableCollection<PartieJoueurM>();

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        /// <param name="serviceCreationPartie">Service de création d'une partie.</param>
        public MainWindowViewModel(IServiceCreationPartie serviceCreationPartie, IServiceCalculScore serviceCalculScore)
        {
            // Assignation des objets injectés.
            _serviceCreationPartie = serviceCreationPartie;
            _serviceCalculScore = serviceCalculScore;

            // Assignation des commandes.
            CommandeAjouterLancer = new DelegateCommand<string>(
                AjouterLancer);

            InitialiserAsync();
        }

        /// <summary>
        /// Initialiser les cases.
        /// </summary>
        /// <returns>Cases.</returns>
        private Task InitialiserAsync() => Task.Run(() =>
        {
            // Réinitialiser.
            _partie = null;
            _partie = _serviceCreationPartie.Creer(6);

            // Réinitialiser.
            PartieJoueurs.Clear();

            // Ajouter.
            for (int iCptJoueurs = 0; iCptJoueurs < _partie.Equipe.Joueurs.Length; iCptJoueurs++)
            {
                PartieJoueurs.Add(new PartieJoueurM(_partie.Equipe.Joueurs[iCptJoueurs], _partie.Cases[iCptJoueurs]));
            }
        });

        /// <summary>
        /// Ajoute le lancer.
        /// </summary>
        private void AjouterLancer(string lancerStr)
        {
            // Variables de travail.
            var lancer = System.Convert.ToInt32(lancerStr);
            var noCase = _partie.IndexCase + 1;
            var partieJoueur = PartieJoueurs[_partie.IndexJoueur];

            if (_partie.AjouterLancer(lancer))
            {
                partieJoueur.CasesJeu
                    .Take(noCase)
                    .ToList()
                    .ForEach((caseJeu) =>
                    {
                        caseJeu.SignalerChangement();

                        // Calculer le score en cours.
                        caseJeu.Score = _serviceCalculScore.Calculer(
                            partieJoueur.CasesJeu
                            .SelectMany(k =>
                                k.Essais
                                    .Where(p => p.HasValue)
                                    .Select(k => k.Value))
                            .ToArray(),
                            System.Math.Min(10, partieJoueur.CasesJeu.IndexOf(caseJeu) + 1));
                    });
            }
        }
    }
}
