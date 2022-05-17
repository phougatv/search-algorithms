namespace VP.Algorithm.Search.UnitTest.ArraySearchExtension;

using FluentAssertions;
using System;
using System.Collections.Generic;
using VP.Algorithm.Search.Array.Extensions;
using Xunit;

public class UseLinearSearchToGetIndexOfShould
{
	[Fact]
	public void NotThrow_NotImplementedException()
	{
		//Arrange
		var sortedList = (IList<Int32>)new List<Int32> { -4, -2, 0, 3, 5, 7, 9, 12 };

		//Act
		Action act = () => sortedList.UseLinearSearchToGetIndexOf(0);

		//Assert
		act.Should().NotThrow<NotImplementedException>();
	}

	[Fact]
	public void Throw_ArgumentNullException_WhenListIsNullAndItemIsNotNull()
	{
		//Arrange
		var list = (IList<Int32>)null!;

		//Act
		Action act = () => list.UseLinearSearchToGetIndexOf(10);

		//Assert
		act.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'list')");
	}

	[Fact]
	public void Return_Minus1_WhenListIsEmpty()
	{
		//Arrange
		var emptyList = (IList<Int32>) new List<Int32>();

		//Act
		var actualIndex = emptyList.UseLinearSearchToGetIndexOf(8);

		//Assert
		emptyList.Should().BeEmpty();
		emptyList.Count.Should().Be(0);

		actualIndex.Should().Be(-1);
	}

	[Fact]
	public void Return_Minus1_WhenItemDoesNotExistsInTheSortedList()
	{
		//Arrange
		var sortedList = (IList<Int32>)new List<Int32> { -4, -2, 0, 3, 5, 7, 9, 12 };

		//Act
		var actualIndexOf1 = sortedList.UseLinearSearchToGetIndexOf(1);
		var actualIndexOf100 = sortedList.UseLinearSearchToGetIndexOf(100);
		var actualIndexOf8 = sortedList.UseLinearSearchToGetIndexOf(8);
		var actualIndexOfInt32MaxValue = sortedList.UseLinearSearchToGetIndexOf(Int32.MaxValue);
		var actualIndexOfInt32MinValue = sortedList.UseLinearSearchToGetIndexOf(Int32.MinValue);

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
	public void Return_Minus1_WhenItemDoesNotExistsInTheUnsortedList()
	{
		//Arrange
		var unsortedList = (IList<Int32>)new List<Int32> { 10, -4, 7, 0, -5, -10, 4, 2, 3 };

		//Act
		var actualIndexOf1 = unsortedList.UseLinearSearchToGetIndexOf(1);
		var actualIndexOf100 = unsortedList.UseLinearSearchToGetIndexOf(100);
		var actualIndexOf8 = unsortedList.UseLinearSearchToGetIndexOf(8);
		var actualIndexOfInt32MaxValue = unsortedList.UseLinearSearchToGetIndexOf(Int32.MaxValue);
		var actualIndexOfInt32MinValue = unsortedList.UseLinearSearchToGetIndexOf(Int32.MinValue);

		//Assert
		unsortedList.Should().NotBeEmpty();
		unsortedList.Should().HaveCount(9).And.Equal(new List<Int32> { 10, -4, 7, 0, -5, -10, 4, 2, 3 });

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
		var actualIndexOfMinus4 = sortedList.UseLinearSearchToGetIndexOf(-4);
		var actualIndexOfMinus2 = sortedList.UseLinearSearchToGetIndexOf(-2);
		var actualIndexOf0 = sortedList.UseLinearSearchToGetIndexOf(0);
		var actualIndexOf3 = sortedList.UseLinearSearchToGetIndexOf(3);
		var actualIndexOf5 = sortedList.UseLinearSearchToGetIndexOf(5);
		var actualIndexOf7 = sortedList.UseLinearSearchToGetIndexOf(7);
		var actualIndexOf9 = sortedList.UseLinearSearchToGetIndexOf(9);
		var actualIndexOf12 = sortedList.UseLinearSearchToGetIndexOf(12);

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

	[Fact]
	public void Return_IndexOfItem_WhenItemExistsInTheUnsortedList()
	{
		//Arrange
		var unsortedList = (IList<Int32>)new List<Int32> { 10, -4, 7, 0, -5, -10, 4, 2, 3 };

		//Act
		var actualIndexOf10 = unsortedList.UseLinearSearchToGetIndexOf(10);
		var actualIndexOfMinus4 = unsortedList.UseLinearSearchToGetIndexOf(-4);
		var actualIndexOf7 = unsortedList.UseLinearSearchToGetIndexOf(7);
		var actualIndexOf0 = unsortedList.UseLinearSearchToGetIndexOf(0);
		var actualIndexOfMinus5 = unsortedList.UseLinearSearchToGetIndexOf(-5);
		var actualIndexOfMinus10 = unsortedList.UseLinearSearchToGetIndexOf(-10);
		var actualIndexOf4 = unsortedList.UseLinearSearchToGetIndexOf(4);
		var actualIndexOf2 = unsortedList.UseLinearSearchToGetIndexOf(2);
		var actualIndexOf3 = unsortedList.UseLinearSearchToGetIndexOf(3);

		//Assert
		unsortedList.Should().NotBeEmpty();
		unsortedList.Should().HaveCount(9).And.Equal(new List<Int32> { 10, -4, 7, 0, -5, -10, 4, 2, 3 });

		actualIndexOf10.Should().Be(0);
		actualIndexOfMinus4.Should().Be(1);
		actualIndexOf7.Should().Be(2);
		actualIndexOf0.Should().Be(3);
		actualIndexOfMinus5.Should().Be(4);
		actualIndexOfMinus10.Should().Be(5);
		actualIndexOf4.Should().Be(6);
		actualIndexOf2.Should().Be(7);
		actualIndexOf3.Should().Be(8);
	}
}