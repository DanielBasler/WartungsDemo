using System;

namespace WartungsDemo
{
    public static class NeuralMath
    {
        public static double[][] MakeMatrix(int rows, int cols)
        {
            double[][] result = new double[rows][];

            for (int i = 0; i < rows; ++i)
            {
                result[i] = new double[cols];
            }

            return result;
        }

        public static double HyperTan(double v)
        {  
           return Math.Tanh(v);
        }

        public static double[] Softmax(double[] oSums)
        {

            double max = oSums[0];

            for (int i = 0; i < oSums.Length; ++i)
            {
                if (oSums[i] > max) max = oSums[i];
            }

            double scale = 0.0;

            for (int i = 0; i < oSums.Length; ++i)
            {
                scale += Math.Exp(oSums[i] - max);
            }

            double[] result = new double[oSums.Length];

            for (int i = 0; i < oSums.Length; ++i)
            {
                result[i] = Math.Exp(oSums[i] - max) / scale;
            }

            return result;

        }        
    }
}
