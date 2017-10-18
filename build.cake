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
var coverageResult = "./coverage.xml";

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
    DeleteDirectoryIfExists("./reportoutput");
	DeleteFileIfExists(coverageResult);


	var settings = new OpenCoverSettings()
    {
        MergeOutput = true,
        SkipAutoProps = true,
        OldStyle = true,
        Register = "user",
        ArgumentCustomization = builder => builder.Append("-hideskipped:File")
    };
	
    
	settings.WithFilter("+[FluentQuery*]*")
	.WithFilter("-[FluentQuery.Tests.Unit*]*");

    OpenCover(t => t.DotNetCoreTest(testProject, testSettings), new FilePath(coverageResult), settings);

    ReportGenerator(coverageResult, "./reportoutput");

	//CoverallsNet("coverage.xml", CoverallsNetReportType.OpenCover, new CoverallsNetSettings()
    //{
    //   RepoToken = "nHA7aVAKJW4V2PcoQXidevpJ9ixDZFBp6"
    //});
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
	
    
	settings.WithFilter("+[FluentQuery.Core*]*").WithFilter("-[FluentQuery.Tests.Unit*]*");

    OpenCover(t => t.DotNetCoreTest(testProject, testSettings), new FilePath("./coverage.xml"), settings);

    Codecov(coverageResult);
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


//////////////////////////////////////////////////////////////////////
// HELPERS
//////////////////////////////////////////////////////////////////////

void CreateDirectoryIfNotExists(string path)
{
	var directory = Directory(path);
	if (!DirectoryExists(directory))
	{
		CreateDirectory(directory);
		Information(directory.Path +" created");
	}
}

void DeleteDirectoryIfExists(string path)
{
	var directory = Directory(path);
	if (DirectoryExists(directory))
	{
		DeleteDirectory(directory, true);
		Information(directory.Path +" deleted");
	}
}

void DeleteFileIfExists(string path)
{
	var file = File(path);
	if (FileExists(file))
	{
		DeleteFile(file);
		Information(file.Path +" deleted");
	}
}