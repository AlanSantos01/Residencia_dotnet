using System;
using System.Collections.Generic;

class Pessoa
{
    private string _nome;
    private string _dataNascimento;
    private string _cpf;

    public string Nome
    {
        get { return _nome; }
        set { _nome = value; }
    }

    public string DataNascimento
    {
        get { return _dataNascimento; }
        set { _dataNascimento = value; }
    }

    public string CPF
    {
        get { return _cpf; }
        set { _cpf = value; }
    }
}

class Advogado : Pessoa
{
    public string CNA;
}

class Cliente : Pessoa
{
    public string EstadoCivil;
    public string Profissao;
}

class Program
{
    static void Main(string[] args)
    {
        List<Advogado> advogados = new List<Advogado>();

        Advogado advogado1 = new Advogado
        {
            Nome = "Helder",
            DataNascimento = "01/01/1990",
            CPF = "12345678900",
            CNA = "ABCD1234"
        };

        if (!IsCPFDuplicated(advogados, advogado1.CPF))
        {
            advogados.Add(advogado1);
        }
        else
        {
            Console.WriteLine("CPF já cadastrado na base de dados.");
        }

        Advogado advogado2 = new Advogado
        {
            Nome = "Maria",
            DataNascimento = "02/02/1995",
            CPF = "98765432100",
            CNA = "EFGH5678"
        };

        if (!IsCPFDuplicated(advogados, advogado2.CPF))
        {
            advogados.Add(advogado2);
        }
        else
        {
            Console.WriteLine("CPF já cadastrado para outro advogado.");
        }

        List<Cliente> clientes = new List<Cliente>();

        Cliente cliente1 = new Cliente
        {
            Nome = "Ana",
            DataNascimento = "10/05/1985",
            CPF = "11111111111",
            EstadoCivil = "Solteiro",
            Profissao = "Advogada"
        };

        if (!IsCPFDuplicated(clientes, cliente1.CPF))
        {
            clientes.Add(cliente1);
        }
        else
        {
            Console.WriteLine("CPF já cadastrado para outro cliente.");
        }

        Cliente cliente2 = new Cliente
        {
            Nome = "Pedro",
            DataNascimento = "15/09/1992",
            CPF = "22222222222",
            EstadoCivil = "Casado",
            Profissao = "Engenheiro"
        };

        if (!IsCPFDuplicated(clientes, cliente2.CPF))
        {
            clientes.Add(cliente2);
        }
        else
        {
            Console.WriteLine("CPF já cadastrado para outro cliente.");
        }
    }

    static bool IsCPFDuplicated<T>(List<T> list, string cpf) where T : Pessoa
    {
        return list.Exists(p => p.CPF == cpf);
    }
}
