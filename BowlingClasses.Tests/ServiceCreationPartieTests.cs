using BowlingClasses.Core;
using BowlingClasses.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BowlingClasses.Tests
{
    [TestClass]
    public class ServiceCreationPartieTests
    {
        /// <summary>
        /// Conteneur.
        /// </summary>
        private static IServiceCreationPartie _service;

        /// <summary>
        /// Initialisation du service.
        /// </summary>
        /// <param name="testContext">Contexte de test.</param>
        [ClassInitialize]
        public static void Initialiser(TestContext testContext)
        {
            _service = new ServiceCreationPartie(null);
        }

        [TestCategory(@"Service de création d'une partie")]
        [TestMethod]
        public void CreerPartieAvec1Joueurs_Succes()
        {
            // Attendu.
            var nombreCasesAttendu = 10;
            var nombreJoueursAttendu = 1;
            var nomJoueur1Attendu = "Joueur 1";

            // Actuel.
            var actuel = _service.Creer(nombreJoueursAttendu);

            // Assertion.
            Assert.AreEqual(nombreCasesAttendu, actuel.Cases[0].Count());
            Assert.AreEqual(nombreJoueursAttendu, actuel.Equipe.Joueurs.Count());
            Assert.AreEqual(nomJoueur1Attendu, actuel.Equipe.Joueurs[0].Nom);
        }

        [TestCategory(@"Service de création d'une partie")]
        [TestMethod]
        public void CreerPartieAvec4Joueurs_Succes()
        {
            // Attendu.
            var nombreCasesAttendu = 10;
            var nombreJoueursAttendu = 4;
            var nomJoueur1Attendu = "Joueur 1";
            var nomJoueur2Attendu = "Joueur 2";
            var nomJoueur3Attendu = "Joueur 3";
            var nomJoueur4Attendu = "Joueur 4";

            // Actuel.
            var actuel = _service.Creer(nombreJoueursAttendu);

            // Assertion.
            Assert.AreEqual(nombreCasesAttendu, actuel.Cases[0].Count());
            Assert.AreEqual(nombreJoueursAttendu, actuel.Equipe.Joueurs.Count());
            Assert.AreEqual(nomJoueur1Attendu, actuel.Equipe.Joueurs[0].Nom);
            Assert.AreEqual(nomJoueur2Attendu, actuel.Equipe.Joueurs[1].Nom);
            Assert.AreEqual(nomJoueur3Attendu, actuel.Equipe.Joueurs[2].Nom);
            Assert.AreEqual(nomJoueur4Attendu, actuel.Equipe.Joueurs[3].Nom);
        }

        [TestCategory(@"Service de création d'une partie")]
        [TestMethod]
        public void CreerPartieAvec2Noms_Succes()
        {
            // Attendu.
            var nombreCasesAttendu = 10;
            var nombreJoueursAttendu = 2;
            var nomJoueur1Attendu = "Franky";
            var nomJoueur2Attendu = "Peter";

            // Actuel.
            var actuel = _service.Creer(nomJoueur1Attendu, nomJoueur2Attendu);

            // Assertion.
            Assert.AreEqual(nombreCasesAttendu, actuel.Cases[0].Count());
            Assert.AreEqual(nombreJoueursAttendu, actuel.Equipe.Joueurs.Count());
            Assert.AreEqual(nomJoueur1Attendu, actuel.Equipe.Joueurs[0].Nom);
            Assert.AreEqual(nomJoueur2Attendu, actuel.Equipe.Joueurs[1].Nom);
        }
    }
}
