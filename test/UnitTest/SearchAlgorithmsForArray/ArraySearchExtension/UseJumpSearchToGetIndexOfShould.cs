namespace VP.Algorithm.Search.UnitTest.ArraySearchExtension;

using FluentAssertions;
using System;
using System.Collections.Generic;
using VP.Algorithm.Search.Array.Extensions;
using Xunit;

public class UseJumpSearchToGetIndexOfShould
{
	[Fact]
	public void NotThrow_NotImplementedException()
	{
		//Arrange
		var sortedList = (IList<Int32>)new List<Int32> { -4, -2, 0, 3, 5, 7, 9, 12 };

		//Act
		Action act = () => sortedList.UseJumpSearchToGetIndexOf(10);

		//Assert
		act.Should().NotThrow<NotImplementedException>();
	}

	[Fact]
	public void Throw_ArgumentNullException_WhenSortedListIsNullAndItemIsNotNull()
	{
		//Arrange
		var list = (IList<Int32>)null!;

		//Act
		Action act = () => list.UseJumpSearchToGetIndexOf(10);

		//Assert
		act.Should().ThrowExactly<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'sortedList')");
	}

	[Fact]
	public void Return_Minus1_WhenSortedListIsEmpty()
	{
		//Arrange
		var emptyList = (IList<Int32>)new List<Int32>();

		//Act
		var actualIndex = emptyList.UseJumpSearchToGetIndexOf(8);

		//Assert
		emptyList.Should().BeEmpty();
		emptyList.Count.Should().Be(0);

		actualIndex.Should().Be(-1);
	}

	[Fact]
	public void Return_Minus1_WhenItemDoesNotExistsInTheSortedList()
	{
		//Arrange
		var sortedList = (IList<Int32>)new List<Int32> { -3, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14 };

		//Act
		var actualIndexOfMinus100 = sortedList.UseJumpSearchToGetIndexOf(-100);
		var actualIndexOfMinus2 = sortedList.UseJumpSearchToGetIndexOf(-2);
		var actualIndexOf13 = sortedList.UseJumpSearchToGetIndexOf(13);
		var actualIndexOfInt32MaxValue = sortedList.UseJumpSearchToGetIndexOf(Int32.MaxValue);
		var actualIndexOfInt32MinValue = sortedList.UseJumpSearchToGetIndexOf(Int32.MinValue);

		//Assert
		sortedList.Should().NotBeEmpty();
		sortedList.Should().HaveCount(16).And.Equal(new List<Int32> { -3, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14 });

		actualIndexOfMinus100.Should().Be(-1);
		actualIndexOfMinus2.Should().Be(-1);
		actualIndexOf13.Should().Be(-1);
		actualIndexOfInt32MaxValue.Should().Be(-1);
		actualIndexOfInt32MinValue.Should().Be(-1);
	}

	[Fact]
	public void Return_IndexOfItem_WhenItemExistsInTheSortedListAndBlockSizeIsThePerfectSquareRoot()
	{
		//Arrange
		var sortedListWith16Elements = (IList<Int32>)new List<Int32> { -3, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14 };

		//Act
		var actualIndexOfMinus3 = sortedListWith16Elements.UseJumpSearchToGetIndexOf(-3);
		var actualIndexOfMinus1 = sortedListWith16Elements.UseJumpSearchToGetIndexOf(-1);
		var actualIndexOf0 = sortedListWith16Elements.UseJumpSearchToGetIndexOf(0);
		var actualIndexOf1 = sortedListWith16Elements.UseJumpSearchToGetIndexOf(1);
		var actualIndexOf2 = sortedListWith16Elements.UseJumpSearchToGetIndexOf(2);
		var actualIndexOf3 = sortedListWith16Elements.UseJumpSearchToGetIndexOf(3);
		var actualIndexOf4 = sortedListWith16Elements.UseJumpSearchToGetIndexOf(4);
		var actualIndexOf5 = sortedListWith16Elements.UseJumpSearchToGetIndexOf(5);
		var actualIndexOf6 = sortedListWith16Elements.UseJumpSearchToGetIndexOf(6);
		var actualIndexOf7 = sortedListWith16Elements.UseJumpSearchToGetIndexOf(7);
		var actualIndexOf8 = sortedListWith16Elements.UseJumpSearchToGetIndexOf(8);
		var actualIndexOf9 = sortedListWith16Elements.UseJumpSearchToGetIndexOf(9);
		var actualIndexOf10 = sortedListWith16Elements.UseJumpSearchToGetIndexOf(10);
		var actualIndexOf11 = sortedListWith16Elements.UseJumpSearchToGetIndexOf(11);
		var actualIndexOf12 = sortedListWith16Elements.UseJumpSearchToGetIndexOf(12);
		var actualIndexOf14 = sortedListWith16Elements.UseJumpSearchToGetIndexOf(14);

		//Assert
		sortedListWith16Elements.Should().NotBeEmpty();
		sortedListWith16Elements.Should().HaveCount(16).And.Equal(new List<Int32> { -3, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14 });

		actualIndexOfMinus3.Should().Be(0);
		actualIndexOfMinus1.Should().Be(1);
		actualIndexOf0.Should().Be(2);
		actualIndexOf1.Should().Be(3);
		actualIndexOf2.Should().Be(4);
		actualIndexOf3.Should().Be(5);
		actualIndexOf4.Should().Be(6);
		actualIndexOf5.Should().Be(7);
		actualIndexOf6.Should().Be(8);
		actualIndexOf7.Should().Be(9);
		actualIndexOf8.Should().Be(10);
		actualIndexOf9.Should().Be(11);
		actualIndexOf10.Should().Be(12);
		actualIndexOf11.Should().Be(13);
		actualIndexOf12.Should().Be(14);
		actualIndexOf14.Should().Be(15);
	}

	[Fact]
	public void Return_IndexOfItem_WhenItemExistsInTheSortedListAndBlockSizeIsNotThePerfectSquareRoot()
	{
		//Arrange
		var sortedListWith11Elements = (IList<Int32>)new List<Int32> { -3, 0, 1, 3, 4, 6, 7, 8, 10, 11, 14 };

		//Act
		var actualIndexOfMinus3 = sortedListWith11Elements.UseJumpSearchToGetIndexOf(-3);
		var actualIndexOf0 = sortedListWith11Elements.UseJumpSearchToGetIndexOf(0);
		var actualIndexOf1 = sortedListWith11Elements.UseJumpSearchToGetIndexOf(1);
		var actualIndexOf3 = sortedListWith11Elements.UseJumpSearchToGetIndexOf(3);
		var actualIndexOf4 = sortedListWith11Elements.UseJumpSearchToGetIndexOf(4);
		var actualIndexOf6 = sortedListWith11Elements.UseJumpSearchToGetIndexOf(6);
		var actualIndexOf7 = sortedListWith11Elements.UseJumpSearchToGetIndexOf(7);
		var actualIndexOf8 = sortedListWith11Elements.UseJumpSearchToGetIndexOf(8);
		var actualIndexOf10 = sortedListWith11Elements.UseJumpSearchToGetIndexOf(10);
		var actualIndexOf11 = sortedListWith11Elements.UseJumpSearchToGetIndexOf(11);
		var actualIndexOf14 = sortedListWith11Elements.UseJumpSearchToGetIndexOf(14);

		//Assert
		sortedListWith11Elements.Should().NotBeEmpty();
		sortedListWith11Elements.Should().HaveCount(11).And.Equal(new List<Int32> { -3, 0, 1, 3, 4, 6, 7, 8, 10, 11, 14 });

		actualIndexOfMinus3.Should().Be(0);
		actualIndexOf0.Should().Be(1);
		actualIndexOf1.Should().Be(2);
		actualIndexOf3.Should().Be(3);
		actualIndexOf4.Should().Be(4);
		actualIndexOf6.Should().Be(5);
		actualIndexOf7.Should().Be(6);
		actualIndexOf8.Should().Be(7);
		actualIndexOf10.Should().Be(8);
		actualIndexOf11.Should().Be(9);
		actualIndexOf14.Should().Be(10);
	}
}
