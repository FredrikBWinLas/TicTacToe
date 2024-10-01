using TicTacToe;
using FluentAssertions;
using System;

namespace Tests;
public class GameTests
{
    [Fact]
    public void NewGame_WhenNotEmptyBoard_ShouldGiveEmptyBoard()
    {
        //Arrange
        var sut = new Game();
        sut.Board.Set(0, 'X');

        //Act
        sut.NewGame();

        //Assert
        sut.Board.ToString().Should().Be("         ");
    }
    [Fact]
    public void NewGame_CurrentPlayer_ShouldBeX()
    {
        //Arrange
        var sut = new Game();

        //Act
        sut.NewGame();

        //Assert
        sut.CurrentPlayer.Should().Be('X');
    }

    [Fact]
    public void Move_WhenCorrectMove_ShoulUpdateBoard()
    {
        //Arrange
        var sut = new Game();
        sut.NewGame();

        //Act
        sut.Move(4);

        //Assert
        sut.Board.ToString().Should().Be("    X    ");
    }
    [Fact]
    public void Move_WhenCorrectMove_ShoulChangePlayer()
    {
        //Arrange
        var sut = new Game();
        sut.NewGame();

        //Act
        sut.Move(4);
        sut.Move(0);

        //Assert
        sut.Board.ToString().Should().Be("O   X    ");
    }
    [Fact]
    public void Move_WhenNotEmpty_ShoulGiveError()
    {
        //Arrange
        var sut = new Game();
        sut.NewGame();
        sut.Board.Set(0, 'X');

        //Act
        Action act = () => sut.Move(0);

        //Assert
        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("XXX      ")]
    [InlineData("   XXX   ")]
    [InlineData("      XXX")]

    [InlineData("X  X  X  ")]
    [InlineData(" X  X  X ")]
    [InlineData("  X  X  X")]

    [InlineData("X   X   X")]
    [InlineData("  X X X  ")]

    [InlineData("OOO      ")]
    public void HasAnyPlayerWon_WhenWon_ShouldGiveTrue(string boardData)
    {
        //Arrange
        var sut = new Game{Board = new Board() { AllowedCharacters = ['X', 'O', ' '] } };
        sut.NewGame();
        for (int i = 0; i < boardData.Length; i++)
        {
            sut.Board.Set(i, boardData[i]);
        }

        //Act
        var result = sut.HasAnyPlayerWon();

        //Assert
        result.Should().BeTrue();
    }
}
