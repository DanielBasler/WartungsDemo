using System.Collections.Generic;

namespace WartungsDemo
{
    public class InitHandler
    {
        NeuralNetwork neuralNetwork = null;
        private VectorAsDisplay vectorDisplay = new VectorAsDisplay();
        List<string> vectorShowValues = new List<string>();

        public List<string> setInitNeuralNetwork()
        {
            vectorShowValues.Clear();
            neuralNetwork = new NeuralNetwork(3, 4, 2);            

            double[] weights = new double[] { 0.126, 0.127, 0.128, 0.129,
                                0.115, 0.116, 0.117, 0.118,
                                0.135, 0.136, 0.137, 0.138,
                                0.15, 0.16, 0.17, 0.18,
                                0.19, 0.20, 0.21, 0.22,
                                0.23, 0.24, 0.25, 0.26,
                                0.3, 0.4 };

            neuralNetwork.SetWeights(weights);

            double[] xValues = new double[] { 1.0, 2.0, 3.0 };

             
            double[] yValues = neuralNetwork.Feedforward(xValues);

            vectorShowValues = neuralNetwork.GetVectorValueList();
            
            vectorShowValues.Add("Ausgabewerte Y1 und Y2");
            List<string> rightOutput = vectorDisplay.ShowVector(yValues, 4);
            foreach(string element in rightOutput)
            {
                vectorShowValues.Add(element);
            } 

            return vectorShowValues;

            
        }
    }
}
