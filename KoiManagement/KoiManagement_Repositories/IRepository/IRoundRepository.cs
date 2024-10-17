using KoiManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
