namespace ValidationPackages.Tests.ReferenceObjects

open System.IO
open ARCExpect


[<AutoOpen>]
module General =

    let expected_prototype_commit_hash = "2635598d9ea365c7ce545a9f279cca39af3de5df"


module invenio =

    module ``3_0_0`` =

        module ArcPrototype =

            let validationResultCritical =
                ValidationResult.create(10,10,0,0)

            let validationResultNonCritical =
                ValidationResult.create(0,0,0,0)


        module testARC_empty =

            let validationResultCritical =
                ValidationResult.create(10,4,6,0)

            let validationResultNonCritical =
                ValidationResult.create(0,0,0,0)


        module testARC_emptyContactsColumn =

            let validationResultCritical =
                ValidationResult.create(10,6,4,0)

            let validationResultNonCritical =
                ValidationResult.create(0,0,0,0)


        module testARC_shiftedContactsCells =

            let validationResultCritical =
                ValidationResult.create(10,9,1,0)

            let validationResultNonCritical =
                ValidationResult.create(0,0,0,0)


        module testARC_shiftedTitleCell =

            let validationResultCritical =
                ValidationResult.create(10,10,0,0)

            let validationResultNonCritical =
                ValidationResult.create(0,0,0,0)


        module testARC_wrongEmail =

            let validationResultCritical =
                ValidationResult.create(10,9,1,0)

            let validationResultNonCritical =
                ValidationResult.create(0,0,0,0)


module pride =

    module ``1_0_3`` =

        module testARC_proteomicsCorrect =

            let validationResultCritical =
                ValidationResult.create(22,22,0,0)

            let validationResultNonCritical =
                ValidationResult.create(0,0,0,0)


    module ``1_0_4`` =

        module testARC_proteomicsCorrect =

            let validationResultCritical =
                ValidationResult.create(23,23,0,0)

            let validationResultNonCritical =
                ValidationResult.create(0,0,0,0)


        module testARC_proteomicsModifValueMissing =

            let validationResultCritical =
                ValidationResult.create(23,22,1,0)

            let validationResultNonCritical =
                ValidationResult.create(0,0,0,0)