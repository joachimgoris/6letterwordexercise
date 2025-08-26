using SixLetterWords.Core;

namespace SixLetterWords.Console;

public class Program {

  public static async Task Main(string[] args) {
    System.Console.WriteLine("Starting");
    // Improvement: Add proper dependency injection
    // Input: Read the input file
    var loader = new Loader();
    var rawInput = await loader.ReadAsync();
    var splitter = new Splitter();
    splitter.Split(rawInput);
    
    // Core functionality. Find the possible combinations
    var combiner = new Combiner(splitter.SixLetterWords, splitter.SmallWords);
    combiner.Combine();
    
    // Output: Display the possible combinations
    var displayer = new Displayer(combiner.CombinedWords, splitter.SixLetterWords);
    displayer.Display();

  }
}