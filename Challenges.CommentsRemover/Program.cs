using Challenges.CommentsRemover.CommentsRemover;

Console.WriteLine("Write your code below, and I will remove the comments");
Console.WriteLine("(finish your code with ':end'. You can paste a code)\n");
Console.WriteLine("-- code --\n");

var codeEndSignal = ":end";
var code = "";
var readlineInput = "";
while ((readlineInput = Console.ReadLine()) != codeEndSignal)
    code = $"{code}{readlineInput}{Environment.NewLine}";

Console.WriteLine("\n-- code end --\n");
Console.WriteLine("Processing...\n");

var commentsRemover = new CommentsRemover();
var characters = code.ToCharArray();

foreach(char character in characters)
    commentsRemover.TrimComment(character);

Console.WriteLine("Your code without the comments is:\n-- code --\n");
Console.Write(commentsRemover.CodeWithoutComments);

Console.WriteLine("\n\n\n\n");