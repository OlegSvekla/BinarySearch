public class BinarySearch
{
    public static void Main()
    {
        int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int target = 7;

        int result = Search(sortedArray, target);
        if (result != -1)
            Console.WriteLine($"Element {target} found by index {result}.");

        else
            Console.WriteLine($"-1");
    }

    public static int Search(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (array[mid] == target)
                return mid;

            else if (array[mid] < target)
                left = mid + 1;

            else
                right = mid - 1;
        }

        return -1;
    }
}