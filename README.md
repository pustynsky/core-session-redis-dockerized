# netcore-session-redis
.NET Core Web With Session stored in dockerized Redis.


Hi there! Feel free to download this project for your own usage as a template for further Redis session storage.
This use case is for Redis placed in Docker container.
You can easily change it to cloud Docker (AWS, Azure, GC etc) or deploy your own stand-alone Redis downloaded from https://redis.io/download

Requrements for run:
1. Docker
2. .NET Core 3.1

Nuget Dependency: Microsoft.Extentions.Caching.Redis

Things to note:

- If you're not yet aquainted with a new IAsyncDisposable interface, it's time to get known! Check out how it's been used in BinarySerializer class. Quite simple - as a regular IDisposable:
await using(MemoryStream ms = new MemoryStream())
To read more: https://docs.microsoft.com/en-us/dotnet/api/system.iasyncdisposable

- Don't forget to add @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers to _ViewImports.cshtml or regular cshtml file in order to support tag helpers on your pages.

- To clear Redis cache in docker use (in your CLI):
docker exec -it container-name redis-cli FLUSHALL

