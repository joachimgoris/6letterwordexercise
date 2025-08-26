using SixLetterWords.Core.Abstractions;
using SixLetterWords.Core.Models;

namespace SixLetterWords.Core;

public class Combiner(HashSet<string> sixLetterWords, List<string> smallWords, bool allowDuplicates = false)
  : ICombiner {
  
  private IOrderedEnumerable<string> _smallWords = smallWords.OrderBy(_ => _.Length);
  public List<CombinedWord> CombinedWords { get; } = [];
  public Dictionary<string, bool> CheckedSmallWords { get; set; } = [];

  public void Combine() {
    // Iterate over known words and find possible parts
    foreach (var sixLetterWord in sixLetterWords) {
      var parts = new List<string>();
      while (true) {
        var part = FindPart(sixLetterWord, parts.Count is 0 ? 0 : parts.Sum(_ => _.Length));
        // Method returns empty handed, no combination for the word is possible. Optimization here is to have proper unhappy path handling
        if (part is "") {
          break;
        }

        parts.Add(part);
        if (parts.Sum(_ => _.Length) is 6) {
          CombinedWords.Add(new CombinedWord(sixLetterWord, [.. parts]));
          if (!allowDuplicates) {
            // Remove used parts if duplicate parts are not allowed
            var smallWordsWithoutParts = _smallWords.ToList();
            smallWordsWithoutParts.RemoveAll(_ => parts.Contains(_));
            _smallWords = smallWordsWithoutParts.OrderBy(_ => _.Length);
          }
          break;
        }
      }
    }
  }

  private string FindPart(string sixLetterWord, int startIndex) {
    var i = 1;
    while (true) {
      // If no possible part is found, return empty handed
      if (i > (6 - startIndex))
        return string.Empty;
      var part = sixLetterWord.Substring(startIndex, i);
      // If a part of the word is found in the small words, huzzah! Return with the part
      if (_smallWords.Contains(part)) {
        return part;
      }

      i++;
    }
  }
}