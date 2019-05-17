namespace Domain.Selections
{
    public interface ISelection : IAggregateRoot
    {
        SheetNameEnum SheetName { get; set; }
        string RangeName { get; set; }
    }
}
