using Challenges.CommentsRemover.CommentsRemover.Interfaces;

namespace Challenges.CommentsRemover.CommentsRemover.CommentTokenCheckers;
public class SlashAndAsteriskCommentTokenChecker
    : ICommentTokenChecker
{
    private const string StartingCommentSignal = "/*";
    private const string FinishingCommentSignal = "*/";

    public bool IsStartingAComment(char newCharacter, string charactersToEvaluate)
       => (
            !string.IsNullOrEmpty(charactersToEvaluate)
            && charactersToEvaluate[0] == StartingCommentSignal[0]
            && newCharacter == StartingCommentSignal[1]
        );

    public bool CanThisBePartOfTheStartOfAComment(char newCharacter, string charactersToEvaluate)
        => (
            String.IsNullOrEmpty(charactersToEvaluate)
            && newCharacter == StartingCommentSignal[0]
        );

    public bool IsFinishingAComment(char newCharacter, string charactersToEvaluate)
        => (
            !string.IsNullOrEmpty(charactersToEvaluate)
            && charactersToEvaluate[0] == FinishingCommentSignal[0]
            && newCharacter == FinishingCommentSignal[1]
        );

    public bool IsToIncludeEndCommentSignalToTheCode()
        => false;

    public bool CanThisBePartOfTheFinishOfAComment(char newCharacter, string charactersToEvaluate)
        => (
            string.IsNullOrEmpty(charactersToEvaluate)
            && newCharacter == FinishingCommentSignal[0]
        );
}
