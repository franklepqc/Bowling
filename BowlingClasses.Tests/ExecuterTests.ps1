# Script pour l'exécution des tests.

# Variables de travail.
$cheminDesktop = [System.Environment]::GetFolderPath([System.Environment+SpecialFolder]::Desktop)
$cheminRepertoire = $cheminDesktop + "\Quilles_ResultatsTests\"

# Exécution des tests
dotnet test -r $cheminRepertoire -l trx --filter "TestCategory=Service de calcul de score"