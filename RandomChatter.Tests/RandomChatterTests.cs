using FluentAssertions;
using NUnit.Framework;
using XmppBot.Common;
using XmppBot_RandomChatter;

namespace RandomChatter.Tests
{
    [TestFixture]
    public class RandomChatterTests
    {
        [Test]
        public void should_always_get_the_one_response()
        {
            // Default app.config; one response in file, 100% response chance
            var plugin = new RandomChatterPlugin();

            var pl = new ParsedLine("This is a random line", "bob");

            plugin.Evaluate(pl)
                  .Should()
                  .Be("This is the only response in the file.", "Only one response in file, 100% chance");
        }

        [Test]
        public void should_never_get_response()
        {
            var plugin = new RandomChatterPlugin("zero_percent.config");

            var pl = new ParsedLine("This is a random line", "bob");

            plugin.Evaluate(pl).Should().BeNull("Percent chance of response is zero");
        }

        [Test]
        public void should_not_have_responses()
        {
            var plugin = new RandomChatterPlugin("no_responses.config");

            var pl = new ParsedLine("This is a random line", "bob");

            plugin.Evaluate(pl).Should().BeNull("No responses in loaded file");
        }
    }
}