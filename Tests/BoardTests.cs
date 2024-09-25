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
        cut.BoardData.Should().Be("         ");
    }

    [Fact]
    public void Init_WhenInitABordWithData_ShouldInitBoardData()
    {
        //Arrange
        var cut = new Board();
        cut.BoardData = "   X  O  ";

        //Act
        cut.Init();

        //Assert
        var result = cut.ToString();
        cut.BoardData.Should().Be("         ");
    }

    [Theory]
    [InlineData(" X O  X  ", 0, ' ')]
    [InlineData(" X O  X  ", 1, 'X')]
    public void Get_WhenIndexIsInside_ShouldGiveContent(string boardData, int index, char expected)
    {
        //Arrange
        var cut = new Board();
        cut.BoardData = boardData;

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
        cut.BoardData = boardData;

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
}