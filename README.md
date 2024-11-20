# ValidationPackages

ARC validation packages for avpr.nfdi4plants.org maintained by DataPLANT

Validation packages are executed in appropriate ARC fixtures placed in `tests/fixtures`.

Test output is then subject to unit testing.

## Pull submodules

ArcPrototype is a submodule in /tests/fixtures/ folder. When cloning the repo it will be empty.

In project root:

```bash
git pull --recurse-submodules
```

## Build

In project root:

```bash
dotnet build
```

## Run tests

In project root:

```bash
dotnet test
```

## Updating integration tests of packages

1. Run the validation package once and make sure that the output matches the expected result
2. Copy the `validationSummary.json` from `<arcPath>/.arc-results/` to `<root>/tests/fixtures/validationSummary/<packageName>/<version>/<nameOfTestArc>`
3. Do the same for `validationReport.xml`
4. Create a new file according to the new package in the test project in the format `<packageName>@<version>.fs`, e.g. `invenio@1.2.3.fs`
5. Use the structure and types from existing files, copy them and refactor them accordingly
6. Create respective in-memory validation results in `ReferenceObjects.fs`
