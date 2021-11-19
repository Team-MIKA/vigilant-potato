[![.NET](https://github.com/Team-MIKA/vigilant-potato/actions/workflows/dotnet.yml/badge.svg?branch=dotnet-mariadb)](https://github.com/Team-MIKA/vigilant-potato/actions/workflows/dotnet.yml)
# vigilant-potato
This is the repository for group MIKA's P7 project

## Feature folder structure
![image](https://user-images.githubusercontent.com/44102455/142428474-daa7da0e-b008-4b97-b96c-959aac18b2d7.png)


## Commands
1 integrator nede
```
docker build . -t my-web-app -f .\Integrator\Dockerfile
```

```
dotnet ef migrations add "message"
```

```
dotnet ef database update
```

### HTTPS (rider and windows)
```
dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\Integrator.pfx -p mikapassword
```

```
dotnet user-secrets set "Kestrel:Certificates:Development:Password" "mikapassword"
```

```
docker build -t <image_tag> . && docker run -p 5000:80 -p 5001:443 -v C:\Users\kaspe\AppData\Roaming\Microsoft\UserSecrets:/root/.microsoft/usersecrets -v C:\Users\kaspe\.aspnet\https:/root/.aspnet/https --env ASPNETCORE_ENVIRONMENT=Development --env ASPNETCORE_URLS=https://+:443;http://+:80 --name API <image_tag> 
```

```
docker build -t <image_tag> . && docker run -p 5000:80 -p 5001:443 -v C:\Users\kaspe\AppData\Roaming\Microsoft\UserSecrets:/root/.microsoft/usersecrets -v C:\Users\kaspe\.aspnet\https:/root/.aspnet/https --env ASPNETCORE_ENVIRONMENT=Development --env ASPNETCORE_URLS=https://+:443;http://+:80 --name API --network random <image_tag> 
```
![image](https://user-images.githubusercontent.com/44102455/142661062-d48d503e-3904-41ef-b85a-43b1be444120.png)

![image](https://i.postimg.cc/fWVwTPvr/image.png)
[image.png](https://postimg.cc/0rqgVcFY)
[![image.png](https://i.postimg.cc/fWVwTPvr/image.png)](https://postimg.cc/0rqgVcFY)

## Issues
Mysql in docker
https://stackoverflow.com/questions/66670789/net-core-application-in-docker-cannot-connect-to-mysql-server
