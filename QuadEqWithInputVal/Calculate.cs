using System;

namespace QuadEqWithInputVal
{

    public class Calculate
    {
        public float a { get; set; }
        public float b { get; set; }
        public float c { get; set; }
        public static (float, float) QuadResult(float a, float b, float c)
        {
            float quad;
            quad = (float)Math.Sqrt(b * b - 4.0 * a * c);
            float result1 = (quad - b) / 2.0F / a;
            float result2 = (-quad - b) / 2.0F / a;
            return (result1, result2);
        }
        public Calculate(float a, float b, float c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public static float SingleResult(float a, float b, float c)
        {
            float result = - b / 2.0F / a;
            return (result);
        }
    }
}
