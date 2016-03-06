#r @"packages/FAKE.4.21.0/tools/NuGet.Core.dll"
#r @"packages/FAKE.4.21.0/tools/FakeLib.dll"

open Fake

let exec command args =
  let result = Shell.Exec(command, args)

  if result <> 0 then failwithf "%s exited with error %d" command result

Target "restore" (fun () ->
  exec "tools/NuGet.exe" "restore QuickLayout.sln"
)

Target "build" (fun () ->
  MSBuild null "Build" [ "Configuration", "Debug" ] [ "QuickLayout.sln" ] 
  |> ignore
)

"restore"
  ==> "build"
  
RunTarget()