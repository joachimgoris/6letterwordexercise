namespace SixLetterWords.Core;

using Abstractions;

public class Splitter : ISplitter {
  private const int MaxLength = 6;
  public HashSet<string> SixLetterWords { get; } = [];
  
  public List<string> SmallWords { get; } = [];
  
  public void Split(string rawInput) {
    var lines = rawInput.Split('\n');
    foreach (var line in lines) {
      if (line.Trim().Length is MaxLength)
      {
        SixLetterWords.Add((line.Trim()));
      }
      else 
      {
        SmallWords.Add(line.Trim());
      }
    }
  }
}