namespace Challenges.CommentsRemover.CommentsRemover.Interfaces;
public interface ICommentTokenChecker
{
    bool IsStartingAComment(char newCharacter, string charactersToEvaluate);
    bool CanThisBePartOfTheStartOfAComment(char newCharacter, string charactersToEvaluate);
    bool IsFinishingAComment(char newCharacter, string charactersToEvaluate);
    bool CanThisBePartOfTheFinishOfAComment(char newCharacter, string charactersToEvaluate);
    bool IsToIncludeEndCommentSignalToTheCode();
}
