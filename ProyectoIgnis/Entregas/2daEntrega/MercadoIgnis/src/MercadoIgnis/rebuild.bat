echo Borrando...
rd Migrations /s /q
del BdMercadoIgnis.db

echo Rebuilding...
dotnet ef migrations add InitialCreate --context MercadoIgnisContext
dotnet ef migrations add InitialCreateIdentity --context IdentityContext
dotnet ef database update --context MercadoIgnisContext
dotnet ef database update --context IdentityContext

echo Listo...
dotnet run
echo Corriendo el programa con la bd actualizada ...
pause