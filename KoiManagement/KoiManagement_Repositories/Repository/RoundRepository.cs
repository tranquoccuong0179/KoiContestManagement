using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Repositories.Repository
{
    public class RoundRepository : IRoundRepository
    {
        public bool AddRound(Round round) => RoundDAO.Instance.AddRound(round);
        public bool DeleteRound(Round round) => RoundDAO.Instance.DeleteRound(round);
        public Round? GetRound(string id) => RoundDAO.Instance.GetRound(id);
        public List<Round> GetRounds() => RoundDAO.Instance.GetRounds();
        public bool UpdateRound(Round round) => RoundDAO.Instance.UpdateRound(round);
    }
}
