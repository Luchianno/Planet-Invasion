public interface ICardView : IUpdateableView
{
    Card Card { get; set; }

    CardClickEvent CardClicked { get; }
}