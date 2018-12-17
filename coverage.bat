@echo off
cd UnitTests/minicover
dotnet build
dotnet clean ../XOProject.Api.Tests/XOProject.Api.Tests.csproj
dotnet clean ../XOProject.Repository.Tests/XOProject.Repository.Tests.csproj
dotnet clean ../XOProject.Services.Tests/XOProject.Services.Tests.csproj
dotnet build ../../XOProject.sln /p:DebugType=Full
dotnet minicover instrument --workdir ../../ --assemblies UnitTests/**/bin/**/*.dll --sources XOProject.Api/**/*.cs --sources XOProject.Services/**/*.cs --sources XOProject.Repository/**/*.cs --exclude-sources XOProject.Api/Migrations/**/*.cs --exclude-sources XOProject.Api/*.cs --exclude-sources XOProject.Repository/ExchangeContext.cs

dotnet minicover reset --workdir ../../

dotnet test ../XOProject.Api.Tests/XOProject.Api.Tests.csproj --no-build
dotnet test ../XOProject.Repository.Tests/XOProject.Repository.Tests.csproj --no-build
dotnet test ../XOProject.Services.Tests/XOProject.Services.Tests.csproj --no-build
dotnet minicover uninstrument --workdir ../../
dotnet minicover report --workdir ../../ --threshold 60

cd ../../