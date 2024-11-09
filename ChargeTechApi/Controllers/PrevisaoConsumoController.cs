using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using Microsoft.ML.Data;
using System.IO;

namespace ChargeTechApi.Controllers
{
    public class ConsumoDispositivo
    {
        [LoadColumn(0)] public string DataRegistro { get; set; }
        [LoadColumn(1)] public float Consumo { get; set; }
        [LoadColumn(2)] public float CustoEstimado { get; set; }
        [LoadColumn(3)] public float CustoConsumo { get; set; }
    }

    public class ConsumoDispositivoPrediction
    {
        [ColumnName("Score")]
        public float PredictedConsumo { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class PrevisaoConsumoController : ControllerBase
    {
        private readonly string caminhoModelo = Path.Combine(Environment.CurrentDirectory, "wwwroot", "MLModels", "ModeloConsumo.zip");
        private readonly string caminhoTreinamento = Path.Combine(Environment.CurrentDirectory, "Data", "consumo-train.csv");
        private readonly MLContext mlContext;

        public PrevisaoConsumoController()
        {
            mlContext = new MLContext();

        
            if (!System.IO.File.Exists(caminhoModelo))
            {
                Console.WriteLine("Modelo não encontrado. Iniciando treinamento...");
                TreinarModelo();
            }
        }

        private void TreinarModelo()
        {
            var pastaModelo = Path.GetDirectoryName(caminhoModelo);
            if (!Directory.Exists(pastaModelo))
            {
                Directory.CreateDirectory(pastaModelo);
            }

            IDataView dadosTreinamento = mlContext.Data.LoadFromTextFile<ConsumoDispositivo>(
                path: caminhoTreinamento, hasHeader: true, separatorChar: ',');

      
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "DataRegistro_encoded", inputColumnName: nameof(ConsumoDispositivo.DataRegistro))
                .Append(mlContext.Transforms.Concatenate("Features", "DataRegistro_encoded", nameof(ConsumoDispositivo.Consumo), nameof(ConsumoDispositivo.CustoEstimado)))
                .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: nameof(ConsumoDispositivo.CustoConsumo), featureColumnName: "Features"));

         
            var modelo = pipeline.Fit(dadosTreinamento);

          
            mlContext.Model.Save(modelo, dadosTreinamento.Schema, caminhoModelo);
        }

        [HttpPost("prever")]
        public ActionResult<ConsumoDispositivoPrediction> PreverConsumo([FromBody] ConsumoDispositivo dadosConsumo)
        {
            if (!System.IO.File.Exists(caminhoModelo))
            {
                return BadRequest("O modelo ainda não foi treinado.");
            }

            ITransformer modelo;
            using (var stream = new FileStream(caminhoModelo, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                modelo = mlContext.Model.Load(stream, out var modeloSchema);
            }

      
            var enginePrevisao = mlContext.Model.CreatePredictionEngine<ConsumoDispositivo, ConsumoDispositivoPrediction>(modelo);

         
            var previsao = enginePrevisao.Predict(dadosConsumo);

            return Ok(previsao);
        }
    }
}
