namespace SSolver;

public static class Box
{
 private static int[][] Nums = new int[][]
 {
  new int[] { 0, 1, 2, 9, 10, 11, 18, 19, 20 },
  new int[] { 3, 4, 5, 12, 13, 14, 21, 22, 23 },
  new int[] { 6, 7, 8, 15, 16, 17, 24, 25, 26 },
  new int[] { 27, 28, 29, 36, 37, 38, 45, 46, 47 },
  new int[] { 30, 31, 32, 39, 40, 41, 48, 49, 50 },
  new int[] { 33, 34, 35, 42, 43, 44, 51, 52, 53 },
  new int[] { 54, 55, 56, 63, 64, 65, 72, 73, 74 },
  new int[] { 57, 58, 59, 66, 67, 68, 75, 76, 77 },
  new int[] { 60, 61, 62, 69, 70, 71, 78, 79, 80 }
 };

 public static IEnumerable<IEnumerable<int>> Boxes()
 {
  foreach (var nums in Nums)
  {
   yield return nums;
  }
 }
}