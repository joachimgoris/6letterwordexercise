using SixLetterWords.Core.Models;

namespace SixLetterWords.Core.Abstractions;

public interface ICombiner {
  List<CombinedWord> CombinedWords { get; }
  
  void Combine();
}