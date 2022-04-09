using Challenges.CommentsRemover.CommentsRemover.Interfaces;

namespace Challenges.CommentsRemover.CommentsRemover.CommentTokenCheckers;
public class TwoSlashesCommentTokenChecker
    : ICommentTokenChecker
{
    private const string StartCommentSignal = "//";
    private IReadOnlyList<char> EndCommentPossibleSignals = 
        new List<char>() { '\r', '\n' }.AsReadOnly();

    public bool IsStartingAComment(char newCharacter, string charactersToEvaluate)
        => (
            !string.IsNullOrEmpty(charactersToEvaluate)
            && charactersToEvaluate[0] == StartCommentSignal[0]
            && newCharacter == StartCommentSignal[1]
        );

    public bool CanThisBePartOfTheStartOfAComment(char newCharacter, string charactersToEvaluate)
        => (
            string.IsNullOrEmpty(charactersToEvaluate)
            && newCharacter == StartCommentSignal[0]
        );

    public bool IsFinishingAComment(char newCharacter, string charactersToEvaluate)
        => EndCommentPossibleSignals.Contains(newCharacter);

    public bool IsToIncludeEndCommentSignalToTheCode()
        => true;

    public bool CanThisBePartOfTheFinishOfAComment(char newCharacter, string charactersToEvaluate)
        => false;
}
