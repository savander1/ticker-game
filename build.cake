var target = Argument("target", "Default");


Task("Clean")
  .Does(() =>
  {
    DotNetCoreClean("");
  });

Task("Restore")
  .IsDependentOn("Clean")
  .Does(() =>
  {
    DotNetCoreRestore("");
  });

Task("Build")
  .IsDependentOn("Restore")
  .Does(() =>
  {
    DotNetCoreMSBuild();
  });

Task("Test")
  .IsDependentOn("Build")
  .Does(() => {
    DotNetCoreTest("**/*.Test.csproj");
  });

Task("Default")
  .IsDependentOn("Test");

RunTarget(target);
