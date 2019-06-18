echo Borrando...
rd Migrations /s /q
del BdMercadoIgnis.db

echo Rebuilding...

dotnet ef migrations add InitialCreateIdentity --context IdentityContext


dotnet ef database update --context IdentityContext


echo Listo...


pause