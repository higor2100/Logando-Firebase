using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Auth;

namespace Logando_Firebase;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        var config = new FirebaseAuthConfig
        {
            ApiKey = "AIzaSyAbj--ori0WT4Kr4Y7N9A0arv9gFtaTyos",
            AuthDomain = "listacompras-6e717.firebaseapp.com",
            Providers = new FirebaseAuthProvider[]
           {
                new EmailProvider()
           },
            UserRepository = new FileUserRepository("FirebaseSample")
        };
        var client = new FirebaseAuthClient(config);
        //Console.WriteLine(client.User.Uid);
        if (client.User != null)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form2());
        }
        else
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
        
    
}