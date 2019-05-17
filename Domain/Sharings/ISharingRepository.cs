namespace Domain.Sharings
{
    public interface ISharingRepository : IRepository<Sharing>
    {
        bool Exists(int recipientID, int selectionID);
    }
}
