using System.Collections.Generic;

namespace WartungsDemo
{
    public class VectorAsDisplay
    {
        List<string> vectorValue = new List<string>();
        public List<string> ShowVector(double[] vector, int decimals)
        {

            for (int i = 0; i < vector.Length; ++i)
            { 
                vectorValue.Add(vector[i].ToString("F" + decimals).PadLeft(decimals + 4));  
            }
           
            return vectorValue;
        }
    }
}
