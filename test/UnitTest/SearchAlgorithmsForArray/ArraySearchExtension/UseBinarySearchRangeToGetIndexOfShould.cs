namespace VP.Algorithm.Search.UnitTest.ArraySearchExtension;

using FluentAssertions;
using System;
using System.Collections.Generic;
using VP.Algorithm.Search.Array.Extensions;
using Xunit;

public class UseBinarySearchRangeToGetIndexOfShould
{
	[Fact]
	public void NotThrow_NotImplementedException()
	{
		//Arrange
		var sortedList = (IList<Int32>)new List<Int32> { -4, -2, 0, 3, 5, 7, 9, 12 };

		//Act
		Action act = () => sortedList.UseBinarySearchRangeToGetIndexOf(10, 0, sortedList.Count);

		//Assert
		act.Should().NotThrow<NotImplementedException>();
	}

	[Fact]
	public void Throw_ArgumentNullException_WhenListIsNull()
	{
		//Arrange
		var list = (IList<Int32>)null!;

		//Act
		Action act = () => list.UseBinarySearchRangeToGetIndexOf(10, 0, 1);

		//Assert
		act.Should()
			.ThrowExactly<ArgumentNullException>()
			.WithParameterName("sortedList")
			.WithMessage("Value cannot be null. (Parameter 'sortedList')");
	}

	[Fact]
	public void Throw_ArgumentOutOfRangeException_WhenUpperBoundIsOutOfRange()
	{
		//Arrange
		var sortedList = (IList<Int32>)new List<Int32> { 1, 2, 3, 4, 5, 6 };

		//Act
		Action actWhenUpperBoundIsNegative = () => sortedList.UseBinarySearchRangeToGetIndexOf(10, 0, -1);
		Action actWhenUpperBoundIsEqualToListCount = () => sortedList.UseBinarySearchRangeToGetIndexOf(10, 0, sortedList.Count);
		Action actWhenUpperBoundIsGreaterThanListCount = () => sortedList.UseBinarySearchRangeToGetIndexOf(-1, 0, sortedList.Count + 1);

		//Assert
		actWhenUpperBoundIsNegative.Should()
			.ThrowExactly<ArgumentOutOfRangeException>()
			.WithParameterName("upperBound")
			.WithMessage("Specified argument was out of the range of valid values. (Parameter 'upperBound')");
		actWhenUpperBoundIsEqualToListCount.Should()
			.ThrowExactly<ArgumentOutOfRangeException>()
			.WithParameterName("upperBound")
			.WithMessage("Specified argument was out of the range of valid values. (Parameter 'upperBound')");
		actWhenUpperBoundIsGreaterThanListCount.Should()
			.ThrowExactly<ArgumentOutOfRangeException>()
			.WithParameterName("upperBound")
			.WithMessage("Specified argument was out of the range of valid values. (Parameter 'upperBound')");
	}

	[Fact]
	public void Throw_ArgumentOutOfRangeException_WhenLowerBoundIsOutOfRange()
	{
		//Arrange
		var sortedList = (IList<Int32>)new List<Int32> { 1, 2, 3, 4, 5, 6 };

		//Act
		Action actWhenLowerBoundIsNegative = () => sortedList.UseBinarySearchRangeToGetIndexOf(10, -1, 5);
		Action actWhenLowerBoundIsEqualToListCount = () => sortedList.UseBinarySearchRangeToGetIndexOf(10, sortedList.Count, 5);
		Action actWhenLowerBoundIsGreaterThanListCount = () => sortedList.UseBinarySearchRangeToGetIndexOf(-1, sortedList.Count + 1, 5);

		//Assert
		actWhenLowerBoundIsNegative.Should()
			.ThrowExactly<ArgumentOutOfRangeException>()
			.WithParameterName("lowerBound")
			.WithMessage("Specified argument was out of the range of valid values. (Parameter 'lowerBound')");
		actWhenLowerBoundIsEqualToListCount.Should()
			.ThrowExactly<ArgumentOutOfRangeException>()
			.WithParameterName("lowerBound")
			.WithMessage("Specified argument was out of the range of valid values. (Parameter 'lowerBound')");
		actWhenLowerBoundIsGreaterThanListCount.Should()
			.ThrowExactly<ArgumentOutOfRangeException>()
			.WithParameterName("lowerBound")
			.WithMessage("Specified argument was out of the range of valid values. (Parameter 'lowerBound')");
	}

	[Fact]
	public void Throw_ArgumentException_WhenLowerBoundIsGreaterThanEqualToUpperBound()
	{
		//Arrange
		var sortedList = (IList<Int32>)new List<Int32> { 1, 2, 3, 4, 5, 6 };

		//Act
		Action actWhenBothBoundsAreEqual = () => sortedList.UseBinarySearchRangeToGetIndexOf(10, 1, 1);
		Action actWhenLowerBoundIsGreaterThanUpperBound = () => sortedList.UseBinarySearchRangeToGetIndexOf(10, 5, 4);

		//Assert
		actWhenBothBoundsAreEqual.Should()
			.ThrowExactly<ArgumentException>()
			.WithMessage("'lowerBound' must be smaller than 'upperBound'");
		actWhenLowerBoundIsGreaterThanUpperBound.Should()
			.ThrowExactly<ArgumentException>()
			.WithMessage("'lowerBound' must be smaller than 'upperBound'");
	}

	[Fact]
	public void Return_Minus1_WhenSortedListIsEmpty()
	{
		//Arrange
		var emptyList = (IList<Int32>)new List<Int32>();

		//Act
		var actualIndex = emptyList.UseBinarySearchRangeToGetIndexOf(8, 0, emptyList.Count);

		//Assert
		emptyList.Should().BeEmpty().And.HaveCount(0);
		actualIndex.Should().Be(-1);
	}

	[Fact]
	public void Return_Minus1_WhenItemDoesNotExistsInTheSortedList()
	{
		//Arrange
		var sortedList = (IList<Int32>)new List<Int32> { -4, -2, 0, 3, 5, 7, 9, 12 };

		//Act
		var actualIndexOf1 = sortedList.UseBinarySearchRangeToGetIndexOf(1, 0, sortedList.Count - 1);
		var actualIndexOf100 = sortedList.UseBinarySearchRangeToGetIndexOf(100, 0, sortedList.Count - 1);
		var actualIndexOf8 = sortedList.UseBinarySearchRangeToGetIndexOf(8, 0, sortedList.Count - 1);
		var actualIndexOfInt32MaxValue = sortedList.UseBinarySearchRangeToGetIndexOf(Int32.MaxValue, 0, sortedList.Count - 1);
		var actualIndexOfInt32MinValue = sortedList.UseBinarySearchRangeToGetIndexOf(Int32.MinValue, 0, sortedList.Count - 1);

		//Assert
		sortedList.Should().NotBeEmpty();
		sortedList.Should().HaveCount(8).And.Equal(new List<Int32> { -4, -2, 0, 3, 5, 7, 9, 12 });

		actualIndexOf1.Should().Be(-1);
		actualIndexOf100.Should().Be(-1);
		actualIndexOf8.Should().Be(-1);
		actualIndexOfInt32MaxValue.Should().Be(-1);
		actualIndexOfInt32MinValue.Should().Be(-1);
	}

	[Fact]
	public void Return_IndexOfItem_WhenItemExistsInTheSortedList()
	{
		//Arrange
		var sortedList = (IList<Int32>)new List<Int32> { -4, -2, 0, 3, 5, 7, 9, 12 };

		//Act
		var actualIndexOfMinus4 = sortedList.UseBinarySearchRangeToGetIndexOf(-4, 0, sortedList.Count - 1);
		var actualIndexOfMinus2 = sortedList.UseBinarySearchRangeToGetIndexOf(-2, 0, sortedList.Count - 1);
		var actualIndexOf0 = sortedList.UseBinarySearchRangeToGetIndexOf(0, 0, sortedList.Count - 1);
		var actualIndexOf3 = sortedList.UseBinarySearchRangeToGetIndexOf(3, 0, sortedList.Count - 1);
		var actualIndexOf5 = sortedList.UseBinarySearchRangeToGetIndexOf(5, 0, sortedList.Count - 1);
		var actualIndexOf7 = sortedList.UseBinarySearchRangeToGetIndexOf(7, 0, sortedList.Count - 1);
		var actualIndexOf9 = sortedList.UseBinarySearchRangeToGetIndexOf(9, 0, sortedList.Count - 1);
		var actualIndexOf12 = sortedList.UseBinarySearchRangeToGetIndexOf(12, 0, sortedList.Count - 1);

		//Assert
		sortedList.Should().NotBeEmpty();
		sortedList.Should().HaveCount(8).And.Equal(new List<Int32> { -4, -2, 0, 3, 5, 7, 9, 12 });

		actualIndexOfMinus4.Should().Be(0);
		actualIndexOfMinus2.Should().Be(1);
		actualIndexOf0.Should().Be(2);
		actualIndexOf3.Should().Be(3);
		actualIndexOf5.Should().Be(4);
		actualIndexOf7.Should().Be(5);
		actualIndexOf9.Should().Be(6);
		actualIndexOf12.Should().Be(7);
	}
}
