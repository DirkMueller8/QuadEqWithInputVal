global using FluentValidation;
using System.Collections;
using System.Collections.Specialized;

namespace QuadEqWithInputVal
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string str;
            bool resultParse;

            float a, b, c;
            float temp;
            float[] coeffM = new float[3];
            OrderedDictionary myOrdDict = new OrderedDictionary();
            myOrdDict.Add("a", 0.0F);
            myOrdDict.Add("b", 0.0F);
            myOrdDict.Add("c", 0.0F);
            ICollection keyCollection = myOrdDict.Keys;
            ICollection valueCollection = myOrdDict.Values;

            while (true)
            {
                bool check = false;
                for (int i = 0; i < 3; i++)
                {
                    while (true)
                    {
                        while (true)
                        {
                            Console.Write($"Give {KeyExtract.DisplayKey(keyCollection, myOrdDict.Count, i)}: ");
                            str = Console.ReadLine();
                            if (str.Contains('.'))
                            {
                                Console.WriteLine("Please us a comma, instead of .!");
                            }
                            else
                            {
                                break;
                            }
                        }

                        resultParse = float.TryParse(str, out temp);
                        if (!resultParse)
                        {
                            Console.WriteLine($"Coefficient {KeyExtract.DisplayKey(keyCollection, myOrdDict.Count, i)} is not a double!");
                        }
                        else
                        {
                            myOrdDict[KeyExtract.DisplayKey(keyCollection, myOrdDict.Count, i)] = temp;
                            break;
                        }
                    }

                }
                Coefficients coefficients = new Coefficients(KeyExtract.DisplayValue(valueCollection, myOrdDict.Count, 0), KeyExtract.DisplayValue(valueCollection, myOrdDict.Count, 1), KeyExtract.DisplayValue(valueCollection, myOrdDict.Count, 2));
                CoeffValidator validator = new CoeffValidator();
                var result = validator.Validate(coefficients);

                if (!result.IsValid)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                        check = true;
                    }
                }
                if (coefficients.a == 0.0)
                {
                    Console.WriteLine($"Coefficient {KeyExtract.DisplayKey(keyCollection, myOrdDict.Count, 0)} cannot be zero!");
                    Console.WriteLine("Please start again with your input");
                    check = true;

                }
                if (!check)
                {
                    break;
                }
                for (int i = 0; i < 2; i++)
                {
                    myOrdDict[KeyExtract.DisplayKey(keyCollection, myOrdDict.Count, i)] = 0;
                }

            }
            Console.WriteLine();
            Console.WriteLine("Your input was successfully validated:");
            KeyExtract.DisplayContents(keyCollection, valueCollection, myOrdDict.Count);
        }
    }
}