var target = Argument("target", "Build");
var configuration = Argument("configuration", "Release");
var solutions = GetFiles("./**/*.csproj");
var solutionPaths = solutions.Select(solution => solution.GetDirectory());
var publishPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Publish");
var publishNugetPath = System.IO.Path.Combine(publishPath, "NuGet");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Version")
    .Does(() => {
        var propsFile = "./Directory.Build.props";
        var readedVersion = XmlPeek(propsFile, "//Version");
        //var currentVersion = new Version(readedVersion);

        string[] versionPieces = readedVersion.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        string newVersion = null;

        versionPieces[2] = Convert.ToString(Convert.ToInt32(versionPieces[2]) + 1);
        versionPieces[3] = Convert.ToString(Convert.ToInt32((DateTime.Now - new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)).TotalSeconds));

        newVersion = versionPieces[0] + "." + versionPieces[1] + "." + versionPieces[2] + "." + versionPieces[3];

        //var currentRevision = currentVersion.Revision;

        //Information("Current revision is " + currentRevision.ToString());

        //var semVersion = new Version(
        //    currentVersion.Major,
        //    currentVersion.Minor,
        //    currentVersion.Revision + 1,
        //    Convert.ToInt32((DateTime.Now - new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)).TotalSeconds)
        //);

        //XmlPoke(propsFile, "//Version", semVersion.ToString());
        XmlPoke(propsFile, "//Version", newVersion);
        //Information("Version is set to " + semVersion.ToString());
        Information("Version is set to " + newVersion);
});

Task("Clean")
    .Does(() =>
{
// Clean solution directories.
    foreach(var path in solutionPaths)
    {
        Information("Cleaning {0}", path);
        CleanDirectories(path + "/**/bin/Debug/net**/");
        CleanDirectories(path + "/**/obj/Release/net**/");
    }    
});

Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Version")
    .Does(() => {
        Information("Current configuration is " + configuration);

        DotNetBuild("./Whippet.sln", new DotNetBuildSettings
        {
            Configuration = configuration,
        });
        
        foreach (var path in solutionPaths)
        {
            var nugetDirectory = Directory(path + "/bin/Release");
            var sourceDirectory = GetDirectories(path + "/bin/Release/net**/").OrderByDescending(d => d.FullPath).FirstOrDefault();
            
            if (!DirectoryExists(publishNugetPath))
            {
                CreateDirectory(publishNugetPath);
            }
            
            if (sourceDirectory != null)
            {
                CopyDirectory(sourceDirectory, publishPath);
            }
            
            if (nugetDirectory != null)
            {
                // copy all NuGet packages
                CopyFiles(System.IO.Path.Combine(nugetDirectory, "*.nupkg"), Directory(publishNugetPath), false);  
            }
        }
    });

// Re-enable this when dotnettest works correctly on mac os --ATH 1/16/23

//Task("Test")
//    .IsDependentOn("Build")
//    .Does(() =>
//{
//    DotNetTest("./src/Example.sln", new DotNetTestSettings
//    {
//        Configuration = configuration,
//        NoBuild = true,
//    });
//});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);