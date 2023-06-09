global using FluentValidation;
using System.Collections;
using System.Collections.Specialized;

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

    internal class Program
    {
        public static void DisplayContents(ICollection keyCollection, ICollection valueCollection, int dictionarySize)
        {
            string[] myKeys = new string[dictionarySize];
            float[] myValues = new float[dictionarySize];
            keyCollection.CopyTo(myKeys, 0);
            valueCollection.CopyTo(myValues, 0);

            Console.WriteLine("   INDEX KEY                       VALUE");
            for (int i = 0; i < dictionarySize; i++)
            {
                Console.WriteLine("   {0,-5} {1,-25} {2}",
                    i, myKeys[i], myValues[i]);
            }
            Console.WriteLine();
        }
        public static string DisplayKey(ICollection keyCollection, int dictionarySize, int i)
        {
            string[] myKeys = new string[dictionarySize];
            keyCollection.CopyTo(myKeys, 0);
            return myKeys[i];
        }
        public static float DisplayValue(ICollection valueCollection, int dictionarySize, int i)
        {
            float[] myValues = new float[dictionarySize];
            valueCollection.CopyTo(myValues, 0);

            return myValues[i];

        }
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
                            Console.Write($"Give {DisplayKey(keyCollection, myOrdDict.Count, i)}: ");
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
                            Console.WriteLine($"Coefficient {DisplayKey(keyCollection, myOrdDict.Count, i)} is not a double!");
                        }
                        else
                        {
                            myOrdDict[DisplayKey(keyCollection, myOrdDict.Count, i)] = temp;
                            break;
                        }
                    }

                }
                Coefficients coefficients = new Coefficients(DisplayValue(valueCollection, myOrdDict.Count, 0), DisplayValue(valueCollection, myOrdDict.Count, 1), DisplayValue(valueCollection, myOrdDict.Count, 2));
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
                    Console.WriteLine($"Coefficient {DisplayKey(keyCollection, myOrdDict.Count, 0)} cannot be zero!");
                    Console.WriteLine("Please start again with your input");
                    check = true;

                }
                if (!check)
                {
                    break;
                }
                for (int i = 0; i < 2; i++)
                {
                    myOrdDict[DisplayKey(keyCollection, myOrdDict.Count, i)] = 0;
                }

            }
            Console.WriteLine();
            Console.WriteLine("Your input was successfully validated:");
            DisplayContents(keyCollection, valueCollection, myOrdDict.Count);
        }
    }
}