# Configure F# interactive

First, ensure that .NET Core scripting is your default scripting environment:

1. Open the Visual Studio Code settings (*Code > Preferences > Settings*).
1. Search for the term *F# Script*.
1. Click the checkbox that says *FSharp: use SDK scripts*.

# initialize project (.NET Core 3.0 or higher)
```
dotnet new tool-manifest
```

# Initialize [Paket](http://fsprojects.github.io/Paket/get-started.html) by creating a dependencies file
```
dotnet tool install paket
dotnet paket init
```

## If you have a build.sh/build.cmd build script, also make sure you add the last two commands before you execute your build:
```
dotnet tool restore
dotnet paket restore
# Your call to build comes after the restore calls, possibly with FAKE: https://fake.build/
```
This will ensure Paket works in any .NET Core build environment.

## Make sure to add the following entries to your .gitignore:
```
#Paket dependency manager
.paket/
paket-files/
```

# Install [FAKE](https://fake.build/fake-gettingstarted.html) as a local dotnet tool (easiest, but needs .NET Core SDK Version 3 or newer)
```
dotnet tool install fake-cli
```
## Bootstrap via the fake dotnet new template. The template bootstraps FAKE and sets up a basic build-script.

To install the template run:
```
dotnet new -i "fake-template::*"
```
Then run the template with:
```
dotnet new fake
```