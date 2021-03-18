using System;
using System.Collections.Generic;

namespace WartungsDemo
{
    public class NeuralNetwork
    {
        private int nInput;
        private int nHidden;
        private int nOutput;

        private double[] inputs;
        private double[][] W_IH;

        private double[] biasHidden;
        private double[] biasOut;

        private double[] outputs_h;
        private double[][] W_HO;

        private double[] outputs;

        private List<string> vectorDisplayValue = null;
        private VectorAsDisplay vectorDisplay = new VectorAsDisplay();
        public NeuralNetwork(int nInput, int nHidden, int nOutput)
        {
            vectorDisplayValue = new List<string>();
            vectorDisplayValue.Add("Starte Initialisierung des neuronalen Netzes...");

            this.nInput = nInput;
            this.nHidden = nHidden;
            this.nOutput = nOutput;

            inputs = new double[nInput];
            biasHidden = new double[nHidden];
            outputs_h = new double[nHidden];

            biasOut = new double[nOutput];
            outputs = new double[nOutput];

            W_IH = NeuralMath.MakeMatrix(nInput, nHidden);
            W_HO = NeuralMath.MakeMatrix(nHidden, nOutput);
        }

        public void SetWeights(double[] weights)
        {
            int numWeights = (nInput * nHidden) + nHidden +
              (nHidden * nOutput) + nOutput;

            if (weights.Length != numWeights)
            {
                throw new Exception("Unglültiges Gewicht");
            }

            int k = 0;

            for (int i = 0; i < nInput; ++i)
            {
                for (int j = 0; j < nHidden; ++j)
                {
                    W_IH[i][j] = weights[k++];
                }
            }

            for (int i = 0; i < nHidden; ++i)
            {
                biasHidden[i] = weights[k++];
            }

            for (int i = 0; i < nHidden; ++i)
            {
                for (int j = 0; j < nOutput; ++j)
                {
                    W_HO[i][j] = weights[k++];
                }
            }

            for (int i = 0; i < nOutput; ++i)
            {
                biasOut[i] = weights[k++];
            }
        }

        public double[] Feedforward(double[] xValues)
        {     

            double[] hSums = new double[nHidden];

            double[] oSums = new double[nOutput];

            for (int i = 0; i < xValues.Length; ++i)
            {
                inputs[i] = xValues[i];
            }

            for (int j = 0; j < nHidden; ++j)
            {
                for (int i = 0; i < nInput; ++i)
                {
                    hSums[j] += inputs[i] * W_IH[i][j];
                }
            }

            for (int i = 0; i < nHidden; ++i)
            {
                hSums[i] += biasHidden[i];
            }  
                    

            for (int i = 0; i < nHidden; ++i)
            {
                outputs_h[i] = NeuralMath.HyperTan(hSums[i]);
            }

            vectorDisplayValue.Add("Werte im Hidden-Layer:");
            List<string> hOutputsList = vectorDisplay.ShowVector(outputs_h, 4);
            foreach (string element in hOutputsList)
            {
                vectorDisplayValue.Add(element);
            }

            for (int j = 0; j < nOutput; ++j)
            {
                for (int i = 0; i < nHidden; ++i)
                {
                    oSums[j] += outputs_h[i] * W_HO[i][j];
                }                    
            }                

            for (int i = 0; i < nOutput; ++i)
            {
                oSums[i] += biasOut[i];
            }                   

            double[] softOut = NeuralMath.Softmax(oSums);

            for (int i = 0; i < outputs.Length; ++i)
            {
                outputs[i] = softOut[i];
            }

            double[] result = new double[nOutput];

            for (int i = 0; i < outputs.Length; ++i)
            {
                result[i] = outputs[i];
            }

            return result;
        }

        public List<string> GetVectorValueList()
        {
            if(vectorDisplayValue.Count > 0)
            {
                return vectorDisplayValue;
            }

            return null;
        }
    }
}
