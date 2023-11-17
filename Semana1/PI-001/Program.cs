#region Exerc 2
    //tipo sbyte - Faixa de valores: -128 a 127
    sbyte testeSByte = 66;

    //tipo byte - Faixa de valores: 0 a 255
    byte testeByte = 155;

    //tipo short - Faixa de valores: -32,768 a 32,767
    short testeShort = 5556

    //tipo ushort - Faixa de valores: 0 a 65,535
    ushort testeUshort = 56789;

    //tipo int - Faixa de valores: -2.147.483.648 a 2.147.483.647
    int testeInt = 547598;

    //tipo uint - Faixa de valores: 0 a 4.294.967.295
    uint testeUInt = 3000000000;

    //tipo long - Faixa de valores: -9.223.372.036.854.775.808 a 9.223.372.036.854.775.807
    long testeLong = 987654321012345678;

    //tipo ulong - Faixa de valores: 0 a 18.446.744.073.709.551.615
    ulong testeULong = 18446744073709551615;
#endregion

#region Exerc 3
    double numeroDouble = 10.75;

    // Convertendo double para int
    int numeroInteiro = (int)numeroDouble;

    Console.WriteLine("Número Double: " + numeroDouble);
    Console.WriteLine("Número Inteiro (após conversão): " + numeroInteiro);
#endregion

#region Exerc 4
    int x = 10;
    int y = 3;

    int soma = x + y;
    Console.WriteLine($"Adição: {x} + {y} = {soma}");

    int subtracao = x - y;
    Console.WriteLine($"Subtração: {x} - {y} = {subtracao}");

    int multiplicacao = x * y;
    Console.WriteLine($"Multiplicação: {x} * {y} = {multiplicacao}");

    if (y != 0){
        float divisao = (float)x / y;
        Console.WriteLine($"Divisão: {x} / {y} = {divisao}");
    }
    else{
        Console.WriteLine("Divisão por zero não é permitida.");
    }
#endregion

#region Exerc 5
    int a = 5;
    int b = 8;

    // Verifica se a é maior que b
    if (a > b){
        Console.WriteLine("a é maior que b");
    }
    else{
        Console.WriteLine("a não é maior que b");
    }
#endregion

#region Exerc 6 
    string str1 = "Hello";
    string str2 = "World";

    // Verifica se as duas strings são iguais
    bool saoIguais = str1.Equals(str2);

    if (saoIguais){
        Console.WriteLine("As strings são iguais.");
    }
    else{
        Console.WriteLine("As strings são diferentes.");
    }
#endregion

#region Exerc 7
    bool condicao1 = true;
    bool condicao2 = false;

    if (condicao1 && condicao2){
        Console.WriteLine("Ambas as condições são verdadeiras.");
    }
    else{
        Console.WriteLine("Pelo menos uma das condições é falsa.");
    }
#endregion

#region Exerc 8
    int num1 = 7;
    int num2 = 3;
    int num3 = 10;

    // Verifica se num1 é maior que num2
    if (num1 > num2){
        Console.WriteLine("num1 é maior que num2.");
    }
    else{
        Console.WriteLine("num1 não é maior que num2.");
    }
    // Verifica se num3 é igual a num1 + num2
    if (num3 == num1 + num2){
        Console.WriteLine("num3 é igual a num1 + num2.");
    }
    else{
        Console.WriteLine("num3 não é igual a num1 + num2.");
    }
#endregion