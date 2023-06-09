global using FluentValidation;
using System.Collections;
using System.Collections.Specialized;

namespace QuadEqWithInputVal
{
    /************************************************************************** 
     * This program solves the quadratic equation ax^2 + b*x + c = 0 and take
     * INPUT: coefficients a, b and c (defined as floats)
     * VALIDATION: uses NuGet "fluentvalidation" to validate the input
     * OUTPUT: prints to the console if the equation is solvable, and if so,
     *         displays the solution
     * 
     *************************************************************************/

    internal class Program
    {
        static void Main(string[] args)
        {
            string str;
            bool resultParse;
            float temp;

            OrderedDictionary myOrdDict = new OrderedDictionary();
            myOrdDict.Add("a", 0.0F);
            myOrdDict.Add("b", 0.0F);
            myOrdDict.Add("c", 0.0F);

            ICollection keyCollection = myOrdDict.Keys;
            ICollection valueCollection = myOrdDict.Values;

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("This program solves the quadratic equation ax ^ 2 + b * x + c = 0");
            Console.WriteLine("It will ask you for the coefficients a, b and c and will validate the input");
            Console.WriteLine("Finally it tells you if it is solvable and, if so, displays the result(s).");
            Console.WriteLine("***************************************************************************\n");

            // Input validation loop:
            while (true)
            {

                for (int i = 0; i < myOrdDict.Count; i++)
                {
                    while (true)
                    {
                        while (true)
                        {
                            Console.Write($"   Give {KeyExtract.DisplayKey(keyCollection, myOrdDict.Count, i)}: ");
                            str = Console.ReadLine();
                            if (str.Contains('.'))
                            {
                                Console.WriteLine("   Please us a comma, instead of .\n");
                            }
                            else
                            {
                                break;
                            }
                        }

                        resultParse = float.TryParse(str, out temp);
                        if (!resultParse)
                        {
                            Console.WriteLine($"   Coefficient {KeyExtract.DisplayKey(keyCollection, myOrdDict.Count, i)} is not a float!\n");
                        }
                        else
                        {
                            // If parsing was successful place input into OrderedDictionary:
                            myOrdDict[KeyExtract.DisplayKey(keyCollection, myOrdDict.Count, i)] = temp;
                            break;
                        }
                    }

                }

                // Input validation through fluentvalidation (https://docs.fluentvalidation.net/en/latest/):
                var coefficients = new Coefficients(KeyExtract.DisplayValue(valueCollection, myOrdDict.Count, 0), KeyExtract.DisplayValue(valueCollection, myOrdDict.Count, 1), KeyExtract.DisplayValue(valueCollection, myOrdDict.Count, 2));
                CoeffValidator validator = new CoeffValidator();
                var result = validator.Validate(coefficients);

                if (!result.IsValid)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

                else
                {
                    break;
                }

            }
            Console.WriteLine();
            Console.WriteLine("   Your input was successfully validated and here the summary:");
            Console.WriteLine();
            KeyExtract.DisplayContents(keyCollection, valueCollection, myOrdDict.Count);

            // Calculation of results, if any exist:
            if (SolvableYesNo.Solvable(KeyExtract.DisplayValue(valueCollection, myOrdDict.Count, 0), KeyExtract.DisplayValue(valueCollection, myOrdDict.Count, 1), KeyExtract.DisplayValue(valueCollection, myOrdDict.Count, 2)))
            {
                Console.WriteLine("   \nThe quadratic equation yields a result, as real number(s)");

                var results = Calculate.QuadResult(KeyExtract.DisplayValue(valueCollection, myOrdDict.Count, 0), KeyExtract.DisplayValue(valueCollection, myOrdDict.Count, 1), KeyExtract.DisplayValue(valueCollection, myOrdDict.Count, 2));
                Console.WriteLine($"found {results.Item1} {results.Item2}.");
            }
        }
    }
}