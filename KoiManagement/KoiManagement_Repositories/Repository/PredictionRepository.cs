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
    public class PredictionRepository : IPredictionRepository
    {
        public List<Prediction> GetAll()=> PredictionDAO.Instance.GetAll();

        public Prediction? GetById(string predictionId) => PredictionDAO.Instance.GetById(predictionId);
 
        public Prediction? GetByUserId(string UserId) => PredictionDAO.Instance.GetByUserId(UserId);

        public bool AddPrediction(Prediction prediction) => PredictionDAO.Instance.AddPrediction(prediction);


        public bool UpdatePrediction(Prediction prediction) => PredictionDAO.Instance.UpdatePrediction(prediction);
        

        public bool DeletePrediction(Prediction prediction) => PredictionDAO.Instance.DeletePrediction(prediction);

    }
}
