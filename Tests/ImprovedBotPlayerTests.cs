using FluentAssertions;
using TicTacToe;

namespace Tests;

public class ImprovedBotPlayerTests
{
    [Fact]
    public void GetNextMove_WhenEmptyMiddleSpot_ShouldGive4()
    {
        //Arrange
        var board = new Board();
        board.Init();
        var cut = new ImprovedBotPlayer();

        //Act
        var result = cut.GetNextMove(board);

        //Assert
        result.Should().Be(4);
    }
}