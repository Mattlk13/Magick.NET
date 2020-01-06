@echo off

powershell .\install.dependencies.ps1
if %errorlevel% neq 0 exit /b %errorlevel%
dir "C:/Program Files (x86)/gs/gs9.27/bin/"