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
