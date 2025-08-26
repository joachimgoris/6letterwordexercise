namespace SixLetterWords.Core;

using Abstractions;

public class Loader : ILoader {
  private const string FilePath = "input.txt";
  
  public async Task<string> ReadAsync() {
    return (await File.ReadAllTextAsync(Path.GetFullPath(FilePath))).Trim();
  }
}