using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Triplet
{
    class Program
    {
        static void Main(string[] args)
        {
     
            string str = "asaasa,ssa,dsf,ds1,dbs";
            string outStr;
            CancellationTokenSource cancellSource = new CancellationTokenSource();
            CancellationToken token = cancellSource.Token;
            
            outStr = MostFrequentTriplet(str,token);
            Console.WriteLine(outStr);
            Console.ReadLine();

        }
        static string MostFrequentTriplet(string str, CancellationToken ct)
        {
            string[] s = str.Split(',');
            List<string> triplets = new List<string>();
            for (int i = 0; i < s.Length;i++ )
            {
                
                for (int j=0;j<s[i].Length-2;j++)
                {
                    triplets.Add(s[i].Substring(j,3));
                }
            }
            var most = from i in triplets
                       group triplets by i into grp1
                       where grp1.Count() == (from j in triplets
                                              group triplets by j into grp
                                              select grp.Count()
                                           ).Max()
                       select  grp1.Key ;
            
            int tripletCount = (from i in triplets
                               group triplets by i into grp


                                select grp.Count()).First();
            string[] sr = most.ToArray();
            return string.Format("{0}\t{1}", string.Join(",", sr), tripletCount);
            
        }
    }
}
