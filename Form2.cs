using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace Logando_Firebase;
public partial class Form2 : Form
{
    public Form2()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {

        // Configure...
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
        client.SignOut();
        this.Hide();
        var form = new Form1();
        form.Closed += fecharFormulario;
        form.Show();
    }
    private void fecharFormulario(object? sender, EventArgs e)
    {
        this.Close();
    }
}
