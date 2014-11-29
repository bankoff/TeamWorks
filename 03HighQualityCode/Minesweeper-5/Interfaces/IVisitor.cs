namespace Minesweeper.Interfaces
{
    using Minesweeper.Data;

    public interface IVisitor
    {
        void Visit(Board board);
    }
}
