using bytebank.Modelos.Conta;

namespace bytebank.Util;

public class listaDeContasCorrentes
{
    private ContaCorrente[] _itens= null;

    public listaDeContasCorrentes(int inicial = 5)
    {
        _itens = new ContaCorrente[inicial];
    }

    public void Adicionar(ContaCorrente item)
    {
        
    }
}