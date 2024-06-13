using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace english_words_console.Classes
{
  internal class Core
  {
    private readonly string _wordsRaw = "https://raw.githubusercontent.com/alemndev/english-words-console/main/words.txt";
    private readonly string _wordsFileName = "words.txt";
    private readonly ConsoleLogs _consoleLogs = new ConsoleLogs();

    internal async Task<bool> DownloadWords()
    {
      try
      {
        using HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync(_wordsRaw);

        response.EnsureSuccessStatusCode();

        using Stream contentStream = await response.Content.ReadAsStreamAsync();
        using FileStream fileStream = new(_wordsFileName, FileMode.Create, FileAccess.Write, FileShare.None, 8193, true);

        await contentStream.CopyToAsync(fileStream);

        return true;
      }
      catch (Exception)
      {
        return false;
        throw;
      }
    }

    internal async Task<bool> CheckWords()
    {
      if (!File.Exists(_wordsFileName))
      {
        _consoleLogs.Info($"El archivo {_wordsFileName} no fue encontrado . ¿Quieres descargarlo desde Github?");
        _consoleLogs.Info($"Para descargar el archivo {_wordsFileName}, presiona (y), para salir presione cualquier tecla: ", true);

        if (Console.ReadKey().Key == ConsoleKey.Y)
        {
          Console.WriteLine();

          _consoleLogs.Warning($"Descargando el archivo {_wordsFileName} desde Github...");

          bool downloadWords = await DownloadWords();

          if (!downloadWords)
          {
            _consoleLogs.Error($"Hubo un problema al intentar descargar el archivo {_wordsFileName}");
          }

          _consoleLogs.Success($"Archivo {_wordsFileName} descargado correctamente.");

          return true;
        }

        Console.WriteLine();

        _consoleLogs.Error($"Sin un archivo {_wordsFileName} la aplicación no puede funcionar.");
        _consoleLogs.Info($"También puedes descargar el archivo {_wordsFileName} desde el repositorio de Github.");
        _consoleLogs.Info("https://github.com/alemndev/english-words-console");

        return false;
      }

      return true;
    }

    internal void Welcome()
    {
      Console.Clear();

      _consoleLogs.Info("English words console v1.0.0");
      _consoleLogs.Info("Seleccion una opción");
      _consoleLogs.Info("1. Aprender una palabra nueva.");
      _consoleLogs.Info("2. Ver las palabras que has aprendido hasta ahora.");
      _consoleLogs.Info("3. Salir.");
      _consoleLogs.Info("Tu opción: ", true);

      Console.ReadKey();
    }
  }
}
