using KoiManagement_BusinessObjects;

namespace KoiManagement_Services.IService
{
    public interface IRoundService
    {
        List<Round> GetRounds();
        Round? GetRound(string id);
        bool AddRound(Round round);
        bool UpdateRound(Round round);
        bool DeleteRound(Round round);
    }
}
