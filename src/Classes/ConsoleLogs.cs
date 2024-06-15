using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace english_words_console.Classes
{
  internal class ConsoleLogs
  {
    // :: WriteLine
    internal void Info(string message, bool oneLine = false)
    {
      message = $"| :: {message}";

      Console.ForegroundColor = ConsoleColor.White;

      if (oneLine)
      {
        Console.Write(message);
        Console.ResetColor();

        return;
      }

      Console.WriteLine(message);
      Console.ResetColor();
    }

    internal void Warning(string message, bool oneLine = false)
    {
      message = $"| :: {message}";

      Console.ForegroundColor = ConsoleColor.DarkYellow;

      if (oneLine)
      {
        Console.Write(message);
        Console.ResetColor();

        return;
      }

      Console.WriteLine(message);
      Console.ResetColor();
    }

    internal void Success(string message, bool oneLine = false)
    {
      message = $"| :: {message}";

      Console.ForegroundColor = ConsoleColor.DarkGreen;

      if (oneLine)
      {
        Console.Write(message);
        Console.ResetColor();

        return;
      }

      Console.WriteLine(message);
      Console.ResetColor();
    }

    internal void Error(string message, bool oneLine = false)
    {
      message = $"| :: {message}";

      Console.ForegroundColor = ConsoleColor.DarkRed;

      if (oneLine)
      {
        Console.Write(message);
        Console.ResetColor();

        return;
      }

      Console.WriteLine(message);
      Console.ResetColor();
    }

    internal void Default(string message, bool oneLine = false)
    {
      message = $"| :: {message}";

      Console.ForegroundColor = ConsoleColor.White;

      if (oneLine)
      {
        Console.Write(message);
        Console.ResetColor();

        return;
      }

      Console.WriteLine(message);
      Console.ResetColor();
    }

    internal void Info()
    {
      string line = "|-------------------------------------------------------------------";

      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine(line);
      Console.ResetColor();
    }
  }
}
