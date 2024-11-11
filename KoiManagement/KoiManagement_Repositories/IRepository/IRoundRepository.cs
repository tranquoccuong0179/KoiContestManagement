using KoiManagement_BusinessObjects;

namespace KoiManagement_Repositories.IRepository
{
    public interface IRoundRepository
    {
        List<Round> GetRounds();
        Round? GetRound(string id);
        bool AddRound(Round round);
        bool UpdateRound(Round round);
        bool DeleteRound(Round round);
    }
}
