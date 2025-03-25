using Microsoft.ML.Data;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Hardware_Application
{
    public class SalesData
    {
        [LoadColumn(0)] public DateTime Date { get; set; }
        [LoadColumn(1)] public string Category { get; set; }
        [LoadColumn(2)] public float Quantity { get; set; }
        [LoadColumn(3)] public float Price { get; set; }
        [LoadColumn(4)] public string Season { get; set; } // Например: "Winter", "Summer"
        [LoadColumn(5)] public bool IsPromotion { get; set; }
    }

    public class SalesPrediction
    {
        [ColumnName("Score")]
        public float PredictedQuantity { get; set; }
    }

    public static class SalesForecastingService
    {
        private static MLContext mlContext = new MLContext();

        /// <summary>
        /// Обучает модель прогнозирования спроса на основе данных о продажах.
        /// </summary>
        /// <param name="dataPath">Путь к файлу с данными о продажах.</param>
        /// <returns>Обученная модель.</returns>
        public static ITransformer TrainModel(string dataPath)
        {
            // Загрузка данных
            IDataView dataView = mlContext.Data.LoadFromTextFile<SalesData>(dataPath, separatorChar: ',', hasHeader: true);

            // Разделение данных на обучающую и тестовую выборки
            var splitData = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);

            // Определение конвейера обработки данных и обучения
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "CategoryEncoded", inputColumnName: "Category")
                .Append(mlContext.Transforms.Concatenate("Features", "Date", "CategoryEncoded", "Price", "Season", "IsPromotion"))
                .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "Quantity", maximumNumberOfIterations: 100));

            // Обучение модели
            var model = pipeline.Fit(splitData.TrainSet);

            // Оценка модели
            var metrics = mlContext.Regression.Evaluate(model.Transform(splitData.TestSet), labelColumnName: "Quantity");
            Console.WriteLine($"R^2 Score: {metrics.RSquared}");

            return model;
        }

        /// <summary>
        /// Прогнозирует спрос на основе обученной модели.
        /// </summary>
        /// <param name="model">Обученная модель.</param>
        /// <param name="input">Входные данные для прогноза.</param>
        /// <returns>Прогнозируемое количество.</returns>
        public static float PredictDemand(ITransformer model, SalesData input)
        {
            var predictionEngine = mlContext.Model.CreatePredictionEngine<SalesData, SalesPrediction>(model);
            var prediction = predictionEngine.Predict(input);
            return prediction.PredictedQuantity;
        }
    }
}
