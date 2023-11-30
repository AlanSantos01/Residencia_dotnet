using System;
using System.Collections.Generic;

class Pessoa{
    public string nome;
    public string dataNascimento;
    public string cpf;
}

class Advogado : Pessoa{
    public string CNA;
}

class Cliente : Pessoa{
    public string estadoCivil;
    public string profissao;
}

class Program
{
    static void Main(string[] args)
    {
        List<Advogado> advogados = new List<Advogado>();

        Advogado advogado1 = new Advogado();
        advogado1.nome = "Helder";
        advogado1.dataNascimento = "01/01/1990";
        advogado1.cpf = "12345678900";
        advogado1.CNA = "ABCD1234";

        if (!advogados.Exists(a => a.cpf == advogado1.cpf || a.CNA == advogado1.CNA))
        {
            advogados.Add(advogado1);
        }
        else
        {
            Console.WriteLine("CPF ou CNA já cadastrado na base de dados.");
        }

        Advogado advogado2 = new Advogado();
        advogado2.nome = "Maria";
        advogado2.dataNascimento = "02/02/1995";
        advogado2.cpf = "98765432100";
        advogado2.CNA = "EFGH5678";

        if (!advogados.Exists(a => a.cpf == advogado2.cpf || a.CNA == advogado2.CNA))
        {
            advogados.Add(advogado2);
        }
        else
        {
            Console.WriteLine("CPF ou CNA já cadastrado para outro advogado.");
        }
    }
    List<Cliente> clientes = new List<Cliente>();

    Cliente cliente1 = new Cliente();
    cliente1.nome = "Ana";
    cliente1.dataNascimento = "10/05/1985";
    cliente1.cpf = "11111111111";
    cliente1.estadoCivil = "Solteiro";
    cliente1.profissao = "Advogada";

    if (!clientes.Exists(c => c.cpf == cliente1.cpf)){
    clientes.Add(cliente1);
    }else{
    Console.WriteLine("CPF já cadastrado para outro cliente.");
    }

    Cliente cliente2 = new Cliente();   
    cliente2.nome = "Pedro";
    cliente2.dataNascimento = "15/09/1992";
    cliente2.cpf = "22222222222";
    cliente2.estadoCivil = "Casado";
    cliente2.profissao = "Engenheiro";

    if (!clientes.Exists(c => c.cpf == cliente2.cpf)){
    clientes.Add(cliente2);
    }else{
    Console.WriteLine("CPF já cadastrado para outro cliente.");
    }
}
