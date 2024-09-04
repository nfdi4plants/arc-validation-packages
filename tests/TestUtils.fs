module TestUtils

open System
open System.IO
open type System.Environment
open Fake.Core
open Fake.DotNet

let runScriptWithArgs (scriptPath: string) (args: string []) =
    let args = Array.concat [|[|scriptPath|]; args|]
    DotNet.exec 
        (fun p -> 
            {
                p with
                    RedirectOutput = true
                    PrintRedirectedOutput = true
            }
        )
        "fsi" 
        (args |> String.concat " ")

let runTool (tool: string) (args: string []) (dir:string) =
    CreateProcess.fromRawCommand tool args
    |> CreateProcess.withWorkingDirectory dir
    |> CreateProcess.redirectOutput
    |> Proc.run

let getCommitHash path = 
    let output = runTool "git" [|"rev-parse"; "HEAD"|] path
    output