@echo off
echo Starting complete coverage report generation (V3 with cleanup)...
echo.

REM Step 0: Clean up old report directories
echo [0/5] Cleaning up old report directories...
if exist "UnitTests\coverage" (
    echo Deleting "UnitTests\coverage"...
    rmdir /s /q "UnitTests\coverage"
)
if exist "UnitTests\coverage-report" (
    echo Deleting "UnitTests\coverage-report"...
    rmdir /s /q "UnitTests\coverage-report"
)
if exist "TestResults" (
    echo Deleting "TestResults"...
    rmdir /s /q "TestResults"
)
if exist "FilteredTestResults" (
    echo Deleting "FilteredTestResults"...
    rmdir /s /q "FilteredTestResults"
)
echo Cleanup complete.
echo.



REM Step 2: Run tests for UnitTests
echo [2/5] Running UnitTests...
dotnet test UnitTests --collect:"XPlat Code Coverage" --results-directory ".\TestResults"
if errorlevel 1 (
    echo ERROR: UnitTests failed
    pause
    exit /b 1
)
echo.

REM Step 3: Filter coverage data to remove 0% line coverage classes
echo [3/5] Filtering coverage data to remove 0%% line coverage classes...
mkdir "FilteredTestResults"

powershell -Command "& { Get-ChildItem -Path '.\TestResults\**\coverage.cobertura.xml' -Recurse | ForEach-Object { Write-Host ('Processing: ' + $_.FullName); try { [xml]$xml = Get-Content -Path $_.FullName -Raw } catch { Write-Error 'Failed to parse XML from: '+$_.FullName; return }; $classesToRemove = @(); foreach ($package in $xml.coverage.packages.package) { foreach ($class in $package.classes.class) { $lineRateStr = $class.'line-rate'; if ([double]::Parse($lineRateStr, [System.Globalization.CultureInfo]::InvariantCulture) -eq 0) { $classesToRemove += $class; Write-Host ('Removing class: ' + $class.name) } } }; foreach ($classToRemove in $classesToRemove) { $null = $classToRemove.ParentNode.RemoveChild($classToRemove) }; $uniqueName = $_.Directory.Name + '.xml'; $outputFile = Join-Path 'FilteredTestResults' $uniqueName; $xml.Save($outputFile); Write-Host ('Saved filtered file: ' + $outputFile) } }"

if errorlevel 1 (
    echo ERROR: Coverage filtering failed
    pause
    exit /b 1
)
echo.

REM Step 4: Generate HTML coverage report from multiple filtered files
echo [4/5] Generating HTML coverage report...
reportgenerator "-reports:.\FilteredTestResults\*.xml" "-targetdir:UnitTests\coverage-report" "-reporttypes:Html;Cobertura;JsonSummary;TextSummary" "-assemblyfilters:-DSKView"
if errorlevel 1 (
    echo ERROR: Report generation failed
    pause
    exit /b 1
)

echo.
echo [5/5] SUCCESS: Coverage report generated successfully!
echo Report location: UnitTests\coverage-report\index.html
echo You can also check the plain text summary at: UnitTests\coverage-report\Summary.txt
start "" "UnitTests\coverage-report\index.html"
echo.

