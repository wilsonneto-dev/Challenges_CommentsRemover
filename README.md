# Challenge - Code Comments Remover

The challenge is to write a code that removes comments from a piece of code, you can write the code you want but you need to use these two interfaces below:

```
public interface ICodeCommentRemover
{
    void TrimComment(char c);
}

public interface ICodeWritter
{
    void Write(char c);
}
```

## Solution
Solution by [Wilson Neto][1]

This is my solution for this problem, a simple and first revision solution that does what needs to be done.

Images:

<img width="600" src="https://user-images.githubusercontent.com/20674439/162590062-89a4e604-4650-4f7c-b2e3-186ce997c919.png" />

![image](https://user-images.githubusercontent.com/20674439/162590079-0ab483e2-aa75-45dd-9de4-f805b1ed8520.png)

## How to run this solution (in Visual Studio, but of course you can use the IDE you like the most)
- 1: Clone this code with `git clone https://github.com/wilsonneto-dev/Challenges_CommentsRemover.git`
- 2: Open the solution with your Visual Studio (2022, or 2019 with .Net 6 support)
- 3: Just run with F5
- 4: The console app will ask you for a piece of code, you can type or you can paste a code
- 5: Type ":end" to finish the input
- 6: The console app will show you a version of your code without comments 

## Contributors

| [<img src="https://github.com/wilsonneto-dev.png" width="75px;"/>][1] |
| :-: |
|[Wilson Neto][1]|


[1]: https://www.twitch.tv/wilsonnetodev
