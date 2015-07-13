using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//core of fuzzy set, include fuzzy function, 
namespace FuzzyDemo_DSS_Team_3
{
    class fuzzyCore
    {
        int a;
        float b;
        public fuzzyCore()
        {
            a = 1;
            b = 1.0f;
        }
        public void setA(int value) 
        {
            a = value;
        }
        public int getA()
        {
            return a;
        }

        public void setA(float value)
        {
            b = value;
        }
        public float getB()
        {
            return b;
        }
        public float weigth()
        {
            return b*a;
        }
    }
}
