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
    DotNetCoreTest("Ticker.Logic.Test/Ticker.Logic.Test.csproj", new DotNetCoreTestSettings{
      NoBuild = true,
      Logger = "Console",
      NoRestore = true,
      Filter = "TestCategory!=Integration"
    });
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
