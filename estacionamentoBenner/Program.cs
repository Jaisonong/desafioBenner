using estacionamentoBenner;
using System;

namespace MyApp
{
    class Program
    {
        static void Main()
        {

            List<Veiculo> listaVeiculo = new List<Veiculo>();
            TabelaPreco tabelaPreco = new TabelaPreco(2.00, 1.00, new DateTime(2025, 1, 1), new DateTime(2025, 12, 29));

            Estacionamento estacionamento = new Estacionamento(listaVeiculo, tabelaPreco);


            while (true)
            {
                Console.WriteLine("\n| 1 - Registrar Entrada \n| 2 - Registrar Saída \n| 3 - Listar Veículos \n| 4 - Alterar Valor da Hora Inicial \n| 5 - Alterar Valor da Hora Adicional \n| 6 - Exibir Tabela De Preco\n| 7 - Sair ");
                Console.Write("Escolha uma opção: ");
                int opcao = int.Parse(Console.ReadLine());

                //Switch para selecionar as opções do estacionamento
                switch (opcao)
                {
                    case 1:
                        if (tabelaPreco.DentroDaVigencia(DateTime.Now))
                        {
                            Console.WriteLine("Informe a placa do Veículo: \n");
                            string placaEntrada = (Console.ReadLine());
                            estacionamento.RegistrarEntrada(placaEntrada);
                        }
                        else
                        {
                            Console.WriteLine("Data fora da vigência");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Informe a placa do Veículo: ");
                        string placaSaida = (Console.ReadLine());
                        estacionamento.RegistrarSaída(placaSaida);
                        break;
                    case 3:
                        estacionamento.ListarVeiculo();
                        break;
                    case 4:
                        Console.Write("Digite o novo valor da hora inicial: ");
                        double novoValorInicial = double.Parse(Console.ReadLine());
                        tabelaPreco.AlterarValorDaHoraInicial(novoValorInicial);
                        break;
                    case 5:
                        Console.Write("Digite o novo valor da hora inicial: ");
                        double novoValorAdicional = double.Parse(Console.ReadLine());
                        tabelaPreco.AlterarValorDaHoraAdicional(novoValorAdicional);
                        return;
                    case 6:
                        tabelaPreco.ExibirTabelaDePreco();
                        return;
                    case 7:
                        Console.WriteLine("Encerrando o Sistema...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
    }
}