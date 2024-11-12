using KoiManagement_BusinessObjects;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Repositories.Repository;
using KoiManagement_Services.IService;

namespace KoiManagement_Services.Service
{
    public class PredictionService : IPredictionService
    {
        private IPredictionRepository _predictionRepository;
        public PredictionService()
        {
            _predictionRepository = new PredictionRepository();
        }

        public List<Prediction> GetAll() => _predictionRepository.GetAll();

        public Prediction? GetById(string predictionId) => _predictionRepository.GetById(predictionId);

        public Prediction? GetByUserId(string UserId) => _predictionRepository.GetByUserId(UserId);

        public bool AddPrediction(Prediction prediction) => _predictionRepository.AddPrediction(prediction);

        public bool UpdatePrediction(Prediction prediction) => _predictionRepository.UpdatePrediction(prediction);

        public bool DeletePrediction(Prediction prediction) => _predictionRepository.DeletePrediction(prediction);
    }
}
