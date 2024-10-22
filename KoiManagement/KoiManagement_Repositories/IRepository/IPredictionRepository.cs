using KoiManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Repositories.IRepository
{
    public interface IPredictionRepository
    {
        public List<Prediction> GetAll();
        public Prediction? GetById(string predictionId);
        public Prediction? GetByUserId(string UserId);
        public bool AddPrediction(Prediction prediction);
        public bool UpdatePrediction(Prediction prediction);
        public bool DeletePrediction(Prediction prediction);
    }
}
