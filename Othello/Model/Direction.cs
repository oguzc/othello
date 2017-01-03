namespace Othello.Model
{
    public static class Direction
    {
        public static int[] East => new[] {1, 0};
        public static int[] SouthEast => new[] {1, 1};
        public static int[] South => new[] {0, 1};
        public static int[] SouthWest => new[] {-1, 1};
        public static int[] West => new[] {-1, 0};
        public static int[] NorthWest => new[] {-1, -1};
        public static int[] North => new[] {0, -1};
        public static int[] NorthEast => new[] {1, -1};
    }
}
