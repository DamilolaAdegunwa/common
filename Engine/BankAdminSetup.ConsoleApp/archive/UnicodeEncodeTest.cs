using System;
using System.Collections.Generic;
using System.Text;
// reference https://www.nuget.org/packages/UnicodeInformation/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
namespace CodeSnippet.ConsoleApp
{
    public class UnicodeEncodeTest
    {
    }               
    public class ProgramUnicodeEncodeTest
    {
        //public static void Main()
        //{
        //    var unicodeEncoding = new UTF8Encoding(false);
        //    Console.OutputEncoding = unicodeEncoding;

        //    var numberCategories = new HashSet<UnicodeCategory>(new[]{
        //    UnicodeCategory.DecimalDigitNumber,
        //    UnicodeCategory.LetterNumber,
        //    UnicodeCategory.OtherNumber
        //});
        //    var numberLikeChars =
        //        from codePoint in Enumerable.Range(0, 0x10ffff)
        //        where codePoint > UInt16.MaxValue
        //            || (!char.IsLowSurrogate((char)codePoint) && !char.IsHighSurrogate((char)codePoint))
        //        let charInfo = UnicodeInfo.GetCharInfo(codePoint)
        //        where numberCategories.Contains(charInfo.Category)
        //        let codePointString = char.ConvertFromUtf32(codePoint)
        //        select (codePoint, charInfo, codePointString);

        //    foreach (var (codePoint, charInfo, codePointString) in numberLikeChars)
        //    {
        //        Console.Write("U+{0} ", codePoint.ToString("X6"));
        //        Console.Write(" {0,-4}", codePointString);
        //        Console.Write(" {0,-40}", charInfo.Name ?? charInfo.OldName);
        //        Console.Write(" {0,-6}", CharUnicodeInfo.GetNumericValue(codePointString, 0));
        //        Console.Write(" {0,-6}", CharUnicodeInfo.GetDigitValue(codePointString, 0));
        //        Console.Write(" {0,-6}", CharUnicodeInfo.GetDecimalDigitValue(codePointString, 0));
        //        Console.WriteLine(" {0}", charInfo.Category);
        //    }
        //}
    }
    /*
     U+000030  0    DIGIT ZERO                               0      0      0      DecimalDigitNumber
U+000031  1    DIGIT ONE                                1      1      1      DecimalDigitNumber
U+000032  2    DIGIT TWO                                2      2      2      DecimalDigitNumber
U+000033  3    DIGIT THREE                              3      3      3      DecimalDigitNumber
U+000034  4    DIGIT FOUR                               4      4      4      DecimalDigitNumber
U+000035  5    DIGIT FIVE                               5      5      5      DecimalDigitNumber
U+000036  6    DIGIT SIX                                6      6      6      DecimalDigitNumber
U+000037  7    DIGIT SEVEN                              7      7      7      DecimalDigitNumber
U+000038  8    DIGIT EIGHT                              8      8      8      DecimalDigitNumber
U+000039  9    DIGIT NINE                               9      9      9      DecimalDigitNumber
U+0000B2  ²    SUPERSCRIPT TWO                          2      2      -1     OtherNumber
U+0000B3  ³    SUPERSCRIPT THREE                        3      3      -1     OtherNumber
U+0000B9  ¹    SUPERSCRIPT ONE                          1      1      -1     OtherNumber
U+0000BC  ¼    VULGAR FRACTION ONE QUARTER              0.25   -1     -1     OtherNumber
U+0000BD  ½    VULGAR FRACTION ONE HALF                 0.5    -1     -1     OtherNumber
U+0000BE  ¾    VULGAR FRACTION THREE QUARTERS           0.75   -1     -1     OtherNumber
U+000660  ٠    ARABIC-INDIC DIGIT ZERO                  0      0      0      DecimalDigitNumber
U+000661  ١    ARABIC-INDIC DIGIT ONE                   1      1      1      DecimalDigitNumber
U+000662  ٢    ARABIC-INDIC DIGIT TWO                   2      2      2      DecimalDigitNumber
U+000663  ٣    ARABIC-INDIC DIGIT THREE                 3      3      3      DecimalDigitNumber
U+000664  ٤    ARABIC-INDIC DIGIT FOUR                  4      4      4      DecimalDigitNumber
U+000665  ٥    ARABIC-INDIC DIGIT FIVE                  5      5      5      DecimalDigitNumber
U+000666  ٦    ARABIC-INDIC DIGIT SIX                   6      6      6      DecimalDigitNumber
U+000667  ٧    ARABIC-INDIC DIGIT SEVEN                 7      7      7      DecimalDigitNumber
U+000668  ٨    ARABIC-INDIC DIGIT EIGHT                 8      8      8      DecimalDigitNumber
U+000669  ٩    ARABIC-INDIC DIGIT NINE                  9      9      9      DecimalDigitNumber
U+0006F0  ۰    EXTENDED ARABIC-INDIC DIGIT ZERO         0      0      0      DecimalDigitNumber
U+0006F1  ۱    EXTENDED ARABIC-INDIC DIGIT ONE          1      1      1      DecimalDigitNumber
U+0006F2  ۲    EXTENDED ARABIC-INDIC DIGIT TWO          2      2      2      DecimalDigitNumber
U+0006F3  ۳    EXTENDED ARABIC-INDIC DIGIT THREE        3      3      3      DecimalDigitNumber
U+0006F4  ۴    EXTENDED ARABIC-INDIC DIGIT FOUR         4      4      4      DecimalDigitNumber
U+0006F5  ۵    EXTENDED ARABIC-INDIC DIGIT FIVE         5      5      5      DecimalDigitNumber
U+0006F6  ۶    EXTENDED ARABIC-INDIC DIGIT SIX          6      6      6      DecimalDigitNumber
U+0006F7  ۷    EXTENDED ARABIC-INDIC DIGIT SEVEN        7      7      7      DecimalDigitNumber
U+0006F8  ۸    EXTENDED ARABIC-INDIC DIGIT EIGHT        8      8      8      DecimalDigitNumber
U+0006F9  ۹    EXTENDED ARABIC-INDIC DIGIT NINE         9      9      9      DecimalDigitNumber
U+0007C0  ߀    NKO DIGIT ZERO                           0      0      0      DecimalDigitNumber
U+0007C1  ߁    NKO DIGIT ONE                            1      1      1      DecimalDigitNumber
U+0007C2  ߂    NKO DIGIT TWO                            2      2      2      DecimalDigitNumber
U+0007C3  ߃    NKO DIGIT THREE                          3      3      3      DecimalDigitNumber
U+0007C4  ߄    NKO DIGIT FOUR                           4      4      4      DecimalDigitNumber
U+0007C5  ߅    NKO DIGIT FIVE                           5      5      5      DecimalDigitNumber
U+0007C6  ߆    NKO DIGIT SIX                            6      6      6      DecimalDigitNumber
U+0007C7  ߇    NKO DIGIT SEVEN                          7      7      7      DecimalDigitNumber
U+0007C8  ߈    NKO DIGIT EIGHT                          8      8      8      DecimalDigitNumber
U+0007C9  ߉    NKO DIGIT NINE                           9      9      9      DecimalDigitNumber
U+000966  ०    DEVANAGARI DIGIT ZERO                    0      0      0      DecimalDigitNumber
U+000967  १    DEVANAGARI DIGIT ONE                     1      1      1      DecimalDigitNumber
U+000968  २    DEVANAGARI DIGIT TWO                     2      2      2      DecimalDigitNumber
U+000969  ३    DEVANAGARI DIGIT THREE                   3      3      3      DecimalDigitNumber
U+00096A  ४    DEVANAGARI DIGIT FOUR                    4      4      4      DecimalDigitNumber
U+00096B  ५    DEVANAGARI DIGIT FIVE                    5      5      5      DecimalDigitNumber
U+00096C  ६    DEVANAGARI DIGIT SIX                     6      6      6      DecimalDigitNumber
U+00096D  ७    DEVANAGARI DIGIT SEVEN                   7      7      7      DecimalDigitNumber
U+00096E  ८    DEVANAGARI DIGIT EIGHT                   8      8      8      DecimalDigitNumber
U+00096F  ९    DEVANAGARI DIGIT NINE                    9      9      9      DecimalDigitNumber
U+0009E6  ০    BENGALI DIGIT ZERO                       0      0      0      DecimalDigitNumber
U+0009E7  ১    BENGALI DIGIT ONE                        1      1      1      DecimalDigitNumber
U+0009E8  ২    BENGALI DIGIT TWO                        2      2      2      DecimalDigitNumber
U+0009E9  ৩    BENGALI DIGIT THREE                      3      3      3      DecimalDigitNumber
U+0009EA  ৪    BENGALI DIGIT FOUR                       4      4      4      DecimalDigitNumber
U+0009EB  ৫    BENGALI DIGIT FIVE                       5      5      5      DecimalDigitNumber
U+0009EC  ৬    BENGALI DIGIT SIX                        6      6      6      DecimalDigitNumber
U+0009ED  ৭    BENGALI DIGIT SEVEN                      7      7      7      DecimalDigitNumber
U+0009EE  ৮    BENGALI DIGIT EIGHT                      8      8      8      DecimalDigitNumber
U+0009EF  ৯    BENGALI DIGIT NINE                       9      9      9      DecimalDigitNumber
U+0009F4  ৴    BENGALI CURRENCY NUMERATOR ONE           0.0625 -1     -1     OtherNumber
U+0009F5  ৵    BENGALI CURRENCY NUMERATOR TWO           0.125  -1     -1     OtherNumber
U+0009F6  ৶    BENGALI CURRENCY NUMERATOR THREE         0.1875 -1     -1     OtherNumber
U+0009F7  ৷    BENGALI CURRENCY NUMERATOR FOUR          0.25   -1     -1     OtherNumber
U+0009F8  ৸    BENGALI CURRENCY NUMERATOR ONE LESS THAN THE DENOMINATOR 0.75   -1     -1     OtherNumber
U+0009F9  ৹    BENGALI CURRENCY DENOMINATOR SIXTEEN     16     -1     -1     OtherNumber
U+000A66  ੦    GURMUKHI DIGIT ZERO                      0      0      0      DecimalDigitNumber
U+000A67  ੧    GURMUKHI DIGIT ONE                       1      1      1      DecimalDigitNumber
U+000A68  ੨    GURMUKHI DIGIT TWO                       2      2      2      DecimalDigitNumber
U+000A69  ੩    GURMUKHI DIGIT THREE                     3      3      3      DecimalDigitNumber
U+000A6A  ੪    GURMUKHI DIGIT FOUR                      4      4      4      DecimalDigitNumber
U+000A6B  ੫    GURMUKHI DIGIT FIVE                      5      5      5      DecimalDigitNumber
U+000A6C  ੬    GURMUKHI DIGIT SIX                       6      6      6      DecimalDigitNumber
U+000A6D  ੭    GURMUKHI DIGIT SEVEN                     7      7      7      DecimalDigitNumber
U+000A6E  ੮    GURMUKHI DIGIT EIGHT                     8      8      8      DecimalDigitNumber
U+000A6F  ੯    GURMUKHI DIGIT NINE                      9      9      9      DecimalDigitNumber
U+000AE6  ૦    GUJARATI DIGIT ZERO                      0      0      0      DecimalDigitNumber
U+000AE7  ૧    GUJARATI DIGIT ONE                       1      1      1      DecimalDigitNumber
U+000AE8  ૨    GUJARATI DIGIT TWO                       2      2      2      DecimalDigitNumber
U+000AE9  ૩    GUJARATI DIGIT THREE                     3      3      3      DecimalDigitNumber
U+000AEA  ૪    GUJARATI DIGIT FOUR                      4      4      4      DecimalDigitNumber
U+000AEB  ૫    GUJARATI DIGIT FIVE                      5      5      5      DecimalDigitNumber
U+000AEC  ૬    GUJARATI DIGIT SIX                       6      6      6      DecimalDigitNumber
U+000AED  ૭    GUJARATI DIGIT SEVEN                     7      7      7      DecimalDigitNumber
U+000AEE  ૮    GUJARATI DIGIT EIGHT                     8      8      8      DecimalDigitNumber
U+000AEF  ૯    GUJARATI DIGIT NINE                      9      9      9      DecimalDigitNumber
U+000B66  ୦    ORIYA DIGIT ZERO                         0      0      0      DecimalDigitNumber
U+000B67  ୧    ORIYA DIGIT ONE                          1      1      1      DecimalDigitNumber
U+000B68  ୨    ORIYA DIGIT TWO                          2      2      2      DecimalDigitNumber
U+000B69  ୩    ORIYA DIGIT THREE                        3      3      3      DecimalDigitNumber
U+000B6A  ୪    ORIYA DIGIT FOUR                         4      4      4      DecimalDigitNumber
U+000B6B  ୫    ORIYA DIGIT FIVE                         5      5      5      DecimalDigitNumber
U+000B6C  ୬    ORIYA DIGIT SIX                          6      6      6      DecimalDigitNumber
U+000B6D  ୭    ORIYA DIGIT SEVEN                        7      7      7      DecimalDigitNumber
U+000B6E  ୮    ORIYA DIGIT EIGHT                        8      8      8      DecimalDigitNumber
U+000B6F  ୯    ORIYA DIGIT NINE                         9      9      9      DecimalDigitNumber
U+000B72  ୲    ORIYA FRACTION ONE QUARTER               0.25   -1     -1     OtherNumber
U+000B73  ୳    ORIYA FRACTION ONE HALF                  0.5    -1     -1     OtherNumber
U+000B74  ୴    ORIYA FRACTION THREE QUARTERS            0.75   -1     -1     OtherNumber
U+000B75  ୵    ORIYA FRACTION ONE SIXTEENTH             0.0625 -1     -1     OtherNumber
U+000B76  ୶    ORIYA FRACTION ONE EIGHTH                0.125  -1     -1     OtherNumber
U+000B77  ୷    ORIYA FRACTION THREE SIXTEENTHS          0.1875 -1     -1     OtherNumber
U+000BE6  ௦    TAMIL DIGIT ZERO                         0      0      0      DecimalDigitNumber
U+000BE7  ௧    TAMIL DIGIT ONE                          1      1      1      DecimalDigitNumber
U+000BE8  ௨    TAMIL DIGIT TWO                          2      2      2      DecimalDigitNumber
U+000BE9  ௩    TAMIL DIGIT THREE                        3      3      3      DecimalDigitNumber
U+000BEA  ௪    TAMIL DIGIT FOUR                         4      4      4      DecimalDigitNumber
U+000BEB  ௫    TAMIL DIGIT FIVE                         5      5      5      DecimalDigitNumber
U+000BEC  ௬    TAMIL DIGIT SIX                          6      6      6      DecimalDigitNumber
U+000BED  ௭    TAMIL DIGIT SEVEN                        7      7      7      DecimalDigitNumber
U+000BEE  ௮    TAMIL DIGIT EIGHT                        8      8      8      DecimalDigitNumber
U+000BEF  ௯    TAMIL DIGIT NINE                         9      9      9      DecimalDigitNumber
U+000BF0  ௰    TAMIL NUMBER TEN                         10     -1     -1     OtherNumber
U+000BF1  ௱    TAMIL NUMBER ONE HUNDRED                 100    -1     -1     OtherNumber
U+000BF2  ௲    TAMIL NUMBER ONE THOUSAND                1000   -1     -1     OtherNumber
U+000C66  ౦    TELUGU DIGIT ZERO                        0      0      0      DecimalDigitNumber
U+000C67  ౧    TELUGU DIGIT ONE                         1      1      1      DecimalDigitNumber
U+000C68  ౨    TELUGU DIGIT TWO                         2      2      2      DecimalDigitNumber
U+000C69  ౩    TELUGU DIGIT THREE                       3      3      3      DecimalDigitNumber
U+000C6A  ౪    TELUGU DIGIT FOUR                        4      4      4      DecimalDigitNumber
U+000C6B  ౫    TELUGU DIGIT FIVE                        5      5      5      DecimalDigitNumber
U+000C6C  ౬    TELUGU DIGIT SIX                         6      6      6      DecimalDigitNumber
U+000C6D  ౭    TELUGU DIGIT SEVEN                       7      7      7      DecimalDigitNumber
U+000C6E  ౮    TELUGU DIGIT EIGHT                       8      8      8      DecimalDigitNumber
U+000C6F  ౯    TELUGU DIGIT NINE                        9      9      9      DecimalDigitNumber
U+000C78  ౸    TELUGU FRACTION DIGIT ZERO FOR ODD POWERS OF FOUR 0      -1     -1     OtherNumber
U+000C79  ౹    TELUGU FRACTION DIGIT ONE FOR ODD POWERS OF FOUR 1      -1     -1     OtherNumber
U+000C7A  ౺    TELUGU FRACTION DIGIT TWO FOR ODD POWERS OF FOUR 2      -1     -1     OtherNumber
U+000C7B  ౻    TELUGU FRACTION DIGIT THREE FOR ODD POWERS OF FOUR 3      -1     -1     OtherNumber
U+000C7C  ౼    TELUGU FRACTION DIGIT ONE FOR EVEN POWERS OF FOUR 1      -1     -1     OtherNumber
U+000C7D  ౽    TELUGU FRACTION DIGIT TWO FOR EVEN POWERS OF FOUR 2      -1     -1     OtherNumber
U+000C7E  ౾    TELUGU FRACTION DIGIT THREE FOR EVEN POWERS OF FOUR 3      -1     -1     OtherNumber
U+000CE6  ೦    KANNADA DIGIT ZERO                       0      0      0      DecimalDigitNumber
U+000CE7  ೧    KANNADA DIGIT ONE                        1      1      1      DecimalDigitNumber
U+000CE8  ೨    KANNADA DIGIT TWO                        2      2      2      DecimalDigitNumber
U+000CE9  ೩    KANNADA DIGIT THREE                      3      3      3      DecimalDigitNumber
U+000CEA  ೪    KANNADA DIGIT FOUR                       4      4      4      DecimalDigitNumber
U+000CEB  ೫    KANNADA DIGIT FIVE                       5      5      5      DecimalDigitNumber
U+000CEC  ೬    KANNADA DIGIT SIX                        6      6      6      DecimalDigitNumber
U+000CED  ೭    KANNADA DIGIT SEVEN                      7      7      7      DecimalDigitNumber
U+000CEE  ೮    KANNADA DIGIT EIGHT                      8      8      8      DecimalDigitNumber
U+000CEF  ೯    KANNADA DIGIT NINE                       9      9      9      DecimalDigitNumber
U+000D58  ൘    MALAYALAM FRACTION ONE ONE-HUNDRED-AND-SIXTIETH 0.00625 -1     -1     OtherNumber
U+000D59  ൙    MALAYALAM FRACTION ONE FORTIETH          0.025  -1     -1     OtherNumber
U+000D5A  ൚    MALAYALAM FRACTION THREE EIGHTIETHS      0.0375 -1     -1     OtherNumber
U+000D5B  ൛    MALAYALAM FRACTION ONE TWENTIETH         0.05   -1     -1     OtherNumber
U+000D5C  ൜    MALAYALAM FRACTION ONE TENTH             0.1    -1     -1     OtherNumber
U+000D5D  ൝    MALAYALAM FRACTION THREE TWENTIETHS      0.15   -1     -1     OtherNumber
U+000D5E  ൞    MALAYALAM FRACTION ONE FIFTH             0.2    -1     -1     OtherNumber
U+000D66  ൦    MALAYALAM DIGIT ZERO                     0      0      0      DecimalDigitNumber
U+000D67  ൧    MALAYALAM DIGIT ONE                      1      1      1      DecimalDigitNumber
U+000D68  ൨    MALAYALAM DIGIT TWO                      2      2      2      DecimalDigitNumber
U+000D69  ൩    MALAYALAM DIGIT THREE                    3      3      3      DecimalDigitNumber
U+000D6A  ൪    MALAYALAM DIGIT FOUR                     4      4      4      DecimalDigitNumber
U+000D6B  ൫    MALAYALAM DIGIT FIVE                     5      5      5      DecimalDigitNumber
U+000D6C  ൬    MALAYALAM DIGIT SIX                      6      6      6      DecimalDigitNumber
U+000D6D  ൭    MALAYALAM DIGIT SEVEN                    7      7      7      DecimalDigitNumber
U+000D6E  ൮    MALAYALAM DIGIT EIGHT                    8      8      8      DecimalDigitNumber
U+000D6F  ൯    MALAYALAM DIGIT NINE                     9      9      9      DecimalDigitNumber
U+000D70  ൰    MALAYALAM NUMBER TEN                     10     -1     -1     OtherNumber
U+000D71  ൱    MALAYALAM NUMBER ONE HUNDRED             100    -1     -1     OtherNumber
U+000D72  ൲    MALAYALAM NUMBER ONE THOUSAND            1000   -1     -1     OtherNumber
U+000D73  ൳    MALAYALAM FRACTION ONE QUARTER           0.25   -1     -1     OtherNumber
U+000D74  ൴    MALAYALAM FRACTION ONE HALF              0.5    -1     -1     OtherNumber
U+000D75  ൵    MALAYALAM FRACTION THREE QUARTERS        0.75   -1     -1     OtherNumber
U+000D76  ൶    MALAYALAM FRACTION ONE SIXTEENTH         0.0625 -1     -1     OtherNumber
U+000D77  ൷    MALAYALAM FRACTION ONE EIGHTH            0.125  -1     -1     OtherNumber
U+000D78  ൸    MALAYALAM FRACTION THREE SIXTEENTHS      0.1875 -1     -1     OtherNumber
U+000DE6  ෦    SINHALA LITH DIGIT ZERO                  0      0      0      DecimalDigitNumber
U+000DE7  ෧    SINHALA LITH DIGIT ONE                   1      1      1      DecimalDigitNumber
U+000DE8  ෨    SINHALA LITH DIGIT TWO                   2      2      2      DecimalDigitNumber
U+000DE9  ෩    SINHALA LITH DIGIT THREE                 3      3      3      DecimalDigitNumber
U+000DEA  ෪    SINHALA LITH DIGIT FOUR                  4      4      4      DecimalDigitNumber
U+000DEB  ෫    SINHALA LITH DIGIT FIVE                  5      5      5      DecimalDigitNumber
U+000DEC  ෬    SINHALA LITH DIGIT SIX                   6      6      6      DecimalDigitNumber
U+000DED  ෭    SINHALA LITH DIGIT SEVEN                 7      7      7      DecimalDigitNumber
U+000DEE  ෮    SINHALA LITH DIGIT EIGHT                 8      8      8      DecimalDigitNumber
U+000DEF  ෯    SINHALA LITH DIGIT NINE                  9      9      9      DecimalDigitNumber
U+000E50  ๐    THAI DIGIT ZERO                          0      0      0      DecimalDigitNumber
U+000E51  ๑    THAI DIGIT ONE                           1      1      1      DecimalDigitNumber
U+000E52  ๒    THAI DIGIT TWO                           2      2      2      DecimalDigitNumber
U+000E53  ๓    THAI DIGIT THREE                         3      3      3      DecimalDigitNumber
U+000E54  ๔    THAI DIGIT FOUR                          4      4      4      DecimalDigitNumber
U+000E55  ๕    THAI DIGIT FIVE                          5      5      5      DecimalDigitNumber
U+000E56  ๖    THAI DIGIT SIX                           6      6      6      DecimalDigitNumber
U+000E57  ๗    THAI DIGIT SEVEN                         7      7      7      DecimalDigitNumber
U+000E58  ๘    THAI DIGIT EIGHT                         8      8      8      DecimalDigitNumber
U+000E59  ๙    THAI DIGIT NINE                          9      9      9      DecimalDigitNumber
U+000ED0  ໐    LAO DIGIT ZERO                           0      0      0      DecimalDigitNumber
U+000ED1  ໑    LAO DIGIT ONE                            1      1      1      DecimalDigitNumber
U+000ED2  ໒    LAO DIGIT TWO                            2      2      2      DecimalDigitNumber
U+000ED3  ໓    LAO DIGIT THREE                          3      3      3      DecimalDigitNumber
U+000ED4  ໔    LAO DIGIT FOUR                           4      4      4      DecimalDigitNumber
U+000ED5  ໕    LAO DIGIT FIVE                           5      5      5      DecimalDigitNumber
U+000ED6  ໖    LAO DIGIT SIX                            6      6      6      DecimalDigitNumber
U+000ED7  ໗    LAO DIGIT SEVEN                          7      7      7      DecimalDigitNumber
U+000ED8  ໘    LAO DIGIT EIGHT                          8      8      8      DecimalDigitNumber
U+000ED9  ໙    LAO DIGIT NINE                           9      9      9      DecimalDigitNumber
...
U+01F10B  🄋   DINGBAT CIRCLED SANS-SERIF DIGIT ZERO    0      -1     -1     OtherNumber
U+01F10C  🄌   DINGBAT NEGATIVE CIRCLED SANS-SERIF DIGIT ZERO 0      -1     -1     OtherNumber
U+01FBF0  🯰   SEGMENTED DIGIT ZERO                     -1     -1     -1     DecimalDigitNumber
U+01FBF1  🯱   SEGMENTED DIGIT ONE                      -1     -1     -1     DecimalDigitNumber
U+01FBF2  🯲   SEGMENTED DIGIT TWO                      -1     -1     -1     DecimalDigitNumber
U+01FBF3  🯳   SEGMENTED DIGIT THREE                    -1     -1     -1     DecimalDigitNumber
U+01FBF4  🯴   SEGMENTED DIGIT FOUR                     -1     -1     -1     DecimalDigitNumber
U+01FBF5  🯵   SEGMENTED DIGIT FIVE                     -1     -1     -1     DecimalDigitNumber
U+01FBF6  🯶   SEGMENTED DIGIT SIX                      -1     -1     -1     DecimalDigitNumber
U+01FBF7  🯷   SEGMENTED DIGIT SEVEN                    -1     -1     -1     DecimalDigitNumber
U+01FBF8  🯸   SEGMENTED DIGIT EIGHT                    -1     -1     -1     DecimalDigitNumber
U+01FBF9  🯹   SEGMENTED DIGIT NINE                     -1     -1     -1     DecimalDigitNumber
     */
}
