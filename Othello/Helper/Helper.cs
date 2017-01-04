using System;
using System.Linq;
using Othello.Model;

namespace Othello.Helper
{
    public static class Helper
    {
        public static int GetMin(int a, int b)
        {
            return a <= b ? a : b;
        }

        public static int GetMax(int a, int b)
        {
            return a >= b ? a : b;
        }

        public static bool IsOutOfBorder(this int value)
        {
            return value < 0 || value >= GlobalVariables.BoardSize;
        }

        public static Color GetOpponentColor(this Color color)
        {
            return color == Color.Black ? Color.White : Color.Black;
        }

        public static PlayerType GetOpponentType(this PlayerType playerType)
        {
            return playerType == PlayerType.Human ? PlayerType.Computer : PlayerType.Human;
        }

        public static int GetDiffWith(this int[] point, int[] otherPoint)
        {
            return (point[0].ConvertNumber() - otherPoint[0].ConvertNumber()) +
                   (point[1].ConvertNumber() - otherPoint[1].ConvertNumber());
        }

        public static bool ContainsSamePoint(this int[][] arr, int x, int y)
        {
            for (var i = 0; i < arr.Count(move => move != null); i++)
            {
                if (arr[i][0] == x && arr[i][1] == y)
                    return true;
            }

            return false;
        }

        public static bool HasAvailableMoves(this int[][] arr)
        {
            return arr.Any(x => x != null);
        }

        public static bool HasNoAvailableMove(this int[][] arr)
        {
            return !HasAvailableMoves(arr);
        }

        public static int Count(this int[][] arr)
        {
            return arr.Count(x => x != null);
        }

        public static string GetName(this Color color)
        {
            return color == Color.Black ? "Siyah" : color == Color.White ? "Beyaz" : "";
        }

        public static Color GetColor(this GameResult gameResult)
        {
            return
                gameResult == GameResult.Player1
                    ? Color.Black
                    : gameResult == GameResult.Player2 ? Color.White : Color.Empty;
        }

        #region private functions

        private static int ConvertNumber(this int number)
        {
            if (number > GlobalVariables.BoardSize/2)
                number = Math.Abs(number - GlobalVariables.BoardSize);

            return number;
        }

        #endregion
    }
}
