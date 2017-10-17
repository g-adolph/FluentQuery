#addin nuget:?package=Cake.Codecov
#addin Cake.Coveralls
#tool nuget:?package=Codecov
#tool "nuget:?package=OpenCover"
#tool "nuget:?package=xunit.runner.console&version=2.2.0"
#tool "nuget:?package=ReportGenerator"
#tool coveralls.net
#tool coveralls.io

var projectName = "FluentQuery";
var target = Argument("target", "Default");
var testProject = "./"+projectName+".Tests.Unit/"+projectName+".Tests.Unit.csproj";
var testSettings = new DotNetCoreTestSettings { Configuration = "Release", NoBuild = true };

Task("Default").Does(() =>
{
    Information("This is task Default! Please choose a specific task.");
});

Task("CiBuild")
	.IsDependentOn("Coverage").IsDependentOn("NugetPack").Does(() =>
{
});

Task("CoverageHtmlReport")
	.IsDependentOn("Build").Does(() =>
{
    var settings = new OpenCoverSettings()
    {
        MergeOutput = true,
        SkipAutoProps = true,
        OldStyle = true,
        Register = "user",
        ArgumentCustomization = builder => builder.Append("-hideskipped:File")
    };
    settings.WithFilter("+["+projectName+".Core*]*").WithFilter("-["+projectName+".Tests.Unit*]*");

    OpenCover(t => t.DotNetCoreTest(testProject, testSettings), new FilePath("./coverage.xml"), settings);

    ReportGenerator("./coverage.xml", "./reportoutput");

	CoverallsNet("coverage.xml", CoverallsNetReportType.OpenCover, new CoverallsNetSettings()
    {
        RepoToken = "nHA7aVAKJW4V2PcoQXidevpJ9ixDZFBp6"
    });
});

Task("Coverage")
	.IsDependentOn("Build").Does(() =>
{
    var settings = new OpenCoverSettings()
    {
        MergeOutput = true,
        SkipAutoProps = true,
        OldStyle = true,
        Register = "user",
        ArgumentCustomization = builder => builder.Append("-hideskipped:File")
    };
    settings
		.WithFilter("+["+projectName+".Core*]*")
		.WithFilter("+["+projectName+".SqlServer*]*")
		.WithFilter($"-["+projectName+".Tests.Unit*]*");

    OpenCover(t => t.DotNetCoreTest(testProject, testSettings), new FilePath("./coverage.xml"), settings);

    Codecov(new CodecovSettings(){
		Files = new[] { "coverage.xml" },
		Verbose = true
	});
});

Task("NugetPack")
	.IsDependentOn("Build").Does(() =>
{
    var settings = new DotNetCorePackSettings
    {
        Configuration = "Release",
        OutputDirectory = "./artifacts/",
        NoBuild = true
    };

    DotNetCorePack($"./"+projectName+".Core/"+projectName+".Core.csproj", settings);
});

Task("Tests")
//	.IsDependentOn("Integration-Tests")
	.IsDependentOn("Build").Does(() =>
{
    DotNetCoreTest(testProject, testSettings);
});

//Task("Integration-Tests")
//.IsDependentOn("Build").Does(() =>
//{
//    DotNetCoreTest(integrationTestProject, testSettings);
//});

Task("Build").Does(() =>
{
    DotNetCoreBuild("./"+projectName+".sln",new DotNetCoreBuildSettings { Configuration = "Release" });
});

RunTarget(target);