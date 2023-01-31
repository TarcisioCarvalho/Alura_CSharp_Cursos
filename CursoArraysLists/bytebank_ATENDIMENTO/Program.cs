using bytebank.Modelos.Conta;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");



void testaArrayContaCorrente()
{
    ContaCorrente[] listaDeContas = new ContaCorrente[]
    {
        new ContaCorrente(487,"5679787-A"),
        new ContaCorrente(487,"5679787-B"),
        new ContaCorrente(487,"5679787-C")
    };

    foreach (ContaCorrente conta in listaDeContas)
    {
        System.Console.WriteLine($"Conta : {conta.Conta}");
    }
}

testaArrayContaCorrente();


/* using bytebank.Modelos.Conta;





//void TestaBuscarPalavras()
{
    string[] palavras = new string[5];

    for (int i = 0; i < palavras.Length; i++)
    {
        System.Console.Write($"Digite {i+1}° Palavra : ");
        palavras[i] = Console.ReadLine();
    }

    System.Console.Write("Digite Palavra a Ser Buscada : ");
    string palavraProcurada = Console.ReadLine();

    foreach (var palavra in palavras)
    {
        if(palavra.Equals(palavraProcurada))
        {
            System.Console.WriteLine($"Palavra {palavra} Encontrada");
            return;
        }
    }
    System.Console.WriteLine("Palavra Não Encontrada");

}

void Idades()
{
    int indice =0;
    int acumulador = 0;
    int[] idades = new int[5];

    idades[0] = 10;
    idades[1] = 20;
    idades[2] = 30;
    idades[3] = 40;
    idades[4] = 50;

    foreach (var idade in idades)
    {
        System.Console.WriteLine($"Indice{indice} = {idade}");
        indice++;
        acumulador+= idade;
    }

    System.Console.WriteLine($"Média de Idade {acumulador/idades.Length}");
}

/* Array amostra = Array.CreateInstance(typeof(double),5);

amostra.SetValue(5.9,0);
amostra.SetValue(1.8,1);
amostra.SetValue(7.1,2);
amostra.SetValue(10,3);
amostra.SetValue(6.9,4); 

void testaMediana(Array array)
{
    if(array == null || array.Length == 0) return;

    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho/2;

    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] :
    (numerosOrdenados[meio] +  numerosOrdenados[meio -1])/2;
}

void testaArrayContaCorrente()
{
    ContaCorrente[] listaDeContas = new ContaCorrente[]
    {
        new ContaCorrente(487,"5679787-A"),
        new ContaCorrente(487,"5679787-B"),
        new ContaCorrente(487,"5679787-C")
    };

    foreach (ContaCorrente conta in listaDeContas)
    {
        System.Console.WriteLine($"Conta : {conta.Conta}");
    }
}
 */