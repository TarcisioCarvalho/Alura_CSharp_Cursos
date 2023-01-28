Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

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

