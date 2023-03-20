using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebaseAdmin.Auth;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace Logando_Firebase;
public partial class Form3 : Form
{
    FirebaseAuth auth = FirebaseAuth.DefaultInstance;

    public Form3()
    {
        InitializeComponent();

    }

    private void button1_Click(object sender, EventArgs e)
    {
        FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromFile("C:\\Users\\higor\\source\\repos\\Logando Firebase\\bin\\Debug\\net6.0-windows\\google-services.json")
        });
        

        try
        {
            var user = FirebaseAuth.DefaultInstance.CreateUserAsync(new UserRecordArgs()
            {
                Email = textBox1.Text,
                Password = textBox2.Text,
            }).Result;

            MessageBox.Show(user.TokensValidAfterTimestamp.ToString());
            MessageBox.Show("ID: " + user.Uid);
            MessageBox.Show("Email: " + user.Email);
            MessageBox.Show("Email Verified: " + user.EmailVerified);
            this.Hide();
            var form = new Form2();
            form.Closed += fecharFormulario;
            form.Show();

        }
        catch (Exception ex)
        {
            //Lembrar que a senha tem que ter no minimo 6 caracteres
            if (ex.Message == "One or more errors occurred. (The user with the provided email already exists (EMAIL_EXISTS).)")
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
