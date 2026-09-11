using Pinta.Core;

namespace FarbfeldFormatAddin;

[Mono.Addins.Extension]
public class FarbfeldFormatExtension : IExtension
{
    const string SHORT_EXTENSION_UPPERCASE = "FF";
    const string SHORT_EXTENSION_LOWERCASE = "ff";

    public void Initialize()
    {
        FarbfeldFormat farbfeldFormat = new();
        FormatDescriptor farbfeldFormatDescriptor = new(
            displayPrefix: "Farbfeld",
            extensions: [SHORT_EXTENSION_UPPERCASE, SHORT_EXTENSION_LOWERCASE],
            mimes: ["image/farbfeld", "image/x-farbfeld"],
            importer: farbfeldFormat,
            exporter: farbfeldFormat,
            supportsLayers: false);
        PintaCore.ImageFormats.RegisterFormat(farbfeldFormatDescriptor);
    }

    public void Uninitialize()
    {
        PintaCore.ImageFormats.UnregisterFormatByExtension(SHORT_EXTENSION_LOWERCASE);
    }
}
