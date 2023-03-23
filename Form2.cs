using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Database;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace Logando_Firebase;
public partial class Form2 : Form
{
    public Form2()
    {
        InitializeComponent();
        obtendoDados();
    }
    private async void obtendoDados()
    {
        listBox1.Items.Clear();
         
        var firebaseClient = new FirebaseClient(
        "https://listacompras-6e717.firebaseio.com/",
        new FirebaseOptions
        {
            AuthTokenAsyncFactory = () => LoginAsync()
        });
        
        var resultado = await firebaseClient.Child("JSON").OnceAsJsonAsync();

        JsonDocument jsonDocument = JsonDocument.Parse(resultado);
        JsonElement root = jsonDocument.RootElement;

        foreach (var teste in root.EnumerateObject())
        {
            // Converter string em JsonElement
            //Array
            // JsonElement te = JsonDocument.Parse(teste.ToString()).RootElement;
            //Object
            JsonElement te = teste.Value;
            // Converter JsonElement em string

            Console.WriteLine(te.GetProperty("Nome"));
            Pessoa pessoa = new Pessoa(te.GetProperty("Nome").ToString(), te.GetProperty("Email").ToString(), teste.Name);
            listBox1.Items.Add(pessoa);
        }
        /*
        // Escrevendo dados no Firebase Realtime
        var pessoa = new Pessoa(textBox1.Text, textBox2.Text, textBox3.Text);
        var json = JsonConvert.SerializeObject(pessoa);
        var result = await client.Child("Pessoas").PostAsync(json);
        MessageBox.Show("Dados salvos com sucesso!");*/
    }
    private static async Task<string> LoginAsync()
    {
        /*
         {
"rules": {
".read": "auth != null",
".write": "auth != null"
  }
}
         */
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
        var cliente = new FirebaseAuthClient(config);
        return await cliente.User.GetIdTokenAsync();
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
