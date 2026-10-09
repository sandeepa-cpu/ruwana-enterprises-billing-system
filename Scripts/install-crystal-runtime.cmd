@echo off
set MSI=%TEMP%\CR13SP37MSI32.msi
if not exist "%MSI%" (
  echo Crystal runtime installer was not found at %MSI%
  echo Download CR13SP37MSI32_0-80007712.MSI and save it to that path, then run this file as Administrator.
  exit /b 1
)
msiexec /i "%MSI%" /qn /norestart UPGRADE=1
echo Installer exit code %ERRORLEVEL%
exit /b %ERRORLEVEL%
