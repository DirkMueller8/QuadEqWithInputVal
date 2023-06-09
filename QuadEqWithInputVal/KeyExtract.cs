using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadEqWithInputVal
{
    public class KeyExtract
    {
        // Display the content of the OrderedDictionary carrying the coefficients:
        public static void DisplayContents(ICollection keyCollection, ICollection valueCollection, int dictionarySize)
        {
            string[] myKeys = new string[dictionarySize];
            float[] myValues = new float[dictionarySize];
            keyCollection.CopyTo(myKeys, 0);
            valueCollection.CopyTo(myValues, 0);

            Console.WriteLine("   INDEX KEY             VALUE");
            for (int i = 0; i < dictionarySize; i++)
            {
                Console.WriteLine("   {0,-5} {1,-15} {2}",
                    i, myKeys[i], myValues[i]);
            }
            Console.WriteLine();
        }


        // Display the key (coefficient a, b or c) of the OrderedDictionary:
        public static string DisplayKey(ICollection keyCollection, int dictionarySize, int i)
        {
            string[] myKeys = new string[dictionarySize];
            keyCollection.CopyTo(myKeys, 0);
            return myKeys[i];
        }


        // Display the value of a coefficient (a, b or c) of the OrderedDictionary:
        public static float DisplayValue(ICollection valueCollection, int dictionarySize, int i)
        {
            float[] myValues = new float[dictionarySize];
            valueCollection.CopyTo(myValues, 0);

            return myValues[i];

        }
    }
}
