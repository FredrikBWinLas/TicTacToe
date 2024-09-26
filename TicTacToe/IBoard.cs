
namespace TicTacToe;

public interface IBoard
{
    void Init();
    char Get(int index);
    void Set(int index, char player);
    string ToString();
    bool IsEmpty(int index);
}

