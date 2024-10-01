using TicTacToe;
using FluentAssertions;

namespace Tests;

public class BoardTests
{
    [Fact]
    public void Init_WhenInitACleanBoard_ShouldInitBoardData()
    {
        //Arrange
        var cut = new Board();

        //Act
        cut.Init();

        //Assert
        cut.ToString().Should().Be("         ");
    }

    [Fact]
    public void Init_WhenInitABordWithData_ShouldInitBoardData()
    {
        //Arrange
        var cut = new Board();
        cut.Init();
        cut.Set(4, 'X');

        //Act
        cut.Init();

        //Assert
        cut.ToString().Should().Be("         ");
    }

    [Theory]
    [InlineData(" X O  X  ", 0, ' ')]
    [InlineData(" X O  X  ", 1, 'X')]
    public void Get_WhenIndexIsInside_ShouldGiveContent(string boardData, int index, char expected)
    {
        //Arrange
        var cut = new Board();
        cut.Init();
        for (int i = 0; i < boardData.Length; i++)
        {
            cut.Set(i, boardData[i]);
        }

        //Act
        var result = cut.Get(index);

        //Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(" X O  X  ", -1)]
    [InlineData(" X O  X  ", 9)]
    public void Get_WhenOutside_ShouldGiveError(string boardData, int index)
    {
        //Arrange
        var cut = new Board();
        for (int i = 0; i < boardData.Length; i++)
        {
            cut.Set(i, boardData[i]);
        }

        //Act
        Action act = () => cut.Get(index);

        //Assert
        act.Should().Throw<IndexOutOfRangeException>();
    }

    [Theory]
    [InlineData(0, 'X')]
    [InlineData(1, 'O')]
    public void Set_ValidIndexAndCharacter_ShouldUpdateBoardData(int index, char ch)
    {
        //Arrange
        var cut = new Board();

        //Act
        cut.Init();
        cut.Set(index, ch);
        var result = cut.Get(index);

        //Assert
        result.Should().Be(ch);
    }

    [Theory]
    [InlineData(0, 'x')]
    [InlineData(1, 's')]
    public void Set_InvalidCharacter_ShouldGiveError(int index, char ch)
    {
        //Arrange
        var cut = new Board();

        //Act
        Action act = () => cut.Set(index, ch);

        //Assert
        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData( -1)]
    [InlineData( 9)]
    public void Set_WhenOutside_ShouldGiveError(int index)
    {
        //Arrange
        var cut = new Board();

        //Act
        Action act = () => cut.Set(index, 'X');

        //Assert
        act.Should().Throw<IndexOutOfRangeException>();
    }

    [Theory]
    [InlineData(" X O  X  ", 0)]
    [InlineData(" X O  X  ", 2)]
    public void IsEmpty_WhenEmpty_ShouldGiveTrue(string boardData, int index)
    {
        //Arrange
        var cut = new Board();
        cut.Init();
        for (int i = 0; i < boardData.Length; i++)
        {
            cut.Set(i, boardData[i]);
        }

        //Act
        var result = cut.IsEmpty(index);

        //Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsBoardFull_WhenBoardIsNotFull_ShouldGiveFalse()
    {
        //Arrange
        var cut = new Board();
        cut.Init();
        cut.Set(0, 'X');

        //Act
        var result = cut.IsBoardFull();

        //Assert
        result.Should().BeFalse();
    }
    [Fact]
    public void IsBoardFull_WhenBoardIsFull_ShouldGiveTrue()
    {
        //Arrange
        var cut = new Board();
        cut.Init();
        for (var i = 0; i < 9; i++)
            cut.Set(i, 'X');

        //Act
        var result = cut.IsBoardFull();

        //Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("XXX      ", 'X')]
    [InlineData("   XXX   ", 'X')]
    [InlineData("      XXX", 'X')]

    [InlineData("X  X  X  ", 'X')]
    [InlineData(" X  X  X ", 'X')]
    [InlineData("  X  X  X", 'X')]

    [InlineData("X   X   X", 'X')]
    [InlineData("  X X X  ", 'X')]

    [InlineData("OOO      ", 'O')]
    public void HasPlayerWon_WhenWon_ShouldGiveTrue(string boardData, char player)
    {
        //Arrange
        var cut = new Board();
        cut.Init();
        for (int i = 0; i < boardData.Length; i++)
        {
            cut.Set(i, boardData[i]);
        }

        //Act
        var result = cut.HasPlayerWon(player);

        //Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("XX       ", 'X')]
    [InlineData("   XX    ", 'X')]
    [InlineData("      XX ", 'X')]

    [InlineData("X  X     ", 'X')]
    [InlineData(" X  X    ", 'X')]
    [InlineData("  X  X   ", 'X')]

    [InlineData("X   X    ", 'X')]
    [InlineData("  X X    ", 'X')]

    [InlineData("XOXOXOXOX", 'O')]
    [InlineData("OXOXOXOXO", 'X')]

    [InlineData("OXXOOXXOX", 'O')]
    [InlineData("OXOXOX X ", 'O')]
    public void HasPlayerWon_WhenNoWins_ShouldGiveFalse(string boardData, char player)
    {
        //Arrange
        var cut = new Board();
        cut.Init();
        for (int i = 0; i < boardData.Length; i++)
        {
            cut.Set(i, boardData[i]);
        }

        //Act
        var result = cut.HasPlayerWon(player);

        // Assert
        result.Should().BeFalse();
    }
}