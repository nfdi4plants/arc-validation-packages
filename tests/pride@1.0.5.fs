module pride_1_0_5


open ValidationPackages.Tests
open TestUtils

open Xunit
open ARCExpect

open System.IO
open System


type BaseTool_Fixture(scriptName : string, version : string, arcfolder : string) =

    let result = runTool "dotnet" [|"fsi"; $"../../validation_packages/{scriptName}/{scriptName}@{version}.fsx"|] $"fixtures/{arcfolder}"

    let arcExpectValidationResult = ARCExpect.ValidationSummary.fromJson (File.ReadAllText $"fixtures/{arcfolder}/.arc-validate-results/{scriptName}@{version}/validation_summary.json")

    let jUnitResult = JUnitResults.fromJUnitFile $"fixtures/{arcfolder}/.arc-validate-results/{scriptName}@{version}/validation_report.xml"

    let jUnitExpected = JUnitResults.fromJUnitFile $"fixtures/validationReport/{scriptName}/{version}/{arcfolder}/validation_report.xml"

    interface IDisposable with
        override this.Dispose() =
            Directory.Delete($"fixtures/{arcfolder}/.arc-validate-results/{scriptName}@{version}/", true)

    member this.Result = result

    member this.ArcExpectValidationResult = arcExpectValidationResult

    member this.JUnitResult = jUnitResult

    member this.JUnitExpected = jUnitExpected


type testARC_proteomicsCorrect_Fixture() =

    inherit BaseTool_Fixture("pride", "1.0.5", "testARC_proteomicsCorrect")


type testARC_proteomicsCorrect() =

    let tool_fixture = new testARC_proteomicsCorrect_Fixture()

    interface IClassFixture<testARC_proteomicsCorrect_Fixture>

    member this.Fixture with get() = tool_fixture

    [<Fact>]
    member this.``result Exitcode is 0`` () =
        Assert.Equal(0, this.Fixture.Result.ExitCode)

    [<Fact>]
    member this.``validation_summary JSON is equal`` () =
        Assert.Equal(ReferenceObjects.pride.``1_0_5``.testARC_proteomicsCorrect.validationResultCritical, this.Fixture.ArcExpectValidationResult.Critical)
        Assert.Equal(ReferenceObjects.pride.``1_0_5``.testARC_proteomicsCorrect.validationResultNonCritical, this.Fixture.ArcExpectValidationResult.NonCritical)

    [<Fact>]
    member this.``validation_report XML is equal`` () =
        Assert.Equal(this.Fixture.JUnitExpected, this.Fixture.JUnitResult)


type testARC_proteomicsModifValueMissing_Fixture() =

    inherit BaseTool_Fixture("pride", "1.0.5", "testARC_proteomicsModifValueMissing")


type testARC_proteomicsModifValueMissing() =

    let tool_fixture = new testARC_proteomicsModifValueMissing_Fixture()

    interface IClassFixture<testARC_proteomicsModifValueMissing_Fixture>

    member this.Fixture with get() = tool_fixture

    [<Fact>]
    member this.``result Exitcode is 0`` () =
        Assert.Equal(0, this.Fixture.Result.ExitCode)

    [<Fact>]
    member this.``validation_summary JSON is equal`` () =
        Assert.Equal(ReferenceObjects.pride.``1_0_5``.testARC_proteomicsModifValueMissing.validationResultCritical, this.Fixture.ArcExpectValidationResult.Critical)
        Assert.Equal(ReferenceObjects.pride.``1_0_5``.testARC_proteomicsModifValueMissing.validationResultNonCritical, this.Fixture.ArcExpectValidationResult.NonCritical)

    [<Fact>]
    member this.``validation_report XML is equal`` () =
        Assert.Equal(this.Fixture.JUnitExpected, this.Fixture.JUnitResult)


type testARC_proteomicsAlternativeTerms_Fixture() =

    inherit BaseTool_Fixture("pride", "1.0.5", "testARC_proteomicsAlternativeTerms")


type testARC_proteomicsAlternativeTerms() =

    let tool_fixture = new testARC_proteomicsAlternativeTerms_Fixture()

    interface IClassFixture<testARC_proteomicsAlternativeTerms_Fixture>

    member this.Fixture with get() = tool_fixture

    [<Fact>]
    member this.``result Exitcode is 0`` () =
        Assert.Equal(0, this.Fixture.Result.ExitCode)

    [<Fact>]
    member this.``validation_summary JSON is equal`` () =
        Assert.Equal(ReferenceObjects.pride.``1_0_5``.testARC_proteomicsAlternativeTerms.validationResultCritical, this.Fixture.ArcExpectValidationResult.Critical)
        Assert.Equal(ReferenceObjects.pride.``1_0_5``.testARC_proteomicsAlternativeTerms.validationResultNonCritical, this.Fixture.ArcExpectValidationResult.NonCritical)

    [<Fact>]
    member this.``validation_report XML is equal`` () =
        Assert.Equal(this.Fixture.JUnitExpected, this.Fixture.JUnitResult)