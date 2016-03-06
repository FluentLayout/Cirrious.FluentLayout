#r @"packages/FAKE.4.21.0/tools/NuGet.Core.dll"
#r @"packages/FAKE.4.21.0/tools/FakeLib.dll"

open System.IO
open System.Linq
open Fake

let exec command args =
  let result = Shell.Exec(command, args)

  if result <> 0 then failwithf "%s exited with error %d" command result

Target "restore" (fun () ->
  exec "tools/nuget.exe" "restore QuickLayout.sln"
)

Target "build" (fun () ->
  MSBuild null "Build" [ "Configuration", "Release" ] [ "QuickLayout.sln" ] 
  |> ignore
)

Target "nuget-package" (fun () ->
  if Directory.Exists("dist") then Directory.Delete("dist", true)
  Directory.CreateDirectory("dist") |> ignore

  exec "tools/nuget.exe" "pack nuspec/Cirrious.FluentLayout.nuspec -NoDefaultExcludes -OutputDirectory dist"
)

Target "nuget-push" (fun () ->
  let nupkgPath = Directory.EnumerateFiles("dist", "*.nupkg").First()

  exec "tools/nuget.exe" ("push " + nupkgPath)
)

"restore" 
  ==> "build" 
  ==> "nuget-package"
  ==> "nuget-push"
  
RunTarget()