using BowlingClasses.Core;
using BowlingClasses.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using System.Linq;

namespace BowlingClasses.Tests
{
    [TestClass]
    public class LecteurFichierTexteTests
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
            _service = new LecteurFichierTexte();
        }

        [TestCategory(@"Service de lecture (fichier texte)")]
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

        [TestCategory(@"Service de lecture (fichier texte)")]
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

        [TestCategory(@"Service de lecture (fichier texte)")]
        [TestMethod]
        public void LectureCaracteres_Succes()
        {
            // Variables de travail.
            var texte = @"a;b;c;1";

            // Attendu.
            var attendu = new[] {
                1
            };

            // Actuel.
            var actuel = _service.Lire(ObtenirStream(texte));

            // Assertion.
            Assert.IsTrue(
                attendu.Distinct().All(valeur => actuel.Contains(valeur)) &&
                attendu.Length == actuel.Length);
        }

        [TestCategory(@"Service de lecture (fichier texte)")]
        [TestMethod]
        public void LectureCaracteres2_Succes()
        {
            // Variables de travail.
            var texte = @"a;b;c;1;99";

            // Attendu.
            var attendu = new[] {
                1,
                99
            };

            // Actuel.
            var actuel = _service.Lire(ObtenirStream(texte));

            // Assertion.
            Assert.IsTrue(
                attendu.Distinct().All(valeur => actuel.Contains(valeur)) &&
                attendu.Length == actuel.Length);
        }

        [TestCategory(@"Service de lecture (fichier texte)")]
        [TestMethod]
        public void Lecture1Valeur_Succes()
        {
            // Variables de travail.
            var texte = @"99";

            // Attendu.
            var attendu = new[]
            {
                99
            };

            // Actuel.
            var actuel = _service.Lire(ObtenirStream(texte));

            // Assertion.
            Assert.IsTrue(
                attendu.Distinct().All(valeur => actuel.Contains(valeur)) &&
                attendu.Length == actuel.Length);
        }

        [TestCategory(@"Service de lecture (fichier texte)")]
        [TestMethod]
        public void Lecture5Valeurs_Succes()
        {
            // Variables de travail.
            var texte = @"1;2;3;4;5";

            // Attendu.
            var attendu = new[]
            {
                1,
                2,
                3,
                4,
                5
            };

            // Actuel.
            var actuel = _service.Lire(ObtenirStream(texte));

            // Assertion.
            Assert.IsTrue(
                attendu.Distinct().All(valeur => actuel.Contains(valeur)) &&
                attendu.Length == actuel.Length);
        }

        [TestCategory(@"Service de lecture (fichier texte)")]
        [TestMethod]
        public void LectureAleatoire1_Succes()
        {
            // Variables de travail.
            var texte = @"10;9;0;10;9;1;9;0;10;9;0;10;9;0;10;10;9";

            // Attendu.
            var attendu = new[]
            {
                10,
                9,
                0,
                10,
                9,
                1,
                9,
                0,
                10,
                9,
                0,
                10,
                9,
                0,
                10,
                10,
                9
            };

            // Actuel.
            var actuel = _service.Lire(ObtenirStream(texte));

            // Assertion.
            Assert.IsTrue(
                attendu.Distinct().All(valeur => actuel.Contains(valeur)) &&
                attendu.Length == actuel.Length);
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
