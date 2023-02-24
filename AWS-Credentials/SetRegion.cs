using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Credentials
{
    public static class SetRegion
    {
        public static string GetRegion(string regionRaw)
        {
            //Get the raw region string, check it for validity, then 
            //convert it to the SDK Store Region version
            //Return the converted region string

            //Send back us-east-1 if region is null or empty
            if (string.IsNullOrEmpty(regionRaw)) return "us-east-1";

            //There are like 30 regions in AWS and more every few months.
            //This is just a straight check for string composition. 

            if (regionRaw.Length == 9 && regionRaw.Contains('-'))
            {          
                return regionRaw;
            }

            return "us-east-1";

        }
        



    }
}
