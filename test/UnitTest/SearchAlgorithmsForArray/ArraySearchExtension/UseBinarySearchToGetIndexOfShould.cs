namespace VP.Algorithm.Search.UnitTest.ArraySearchExtension;

using FluentAssertions;
using System;
using System.Collections.Generic;
using VP.Algorithm.Search.Array.Extensions;
using Xunit;

public class UseBinarySearchToGetIndexOfShould
{
	[Fact]
	public void NotThrow_NotImplementedException()
	{
		//Arrange
		var sortedList = (IList<Int32>)new List<Int32> { -4, -2, 0, 3, 5, 7, 9, 12 };

		//Act
		Action act = () => sortedList.UseBinarySearchToGetIndexOf(10);

		//Assert
		act.Should().NotThrow<NotImplementedException>();
	}

	[Fact]
	public void Throw_ArgumentNullException_WhenSortedListIsNullAndItemIsNotNull()
	{
		//Arrange
		var list = (IList<Int32>)null!;

		//Act
		Action act = () => list.UseBinarySearchToGetIndexOf(10);

		//Assert
		act.Should()
			.ThrowExactly<ArgumentNullException>()
			.WithParameterName("sortedList")
			.WithMessage("Value cannot be null. (Parameter 'sortedList')");
	}

	[Fact]
	public void Return_Minus1_WhenSortedListIsEmpty()
	{
		//Arrange
		var emptyList = (IList<Int32>)new List<Int32>();

		//Act
		var actualIndex = emptyList.UseBinarySearchToGetIndexOf(8);

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
		var actualIndexOf1 = sortedList.UseBinarySearchToGetIndexOf(1);
		var actualIndexOf100 = sortedList.UseBinarySearchToGetIndexOf(100);
		var actualIndexOf8 = sortedList.UseBinarySearchToGetIndexOf(8);
		var actualIndexOfInt32MaxValue = sortedList.UseBinarySearchToGetIndexOf(Int32.MaxValue);
		var actualIndexOfInt32MinValue = sortedList.UseBinarySearchToGetIndexOf(Int32.MinValue);

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
		var actualIndexOfMinus4 = sortedList.UseBinarySearchToGetIndexOf(-4);
		var actualIndexOfMinus2 = sortedList.UseBinarySearchToGetIndexOf(-2);
		var actualIndexOf0 = sortedList.UseBinarySearchToGetIndexOf(0);
		var actualIndexOf3 = sortedList.UseBinarySearchToGetIndexOf(3);
		var actualIndexOf5 = sortedList.UseBinarySearchToGetIndexOf(5);
		var actualIndexOf7 = sortedList.UseBinarySearchToGetIndexOf(7);
		var actualIndexOf9 = sortedList.UseBinarySearchToGetIndexOf(9);
		var actualIndexOf12 = sortedList.UseBinarySearchToGetIndexOf(12);

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
