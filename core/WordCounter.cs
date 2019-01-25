using System;

namespace word_counter.core
{   public static class WordCounter
    {        
        public static int CountWordInText(this string value, string word, int startFrom = 0)
        {
            if (string.IsNullOrWhiteSpace(word)) throw new ArgumentException("What to count?", "word");

            if (startFrom > value.Length) return 0;

            var occurrences = 0;

            var position = value.IndexOf(word, startFrom, StringComparison.InvariantCultureIgnoreCase);

            if (position >= 0)
            {
                occurrences++;
                occurrences += value.CountWordInText(word, position + word.Length);
            }

            return occurrences;
        }
    }
}