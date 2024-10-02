namespace ValidationPackages.Tests.ReferenceObjects

open System.IO
open ARCExpect


[<AutoOpen>]
module General =

    let expected_prototype_commit_hash = "2635598d9ea365c7ce545a9f279cca39af3de5df"


module invenio =

    let validationResultCritical =
        ValidationResult.create(10,10,0,0)

    let validationResultNonCritical =
        ValidationResult.create(0,0,0,0)