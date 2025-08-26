using SixLetterWords.Core.Models;

namespace SixLetterWords.Core;

public class Displayer(IList<CombinedWord> combinedWords, HashSet<string> sixLetterWords) {
  
  public void Display() {
    foreach (var combinedWord in combinedWords) {
      foreach (var smallWord in combinedWord.SmallWords) {
        System.Console.Write(smallWord);
        if (smallWord != combinedWord.SmallWords.Last())
          System.Console.Write("+");
      }

      System.Console.Write($"={combinedWord.Word} {combinedWords.IndexOf(combinedWord)}\n");
    }

    System.Console.WriteLine();
    System.Console.WriteLine("Words without combination:");
    var combinedSet = new HashSet<string>(combinedWords.Select(c => c.Word));

    var counter = 1;
    foreach (var word in sixLetterWords.Where(word => !combinedSet.Contains(word))) {
      System.Console.Write($"{word}, ");
      counter++;
    }

    System.Console.WriteLine($"There are {counter} words without a combination.");
  }
}