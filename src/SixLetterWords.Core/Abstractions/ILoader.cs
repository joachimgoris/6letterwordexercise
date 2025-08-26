namespace SixLetterWords.Core.Abstractions;

public interface ILoader {
  Task<string> ReadAsync();
}