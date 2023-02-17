using Amazon;
using Amazon.Runtime.CredentialManagement;

namespace AWS_Credentials
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Writing Keys into the SDK Store");
            GetCredentials.WriteProfile("my_new_profile", "AWS-ACCESS-KEY-VALUE", "AWS-SECRET-KEY-VALUE");
            GetCredentials.AddRegion("my_new_profile", RegionEndpoint.USEast1);
        }
    }
}