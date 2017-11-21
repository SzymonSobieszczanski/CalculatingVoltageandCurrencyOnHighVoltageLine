using System;
using System.Collections.Generic;

namespace Zad2MetBadUrzKomp
{
    class Calculating
    {
      

        private List<float> _FirstList;
        private List<float> _SecondList;
        private float _Quantity;
        private float _R;
        private float _X;

        public float R { get { return _R; } set { _R = value; } }
        public float X { get { return _X; } set { _X = value; } }
        public float quantity { get { return _Quantity; } set { _Quantity = value; } }
        public List<float> firstList { get { return _FirstList; } set { _FirstList = value; } }
        public List<float> secondList { get { return _SecondList; } set { _SecondList = value; } }
  

     
    
        public float CalcRp()
        {
            float result = 0;
         

            result = ((Aku() * AkI())+(Bku()*AkI()))/(((float)Math.Pow(AkI(),2))+ ((float)Math.Pow(BkI(), 2)));
            return result;

        }

        public float calcXp()
        {

            float result = 0;


            result = ((Aku() * BkI()) - (Bku() * AkI())) / (((float)Math.Pow(AkI(), 2)) + ((float)Math.Pow(BkI(), 2)));
            return result;
        }

        public float calcLaf()
        {
            float result = 0;
            result = calcXp() / X;
            return result;
        }

        public float calcRf()
        {
            float result = 0;
            result = CalcRp() - calcLaf() * R;
            return result;
        }

      
        public float Aku() 
        {
           float result = 0;
            for (int i = 0; i < _FirstList.Count; i++)
            {
                
                result += (_FirstList[i] * ((float)Math.Cos((1 * (Math.PI * 2 * i)) / _Quantity) )) ;
               
            }
            return (float)Math.Round(((2 / _Quantity) * result), 4);
        }
        public float Bku()
        {
           float result = 0;
            for (int i = 0; i < _FirstList.Count; i++)
            {
                result += (_FirstList[i] * ((float)Math.Sin((1 * (Math.PI * 2 * i)) / _Quantity)));
           
            }
            return (float)Math.Round(((2 / _Quantity) * result), 4);
        }
        public float AkI()
        {
            float result = 0;
            for (int i = 0; i < _SecondList.Count; i++)
            {
                result += (_SecondList[i] * ((float)Math.Cos((1 * (Math.PI * 2 * i)) / _Quantity)));
     
            }
            return (float)Math.Round(((2 / _Quantity) * result), 4);
        }

      public float BkI()
        {

            float result = 0;
            for (int i = 0; i < _SecondList.Count; i++)
            {

                result += (_SecondList[i] * ((float)Math.Sin((1 * (Math.PI * 2 * i)) / _Quantity)));
           
            }
            return (float)Math.Round(((2 / _Quantity) * result), 4);
        }
    }
}
