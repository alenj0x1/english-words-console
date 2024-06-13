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
      message = $"| :: Info    :: {message}";

      Console.ForegroundColor = ConsoleColor.DarkCyan;

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
      message = $"| :: Warning :: {message}";

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
      message = $"| :: Success :: {message}";

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
      message = $"| :: Error   :: {message}";

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
      message = $"| :: Alert   :: {message}";

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
  }
}
