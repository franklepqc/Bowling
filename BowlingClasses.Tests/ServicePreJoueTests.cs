using BowlingClasses.Core;
using BowlingClasses.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using System.Linq;

namespace BowlingClasses.Tests
{
    [TestClass]
    public class ServicePreJoueTests
    {
        /// <summary>
        /// Conteneur.
        /// </summary>
        private static IServicePreJoue _service;

        /// <summary>
        /// Initialisation du service.
        /// </summary>
        /// <param name="testContext">Contexte de test.</param>
        [ClassInitialize]
        public static void Initialiser(TestContext testContext)
        {
            _service = new ServicePreJoue(new LecteurFichierTexte());
        }

        [TestCategory(@"Service de partie pré-jouée")]
        [TestMethod]
        public void PartieComplete_Succes()
        {
            // Variables de travail.
            var texte = @"10;9;0;10;9;1;9;0;10;9;0;10;9;0;10;10;9";
            var partie = new ServiceCreationPartie(null).Creer(1);

            // Attendu.
            var attendu = true;

            // Actuel.
            var actuel = _service.EntrerScore(ObtenirStream(texte), partie, 0);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
            Assert.IsTrue(partie.Cases[0].Where(p => p.EstTerminee).Count() == 10);
        }

        [TestCategory(@"Service de partie pré-jouée")]
        [TestMethod]
        public void PartieCompleteDeuxJoueurs_Succes()
        {
            // Variables de travail.
            var texte = @"10;9;0;10;9;1;9;0;10;9;0;10;9;0;10;10;9";
            var partie = new ServiceCreationPartie(null).Creer(2);

            // Attendu.
            var attendu = true;

            // Actuel.
            var actuel = _service.EntrerScore(ObtenirStream(texte), partie, 1);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
            Assert.IsTrue(partie.Cases[1].Where(p => p.EstTerminee).Count() == 10);
        }

        [TestCategory(@"Service de partie pré-jouée")]
        [TestMethod]
        public void PartieIncomplete_Succes()
        {
            // Variables de travail.
            var texte = @"10;9;1";
            var partie = new ServiceCreationPartie(null).Creer(1);

            // Attendu.
            var attendu = true;

            // Actuel.
            var actuel = _service.EntrerScore(ObtenirStream(texte), partie, 0);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
            Assert.IsTrue(partie.Cases[0].Where(p => p.EstTerminee).Count() == 2, "Il n'y a pas deux cases de remplies");
        }

        /// <summary>
        /// Obtenir le stream selon le texte.
        /// </summary>
        /// <param name="texte">Texte du fichier.</param>
        /// <returns>Simule un fichier.</returns>
        private Stream ObtenirStream(string texte) =>
            new MemoryStream(Encoding.UTF8.GetBytes(texte), false);
    }
}
