# Farbfeld Format Add-in

## Purpose

This sample is for teaching how to create a custom export format for Pinta as an add-in.

## The Format

The Farbfeld format was envisioned and specified by a community of hackers. It is essentially raw pixel data that is easy to generate and pipe into other programs. The gist of it is the separation of image generation from image compression/encoding, two processes which are often done together.

For more information, see the [official page of the format](https://tools.suckless.org/farbfeld/).

## Guide for Creating a Custom Format Add-in

Create a solution and a class library project.

Add Pinta as a Git submodule:

```bash
git submodule add https://github.com/PintaProject/Pinta.git Pinta # From solution folder
```

Now see the `.csproj` file in this sample repo and follow the pattern. In summary:

- Determine an appropriate version of the .NET SDK
- Reference the `Pinta.Core` project
- Reference `Mono.Addins` (Extension system used for Pinta's add-ins)
- Reference `.addin.xml`, which contains the add-in's metadata

Implement your add-in. Look for the `FarbfeldFormat.cs` and `FarbfeldFormatExtension.cs` files and follow the pattern.

Build your add-in (the output will be in `[AddinProject]/bin/Release/net[X].[X]`, in this case `FarbfeldFormatAddin/bin/Release/net10.0`):

```bash
dotnet build -c Release
```

Install the packaging tool:

```bash
dotnet tool install --global Mono.Addins.UtilTool
```

Package the compiled add-in by referencing the output dll:

```bash
mautil pack FarbfeldFormatAddin/bin/Release/net10.0/FarbfeldFormatAddin.dll
```

You should get a `.mpack` file.

To test the add-in, load the `.mpack` into Pinta using the extension manager.

If you want to share the add-in with the community, go to the [repo for add-ins](https://github.com/PintaProject/Pinta-Community-Addins), look for the appropriate folder inside `repository` and open a pull request adding the `.mpack` inside that folder.

## To-do list

Show how to set up github workflows properly
