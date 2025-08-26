namespace SixLetterWords.Core.UnitTests;

public class CombinerTests {
  private Combiner _combiner;
  
  [SetUp]
  public void Setup() {
    
  }

  [Test]
  public void CombinerTest_WithFoobar() {
    var hashSet = new HashSet<string>(["foobar"]);
    var smallWords = new List<string>(["fo", "o", "bar"]);
    _combiner = new Combiner(hashSet, smallWords);
    _combiner.Combine();
    Assert.Multiple(() => {
      Assert.That(_combiner.CombinedWords.First().Word, Is.EqualTo("foobar"));
      Assert.That(_combiner.CombinedWords.First().SmallWords, Has.Length.EqualTo(3));
    });
    Assert.Multiple(() => {
      Assert.That(_combiner.CombinedWords.First().SmallWords[0], Is.EqualTo("fo"));
      Assert.That(_combiner.CombinedWords.First().SmallWords[1], Is.EqualTo("o"));
      Assert.That(_combiner.CombinedWords.First().SmallWords[2], Is.EqualTo("bar"));
    });
  }
  
  [Test]
  public void CombinerTest_WithFoobarAscend() {
    var hashSet = new HashSet<string>(["foobar", "ascend"]);
    var smallWords = new List<string>(["fo", "s", "o",  "a", "bar", "ce", "nd"]);
    _combiner = new Combiner(hashSet, smallWords);
    _combiner.Combine();
    Assert.Multiple(() => {
      Assert.That(_combiner.CombinedWords.First().Word, Is.EqualTo("foobar"));
      Assert.That(_combiner.CombinedWords.First().SmallWords, Has.Length.EqualTo(3));
    });
    Assert.Multiple(() => {
        Assert.That(_combiner.CombinedWords.Last().Word, Is.EqualTo("ascend"));
        Assert.That(_combiner.CombinedWords.Last().SmallWords, Has.Length.EqualTo(4));
      }
      );
    Assert.Multiple(() => {
      Assert.That(_combiner.CombinedWords.First().SmallWords[0], Is.EqualTo("fo"));
      Assert.That(_combiner.CombinedWords.First().SmallWords[1], Is.EqualTo("o"));
      Assert.That(_combiner.CombinedWords.First().SmallWords[2], Is.EqualTo("bar"));
    });
    Assert.Multiple(() => {
      Assert.That(_combiner.CombinedWords.Last().SmallWords[0], Is.EqualTo("a"));
      Assert.That(_combiner.CombinedWords.Last().SmallWords[1], Is.EqualTo("s"));
      Assert.That(_combiner.CombinedWords.Last().SmallWords[2], Is.EqualTo("ce"));
      Assert.That(_combiner.CombinedWords.Last().SmallWords[3], Is.EqualTo("nd"));
    });
  }
}