@echo off
set MSI=%~dp0CR13SP37MSI32.msi
if not exist "%MSI%" set MSI=%TEMP%\CR13SP37MSI32.msi
if not exist "%MSI%" (
  echo Crystal runtime installer was not found.
  echo Put CR13SP37MSI32.msi next to this script, then run this file as Administrator.
  exit /b 1
)
msiexec /i "%MSI%" /qn /norestart UPGRADE=1
echo Installer exit code %ERRORLEVEL%
exit /b %ERRORLEVEL%
