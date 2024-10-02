using Code_Wars.Cartesia_Walk;

namespace UnitTests
{
    public class CartasiaWalkTests
    {
        [Fact]
        public static void IsValidWalk1()
        {
            Assert.True(CartasiaWalk.IsValidWalk(new string[] { "n", "s", "n", "s", "n", "s", "n", "s", "n", "s" }));
        }

        [Fact]
        public static void IsValidWalk2()
        {
            Assert.False(CartasiaWalk.IsValidWalk(new string[] { "w", "e", "w", "e", "w", "e", "w", "e", "w", "e", "w", "e" }));

        }

        [Fact]
        public static void IsValidWalk3()
        {
            Assert.False(CartasiaWalk.IsValidWalk(new string[] { "w" }));
        }

        [Fact]
        public static void IsValidWalk4()
        {
            Assert.False(CartasiaWalk.IsValidWalk(new string[] { "n", "n", "n", "s", "n", "s", "n", "s", "n", "s" }));
        }
    }
}
