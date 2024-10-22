using KoiManagement_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_DAO
{
    public class PredictionDAO
    {
        private KoiManagementContext context;
        private static PredictionDAO instance;

        public PredictionDAO()
        {
            context = new KoiManagementContext();
        }

        public static PredictionDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new PredictionDAO();
                return instance;
            }
        }
        public List<Prediction> GetAll()
        {
            return context.Predictions.ToList();

        }

        public Prediction? GetById(string predictionId)
        {
            return context.Predictions.FirstOrDefault(p => p.Id.Equals(predictionId));
        }

        public Prediction? GetByUserId(string UserId)
        {
            return context.Predictions.FirstOrDefault(p => p.UserId.Equals(UserId));
        }

        public bool AddPrediction(Prediction prediction)
        {
            bool result = false;
            Prediction? exsitedPrediction = GetById(prediction.Id);
            try
            {
                if (exsitedPrediction == null)
                {
                    context.Predictions.Add(prediction);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //log
            }
            return result;
        }

        public bool UpdatePrediction(Prediction prediction)
        {
            bool result = false;
            Prediction? exsitedPrediction = GetById(prediction.Id);
            try
            {
                if (exsitedPrediction != null)
                {
                    context.Entry<Prediction>(prediction).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //log
            }
            return result;
        }

        public bool DeletePrediction(Prediction prediction)
        {
            bool result = false;
            Prediction? exsitedPrediction = GetById(prediction.Id);
            try
            {
                if (exsitedPrediction != null)
                {
                    context.Predictions.Remove(prediction);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //log
            }
            return result;
        }
    }
}
