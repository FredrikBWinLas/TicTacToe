using TicTacToe;
using FluentAssertions;

namespace Tests;

public class BoardTests
{
    [Fact]
    public void Init_ExistingBoardData_ShouldInitBoardData()
    {
        //Arrange
        var cut = new Board();

        //Act
        cut.Init();

        //Assert
        cut.BoardData.Should().Be("         ");
    }
}