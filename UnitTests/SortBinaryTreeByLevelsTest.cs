
using Code_Wars.Sort_Binary_Tree_By_Levels;

namespace UnitTests
{
    public class SortBinaryTreeByLevelsTest
    {
        [Fact]
        public static void NullTest()
        {
            Assert.Equal(new List<int>(), SortBinaryTree.TreeByLevels(null));
        }

        [Fact]
        public static void BasicTest()
        {
            Assert.Equal(new List<int>() { 1, 2, 3, 4, 5, 6 }, SortBinaryTree.TreeByLevels(new Node(new Node(null, new Node(null, null, 4), 2), new Node(new Node(null, null, 5), new Node(null, null, 6), 3), 1)));
        }
    }
}

