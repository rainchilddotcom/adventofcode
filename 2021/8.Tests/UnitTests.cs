using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Xunit;

namespace _8.Tests
{
    public class UnitTests
    {
        private static Task StartSTATask(Action action)
        {
            var tcs = new TaskCompletionSource<object>();
            var thread = new Thread(() =>
            {
                try
                {
                    action();
                    tcs.SetResult(new object());
                }
                catch (Exception e)
                {
                    tcs.SetException(e);
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            return tcs.Task;
        }

        [Fact]
        public async Task DigitsAreVisible()
        {
            await StartSTATask(() =>
            {
                var digit = new Digit();

                Assert.False(digit.SignalA);
                Assert.False(digit.SignalB);
                Assert.False(digit.SignalC);
                Assert.False(digit.SignalD);
                Assert.False(digit.SignalE);
                Assert.False(digit.SignalF);
                Assert.False(digit.SignalG);

                digit.Signal = "abcdefg";

                Assert.True(digit.SignalA);
                Assert.True(digit.SignalB);
                Assert.True(digit.SignalC);
                Assert.True(digit.SignalD);
                Assert.True(digit.SignalE);
                Assert.True(digit.SignalF);
                Assert.True(digit.SignalG);
            });
        }

        readonly string[] input = {
            "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
            "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
            "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
            "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
            "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
            "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
            "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
            "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
            "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
            "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
        };

        [Fact]
        public void CountEasyDigits()
        {
            var unscrambler = new Unscrambler();
            Assert.Equal(26, unscrambler.CountEasyDigits(input));
        }

        [Fact]
        public void UnscramblerCanUnscramble()
        {
            var unscrambler = new Unscrambler();
            Assert.Equal("8394", unscrambler.UnscrambleLine(input[0]));
            Assert.Equal("9781", unscrambler.UnscrambleLine(input[1]));
            Assert.Equal("1197", unscrambler.UnscrambleLine(input[2]));
            Assert.Equal("9361", unscrambler.UnscrambleLine(input[3]));
            Assert.Equal("4873", unscrambler.UnscrambleLine(input[4]));
            Assert.Equal("8418", unscrambler.UnscrambleLine(input[5]));
            Assert.Equal("4548", unscrambler.UnscrambleLine(input[6]));
            Assert.Equal("1625", unscrambler.UnscrambleLine(input[7]));
            Assert.Equal("8717", unscrambler.UnscrambleLine(input[8]));
            Assert.Equal("4315", unscrambler.UnscrambleLine(input[9]));
        }

        [Fact]
        public void UnscramblerChecksumOk()
        {
            var unscrambler = new Unscrambler();
            Assert.Equal(61229, unscrambler.UnscrambleInput(input));
        }
    }
}
