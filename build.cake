#tool "nuget:?package=Microsoft.TestPlatform"

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
    var testSettings = new VSTestSettings{
        ToolPath = Context.Tools.Resolve("vstest.console.exe"),
        Parallel = true
    }.WithLogger("Console");
    VSTest("./Ticker.Test/bin/Debug/netcoreapp2.1/Ticker.Test.dll", testSettings);
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
