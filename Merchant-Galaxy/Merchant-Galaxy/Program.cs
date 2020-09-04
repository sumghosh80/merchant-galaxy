using Merchant_Galaxy.Expressions;
using Merchant_Galaxy.Roman;
using Merchant_Galaxy.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Merchant_Galaxy
{
    class Program
    {


        static void Main(string[] args)
        {
            try
            {
                // The code provided will print ‘Hello World’ to the console.
                // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
                Console.WriteLine("--- Merchant Galaxy --- ");
                Console.WriteLine();

                string path = "../../inputData.txt";
                string readText = File.ReadAllText(path);
                string[] lines = readText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine("--- Input Start ---");
                Console.WriteLine(readText);
                Console.WriteLine("--- Input End ---");

                Console.WriteLine();
                Console.WriteLine("--- Output Start ---");

                #region "Initialize components for the conversions"

                AliasMapper aliasMap = new AliasMapper();
                IDecimalConverter converter = new RomanConverter();
                CommodityIndex commodityIndex = new CommodityIndex();

                #endregion

                ExpressionParser parser = new ExpressionParser(aliasMap, converter, commodityIndex);
                foreach (string line in lines)
                {
                    parser.Parse(line);
                }

                Console.WriteLine("--- Output End ---");
                Console.ReadLine();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
    }
}
