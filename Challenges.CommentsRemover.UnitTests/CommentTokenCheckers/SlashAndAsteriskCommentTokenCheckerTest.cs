using Challenges.CommentsRemover.CommentsRemover.CommentTokenCheckers;
using FluentAssertions;
using Xunit;

namespace Challenges.CommentsRemover.UnitTests.CommentTokenCheckers;
public class TwoSlashesCommentTokenCheckerTest
{
    [Theory(DisplayName = nameof(IsStartingAComment))]
    [Trait("CommentTokenCheckers", "TwoSlashesCommentTokenChecker")]
    [InlineData('*', "/", false)]
    [InlineData('a', "b", false)]
    [InlineData('*', "", false)]
    [InlineData('/', "/", true)]
    [InlineData('/', "", false)]
    public void IsStartingAComment(
        char inputCharacter,
        string lastCharactersToAnalise,
        bool expectedOutput
    )
    {
        var checker = new TwoSlashesCommentTokenChecker();
        
        var isStarting = checker.IsStartingAComment(inputCharacter, lastCharactersToAnalise);

        isStarting.Should().Be(expectedOutput);
    }

    [Theory(DisplayName = nameof(CanThisBePartOfTheStartOfAComment))]
    [Trait("CommentTokenCheckers", "TwoSlashesCommentTokenChecker")]
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
        var checker = new TwoSlashesCommentTokenChecker();

        var canThisBePartOfStartingAComment =
            checker.CanThisBePartOfTheStartOfAComment(inputCharacter, lastCharactersToAnalise);

        canThisBePartOfStartingAComment.Should().Be(expectedOutput);
    }

    [Theory(DisplayName = nameof(IsFinishingAComment))]
    [Trait("CommentTokenCheckers", "TwoSlashesCommentTokenChecker")]
    [InlineData('/', "*", false)]
    [InlineData('a', "b", false)]
    [InlineData('*', "", false)]
    [InlineData('/', "/", false)]
    [InlineData('/', "", false)]
    [InlineData('\r', "", true)]
    [InlineData('\n', "", true)]
    public void IsFinishingAComment(
        char inputCharacter,
        string lastCharactersToAnalise,
        bool expectedOutput
    )
    {
        var checker = new TwoSlashesCommentTokenChecker();

        var IsFinishingAComment =
            checker.IsFinishingAComment(inputCharacter, lastCharactersToAnalise);

        IsFinishingAComment.Should().Be(expectedOutput);
    }
    
    [Theory(DisplayName = nameof(CanThisBePartOfTheFinishOfAComment))]
    [Trait("CommentTokenCheckers", "TwoSlashesCommentTokenChecker")]
    [InlineData('*', "", false)]
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
        var checker = new TwoSlashesCommentTokenChecker();

        var CanThisBePartOfTheFinishOfAComment =
            checker.CanThisBePartOfTheFinishOfAComment(inputCharacter, lastCharactersToAnalise);

        CanThisBePartOfTheFinishOfAComment.Should().Be(expectedOutput);
    }

    [Fact(DisplayName = nameof(IsToIncludeEndCommentSignalToTheCodeReturnsTrue))]
    [Trait("CommentTokenCheckers", "TwoSlashesCommentTokenChecker")]
    public void IsToIncludeEndCommentSignalToTheCodeReturnsTrue()
    {
        var checker = new TwoSlashesCommentTokenChecker();

        var include = checker.IsToIncludeEndCommentSignalToTheCode();

        include.Should().BeTrue();
    }
}
