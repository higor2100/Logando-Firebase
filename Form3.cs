using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Logando_Firebase;
public partial class Form3 : Form
{

    public Form3()
    {
        InitializeComponent();

    }

    private void button1_Click(object sender, EventArgs e)
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


        try
        {

            var client = new FirebaseAuthClient(config);
            MessageBox.Show(client.User.Uid);
            var usuario = client.CreateUserWithEmailAndPasswordAsync(textBox1.Text, textBox2.Text).Result;
            MessageBox.Show(usuario.User.Uid);
            /*var user = FirebaseAuth.DefaultInstance.CreateUserAsync(new UserRecordArgs()
            {
                Email = textBox1.Text,
                Password = textBox2.Text,
            }).Result;

            MessageBox.Show(user.TokensValidAfterTimestamp.ToString());
            MessageBox.Show("ID: " + user.Uid);
            MessageBox.Show("Email: " + user.Email);
            MessageBox.Show("Email Verified: " + user.EmailVerified);*/
            this.Hide();
            var form = new Form2();
            form.Closed += fecharFormulario;
            form.Show();

        }
        catch (Exception ex)
        {
            //Lembrar que a senha tem que ter no minimo 6 caracteres
            if (ex.Message.Contains("EMAIL_EXISTS"))
                MessageBox.Show("Esse email já esta cadastro");
            else
            {
                MessageBox.Show("Authentication failed: " + ex.Message);
            }

        }
    }
    private void fecharFormulario(object? sender, EventArgs e)
    {
        this.Close();
    }
}
