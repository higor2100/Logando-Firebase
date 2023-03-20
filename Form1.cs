//Explicar o erro do Google em relação ao Firebase
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;


namespace Logando_Firebase;

public partial class Form1 : Form
{


    public Form1()
    {
        InitializeComponent();

    }
    //Explicar o problema com o Form
    private void button1_Click(object sender, EventArgs e)
    {

        try
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
            var auth = client.SignInWithEmailAndPasswordAsync(textBox1.Text, textBox2.Text).Result;
            this.Hide();
            var form = new Form2();
            form.Closed += fecharFormulario;
            form.Show();

        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("InvalidEmailAddress"))
                MessageBox.Show("Informe um email valido");
            else if (ex.Message.Contains("MissingPassword"))
                MessageBox.Show("Senha Incorreta");
            else MessageBox.Show(ex.Message);
        }


    }

    private void fecharFormulario(object? sender, EventArgs e)
    {
        this.Close();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        this.Hide();
        var form = new Form3();
        form.Closed += fecharFormulario;
        form.Show();
    }
}
