using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estacionamentoBenner
{
    internal class Estacionamento
    {
        private List<Veiculo> veiculos;
        private TabelaPreco tabela { get; set; }

        public Estacionamento(List<Veiculo> veiculos, TabelaPreco tabela)
        {
            this.veiculos = veiculos;
            this.tabela = tabela;
        }

        //Registra a entrada
        public void RegistrarEntrada(string placa)
        {

            if (veiculos.Exists(v => v.Placa.Equals(placa)))
            {
                Console.WriteLine("Veículo no estacionamento.");
                return;
            }
            //Chamando a lista para adicionar um novo veículo
            Veiculo novoVeiculo = new Veiculo(placa);
            veiculos.Add(novoVeiculo);
        }

        //Faz o registro da saída
        public void RegistrarSaída(string placa)
        {
            Veiculo veiculo = veiculos.Find(v => v.Placa.Equals(placa));
            if (veiculo == null || veiculo.Saida != null)
            {
                Console.WriteLine("Veículo não está no estacionamento ou já saiu.");
                return;
            }

            //Utiliza o registro de saída para fazer o calculo
            veiculo.RegistrarSaida();
            double minutos = veiculo.CalcularTempo();
            double valorCobrado = tabela.CalcularValor(minutos);

            Console.WriteLine($"Registro de saída: {placa} as {veiculo.Saida}");
            Console.WriteLine($"Tempo: {minutos} minutos. Valor: {valorCobrado}");

            //Remove o veículo da lista
            veiculos.Remove(veiculo);
        }

        //Faz a listagem de veículos no estacionamento
        public void ListarVeiculo()
        {
            
            Console.WriteLine("\nVeiculos no estacionamento:");
            foreach (var v in veiculos)
            {
                //Percorre a lista, se o veiculo saiu trás um valor, se o valor for null retorna "Ainda no estacionamento"
                Console.WriteLine($"Placa: {v.Placa} \nEntrada: {v.Entrada} | Saída: {(v.Saida.HasValue ? v.Saida.ToString() : "Ainda no estacionamento")}\n");
            }
        }



    }
}
