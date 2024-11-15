using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_DAO.DTO
{
    public class CompetitionRoundScore
    {
        public string CompetitionRoundId { get; set; }
        public string KoiId { get; set; }
        public string KoiName { get; set; }
        public string OwnerName { get; set; }
        public double AveragePoint { get; set; }
    }

}
