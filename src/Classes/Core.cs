using english_words_console.Models;
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
    private readonly string _wordsBaseFileName = "words.txt";
    private readonly string _wordsLearnFileName = "wordsLearn.txt";
    private readonly ConsoleLogs _consoleLogs = new();

    private readonly List<string> _wordsBase = [];
    private readonly List<WordLearn> _wordsLearn = [];

    private async Task<bool> DownloadWords()
    {
      try
      {
        using HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync(_wordsRaw);

        response.EnsureSuccessStatusCode();

        using Stream contentStream = await response.Content.ReadAsStreamAsync();
        using FileStream fileStream = new(_wordsBaseFileName, FileMode.Create, FileAccess.Write, FileShare.None, 8193, true);

        await contentStream.CopyToAsync(fileStream);

        return true;
      }
      catch (Exception)
      {
        return false;
        throw;
      }
    }

    internal async Task<bool> CheckWordsBase()
    {
      if (!File.Exists(_wordsBaseFileName))
      {
        _consoleLogs.Info($"El archivo {_wordsBaseFileName} no fue encontrado . ¿Quieres descargarlo desde Github?");
        _consoleLogs.Info($"Para descargar el archivo {_wordsBaseFileName}, presiona (y), para salir presione cualquier tecla: ", true);

        if (Console.ReadKey().Key == ConsoleKey.Y)
        {
          Console.WriteLine();

          _consoleLogs.Warning($"Descargando el archivo {_wordsBaseFileName} desde Github...");

          bool downloadWords = await DownloadWords();

          if (!downloadWords)
          {
            _consoleLogs.Error($"Hubo un problema al intentar descargar el archivo {_wordsBaseFileName}");
          }

          _consoleLogs.Success($"Archivo {_wordsBaseFileName} descargado correctamente.");

          return true;
        }

        Console.WriteLine();

        _consoleLogs.Error($"Sin un archivo {_wordsBaseFileName} la aplicación no puede funcionar.");
        _consoleLogs.Info($"También puedes descargar el archivo {_wordsBaseFileName} desde el repositorio de Github.");
        _consoleLogs.Info("https://github.com/alemndev/english-words-console");

        return false;
      }

      return true;
    }

    private void CheckWordsLearn()
    {
      if (!File.Exists(_wordsLearnFileName))
      {
        using StreamWriter writer = new(_wordsLearnFileName, append: true);

        foreach (string word in _wordsBase)
        {
          writer.WriteLine($"{word};False;0;");
        }
      }
    }

    private void LoadWordsBase()
    {
      IEnumerable<string> lines = File.ReadLines(_wordsBaseFileName);

      foreach (string line in lines)
      {
        _wordsBase.Add(line);
      }
    }

    private void LoadWordsLearn()
    {
      IEnumerable<string> lines = File.ReadLines(_wordsLearnFileName);

      foreach (string line in lines)
      {
        string[] wordSplit = line.Split(';');

        if (wordSplit.Length == 4)
        {
          WordLearn word = new()
          {
            Value = wordSplit[0],
            Learned = Convert.ToBoolean(wordSplit[1]),
            TimesLearned = Convert.ToInt32(wordSplit[2])
          };

          _wordsLearn.Add(word);
        }
      }
    }


    internal void Welcome()
    {
      Console.Clear();

      LoadWordsBase();
      CheckWordsLearn();
      LoadWordsLearn();

      while (true)
      {
        Console.Clear();

        int wordsLearnedCount = _wordsLearn.Where(w => w.Learned).Count();
        string withoutWordsLearned = "Aún no has aprendido una palabra, aprende una ahora.";
        string withWordsLearned = $"Aprendiste un total de {wordsLearnedCount} {(wordsLearnedCount == 1 ? "palabra" : "palabras")}.";

        _consoleLogs.Info();
        _consoleLogs.Info("English words console v1.0.0");
        _consoleLogs.Info();
        _consoleLogs.Info($"Se cargaron un total de {_wordsLearn.Count} palabras.");
        _consoleLogs.Info(wordsLearnedCount == 0 ? withoutWordsLearned : withWordsLearned);
        _consoleLogs.Info();
        _consoleLogs.Info("Seleccione una opción");
        _consoleLogs.Info("1. Aprender una palabra nueva.");
        _consoleLogs.Info("2. Ver las palabras que has aprendido hasta ahora.");
        _consoleLogs.Info("3. Salir.");
        _consoleLogs.Info("Tu opción: ", true);

        string? option = Console.ReadLine();

        switch (option)
        {
          case "1":
            Console.WriteLine("Aprender palabra nueva");
            Console.ReadKey();
            break;
          case "2":
            Console.WriteLine("Ver las palabras que has aprendido hasta ahora");
            Console.ReadKey();
            break;
          case "3":
            Environment.Exit(0);
            break;
          default:
            break;
        }
      }
    }
  }
}
