module invenio


open ValidationPackages.Tests
open TestUtils

open Xunit
open ARCExpect

open System.IO


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
    let ``validation_summary JSON is equal`` () =
        // this is needed due to the unordered sequencing and partial parallelism xUnit works with. Otherwise it is not ensured that the necessary summary file is present.
        runTool "dotnet" [|"fsi"; "../../validation_packages/invenio/invenio@3.0.0.fsx"|] "fixtures/ArcPrototype" |> ignore

        let arcExpectValidationResult = ARCExpect.ValidationSummary.fromJson (File.ReadAllText "fixtures/ArcPrototype/.arc-validate-results/invenio@3.0.0/validation_summary.json")
        Assert.Equal(ReferenceObjects.invenio.ArcPrototype.validationResultCritical, arcExpectValidationResult.Critical)
        Assert.Equal(ReferenceObjects.invenio.ArcPrototype.validationResultNonCritical, arcExpectValidationResult.NonCritical)


module testARC_empty =

    [<Fact>]
    let ``result Exitcode is 0`` () =
        let result = runTool "dotnet" [|"fsi"; "../../validation_packages/invenio/invenio@3.0.0.fsx"|] "fixtures/testARC_empty"
        Assert.Equal(0, result.ExitCode)

    [<Fact>]
    let ``validation_summary JSON is equala`` () =
        // this is needed due to the unordered sequencing and partial parallelism xUnit works with. Otherwise it is not ensured that the necessary summary file is present.
        runTool "dotnet" [|"fsi"; "../../validation_packages/invenio/invenio@3.0.0.fsx"|] "fixtures/ArcPrototype" |> ignore

        let arcExpectValidationResult = ARCExpect.ValidationSummary.fromJson (File.ReadAllText "fixtures/testARC_empty/.arc-validate-results/invenio@3.0.0/validation_summary.json")
        Assert.Equal(ReferenceObjects.invenio.testARC_empty.validationResultCritical, arcExpectValidationResult.Critical)
        Assert.Equal(ReferenceObjects.invenio.testARC_empty.validationResultNonCritical, arcExpectValidationResult.NonCritical)


module testARC_emptyContactsColumn =

    [<Fact>]
    let ``result Exitcode is 0`` () =
        let result = runTool "dotnet" [|"fsi"; "../../validation_packages/invenio/invenio@3.0.0.fsx"|] "fixtures/testARC_emptyContactsColumn"
        Assert.Equal(0, result.ExitCode)

    [<Fact>]
    let ``validation_summary JSON is equal`` () =
        // this is needed due to the unordered sequencing and partial parallelism xUnit works with. Otherwise it is not ensured that the necessary summary file is present.
        runTool "dotnet" [|"fsi"; "../../validation_packages/invenio/invenio@3.0.0.fsx"|] "fixtures/testARC_emptyContactsColumn" |> ignore

        let arcExpectValidationResult = ARCExpect.ValidationSummary.fromJson (File.ReadAllText "fixtures/testARC_emptyContactsColumn/.arc-validate-results/invenio@3.0.0/validation_summary.json")
        Assert.Equal(ReferenceObjects.invenio.testARC_emptyContactsColumn.validationResultCritical, arcExpectValidationResult.Critical)
        Assert.Equal(ReferenceObjects.invenio.testARC_emptyContactsColumn.validationResultNonCritical, arcExpectValidationResult.NonCritical)


module shiftedContactsCells =

    [<Fact>]
    let ``result Exitcode is 0`` () =
        let result = runTool "dotnet" [|"fsi"; "../../validation_packages/invenio/invenio@3.0.0.fsx"|] "fixtures/testARC_shiftedContactsCells"
        Assert.Equal(0, result.ExitCode)

    [<Fact>]
    let ``validation_summary JSON is equal`` () =
        // this is needed due to the unordered sequencing and partial parallelism xUnit works with. Otherwise it is not ensured that the necessary summary file is present.
        runTool "dotnet" [|"fsi"; "../../validation_packages/invenio/invenio@3.0.0.fsx"|] "fixtures/testARC_shiftedContactsCells" |> ignore

        let arcExpectValidationResult = ARCExpect.ValidationSummary.fromJson (File.ReadAllText "fixtures/testARC_shiftedContactsCells/.arc-validate-results/invenio@3.0.0/validation_summary.json")
        Assert.Equal(ReferenceObjects.invenio.testARC_shiftedContactsCells.validationResultCritical, arcExpectValidationResult.Critical)
        Assert.Equal(ReferenceObjects.invenio.testARC_shiftedContactsCells.validationResultNonCritical, arcExpectValidationResult.NonCritical)


module shiftedTitleCell =

    [<Fact>]
    let ``result Exitcode is 0`` () =
        let result = runTool "dotnet" [|"fsi"; "../../validation_packages/invenio/invenio@3.0.0.fsx"|] "fixtures/testARC_shiftedTitleCell"
        Assert.Equal(0, result.ExitCode)

    [<Fact>]
    let ``validation_summary JSON is equal`` () =
        // this is needed due to the unordered sequencing and partial parallelism xUnit works with. Otherwise it is not ensured that the necessary summary file is present.
        runTool "dotnet" [|"fsi"; "../../validation_packages/invenio/invenio@3.0.0.fsx"|] "fixtures/testARC_shiftedTitleCell" |> ignore

        let arcExpectValidationResult = ARCExpect.ValidationSummary.fromJson (File.ReadAllText "fixtures/testARC_shiftedTitleCell/.arc-validate-results/invenio@3.0.0/validation_summary.json")
        Assert.Equal(ReferenceObjects.invenio.testARC_shiftedTitleCell.validationResultCritical, arcExpectValidationResult.Critical)
        Assert.Equal(ReferenceObjects.invenio.testARC_shiftedTitleCell.validationResultNonCritical, arcExpectValidationResult.NonCritical)


module wrongEmail =

    [<Fact>]
    let ``result Exitcode is 0`` () =
        let result = runTool "dotnet" [|"fsi"; "../../validation_packages/invenio/invenio@3.0.0.fsx"|] "fixtures/testARC_wrongEmail"
        Assert.Equal(0, result.ExitCode)

    [<Fact>]
    let ``validation_summary JSON is equal`` () =
        // this is needed due to the unordered sequencing and partial parallelism xUnit works with. Otherwise it is not ensured that the necessary summary file is present.
        runTool "dotnet" [|"fsi"; "../../validation_packages/invenio/invenio@3.0.0.fsx"|] "fixtures/testARC_wrongEmail" |> ignore

        let arcExpectValidationResult = ARCExpect.ValidationSummary.fromJson (File.ReadAllText "fixtures/testARC_wrongEmail/.arc-validate-results/invenio@3.0.0/validation_summary.json")
        Assert.Equal(ReferenceObjects.invenio.testARC_wrongEmail.validationResultCritical, arcExpectValidationResult.Critical)
        Assert.Equal(ReferenceObjects.invenio.testARC_wrongEmail.validationResultNonCritical, arcExpectValidationResult.NonCritical)