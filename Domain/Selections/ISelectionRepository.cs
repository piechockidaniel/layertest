namespace Domain.Selections
{
    public interface ISelectionRepository : IRepository<Selection>
    {
        Selection Get(string sheetName, string selectionName);
        bool Exists(string sheetName, string selectionName);
    }
}
