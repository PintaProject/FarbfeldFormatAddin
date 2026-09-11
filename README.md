# Farbfeld Format Add-in for Pinta

Sample implementation of a custom export format add-in for Pinta. [Farbfeld](https://tools.suckless.org/farbfeld/) decouples pixel generation from compression via raw, pipeable 16-bit RGBA streams.

## Implementation Pattern

Follow the sample project structure:

* **Project:** .NET class library referencing `Pinta.Core`, `Mono.Addins`, and `.addin.xml` (metadata).
* **Format Logic:** `FarbfeldFormat.cs` (encode/export) and `FarbfeldFormatExtension.cs` (add-in registration).

## Build & Packaging

```bash
git submodule add https://github.com/PintaProject/Pinta.git Pinta # Dependency
dotnet build -c Release # Build
dotnet tool install --global Mono.Addins.UtilTool # Package tool
mautil pack FarbfeldFormatAddin/bin/Release/net10.0/FarbfeldFormatAddin.dll # Package (.mpack)
```

## Testing & Distribution

* **Local test:** Load generated `.mpack` via Pinta's Extension Manager.
* **Publish:** Open PR adding the `.mpack` to the target directory in [Pinta-Community-Addins](https://github.com/PintaProject/Pinta-Community-Addins).

## TODO

* Add GitHub workflows to guide
