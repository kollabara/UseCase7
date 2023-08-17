using UseCase7.Entities;
using UseCase7.Helpers;

namespace UseCase7.Tests;

public class PlayerAnalyzerTests
{
    [Fact]
    public void CalculateScore_NormalPlayer_ReturnsCorrectScore()
    {
        var players = new List<Player>
        {
            new() { Name = "John", Age = 25, Experience = 5, Skills = new List<int> { 2, 2, 2 } }
        };

        var score = PlayerAnalyzer.CalculateScore(players);

        Assert.Equal(250, score);
    }

    [Fact]
    public void CalculateScore_JuniorPlayer_ReturnsCorrectScore()
    {
        var players = new List<Player>
        {
            new() { Name = "Jane", Age = 15, Experience = 3, Skills = new List<int> { 3, 3, 3 } }
        };

        var score = PlayerAnalyzer.CalculateScore(players);

        Assert.Equal(67.5, score);
    }

    [Fact]
    public void CalculateScore_SeniorPlayer_ReturnsCorrectScore()
    {
        var players = new List<Player>
        {
            new() { Name = "Alice", Age = 35, Experience = 15, Skills = new List<int> { 4, 4, 4 } }
        };

        var score = PlayerAnalyzer.CalculateScore(players);

        Assert.Equal(2520, score);
    }

    [Fact]
    public void CalculateScore_MultiplePlayers_ReturnsSumOfScores()
    {
        var players = new List<Player>
        {
            new() { Name = "John", Age = 25, Experience = 5, Skills = new List<int> { 2, 2, 2 } },
            new() { Name = "Jane", Age = 15, Experience = 3, Skills = new List<int> { 3, 3, 3 } }
        };

        var score = PlayerAnalyzer.CalculateScore(players);

        Assert.Equal(250 + 67.5, score);
    }

    [Fact]
    public void CalculateScore_SkillsIsNull_ThrowsArgumentNullException()
    {
        var players = new List<Player>
        {
            new() { Name = "Alice", Age = 35, Experience = 15, Skills = null }
        };

        Assert.Throws<ArgumentNullException>(() => PlayerAnalyzer.CalculateScore(players));
    }

    [Fact]
    public void CalculateScore_EmptyArray_ReturnsZeroScore()
    {
        var players = new List<Player>();

        var score = PlayerAnalyzer.CalculateScore(players);

        Assert.Equal(0, score);
    }
}