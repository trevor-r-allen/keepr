dotnet publish -c Release
docker build -t keepr ./bin/Release/net5.0/publish
docker tag keepr registry.heroku.com/tallen-keepr/web
docker push registry.heroku.com/tallen-keepr/web
heroku container:release web -a tallen-keepr
echo press any key
read end