using Amazon;
using Amazon.Runtime.CredentialManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Credentials
{
    public static class GetCredentials
    {
        //No one wants to accidentally ship AWS credentials and keys to GitHub
        //This set of methods gets the credentials from the home computer at runtime
        //avoiding the need to place anything in the code itself.

        //REQUIRED:  Obtain an AWS key and secret key. Place them in the .NET
        //SDK Store on your computer which stores them encrypted in a standard
        //place for Visual Studio Community and Visual Studio Code to find and use.
        //The following program will place them in the SDK Store which is located at:
        // %USERPROFILE%\AppData\Local\AWSToolkit\RegisteredAccounts.json

        //1. Use NuGet to add the following packages to the project:
        //      AWSSDK.Core
        //
        //2. Add "using Amazon;" and "using Amazon.Runtime.CredentialManagement;"
        //   to your libraries at the top of the code.
        //
        //3. From Program.cs, run the following two lines with your profile name
        //   and key, then with your profile name and region:
        //
        //   WriteProfile("my_new_profile", "AWS-ACCESS-KEY-VALUE", "AWS-SECRET-KEY-VALUE");
        //   AddRegion("my_new_profile", RegionEndpoint.USEast1);
        //
        //4. Once the SDK Store is written, REMOVE THOSE KEYS FROM YOUR CODE.
        public static void WriteProfile(string profileName, string keyId, string secret)
        {
            Console.WriteLine($"Create the [{profileName}] profile...");
            var options = new CredentialProfileOptions
            {
                AccessKey = keyId,
                SecretKey = secret
            };
            var profile = new CredentialProfile(profileName, options);
            var netSdkStore = new NetSDKCredentialsFile();
            netSdkStore.RegisterProfile(profile);
        }

        public static void AddRegion(string profileName, RegionEndpoint region)
        {
            var netSdkStore = new NetSDKCredentialsFile();
            CredentialProfile profile;
            if (netSdkStore.TryGetProfile(profileName, out profile))
            {
                profile.Region = region;
                netSdkStore.RegisterProfile(profile);
            }
        }

        //This can also be done manually, but the keys are stored in plain text on
        //your computer, which is not optimal. (The keys listed here are no longer
        //valid keys)
        // In C:\Users\YourAccount\.aws, place them  with the following names:
        // "credentials" with the following content:
        //
        //[default]
        //aws_access_key_id=AWS-ACCESS-KEY-VALUE
        //aws_secret_access_key=AWS-SECRET-KEY-VALUE
        //
        // and "config" with the following content using US-East-Northern-Virginia
        // as the region:
        //
        //[default]
        //region = us-east-1 



    }
}
