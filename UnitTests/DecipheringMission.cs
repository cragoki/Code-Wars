using Code_Wars.DecipheringMission;

namespace UnitTests
{
    public class DecipheringMission
    {
        [Fact]
        public static void SecretMessage()
        {
            Assert.Equal("This is a test.",
              Decoderr.Decode("Aopz mw e xiwx.", new int[] { 0, 2, 0, 1 }));
                            //"RULE IDs: 0, 2, 0, 1");
        }

        [Fact]
        public static void LongerSentence()
        {
            Assert.Equal("Sometimes sentences can be long and complex, man.",
              Decoderr.Decode("Zt0e9ujy9u53z zs5udjudsu5mu rts7dwx ubrus2 ntbed8pl 1l7dtz0 5dse9fbun,sa 9p97d.7d", new int[] { 1, 3, 1, 4 }));
            // "RULE IDs: 1, 3, 1, 4");
        }

        [Fact]
        public static void OrderMatters()
        {
            Assert.Equal("Test this.",
              Decoderr.Decode("Lnh9bXkgdnVnVg==", new int[] { 2, 0, 1, 5, 3 }));
            //"RULE IDs: 2, 0, 1, 5, 3");
        }

        [Fact]
        public static void NumbersToo()
        {
            Assert.Equal("Even numbers like 123 should be decoded properly.",
              Decoderr.Decode("MXY2biBuOW1iZXJzIGw3a2UgJzEyMycgc2g4OWxkIGI2IGQ2YzhkNmQgcHI4cDZybHku", new int[] { 3, 5 }));
            //"RULE IDs: 3, 5");
        }
    }
}
