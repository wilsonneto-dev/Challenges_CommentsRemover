using Challenges.CommentsRemover.CommentsRemover.CommentTokenCheckers;
using Challenges.CommentsRemover.CommentsRemover.Interfaces;

namespace Challenges.CommentsRemover.CommentsRemover;
public class CommentsRemover
    : ICodeCommentRemover, ICodeWritter
{
    public string CodeWithoutComments { get; private set; }

    private bool _insideAComment;
    private string _temporaryCharactersToEvaluate;

    private readonly List<ICommentTokenChecker> _commentTokenCheckers;
    private ICommentTokenChecker? _tokenCheckerToFinishCurrentComment;

    private bool _outputEnabled;
    private string _temporaryOutput;

    public CommentsRemover()
    {
        CodeWithoutComments = "";
        _temporaryCharactersToEvaluate = "";
        _insideAComment = false;
        _tokenCheckerToFinishCurrentComment = null;
        _outputEnabled = false;
        _temporaryOutput = "";

        _commentTokenCheckers = new List<ICommentTokenChecker>();
        _commentTokenCheckers.Add(new TwoSlashesCommentTokenChecker());
        _commentTokenCheckers.Add(new SlashAndAsteriskCommentTokenChecker());
    }

    public void TrimComment(char character)
        => ProccessNextCharacter(character);

    public void Write(char character)
    {
        _outputEnabled = true;
        
        ProccessNextCharacter(character);
        if (_temporaryOutput.Length > 0)
            Console.Write(_temporaryOutput);

        _temporaryOutput = "";
        _outputEnabled = false;
    }

    private void ProccessNextCharacter(char character)
    {
        if (!_insideAComment)
            CheckForStartingAComment(character);
        else
            CheckForFinishingAComment(character);
    }

    private void CheckForStartingAComment(char character)
    {
        bool addTheNewCharacterToCurrentCode = true;
        foreach (var commentChecker in _commentTokenCheckers)
            if (commentChecker.IsStartingAComment(character, _temporaryCharactersToEvaluate))
            {
                _tokenCheckerToFinishCurrentComment = commentChecker;
                _temporaryCharactersToEvaluate = "";
                _insideAComment = true;
                addTheNewCharacterToCurrentCode = false;
                break;
            }
            else if (commentChecker.CanThisBePartOfTheStartOfAComment(character, _temporaryCharactersToEvaluate))
            {
                AddToTemporaryCharacters(character);
                addTheNewCharacterToCurrentCode = false;
                break;
            }

        if (addTheNewCharacterToCurrentCode)
        {
            if (_temporaryCharactersToEvaluate.Length > 0)
            {
                AddToCurrentCode(_temporaryCharactersToEvaluate);
                _temporaryCharactersToEvaluate = "";
            }
            AddToCurrentCode(character);
        }
    }

    private void CheckForFinishingAComment(char character)
    {
        if (_tokenCheckerToFinishCurrentComment is null)
            throw new NullReferenceException();

        if (_tokenCheckerToFinishCurrentComment.IsFinishingAComment(character, _temporaryCharactersToEvaluate))
        {
            if (_tokenCheckerToFinishCurrentComment.IsToIncludeEndCommentSignalToTheCode())
                AddToCurrentCode($"{_temporaryCharactersToEvaluate}{character}");
            _tokenCheckerToFinishCurrentComment = null;
            _insideAComment = false;
            _temporaryCharactersToEvaluate = "";
        }
        else if (_tokenCheckerToFinishCurrentComment.CanThisBePartOfTheFinishOfAComment(character, _temporaryCharactersToEvaluate))
            AddToTemporaryCharacters(character);
        else
            _temporaryCharactersToEvaluate = "";
    }

    private void AddToCurrentCode(char character)
    {
        CodeWithoutComments = $"{CodeWithoutComments}{character}";
        if (_outputEnabled)
            _temporaryOutput = $"{_temporaryOutput}{character}"; 
    }

    private void AddToCurrentCode(string newCode)
    {
        CodeWithoutComments = $"{CodeWithoutComments}{newCode}";
        if (_outputEnabled)
            _temporaryOutput = $"{_temporaryOutput}{newCode}";
    }

    private void AddToTemporaryCharacters(char character)
        => _temporaryCharactersToEvaluate = $"{_temporaryCharactersToEvaluate}{character}";
}
