namespace VP.Algorithm.Search.UnitTest.ArraySearchExtension;

using FluentAssertions;
using System;
using System.Collections.Generic;
using VP.Algorithm.Search.Array.Extensions;
using Xunit;

public class UseExponentialSearchToGetIndexOfShould
{
	[Fact]
	public void NotThrow_NotImplementedException()
	{
		//Arrange
		var sortedList = (IList<Int32>)new List<Int32> { -4, -2, 0, 3, 5, 7, 9, 12 };

		//Act
		Action act = () => sortedList.UseExponentialSearchToGetIndexOf(10);

		//Assert
		act.Should().NotThrow<NotImplementedException>();
	}

	[Fact]
	public void Throw_ArgumentNullException_WhenListIsNull()
	{
		//Arrange
		var sortedList = (IList<Int32>)null!;

		//Act
		Action act = () => sortedList.UseExponentialSearchToGetIndexOf(10);

		//Assert
		act.Should()
			.ThrowExactly<ArgumentNullException>()
			.WithParameterName("sortedList")
			.WithMessage("Value cannot be null. (Parameter 'sortedList')");
	}

	[Fact]
	public void Return_Minus1_WhenTheSortedListIsEmpty()
	{
		//Arrange
		var emptyList = (IList<Int32>)new List<Int32>();

		//Act
		var actualIndex = emptyList.UseExponentialSearchToGetIndexOf(10);

		//Assert
		emptyList.Should().BeEmpty();
		emptyList.Count.Should().Be(0);

		actualIndex.Should().Be(-1);
	}

	[Fact]
	public void Return_Minus1_WhenTheSoughtItemDoesNotExistInTheSortedList()
	{
		//Arrange
		var sortedList = (IList<Int32>)new List<Int32> { -3, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14 };

		//Act
		var actualIndexOfMinus2 = sortedList.UseExponentialSearchToGetIndexOf(-2);
		var actualIndexOf13 = sortedList.UseExponentialSearchToGetIndexOf(13);
		var actualIndexOf100 = sortedList.UseExponentialSearchToGetIndexOf(100);

		//Assert
		sortedList.Should().NotBeEmpty();
		sortedList.Count.Should().Be(16);

		actualIndexOf100.Should().Be(-1);
		actualIndexOf13.Should().Be(-1);
		actualIndexOfMinus2.Should().Be(-1);
	}

	[Fact]
	public void Return_IndexOfItem_WhenTheSoughtItemExistsInTheSortedList()
	{
		//Arrange
		var sortedListWith18Elements = (IList<Int32>)new List<Int32> { -3, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 15, 16 };

		//Act
		var actualIndexOfMinus3 = sortedListWith18Elements.UseExponentialSearchToGetIndexOf(-3);
		var actualIndexOfMinus1 = sortedListWith18Elements.UseExponentialSearchToGetIndexOf(-1);
		var actualIndexOf0 = sortedListWith18Elements.UseExponentialSearchToGetIndexOf(0);
		var actualIndexOf1 = sortedListWith18Elements.UseExponentialSearchToGetIndexOf(1);
		var actualIndexOf2 = sortedListWith18Elements.UseExponentialSearchToGetIndexOf(2);
		var actualIndexOf3 = sortedListWith18Elements.UseExponentialSearchToGetIndexOf(3);
		var actualIndexOf4 = sortedListWith18Elements.UseExponentialSearchToGetIndexOf(4);
		var actualIndexOf5 = sortedListWith18Elements.UseExponentialSearchToGetIndexOf(5);
		var actualIndexOf6 = sortedListWith18Elements.UseExponentialSearchToGetIndexOf(6);
		var actualIndexOf7 = sortedListWith18Elements.UseExponentialSearchToGetIndexOf(7);
		var actualIndexOf8 = sortedListWith18Elements.UseExponentialSearchToGetIndexOf(8);
		var actualIndexOf9 = sortedListWith18Elements.UseExponentialSearchToGetIndexOf(9);
		var actualIndexOf10 = sortedListWith18Elements.UseExponentialSearchToGetIndexOf(10);
		var actualIndexOf11 = sortedListWith18Elements.UseExponentialSearchToGetIndexOf(11);
		var actualIndexOf12 = sortedListWith18Elements.UseExponentialSearchToGetIndexOf(12);
		var actualIndexOf14 = sortedListWith18Elements.UseExponentialSearchToGetIndexOf(14);
		var actualIndexOf15 = sortedListWith18Elements.UseExponentialSearchToGetIndexOf(15);
		var actualIndexOf16 = sortedListWith18Elements.UseExponentialSearchToGetIndexOf(16);

		//Assert
		sortedListWith18Elements.Should().NotBeEmpty();
		sortedListWith18Elements.Should().HaveCount(18).And.Equal(new List<Int32> { -3, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 15, 16 });

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
		actualIndexOf15.Should().Be(16);
		actualIndexOf16.Should().Be(17);
	}

	[Fact]
	public void Return_IndexOfItem_WhenTheSoughtItemExistsInTheLargeSortedList()
	{
		//Arrange
		var sortedList = (IList<Int32>)new List<Int32>(UInt16.MaxValue) { -5, -1 };
		for (var i = 2; i < UInt16.MaxValue; i++)
			sortedList.Add(i - 2);

		//Act
		var actualIndexOf100 = sortedList.UseExponentialSearchToGetIndexOf(100);
		var actualIndexOf1000 = sortedList.UseExponentialSearchToGetIndexOf(1000);
		var actualIndexOf20000 = sortedList.UseExponentialSearchToGetIndexOf(20000);

		//Assert
		sortedList.Should().NotBeNull();
		sortedList.Should().NotBeEmpty();
		sortedList.Count.Should().Be(UInt16.MaxValue);

		actualIndexOf100.Should().Be(102);
		actualIndexOf1000.Should().Be(1002);
		actualIndexOf20000.Should().Be(20002);
	}
}
