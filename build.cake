using System.Runtime.CompilerServices;
using System.Threading;
///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Publish-AspNet");
var configuration = Argument("configuration", "Release");
var webSolution = Argument("webSolution", "./fittracker.sln");
var artifactDirectory = Argument("artifactDirectory", "./artifacts/");

///////////////////////////////////////////////////////////////////////////////
// BUILD TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
.Does(() => {
   CleanDirectory(artifactDirectory);
   DotNetCoreClean(webSolution);
});

Task("Build")
.IsDependentOn("Clean")
.Does(() => {
   DotNetCoreBuild(webSolution, new DotNetCoreBuildSettings
   {
      Configuration = configuration,
   });
});

Task("Test")
.IsDependentOn("Build")
.Does(() => {
    DotNetTest(webSolution, new DotNetCoreTestSettings
    {
       Configuration = configuration,
       NoBuild = true
    });
});

Task("Publish-AspNet")
.IsDependentOn("Test")
.Does(() => {
   DotNetCorePublish(webSolution, new DotNetCorePublishSettings
   {
      Configuration = configuration,
      OutputDirectory = $"{artifactDirectory}/webapi/"
   });
});

RunTarget(target);
