# netcore-session-redis
.NET Core Web With Session stored in Redis


Hi there! Feel free to download this project for your own usage as a template for further Redis session storage.
Requrements for run:

1. Docker
2. .NET Core 3.1

Nuget Dependency: Microsoft.Extentions.Caching.Redis
Check out new async pattern like IAsyncDisposable implemented in BinarySerializer class
await using(MemoryStream ms = new MemoryStream())


To clear Redis cache in docker use 

docker exec -it container-name redis-cli FLUSHALL

