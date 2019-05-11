using BowlingClasses.Core;
using BowlingClasses.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingClasses.Tests
{
    [TestClass]
    public class ServiceCalculScoreTests
    {
        /// <summary>
        /// Classe bidon pour les tests.
        /// On assume que tous les paramètres sont valides.
        /// </summary>
        private class ServiceValidationBidon : IServiceValidation
        {
            /// <summary>
            /// Aucune validation. Ok tout le temps.
            /// </summary>
            /// <param name="cases">Cases à valider.</param>
            /// <returns>Vrai.</returns>
            public bool Valider(ICase[] cases) => true;
        }

        /// <summary>
        /// Conteneur.
        /// </summary>
        private static IServiceCalculScore _service;

        /// <summary>
        /// Initialisation du service.
        /// </summary>
        /// <param name="testContext">Contexte de test.</param>
        [ClassInitialize]
        public static void Initialiser(TestContext testContext)
        {
            _service = new ServiceCalculScore(
                new ServiceValidationBidon());
        }

        [TestCategory(@"Service de calcul de score")]
        [TestMethod]
        public void CalculerScore_Succes100Points()
        {
            // Variables de travail.
            var cases = new[]
            {
                new CaseJeu(new int?[] { 0, 10 }),    // Case 1.
                new CaseJeu(new int?[] { 0, 10}),     // Case 2.
                new CaseJeu(new int?[] { 0, 10}),     // Case 3.
                new CaseJeu(new int?[] { 0, 10}),     // Case 4.
                new CaseJeu(new int?[] { 0, 10}),     // Case 5.
                new CaseJeu(new int?[] { 0, 10}),     // Case 6.
                new CaseJeu(new int?[] { 0, 10}),     // Case 7.
                new CaseJeu(new int?[] { 0, 10}),     // Case 8.
                new CaseJeu(new int?[] { 0, 10}),     // Case 9.
                new CaseJeu(new int?[] { 0, 10, 0 })  // Case 10.
            };

            // Attendu.
            var attendu = 100;

            // Actuel.
            var actuel = _service.Calculer(cases);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Service de calcul de score")]
        [TestMethod]
        public void CalculerScore_Succes50Points()
        {
            // Variables de travail.
            var lancers = new[]
            {
                new CaseJeu(new int?[] { 0, 10 }),     // Case 1.
                new CaseJeu(new int?[] { 0, 10 }),     // Case 2.
                new CaseJeu(new int?[] { 0, 10 }),     // Case 3.
                new CaseJeu(new int?[] { 0, 10 }),     // Case 4.
                new CaseJeu(new int?[] { 0, 10 }),     // Case 5.
                new CaseJeu(new int?[] { 0, 10 }),     // Case 6.
                new CaseJeu(new int?[] { 0, 10 }),     // Case 7.
                new CaseJeu(new int?[] { 0, 10 }),     // Case 8.
                new CaseJeu(new int?[] { 0, 10 }),     // Case 9.
                new CaseJeu(new int?[] { 0, 10, 0 })   // Case 10.
            };

            // Attendu.
            var attendu = 50;

            // Actuel.
            var actuel = _service.Calculer(lancers, 5);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Service de calcul de score")]
        [TestMethod]
        public void CalculerScore_SuccesPointageInconnuSeulement5Cases()
        {
            // Variables de travail.
            var lancers = new[]
            {
                new CaseJeu(new int?[] { 0, 10 }),     // Case 1.
                new CaseJeu(new int?[] { 0, 10 }),     // Case 2.
                new CaseJeu(new int?[] { 0, 10 }),     // Case 3.
                new CaseJeu(new int?[] { 0, 10 }),     // Case 4.
                new CaseJeu(new int?[] { 0, 10 })      // Case 5.
            };

            // Attendu.
            var attendu = null as int?;

            // Actuel.
            var actuel = _service.Calculer(lancers);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Service de calcul de score")]
        [TestMethod]
        public void CalculerScore_Succes40PointsSeulement5Cases()
        {
            // Variables de travail.
            var lancers = new[]
            {
                new CaseJeu(new int?[] { 0, 10 }),     // Case 1.
                new CaseJeu(new int?[] { 0, 10 }),     // Case 2.
                new CaseJeu(new int?[] { 0, 10 }),     // Case 3.
                new CaseJeu(new int?[] { 0, 10 }),     // Case 4.
                new CaseJeu(new int?[] { 0, 10 })      // Case 5.
            };

            // Attendu.
            var attendu = 40;

            // Actuel.
            var actuel = _service.Calculer(lancers, 4);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Service de calcul de score")]
        [TestMethod]
        public void CalculerScore_SuccesReserves()
        {
            // Variables de travail.
            var lancers = new[]
            {
                new CaseJeu(new int?[] { 1, 9 }),     // Case 1.
                new CaseJeu(new int?[] { 1, 9 }),     // Case 2.
                new CaseJeu(new int?[] { 1, 9 }),     // Case 3.
                new CaseJeu(new int?[] { 1, 9 }),     // Case 4.
                new CaseJeu(new int?[] { 1, 9 }),     // Case 5.
                new CaseJeu(new int?[] { 1, 9 }),     // Case 6.
                new CaseJeu(new int?[] { 1, 9 }),     // Case 7.
                new CaseJeu(new int?[] { 1, 9 }),     // Case 8.
                new CaseJeu(new int?[] { 1, 9 }),     // Case 9.
                new CaseJeu(new int?[] { 1, 9, 1 })   // Case 10.
            };

            // Attendu.
            var attendu = 110;

            // Actuel.
            var actuel = _service.Calculer(lancers);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Service de calcul de score")]
        [TestMethod]
        public void CalculerScore_SuccesAucuneReserveAucunAbat()
        {
            // Variables de travail.
            var lancers = new[]
            {
                new CaseJeu(new int?[] { 1, 1 }),     // Case 1.
                new CaseJeu(new int?[] { 1, 1 }),     // Case 2.
                new CaseJeu(new int?[] { 1, 1 }),     // Case 3.
                new CaseJeu(new int?[] { 1, 1 }),     // Case 4.
                new CaseJeu(new int?[] { 1, 1 }),     // Case 5.
                new CaseJeu(new int?[] { 1, 1 }),     // Case 6.
                new CaseJeu(new int?[] { 1, 1 }),     // Case 7.
                new CaseJeu(new int?[] { 1, 1 }),     // Case 8.
                new CaseJeu(new int?[] { 1, 1 }),     // Case 9.
                new CaseJeu(new int?[] { 1, 1 })      // Case 10.
            };

            // Attendu.
            var attendu = 20;

            // Actuel.
            var actuel = _service.Calculer(lancers);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Service de calcul de score")]
        [TestMethod]
        public void CalculerScore_SuccesPartieParfaite()
        {
            // Variables de travail.
            var lancers = new[]
            {
                new CaseJeu(new int?[] { 10 }),         // Case 1.
                new CaseJeu(new int?[] { 10 }),         // Case 2.
                new CaseJeu(new int?[] { 10 }),         // Case 3.
                new CaseJeu(new int?[] { 10 }),         // Case 4.
                new CaseJeu(new int?[] { 10 }),         // Case 5.
                new CaseJeu(new int?[] { 10 }),         // Case 6.
                new CaseJeu(new int?[] { 10 }),         // Case 7.
                new CaseJeu(new int?[] { 10 }),         // Case 8.
                new CaseJeu(new int?[] { 10 }),         // Case 9.
                new CaseJeu(new int?[] { 10, 10, 10 })  // Case 10.
            };

            // Attendu.
            var attendu = 300;

            // Actuel.
            var actuel = _service.Calculer(lancers);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Service de calcul de score")]
        [TestMethod]
        public void CalculerScore_PartieAleatoire1()
        {
            // Variables de travail.
            var lancers = new[]
            {
                new CaseJeu(new int?[] { 10 }),         // Case 1.
                new CaseJeu(new int?[] { 9, 0 }),       // Case 2.
                new CaseJeu(new int?[] { 10 }),         // Case 3.
                new CaseJeu(new int?[] { 9, 1 }),       // Case 4.
                new CaseJeu(new int?[] { 9, 0 }),       // Case 5.
                new CaseJeu(new int?[] { 10 }),         // Case 6.
                new CaseJeu(new int?[] { 9, 0 }),       // Case 7.
                new CaseJeu(new int?[] { 10 }),         // Case 8.
                new CaseJeu(new int?[] { 9, 0 }),       // Case 9.
                new CaseJeu(new int?[] { 10, 10, 9 })   // Case 10.
            };

            // Attendu.
            var attendu = 161;

            // Actuel.
            var actuel = _service.Calculer(lancers);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }
    }
}
