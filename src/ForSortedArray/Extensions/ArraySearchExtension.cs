namespace VP.Algorithm.Search.Array.Extensions;

using System.Diagnostics.CodeAnalysis;
using VP.DotNet.Assist.Extensions;

public static class ArraySearchExtension
{
	/// <summary>
	/// Performs binary search on the sorted list. It does not sort the list before searching,
	/// so if you passed an unsorted list as an argument, it will return an incorrect index.
	/// Pass a sorted list for correct result.
	/// </summary>
	/// <typeparam name="T">Any type that implements <see cref="IComparable{T}"/></typeparam>
	/// <param name="sortedList">The <see cref="IList{T}"/></param>
	/// <param name="item">The item <see cref="{T}"/></param>
	/// <returns>Index of item if it exists in the list, -1 otherwise.</returns>
	public static Int32 UseBinarySearchToGetIndexOf<T>(
		[NotNull] this IList<T> sortedList,
		[NotNull] T item)
		where T : notnull, IComparable<T>
	{
		if (sortedList.IsNull())
			ArgumentNullException.ThrowIfNull(sortedList, nameof(sortedList));
		if (sortedList.IsEmpty())
			return -1;

		return sortedList.UseBinarySearchRangeToGetIndexOf(item, 0, sortedList.Count - 1);
	}

	/// <summary>
	/// Performs binary search on the section between <paramref name="lowerBound"/> and <paramref name="upperBound"/>.
	/// Value of both bounds is inclusive.
	/// </summary>
	/// <typeparam name="T"><see cref="notnull"/> and <see cref="IComparable{T}"/></typeparam>
	/// <param name="sortedList">The <see cref="IList{T}"/></param>
	/// <param name="item">The item</param>
	/// <param name="lowerBound">The <see cref="Int32"/></param>
	/// <param name="upperBound">The <see cref="Int32"/></param>
	/// <returns>Index of the specified item if it exists, -1 otherwise</returns>
	public static Int32 UseBinarySearchRangeToGetIndexOf<T>(
		[NotNull] this IList<T> sortedList,
		[NotNull] T item,
		Int32 lowerBound,
		Int32 upperBound)
		where T : notnull, IComparable<T>
	{
		if (sortedList.IsNull())
			ArgumentNullException.ThrowIfNull(sortedList, nameof(sortedList));
		if (sortedList.IsEmpty())
			return -1;
		if (upperBound.IsOutOfRange(0, sortedList.Count - 1))
			Throw.ArgumentOutOfRangeException(nameof(upperBound));
		if (lowerBound.IsOutOfRange(0, sortedList.Count - 1))
			Throw.ArgumentOutOfRangeException(nameof(lowerBound));
		if (lowerBound.IsGreaterThanEqualTo(upperBound))
			Throw.ArgumentException("'lowerBound' must be smaller than 'upperBound'");

		while (lowerBound.IsLessThanEqualTo(upperBound))
		{
			var currentIndex = (upperBound + lowerBound) >> 1;
			if (item.IsGreaterThan(sortedList[currentIndex]))
			{
				lowerBound = currentIndex + 1;
				continue;
			}

			if (item.IsLessThan(sortedList[currentIndex]))
			{
				upperBound = currentIndex - 1;
				continue;
			}

			return currentIndex;
		}

		return -1;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="sortedList"></param>
	/// <param name="item"></param>
	/// <returns></returns>
	/// <exception cref="NotImplementedException"></exception>
	public static Int32 UseExponentialSearchToGetIndexOf<T>(
		[NotNull] this IList<T> sortedList,
		[NotNull] T item)
		where T : notnull, IComparable<T>
	{
		if (sortedList.IsNull())
			ArgumentNullException.ThrowIfNull(sortedList, nameof(sortedList));
		if (sortedList.IsEmpty())
			return -1;

		var index = 1;
		while (index.IsLessThan(sortedList.Count) && item.IsGreaterThan(sortedList[index]))
			index = index << 1;     //multiply by 2

		if (index.IsGreaterThanEqualTo(sortedList.Count))
			index = sortedList.Count - 1;

		return sortedList.UseBinarySearchRangeToGetIndexOf(item, 0, index);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="sortedList"></param>
	/// <param name="item"></param>
	/// <returns></returns>
	/// <exception cref="NotImplementedException"></exception>
	public static Int32 UseJumpSearchToGetIndexOf<T>(
		[NotNull] this IList<T> sortedList,
		[NotNull] T item)
		where T : notnull, IComparable<T>
	{
		if (sortedList.IsNull())
			ArgumentNullException.ThrowIfNull(sortedList, nameof(sortedList));

		var blockSize = (Int32)Math.Floor(Math.Sqrt(sortedList.Count));
		var lowerBound = 0;
		var upperBound = blockSize - 1;
		while (
			upperBound.IsPositive()
			&& upperBound.IsLessThan(sortedList.Count)
			&& item.IsWithinRange(sortedList[0], sortedList[^1]))
		{
			if (item.IsOutOfRange(sortedList[lowerBound], sortedList[upperBound]))
			{
				lowerBound = upperBound + 1;
				if ((upperBound + blockSize).IsLessThan(sortedList.Count))
					upperBound = upperBound + blockSize;
				else if ((sortedList.Count - upperBound).IsLessThanEqualTo(blockSize))
					upperBound = sortedList.Count - 1;
				else
					upperBound = sortedList.Count;

				continue;
			}

			while (lowerBound.IsLessThanEqualTo(upperBound))
			{
				if (item.IsEqualTo(sortedList[lowerBound]))
					return lowerBound;
				lowerBound++;
			}

			return -1;
		}

		return -1;
	}

	/// <summary>
	/// Performs linear search on the list
	/// </summary>
	/// <typeparam name="T">Any type that implements <see cref="IComparable{T}"/></typeparam>
	/// <param name="list">The <see cref="IList{T}"/></param>
	/// <param name="item">The item <see cref="{T}"/></param>
	/// <returns>Index of item if it exists in the list, -1 otherwise.</returns>
	public static Int32 UseLinearSearchToGetIndexOf<T>(
		[NotNull] this IList<T> list,
		[NotNull] T item)
		where T : notnull, IComparable<T>
	{
		if (list.IsNull())
			ArgumentNullException.ThrowIfNull(list, nameof(list));

		for (var i = 0; i < list.Count; i++)
		{
			if (item.IsEqualTo(list[i]))
				return i;
		}

		return -1;
	}
}
