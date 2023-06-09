using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .WithMessage("Input for a cannot be zero: no quadratic equation")
                .LessThan(maxSize)
                .WithMessage("Input for a too big");

            RuleFor(x => x.b)
                .NotEmpty()
                .WithMessage("Input for b cannot be empty")
                .LessThan(maxSize)
                .WithMessage("Input for b too big");

            RuleFor(x => x.c)
                .NotEmpty()
                .WithMessage("Input for c cannot be empty")
                .LessThan(maxSize)
                .WithMessage("Input for c too big");
        }
    }
}
