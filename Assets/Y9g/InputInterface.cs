namespace Y9g
{
    public interface IButtonClick
    {
        void OnButtonClick();
    }

    public interface IEscClick
    {
        void OnEsc();
    }

    public interface IMove
    {
        void OnMove(Move4Direction direction);
    }
}