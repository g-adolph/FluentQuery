#addin nuget:?package=Cake.Codecov
#tool nuget:?package=Codecov
#tool "nuget:?package=OpenCover"
#tool "nuget:?package=xunit.runner.console&version=2.2.0"
#tool "nuget:?package=ReportGenerator"

var target = Argument("target", "Default");
var projectName = "FluentQuery";
var testProject = "./"+projectName+".Tests.Unit/"+projectName+".Tests.Unit.csproj";
var testSettings = new DotNetCoreTestSettings { Configuration = "Release", NoBuild = true };

string[] coverageFilters = {
	"+["+projectName+".*]*",
	"-["+projectName+".Tests.Unit*]*"
};

Task("Default").Does(() =>
{
    Information("Hello World!");
});
Task("Clean").Does(()=>
{
	DeleteDirectoryIfExists("./artifacts");
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
	foreach(var filter in coverageFilters)
	{
		settings.WithFilter(filter);
	}

    OpenCover(t => t.DotNetCoreTest(testProject, testSettings), new FilePath("./coverage.xml"), settings);

    ReportGenerator("./coverage.xml", "./reportoutput");
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

    foreach(var filter in coverageFilters)
	{
		settings.WithFilter(filter);
	}

    OpenCover(t => t.DotNetCoreTest(testProject, testSettings), new FilePath("./coverage.xml"), settings);

    Codecov("./coverage.xml");

	CoverallsNet("coverage.xml", CoverallsNetReportType.OpenCover);
});

Task("NugetPack")
.IsDependentOn("Clean")
.IsDependentOn("Build").Does(() =>
{
    var settings = new DotNetCorePackSettings
    {
        Configuration = "Release",
        OutputDirectory = "./artifacts/",
        NoBuild = true
    };

    DotNetCorePack("./FluentQuery.Core/FluentQuery.Core.csproj", settings);
});

Task("Tests")
.IsDependentOn("Build").Does(() =>
{
    DotNetCoreTest(testProject, testSettings);
});

Task("Build").Does(() =>
{
    DotNetCoreBuild("./FluentQuery.sln",new DotNetCoreBuildSettings { Configuration = "Release" });
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