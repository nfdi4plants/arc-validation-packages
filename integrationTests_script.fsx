#r "nuget: Xunit"
#r "nuget: Fake.DotNet.Cli"


open Xunit
open Fake.Core

open System.Xml


let runTool (tool: string) (args: string []) (dir:string) =
    CreateProcess.fromRawCommand tool args
    |> CreateProcess.withWorkingDirectory dir
    |> CreateProcess.redirectOutput
    |> Proc.run


//let result = runTool "dotnet" [|"fsi"; @"C:\Repos\nfdi4plants\arc-validation-packages\validation_packages\invenio\invenio@3.0.0.fsx"|] @"C:\Repos\nfdi4plants\arc-validation-packages\tests\fixtures\testARC_empty\"
let result = runTool "dotnet" [|"fsi"; @"C:\Repos\nfdi4plants\arc-validation-packages\validation_packages\invenio\invenio@3.0.0.fsx"|] @"C:\Repos\nfdi4plants\arc-validation-packages\tests\fixtures\testARC_emptyContactsColumn\"


type JUnitResults = {
    PassedTests: string list
    FailedTests: string list
    ErroredTests: string list
} with
    static member fromJUnitFile (path:string) =
        let doc = new XmlDocument()
        doc.Load(path)
        let suite = doc.SelectNodes("/testsuites/testsuite[@name='arc-validate']").Item(0);
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


let jUnitRes = JUnitResults.fromJUnitFile @"C:\Repos\nfdi4plants\arc-validation-packages\tests\fixtures\ArcPrototype\.arc-validate-results\invenio@3.0.0\validation_report.xml"

null = null

let doc = new XmlDocument()
doc.Load(@"C:\Repos\nfdi4plants\arc-validation-packages\tests\fixtures\ArcPrototype\.arc-validate-results\invenio@3.0.0\validation_report.xml")
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