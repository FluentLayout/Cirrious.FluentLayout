/*
 * Author: Roger Weiss
 * Requires: http://cakebuild.net to run.
 * Install Cake Build bootstrap once-off:
 *
 * Windows:
 * Open a new PowerShell window and run the following command
 *   C> Invoke-WebRequest http://cakebuild.net/download/bootstrapper/windows -OutFile build.ps1
 * May need allow remote scripts permission in order to run build.ps1
 *   PS> Set-ExecutionPolicy RemoteSigned
 *
 * OS X:
 * Open a new shell and run the following command.
 *   $> curl -Lsfo build.sh http://cakebuild.net/download/bootstrapper/osx
 *
 *  Enable execute permissions
 *   $> chmod +x build.sh
 *
 * Example usage:
 *  ./build.sh -target="NugetPackage" -packageVersion="2.7.0"
 */

#addin nuget:?package=Cake.Git
#addin "nuget:?package=Cake.ExtendedNuGet"
#addin "nuget:?package=NuGet.Core"

var target = Argument("target", "Default");
var packageVersion = Argument("packageVersion", "2.7.0");
//var nugetSource = "https://nuget.org";
var solutionFile = "QuickLayout.sln";


Task("NugetPackageRestore")
    .Does(() =>
{
    NuGetRestore(solutionFile);
});

void SetAssemblyVersion(string file, string os, string version)
{
    CreateAssemblyInfo(file, new AssemblyInfoSettings {
        Title = "Cirrious.FluentLayout",
        Product = "Cirrious.FluentLayout",
        Description = "Easy API for using AutoLayout in " + os,
        Version = version,
        FileVersion = version,
        Copyright = string.Format("Copyright (c) 2013 - {0}", DateTime.Now.Year)
    });
}

Task("SetAssemblyVersion")
    .Does(() =>
{
   SetAssemblyVersion("./Cirrious.FluentLayout/Properties/AssemblyInfo.cs", "iOS", packageVersion);
   SetAssemblyVersion("./Cirrious.FluentLayout.tvOS/Properties/AssemblyInfo.cs", "iOS", packageVersion);
});

Task("BuildSolution")
     .IsDependentOn("NugetPackageRestore")
     .IsDependentOn("SetAssemblyVersion")
     .Does(() => 
{
    MSBuild(solutionFile, settings => settings
        .SetConfiguration("Release")
        .WithTarget("Clean")
        .WithTarget("Build")
        .WithProperty("Platform", "iPhoneSimulator")); 
});

Task("NugetPackage")
    .IsDependentOn("BuildSolution")
    .Does(() => {
    
    if (string.IsNullOrWhiteSpace(packageVersion))
    {
       throw new ArgumentNullException("-packageVersion command line parameter missing");
    };

    if (DirectoryExists("dist")) { DeleteDirectory("dist", true); }
    CreateDirectory("dist");

    var nugetPackSettings = new NuGetPackSettings();
    nugetPackSettings.Version = packageVersion;
    nugetPackSettings.OutputDirectory = "dist";
    var nuspecFile = $"./nuspec/Cirrious.FluentLayout.nuspec";
    NuGetPack(nuspecFile, nugetPackSettings);
});

Task("Default")
  .IsDependentOn("NugetPackage")
  .Does(() =>
{
});  


RunTarget(target);