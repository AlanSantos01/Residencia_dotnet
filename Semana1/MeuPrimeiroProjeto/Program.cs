// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

#region Teste de tipos de Dados
    int tipoInteiro;
    double tipoDouble;
    string tipoString;
    long tipoLong;

    tipoInteiro = int.MaxValue;
    tipoLong = long.MaxValue;

    tipoString = "100";
    tipoInteiro = int.Parse(tipoString);

    Console.WriteLine("O maximo inteiro é " + tipoInteiro);
    Console.WriteLine("O maximo inteiro é " + tipoLong);
#endregion

#region Teste de Operadores
    tipoDouble = tipoInteiro + tipoLong;

    tipoInteiro = 10 > 5 ? 1 : 0;
    Console.WriteLine(tipoInteiro);
#endregion