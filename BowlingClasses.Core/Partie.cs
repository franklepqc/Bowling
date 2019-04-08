using BowlingClasses.Core.Interfaces;

namespace BowlingClasses.Core
{
    public class Partie : IPartie
    {
        /// <summary>
        /// Cases du jeu.
        /// </summary>
        public ICase[][] Cases { get; set; }

        /// <summary>
        /// Équipe.
        /// </summary>
        public IEquipe Equipe { get; set; }

        /// <summary>
        /// Index de la case à jouer.
        /// </summary>
        public int IndexCase { get; private set; }

        /// <summary>
        /// Index du joueur.
        /// </summary>
        public int IndexJoueur { get; private set; }

        /// <summary>
        /// Ajout d'un lancer.
        /// </summary>
        /// <param name="lancer">Nombre de quilles abattues.</param>
        /// <returns>Vrai si l'opération est une réussite.</returns>
        public bool AjouterLancer(int lancer, int? ixJoueur = null, int? ixCase = null)
        {
            // Variables de travail.
            var indexJoueur = (ixJoueur ?? IndexJoueur);
            var indexCase = (ixCase ?? IndexCase);

            if (indexJoueur < Equipe.Joueurs.Length && indexCase < 10)
            {
                var essais = Cases[indexJoueur][indexCase].Essais;

                if (!essais[0].HasValue)
                {
                    essais[0] = lancer;

                    if (indexCase < 9 && 10 == lancer)
                    {
                        Suivant();
                    }
                }
                else if (!essais[1].HasValue)
                {
                    // Réserve, calcul automatisé.
                    if (lancer == 10)
                    {
                        lancer -= essais[0].Value;
                    }
                    // On a voulu jouer au fin fineau!
                    else if ((lancer + essais[0].Value) > 10)
                    {
                        return false;
                    }

                    essais[1] = lancer;

                    // Si on ne se trouve pas au 10ième carreau.
                    if (indexCase < 9)
                    {
                        Suivant();
                    }
                    // Si on se trouve au 10ième et que la deuxième chance est ratée.
                    else if (indexCase == 9 && (essais[0].Value + essais[1].Value < 10))
                    {
                        Suivant();
                    }
                }
                else if (indexCase == 9 && essais.Length == 3 && !essais[2].HasValue)
                {
                    essais[2] = lancer;
                    Suivant();
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Passe au suivant. Si les joueurs ont tous joué, on va au prochain carreau.
        /// </summary>
        private void Suivant()
        {
            // Si tous les joueurs ont joué.
            if (++IndexJoueur >= Equipe.Joueurs.Length)
            {
                IndexJoueur = 0;
                IndexCase++;
            }
        }
    }
}
