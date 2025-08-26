namespace SixLetterWords.Core.Abstractions;

public interface ISplitter { 
  HashSet<string> SixLetterWords { get; }
  
  List<string> SmallWords { get; }
  
  void Split(string rawInput);
}