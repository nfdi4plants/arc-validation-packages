module invenio


open System.IO
open Xunit
open ARCTokenization
open ControlledVocabulary
open System
open Fake.DotNet
open TestUtils
open ARCExpect
open System.Text.Json
open ValidationPackages.Tests


//let arcDir = Path.Combine(__SOURCE_DIRECTORY__, "fixtures", "ArcPrototype")

//let absoluteDirectoryPaths = FileSystem.parseARCFileSystem arcDir

//let investigationMetadata = 
//    absoluteDirectoryPaths
//    |> Investigation.parseMetadataSheetsFromTokens() arcDir 
//    |> List.concat 

//// Investigation has title
//let expectedTitleCvPExists =
//    investigationMetadata 
//    |> List.exists (
//        fun ip -> 
//            Param.getCvAccession ip = "INVMSO:00000009" && 
//            Param.getValueAsString ip |> String.IsNullOrWhiteSpace |> not && 
//            match Param.getParamValue ip with | CvValue x -> x.Accession = "AGMO:00000001" | _ -> false
//    )

//Assert.True expectedTitleCvPExists


module ArcPrototype =

    [<Fact>]
    let ``result Exitcode is 0`` () =
        let result = runTool "dotnet" [|"fsi"; "../../validation_packages/invenio/invenio@3.0.0.fsx"|] "fixtures/ArcPrototype"

        Assert.Equal(0, result.ExitCode)

    [<Fact>]
    let ``validation_summary.json is equal`` () =
        let arcExpectValidationResult = ARCExpect.ValidationSummary.fromJson (File.ReadAllText "fixtures/ArcPrototype/.arc-validate-results/invenio@3.0.0/validation_summary.json")
        Assert.Equal(ReferenceObjects.invenio.ArcPrototype.validationResultCritical, arcExpectValidationResult.Critical)
        Assert.Equal(ReferenceObjects.invenio.ArcPrototype.validationResultNonCritical, arcExpectValidationResult.NonCritical)


module testARC_emptyContacts =

    [<Fact>]
    let ``result Exitcode is 1`` =
        let result = runTool "dotnet" [|"fsi"; "../../validation_packages/invenio/invenio@3.0.0.fsx"|] "fixtures/testARC_emptyContactsColumn"
        Assert.Equal(1, result.ExitCode)

    [<Fact>]
    let ``validation_summary.json is equal`` () =
        let arcExpectValidationResult = ARCExpect.ValidationSummary.fromJson (File.ReadAllText "fixtures/testARC_emptyContacts/.arc-validate-results/invenio@3.0.0/validation_summary.json")
        Assert.Equal(ReferenceObjects.invenio.testARC_emptyContacts.validationResultCritical, arcExpectValidationResult.Critical)
        Assert.Equal(ReferenceObjects.invenio.testARC_emptyContacts.validationResultNonCritical, arcExpectValidationResult.NonCritical)


module testARC_empty