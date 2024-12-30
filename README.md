## Quadratic equation solver
**********************************************
Software:	&emsp;	C# 10 / .NET 6.0

Version:  &emsp;  	1.0

Date: 	&emsp;		June 10, 2023

Author:	&emsp;		Dirk Mueller
**********************************************  

This software is a quadratic equation solver.

![](https://github.com/DirkMueller8/QuadEqWithInputVal/blob/master/QuadEq.png)
 
*Fig 1: Basic problem setting*

**Input validation**

For the validation of the user input I used the NuGet package `fluentvalidation` (ver. 11.5.2) to check:
1. that a is unequal to zero
2. that any of the coefficients (defined as float) does not exceed `float.MaxValue`

**Storing values**

To follow the DRY principle and to store the names and values of the coefficients a, b and c, I used the `OrderedDictionary` Class (https://learn.microsoft.com/en-us/dotnet/api/system.collections.specialized.ordereddictionary?view=net-7.0)

![](https://github.com/DirkMueller8/QuadEqWithInputVal/blob/master/OrderedDict.png)

*Fig 2: Input example for coefficients stored in a `OrderedDictionary` *

**Determination if solution exists**

The static method `Solvable()` (within class `SolvableYesNo()`) determines if a solution exists. 
The static method `SingleResult` (within class `SolvableYesNo()`) determines if exactly one solution exists.
Depending on these results either `QuadResult()` (within class `Calculate()`) is called to return a tuple of two solutions.
Or, in case of a one-solution case, the method `SingleResult()` (within class `Calculate()`) is called to calculate it.

```CSharp
namespace QuadEqWithInputVal
{
    public class Calculate
    {
        public float a { get; set; }
        public float b { get; set; }
        public float c { get; set; }

        // Calculation of the two-result case:
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

        // Calculation of the case when there is only one solution:
        public static float SingleResult(float a, float b, float c)
        {
            float result = -b / 2.0F / a;
            return (result);
        }
    }
}
```

**Unit Tests**

I used the MSTest library `Microsoft.VisualStudio.TestTools.UnitTesting` for unit testing, to cover various cases. 
I also included a tolerance for the sake of incorporating rounding erros, as they can typically occur with floats.
