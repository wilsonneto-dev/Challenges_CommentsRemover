
using System.Collections.Generic;

namespace Challenges.CommentsRemover.UnitTests.CommentsRemover;

public class CommentsRemoverTestDataGenerator
{
    public static IEnumerable<object[]> TwoSlashesCommentsExamples()
    {
        var code01 =
            "public class OneClass { // classe Xpto\r\n" +
            "   private int n;\r\n" +
            "};\r\n";
        var expectedCodeCleaned01 =
            "public class OneClass { \r\n" +
            "   private int n;\r\n" +
            "};\r\n";
        yield return new object[] { code01, expectedCodeCleaned01 };

        var code02 =
            "public class AnotherClass { // comments here\r\n" +
            "   private int n;// and another comment here\r\n" +
            "};\r\n// maybe a commet here too";
        var expectedCodeCleaned02 =
            "public class AnotherClass { \r\n" +
            "   private int n;\r\n" +
            "};\r\n";
        yield return new object[] { code02, expectedCodeCleaned02 };

        var code03 =
            "// here we have only comments\r\n"+
            "// here we have only comments\r\n";
        var expectedCodeCleaned03 =
            "\r\n" +
            "\r\n";
        yield return new object[] { code03, expectedCodeCleaned03 };

        var code04 =
            "var a = 10;\r\n" +
            "var b = 30;\r\n" +
            "// a comment here\r\n" +
            "var c = 60\r\n";
        var expectedCodeCleaned04 =
            "var a = 10;\r\n" +
            "var b = 30;\r\n" +
            "\r\n" +
            "var c = 60\r\n";
        yield return new object[] { code04, expectedCodeCleaned04 };
    }

    public static IEnumerable<object[]> SlashAndAsteriskCommentsExamples()
    {
        var code01 =
            "public class OneClass { /* classe Xpto */\r\n" +
            "   private int n;\r\n" +
            "};\r\n";
        var expectedCodeCleaned01 =
            "public class OneClass { \r\n" +
            "   private int n;\r\n" +
            "};\r\n";
        yield return new object[] { code01, expectedCodeCleaned01 };

        var code02 =
            "public class AnotherClass { /* comments here */\r\n" +
            "   private int n;/* and another comment here */\r\n" +
            "};\r\n/* maybe a commet here too */";
        var expectedCodeCleaned02 =
            "public class AnotherClass { \r\n" +
            "   private int n;\r\n" +
            "};\r\n";
        yield return new object[] { code02, expectedCodeCleaned02 };

        var code03 =
            "/* here we have only comments */\r\n" +
            "/* here we have only comments */\r\n";
        var expectedCodeCleaned03 =
            "\r\n" +
            "\r\n";
        yield return new object[] { code03, expectedCodeCleaned03 };

        var code04 =
            "var a = 10;\r\n" +
            "var b = 30;\r\n" +
            "/* a comment here */\r\n" +
            "var c = 60\r\n";
        var expectedCodeCleaned04 =
            "var a = 10;\r\n" +
            "var b = 30;\r\n" +
            "\r\n" +
            "var c = 60\r\n";
        yield return new object[] { code04, expectedCodeCleaned04 };

        var code05 =
            "public class AnotherClass { /* multiline comment here \r\n" +
            "   private int n; \r\n" +
            "};\r\n maybe a commet here too */";
        var expectedCodeCleaned05 =
            "public class AnotherClass { ";
        yield return new object[] { code05, expectedCodeCleaned05 };
    }
}
