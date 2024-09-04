module GitSubmoduleTests

open System
open System.IO
open Xunit

[<Fact>]
let ``ArcPrototype commit hash is correct`` () = 
    Assert.Equal(
        ReferenceObjects.expected_prototype_commit_hash, 
        TestObjects.prototypeCommitHash
    )
