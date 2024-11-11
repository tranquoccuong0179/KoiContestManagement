using KoiManagement_BusinessObjects;

namespace KoiManagement_Services.IService
{
    public interface IPredictionService
    {
        public List<Prediction> GetAll();
        public Prediction? GetById(string predictionId);
        public Prediction? GetByUserId(string UserId);
        public bool AddPrediction(Prediction prediction);
        public bool UpdatePrediction(Prediction prediction);
        public bool DeletePrediction(Prediction prediction);
    }
}
