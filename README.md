## Quadratic equation solver
**********************************************
Software:		C# 10 / .NET 6

Version:    	0.1

Date: 			June 6, 2023

Author:			Dirk Mueller
**********************************************
This software is a quadratic equation solver.

![](https://github.com/DirkMueller8/QuadEqWithInputVal/blob/master/QuadEq.png)

*Fig 1: Basic problem setting*

**Input validation**

For the validation of the user input I used the NuGet package `fluentvalidation` to check:
1. that a is unequal to zero
2. that any of the coefficients (defined as float) does not exceed `float.MaxValue`

**Storing values**

To follow the DRY principle and to store the names and values of the coefficients a, b and c, I used the `OrderedDictionary` Class (https://learn.microsoft.com/en-us/dotnet/api/system.collections.specialized.ordereddictionary?view=net-7.0)

![](https://github.com/DirkMueller8/QuadEqWithInputVal/blob/master/OrderedDict.png)

*Fig 2: Input example for coefficients stored in a `OrderedDictionary` *
