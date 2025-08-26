namespace SixLetterWords.Core.Models;

public class CombinedWord(string word, string[] smallWords) {
  public string Word { get; } = word;
  public string[] SmallWords { get; } = smallWords;
}