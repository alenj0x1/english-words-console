using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace english_words_console.Models
{
  internal class WordLearn
  {
    internal string Value { get; set; }
    internal bool Learned { get; set; } = false;
    internal int TimesLearned { get; set; } = 0;
  }
}
