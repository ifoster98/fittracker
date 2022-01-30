using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[CheckBuildProjectConfigurations]
[ShutdownDotNetAfterServerBuild]
class Build : NukeBuild
{
    public static int Main () => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Parameter("AWS Endpoint url to target the deployment to. Defaults to localhost:4566 for localstack development.")]
    readonly static string AWSEndpoint = "http://localhost:4566";

    [Parameter("AWS S3 bucket name to use. Defaults to 'fittracker'.")]
    readonly static string WebAppBucketName = "fittracker-client";

    [Solution] readonly Solution Solution;
    [GitRepository] readonly GitRepository GitRepository;
    

    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            EnsureCleanDirectory(ArtifactsDirectory);
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore, Clean)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .EnableNoRestore());
        });

    Target Test => _ => _
        .DependsOn(Compile)
        .Executes(() => 
        {
            DotNetTest(s => s
                .SetProjectFile(RootDirectory / "Ianf.Fittracker.Services.Tests")
                .EnableNoRestore()
                .EnableNoBuild());
        });

    Target CreateArtifacts => _ => _
        .DependsOn(Test)
        .Executes(() => {
            // Package up compile phase into format required for deploying to AWS Lambda
            // Copy output of .net build to artifacts directory
        });

    Target StartServer => _ => _
//        .DependsOn(CreateArtifacts)
        .Executes(() => {
            ProcessTasks.StartProcess("localstack", "start -d");
        });

    Target SetUpS3Infrastructure => _ => _
        .DependsOn(StartServer)
        .Executes(() => {
        });

    Target SetUpInfrastructure => _ => _
        .DependsOn(SetUpS3Infrastructure)
        .Executes(() => {
            // To do using CloudFormation 
        });

    Target DeployToLocal => _ => _
        .DependsOn(SetUpInfrastructure)
        .Executes(() => {

        });

    Target RunApiTests => _ => _
        .DependsOn(DeployToLocal)
        .Executes(() => {

        });

    Target StopServer => _ => _
        .DependsOn(RunApiTests) 
        .Executes(() => {
            ProcessTasks.StartProcess("localstack", "stop");
        });
}
