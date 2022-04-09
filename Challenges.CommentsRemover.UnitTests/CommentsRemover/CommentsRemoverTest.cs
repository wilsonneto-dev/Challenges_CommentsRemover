using Xunit;
using FluentAssertions;
using Implementation = Challenges.CommentsRemover.CommentsRemover;

namespace Challenges.CommentsRemover.UnitTests.CommentsRemover;
public class CommentsRemoverTest
{
    [Theory(DisplayName = nameof(TwoSlashesCommentRemoval))]
    [Trait("CommentsRemover", "CommentsRemover")]
    [MemberData(
        nameof(CommentsRemoverTestDataGenerator.TwoSlashesCommentsExamples),
        MemberType = typeof(CommentsRemoverTestDataGenerator))
    ]
    public void TwoSlashesCommentRemoval(string code, string expectedCodeCleaned)
    {
        var remover = new Implementation.CommentsRemover();
        var codeCharArray = code.ToCharArray();

        foreach (char character in codeCharArray)
            remover.TrimComment(character);

        remover.CodeWithoutComments.Should().Be(expectedCodeCleaned);
    }

    [Theory(DisplayName = nameof(SlashAndAsteriskCommentRemoval))]
    [Trait("CommentsRemover", "CommentsRemover")]
    [MemberData(
        nameof(CommentsRemoverTestDataGenerator.SlashAndAsteriskCommentsExamples),
        MemberType = typeof(CommentsRemoverTestDataGenerator))
    ]
    public void SlashAndAsteriskCommentRemoval(string code, string expectedCodeCleaned)
    {
        var remover = new Implementation.CommentsRemover();
        var codeCharArray = code.ToCharArray();

        foreach (char character in codeCharArray)
            remover.TrimComment(character);

        remover.CodeWithoutComments.Should().Be(expectedCodeCleaned);
    }
}