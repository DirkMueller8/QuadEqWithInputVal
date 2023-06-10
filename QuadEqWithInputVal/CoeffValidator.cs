namespace QuadEqWithInputVal
{
    public class Coefficients
    {
        public float a { get; set; }
        public float b { get; set; }
        public float c { get; set; }
        public Coefficients(float a, float b, float c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }
    public class CoeffValidator : AbstractValidator<Coefficients>
    {
        float maxSize = float.MaxValue;
        public CoeffValidator()
        {
            RuleFor(x => x.a)
                .NotEqual(0)
                .WithMessage("   \nInput for a cannot be zero: no quadratic equation\n")
                .LessThan(maxSize)
                .WithMessage("   \nInput for a too big\n");

            RuleFor(x => x.b)
                .LessThan(maxSize)
                .WithMessage("   \nInput for b too big\n");

            RuleFor(x => x.c)
                .LessThan(maxSize)
                .WithMessage("   \nInput for c too big\n");
        }
    }
}