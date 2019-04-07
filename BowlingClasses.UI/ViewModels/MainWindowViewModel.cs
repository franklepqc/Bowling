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
        /// Service de création d'une partie.
        /// </summary>
        private readonly IServiceCreationPartie _serviceCreationPartie;
        private readonly IServiceCalculScore _serviceCalculScore;

        /// <summary>
        /// Partie en cours.
        /// </summary>
        private IPartie _partie;

        /// <summary>
        /// Lancer.
        /// </summary>
        private int? _lancer;

        /// <summary>
        /// Commande pour ajouter un lancer.
        /// </summary>
        public DelegateCommandBase CommandeAjouterLancer { get; private set; }

        /// <summary>
        /// Lancer à ajouter.
        /// </summary>
        public int? Lancer
        {
            get => _lancer;
            set
            {
                _lancer = value;
                RaisePropertyChanged();
                CommandeAjouterLancer.RaiseCanExecuteChanged();
            }
        }

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
            CommandeAjouterLancer = new DelegateCommand<PartieJoueurM>(
                AjouterLancer, 
                (pjm) => pjm != null && Lancer.HasValue);

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
            _partie.Equipe.Joueurs
                .ToList()
                .ForEach(joueur =>
                {
                    PartieJoueurs.Add(new PartieJoueurM(joueur, _partie.Cases));
                });
        });

        /// <summary>
        /// Ajoute le lancer.
        /// </summary>
        private void AjouterLancer(PartieJoueurM partieJoueur)
        {
            if (_partie.AjouterLancer(Lancer.Value))
            {
                partieJoueur.CasesJeu
                    .ToList()
                    .ForEach((caseJeu) => {
                        caseJeu.SignalerChangement();

                        caseJeu.Score = _serviceCalculScore.Calculer(
                            partieJoueur.CasesJeu
                            .Take(System.Math.Min(10, partieJoueur.CasesJeu.IndexOf(caseJeu) + 3))
                            .SelectMany(k => 
                                k.Essais
                                    .Where(p => p.HasValue)
                                    .Select(k => k.Value))
                            .ToArray());
                    });
            }
        }
    }
}
