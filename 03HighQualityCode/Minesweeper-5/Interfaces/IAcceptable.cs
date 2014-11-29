namespace Minesweeper.Interfaces
{
    public interface IAcceptable
    {
        void Accept(IVisitor visitor);
    }
}
