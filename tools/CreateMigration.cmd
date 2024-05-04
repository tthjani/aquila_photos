@echo off
cd "..\backend\src\APhoto.Data"
echo Creating migration %1
echo With connection string: %2
dotnet ef migrations add %1 -- --connString %2