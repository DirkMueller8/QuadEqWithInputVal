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
    }
}
