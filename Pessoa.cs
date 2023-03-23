using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logando_Firebase;
public class Pessoa
{
    public string Nome;
    public string Email;
    public string id;

    public override string ToString() => this.Nome + " " + this.Email;

    public Pessoa(string nome, string email, string id)
    {
        this.Nome = nome;
        this.Email = email;
        this.id = id;
    }
}
