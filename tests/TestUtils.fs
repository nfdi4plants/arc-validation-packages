module TestUtils


open System.Xml

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


type JUnitResults = {
    PassedTests: string list
    FailedTests: string list
    ErroredTests: string list
} with
    static member fromJUnitFile (path : string) =
        let doc = new XmlDocument()
        doc.Load(path)
        let suite = 
            doc.SelectNodes("/testsuites/testsuite[@name='arc-validate']").Item(0)
            |> fun r -> 
                if isNull r then
                    doc.SelectNodes("/testsuites/testsuite[@name='fsi']").Item(0)
                else r
        let testCases = suite.SelectNodes("testcase") |> Seq.cast<XmlNode>
        {
            PassedTests =
                testCases
                |> Seq.filter (fun tc -> tc.SelectNodes("failure").Count = 0)
                |> Seq.map (fun tc -> tc.Attributes.["name"].Value)
                |> Seq.toList
                |> List.sort

            FailedTests =
                testCases
                |> Seq.filter (fun tc -> tc.SelectNodes("failure").Count > 0)
                |> Seq.map (fun tc -> tc.Attributes.["name"].Value)
                |> Seq.toList
                |> List.sort

            ErroredTests =
                testCases
                |> Seq.filter (fun tc -> tc.SelectNodes("error").Count > 0)
                |> Seq.map (fun tc -> tc.Attributes.["name"].Value)
                |> Seq.toList
                |> List.sort
        }

    static member getTotalTestCount (res : JUnitResults) =
        res.ErroredTests.Length + res.FailedTests.Length + res.PassedTests.Length