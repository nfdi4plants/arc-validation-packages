module TestObjects

let prototypeCommitHashOutput = TestUtils.getCommitHash "../../../fixtures/ArcPrototype"

let prototypeCommitHash = prototypeCommitHashOutput.Result.Output.TrimStart().TrimEnd()