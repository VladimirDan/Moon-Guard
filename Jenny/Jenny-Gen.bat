@echo off
:: Устанавливаем переменную окружения MSBUILD_EXE_PATH
set MSBUILD_EXE_PATH="C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\amd64\MSBuild.exe"

:: Запускаем Jenny с указанными параметрами
dotnet .\Jenny\Jenny.Generator.Cli.dll gen JennyRoslyn.properties -v

:: Ожидаем, чтобы окно не закрылось сразу
pause
