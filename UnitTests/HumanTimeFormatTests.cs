
namespace UnitTests
{
    public class HumanTimeFormatTests
    {
        [Fact]
        public static void NowTest()
        {
            Assert.Equal("now", HumanTimeFormat.formatDuration(0));
        }

        [Fact]
        public static void SecondsTest()
        {
            Assert.Equal("1 second", HumanTimeFormat.formatDuration(1));
        }

        [Fact]
        public static void MinutesAndSecondsTest()
        {
            Assert.Equal("1 minute and 2 seconds", HumanTimeFormat.formatDuration(62));
        }

        [Fact]
        public static void HoursMinutesSecondsTest()
        {
            Assert.Equal("1 hour, 1 minute and 2 seconds", HumanTimeFormat.formatDuration(3662));
        }

        [Fact]
        public static void DaysHoursMinutesSecondsTest()
        {
            Assert.Equal("182 days, 1 hour, 44 minutes and 40 seconds", HumanTimeFormat.formatDuration(15731080));
        }
        [Fact]
        public static void YearsDaysHoursMinutesSecondsTest()
        {
            Assert.Equal("4 years, 68 days, 3 hours and 4 minutes", HumanTimeFormat.formatDuration(132030240));
        }

    }
}

