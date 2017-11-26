using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELM_SMP
{
    static class HelperFunctions
    {

        public static t[][] tojaggedarray<t>(this t[,] twodimensionalarray)
        {
            int rowsfirstindex = twodimensionalarray.GetLowerBound(0);
            int rowslastindex = twodimensionalarray.GetUpperBound(0);
            int numberofrows = rowslastindex + 1;

            int columnsfirstindex = twodimensionalarray.GetLowerBound(1);
            int columnslastindex = twodimensionalarray.GetUpperBound(1);
            int numberofcolumns = columnslastindex + 1;

            t[][] jaggedarray = new t[numberofrows][];
            for (int i = rowsfirstindex; i <= rowslastindex; i++)
            {
                jaggedarray[i] = new t[numberofcolumns];

                for (int j = columnsfirstindex; j <= columnslastindex; j++)
                {
                    jaggedarray[i][j] = twodimensionalarray[i, j];
                }
            }
            return jaggedarray;
        }
    }
}
