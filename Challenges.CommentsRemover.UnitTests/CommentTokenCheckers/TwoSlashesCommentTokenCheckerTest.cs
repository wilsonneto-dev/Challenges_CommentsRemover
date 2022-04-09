using Challenges.CommentsRemover.CommentsRemover.CommentTokenCheckers;
using FluentAssertions;
using Xunit;

namespace Challenges.CommentsRemover.UnitTests.CommentTokenCheckers;
public class SlashAndAsteriskCommentTokenCheckerTest
{
    [Theory(DisplayName = nameof(IsStartingAComment))]
    [Trait("CommentTokenCheckers", "SlashAndAsteriskCommentTokenChecker")]
    [InlineData('*', "/", true)]
    [InlineData('a', "b", false)]
    [InlineData('*', "", false)]
    [InlineData('/', "/", false)]
    [InlineData('/', "", false)]
    public void IsStartingAComment(
        char inputCharacter,
        string lastCharactersToAnalise,
        bool expectedOutput
    )
    {
        var checker = new SlashAndAsteriskCommentTokenChecker();
        
        var isStarting = checker.IsStartingAComment(inputCharacter, lastCharactersToAnalise);

        isStarting.Should().Be(expectedOutput);
    }

    [Theory(DisplayName = nameof(CanThisBePartOfTheStartOfAComment))]
    [Trait("CommentTokenCheckers", "SlashAndAsteriskCommentTokenChecker")]
    [InlineData('*', "/", false)]
    [InlineData('a', "b", false)]
    [InlineData('*', "", false)]
    [InlineData('/', "/", false)]
    [InlineData('/', "", true)]
    public void CanThisBePartOfTheStartOfAComment(
        char inputCharacter,
        string lastCharactersToAnalise,
        bool expectedOutput
    )
    {
        var checker = new SlashAndAsteriskCommentTokenChecker();

        var canThisBePartOfStartingAComment =
            checker.CanThisBePartOfTheStartOfAComment(inputCharacter, lastCharactersToAnalise);

        canThisBePartOfStartingAComment.Should().Be(expectedOutput);
    }

    [Theory(DisplayName = nameof(IsFinishingAComment))]
    [Trait("CommentTokenCheckers", "SlashAndAsteriskCommentTokenChecker")]
    [InlineData('/', "*", true)]
    [InlineData('a', "b", false)]
    [InlineData('*', "", false)]
    [InlineData('/', "/", false)]
    [InlineData('/', "", false)]
    public void IsFinishingAComment(
        char inputCharacter,
        string lastCharactersToAnalise,
        bool expectedOutput
    )
    {
        var checker = new SlashAndAsteriskCommentTokenChecker();

        var IsFinishingAComment =
            checker.IsFinishingAComment(inputCharacter, lastCharactersToAnalise);

        IsFinishingAComment.Should().Be(expectedOutput);
    }
    
    [Theory(DisplayName = nameof(CanThisBePartOfTheFinishOfAComment))]
    [Trait("CommentTokenCheckers", "SlashAndAsteriskCommentTokenChecker")]
    [InlineData('*', "", true)]
    [InlineData('a', "b", false)]
    [InlineData('*', "/", false)]
    [InlineData('/', "/", false)]
    [InlineData('/', "", false)]
    public void CanThisBePartOfTheFinishOfAComment(
        char inputCharacter,
        string lastCharactersToAnalise,
        bool expectedOutput
    )
    {
        var checker = new SlashAndAsteriskCommentTokenChecker();

        var CanThisBePartOfTheFinishOfAComment =
            checker.CanThisBePartOfTheFinishOfAComment(inputCharacter, lastCharactersToAnalise);

        CanThisBePartOfTheFinishOfAComment.Should().Be(expectedOutput);
    }

    [Fact(DisplayName = nameof(IsToIncludeEndCommentSignalToTheCodeReturnsFalse))]
    [Trait("CommentTokenCheckers", "SlashAndAsteriskCommentTokenChecker")]
    public void IsToIncludeEndCommentSignalToTheCodeReturnsFalse()
    {
        var checker = new SlashAndAsteriskCommentTokenChecker();

        var include = checker.IsToIncludeEndCommentSignalToTheCode();

        include.Should().BeFalse();
    }
}
