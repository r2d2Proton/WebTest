using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace WebTest.Utilities;

public class AssetLoader
{
    static public async Task<string> LoadTextFileAsync(string fileName)
    {
        using Stream fileStream = await FileSystem.OpenAppPackageFileAsync(fileName);
        using StreamReader reader = new StreamReader(fileStream);
        return await reader.ReadToEndAsync();
    }
}
