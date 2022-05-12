namespace VP.Algorithm.Search.ClientFirstDesign;

using VP.Algorithm.Search.Array.Extensions;

public class Program
{
	public static void Main(String[] args)
	{
		var sortedList = (IList<Int32>)new List<Int32> { -4, -2, 0, 3, 5, 7, 9, 12 };
		var unsortedList = (IList<Int32>)new List<Int32> { 10, -4, 7, 0, -5, -10, 4, 2, 3 };

		//perform linear search
		var indexViaLinearSearch = sortedList.UseLinearSearchToGetIndexOf(9);

		//perform binary search
		var indexViaBinarySearch = sortedList.UseBinarySearchToGetIndexOf(3);
	}
}