using System;
using System.Collections.Generic;
using System.Globalization;

class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }
}

class Advogado : Pessoa
{
    public string CNA { get; set; }
}

class Cliente : Pessoa
{
    public string EstadoCivil { get; set; }
    public string Profissao { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        try{
            List<Advogado> advogados = new List<Advogado>();

            AddAdvogado(advogados, "Helder", "01/01/1990", "12345678900", "ABCD1234");
            AddAdvogado(advogados, "Maria", "02/02/1995", "98765432100", "EFGH5678");

            List<Cliente> clientes = new List<Cliente>();

            AddCliente(clientes, "Ana", "10/05/1985", "11111111111", "Solteiro", "Advogada");
            AddCliente(clientes, "Pedro", "15/09/1992", "22222222222", "Casado", "Engenheiro");
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message);
        }
        
    }

    static void AddAdvogado(List<Advogado> advogados, string nome, string dataNascimento, string cpf, string cna)
    {
        try{
            DateTime parsedDate = DateTime.ParseExact(dataNascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Advogado advogado = new Advogado{
                Nome = nome,
                DataNascimento = DateTime.Parse(dataNascimento),
                CPF = cpf,
                CNA = cna
            };

            if (!IsDuplicate(advogados, advogado.CPF, advogado.CNA)){
                advogados.Add(advogado);
            }
            else{
                Console.WriteLine("CPF ou CNA já cadastrado na base de dados.");
            }
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message);
        }
        
    }

    static void AddCliente(List<Cliente> clientes, string nome, string dataNascimento, string cpf, string estadoCivil, string profissao)
    {
        try{
            Cliente cliente = new Cliente{
                Nome = nome,
                DataNascimento = DateTime.Parse(dataNascimento),
                CPF = cpf,
                EstadoCivil = estadoCivil,
                Profissao = profissao
            };

            if (!IsDuplicate(clientes, cliente.CPF)){
                clientes.Add(cliente);
            }else{
                Console.WriteLine("CPF já cadastrado para outro cliente.");
            }
        }catch(FormatException){
            Console.WriteLine("Formato de data inválido");
        }
        
    }

    static bool IsDuplicate<T>(List<T> list, params string[] fields)
        where T : Pessoa
    {
        return list.Exists(item => fields.Any(field => field == item.CPF || (item is Advogado advogado && field == advogado.CNA)));
    }
    
}
