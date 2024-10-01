using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using TicTacToe;

namespace Tests;
public class UITests
{
    [Fact]
    public void Print_SholdRenderMessage()
    {
        //Arrange
        var writeOutputMock = Substitute.For<WriteOutputDelegate>();
        var clearOutputMock = Substitute.For<ClearOutputDelegate>();

        var cut = new UI { ClearOutput = clearOutputMock, WriteOutput = writeOutputMock };
        var message = "Test";

        //Act
        cut.Print(message);

        //Assert
        cut.WriteOutput.Received(1).Invoke(message);
    }

    [Fact]
    public void RenderHeader_ShouldWriteHeader()
    {
        //Arrange
        var writeOutputMock = Substitute.For<WriteOutputDelegate>();
        var clearOutputMock = Substitute.For<ClearOutputDelegate>();

        var cut = new UI { ClearOutput = clearOutputMock, WriteOutput = writeOutputMock };

        //Act
        cut.RenderHeader();

        //Assert
        cut.WriteOutput.Received(5).Invoke(Arg.Any<string>());
    }

    [Fact]
    public void RenderBoard_ShouldWriteBoard()
    {
        //Arrange
        var writeOutputMock = Substitute.For<WriteOutputDelegate>();
        var clearOutputMock = Substitute.For<ClearOutputDelegate>();
        var board = new Board();
        board.Set(0, 'X');
        board.Set(1, 'X');
        board.Set(2, 'O');

        var cut = new UI { ClearOutput = clearOutputMock, WriteOutput = writeOutputMock };

        //Act
        cut.RenderBoard(board);

        //Assert
        cut.WriteOutput.Received(13).Invoke(Arg.Any<string>());
        writeOutputMock.Received().Invoke(Arg.Is<string>(s => s.Contains("|  X  |  X  |  O  |")));
    }
}
