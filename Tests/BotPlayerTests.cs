using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using TicTacToe;

namespace Tests;
public class BotPlayerTests
{
    [Fact]
    public void GetNextMove_WhenEmptyBoard_SouldGiveANumberInRange0To8()
    {
        //Arrange
        var board = new Board();
        board.Init();
        var cut = new BotPlayer();

        //Act
        var result = cut.GetNextMove(board);

        //Assert
        result.Should().BeInRange(0, 8);
    }

    [Fact]
    public void GetNextMove_WhenOneEmptyBoard_SouldGiveIndexOfTheEmptySpot()
    {
        //Arrange
        var board = new Board();
        board.Init();
        var expected = 8;
        for (int i = 0; i < expected; i++)
            board.Set(i, 'X');

        var cut = new BotPlayer();

        //Act
        var result = cut.GetNextMove(board);

        //Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void GetNextMove_WhenBoardIsFull_SouldGiveMinusOne()
    {
        //Arrange
        var board = new Board();
        board.Init();
        for (int i = 0; i < 9; i++)
            board.Set(i, 'X');

        var cut = new BotPlayer();

        //Act
        var result = cut.GetNextMove(board);

        //Assert
        result.Should().Be(-1);
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
    public void GetNextMove_WhenMove_SouldGiveANumberOnEmptySpot(string boardData)
    {
        //Arrange
        var board = new Board();
        board.Init();
        for (int i = 0; i < boardData.Length; i++)
        {
            board.Set(i, boardData[i]);
        }

        var cut = new BotPlayer();

        //Act
        var index = cut.GetNextMove(board);
        var result = board.IsEmpty(index);

        //Assert
        result.Should().BeTrue();
    }
}