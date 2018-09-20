using System.IO;
using System.Reflection;
using TensorFlow;

namespace Mnist.LeNet
{
    public class Model
    {
        private TFSession _session = null;

        public Model(string path = null)
        {
            if (path == null)
            {
                var dllPath = Assembly.GetExecutingAssembly().Location;
                var rootDir = Path.GetDirectoryName(dllPath);
                path = Directory.GetFiles(rootDir, "*.pb")[0];
            }

            var graph = new TFGraph();
            var bytes = File.ReadAllBytes(path);
            graph.Import(bytes);
            var session = new TFSession(graph);
            _session = session;
        }

        ~Model()
        {
            if (_session != null)
            {
                _session.CloseSession();
                _session.Graph.Dispose();
            }
        }

        private TFTensor Predict(TFTensor input)
        {
            var runner = _session.GetRunner();
            var graph = _session.Graph;

            runner.AddInput(graph["Image"][0], input);
            runner.Fetch(graph["Predict"][0]);

            var output = runner.Run();
            return output[0];
        }

        public const int ImageSize = 28;

        private readonly TFShape SingleShape = new TFShape(1, 28, 28, 1);

        public float[] Predict(float[] input)
        {
            var tensor = TFTensor.FromBuffer(SingleShape, input, 0, input.Length);
            var ouptut = (float[][])Predict(tensor).GetValue(true);
            return ouptut[0]; // Batch size is 1
        }
    }
}
