namespace QuadEqWithInputVal
{
    public class SolvableYesNo
    {
        public float a { get; set; }
        public float b { get; set; }
        public float c { get; set; }

        // Tests, if the quadratic equation yields any solutions:
        public static bool Solvable(float a, float b, float c)
        {
            if (b * b - 4 * a * c < 0.0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public SolvableYesNo(float a, float b, float c) 
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }

    public class OneResultOnly
    {
        public float a { get; set; }
        public float b { get; set; }
        public float c { get; set; }

        // Test, if there is only one solution:
        public static bool SingleResult(float a, float b, float c)
        {
            if (b * b - 4 * a * c != 0.0F)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public OneResultOnly(float a, float b, float c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }
}