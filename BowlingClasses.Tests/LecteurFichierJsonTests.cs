using BowlingClasses.Core;
using BowlingClasses.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using System.Linq;

namespace BowlingClasses.Tests
{
    [TestClass]
    public class LecteurFichierJsonTests : LecteurFichierBase
    {
        /// <summary>
        /// Conteneur.
        /// </summary>
        private static ILecteur _service;

        /// <summary>
        /// Initialisation du service.
        /// </summary>
        /// <param name="testContext">Contexte de test.</param>
        [ClassInitialize]
        public static void Initialiser(TestContext testContext)
        {
            _service = new LecteurFichierJson();
        }

        [TestCategory(@"Service de lecture (fichier json)")]
        [TestMethod]
        public void LectureNullStream_Succes()
        {
            // Variables de travail.

            // Attendu.
            var attendu = new int[0];

            // Actuel.
            var actuel = _service.Lire(null);

            // Assertion.
            Assert.IsTrue(
                attendu.Distinct().All(valeur => actuel.Contains(valeur)) &&
                attendu.Length == actuel.Length);
        }

        [TestCategory(@"Service de lecture (fichier json)")]
        [TestMethod]
        public void LectureChaineVide_Succes()
        {
            // Variables de travail.
            var texte = string.Empty;

            // Attendu.
            var attendu = new int[0];

            // Actuel.
            var actuel = _service.Lire(ObtenirStream(texte));

            // Assertion.
            Assert.IsTrue(
                attendu.Distinct().All(valeur => actuel.Contains(valeur)) &&
                attendu.Length == actuel.Length);
        }

        [TestCategory(@"Service de lecture (fichier json)")]
        [TestMethod]
        public void LectureJsonComplet_Succes()
        {
            // Variables de travail.
            var texte = @"[ { ""id"": 1, ""essais"": [ 10 ] }, { ""id"": 2, ""essais"": [ 9, 0 ] }, { ""id"": 3, ""essais"": [ 10 ] } ]";

            // Attendu.
            var attendu = new[] {
                10,
                9,
                0,
                10
            };

            // Actuel.
            var actuel = _service.Lire(ObtenirStream(texte));

            // Assertion.
            Assert.IsTrue(
                attendu.Distinct().All(valeur => actuel.Contains(valeur)) &&
                attendu.Length == actuel.Length);
        }
    }
}
