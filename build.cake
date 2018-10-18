#tool "nuget:?package=Microsoft.TestPlatform&version=15.7.0"

var target = Argument("target", "Default");


Task("Clean")
  .Does(() =>
  {
    DotNetCoreClean("");
  });

Task("Restore")
  .Does(() =>
  {
    DotNetCoreRestore("");
  });

Task("Build")
  .Does(() =>
  {
    DotNetCoreMSBuild();
  });

Task("Test")
  .Does(() => {
    // DotNetCoreTest("Ticker.Logic.Test/Ticker.Logic.Test.csproj", new DotNetCoreTestSettings{
    //   NoBuild = true,
    //   Logger = "Console",
    //   NoRestore = true,
    //   Filter = "TestCategory!=Integration"
    // });
    var testSettings = new VSTestSettings{
        ToolPath        = Context.Tools.Resolve("vstest.console.exe"),
    }.WithLogger("Console");
    VSTest("./Ticker.Logic.Test/bin/Debug/netcoreapp2.1/Ticker.Logic.Test.dll", testSettings);
  });

Task("CIBuild")
  .IsDependentOn("Clean")
  .IsDependentOn("Restore")
  .IsDependentOn("Build");

Task("Default")
  .IsDependentOn("Clean")
  .IsDependentOn("Restore")
  .IsDependentOn("Build")
  .IsDependentOn("Test");

RunTarget(target);
