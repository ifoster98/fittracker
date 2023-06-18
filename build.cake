using System.Runtime.CompilerServices;
using System.Threading;
///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Run");
var configuration = Argument("configuration", "Release");
var webSolution = Argument("webSolution", "./fittracker.sln");
var webTestSolution = Argument("webTestSolution", "./fittrackertests.sln");
var runnableProject = Argument("runnableProject", "./Ianf.Fittracker.Web/Ianf.Fittracker.Web.csproj");
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
   DotNetBuild(webSolution, new DotNetCoreBuildSettings
   {
      Configuration = configuration,
   });
});

Task("Test")
.IsDependentOn("Build")
.Does(() => {
    DotNetTest("./Ianf.Fittracker.Engine.Tests/Ianf.Fittracker.Engine.Tests.csproj", new DotNetCoreTestSettings
    {
       Configuration = configuration,
       NoBuild = true
    });
    DotNetTest("./Ianf.Fittracker.Service.Tests/Ianf.Fittracker.Service.Tests.csproj", new DotNetCoreTestSettings
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

Task("Run")
.IsDependentOn("Publish-AspNet")
.Does(() => {
   DotNetRun(runnableProject);
});

Task("API-Tests")
.Does(() => {
    DotNetBuild(webTestSolution, new DotNetCoreBuildSettings
    {
       Configuration = configuration,
    });
    DotNetTest("./Ianf.Fittracker.Web.Tests/Ianf.Fittracker.Web.Tests.csproj", new DotNetCoreTestSettings
    {
       Configuration = configuration,
       NoBuild = true
    });
});

RunTarget(target);
