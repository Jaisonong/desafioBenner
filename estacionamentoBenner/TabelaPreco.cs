using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estacionamentoBenner
{
    internal class TabelaPreco
    {
        public double ValorDaHoraInicial{  get; private set; }
        public double ValorDaHoraAdicional { get; private set; }
        public DateTime DataInicioVigencia { get; private set; }
        public DateTime DataFimVigencia { get; private set; }

        public TabelaPreco(double valorDaHoraInicial, double valorDaHoraAdicional, DateTime inicio, DateTime fim)
        {
            ValorDaHoraInicial = valorDaHoraInicial;
            ValorDaHoraAdicional = valorDaHoraAdicional;
            DataInicioVigencia = inicio;
            DataFimVigencia = fim;
        }

        //Verifica a vigencia da tabela
        public bool DentroDaVigencia(DateTime data)
        {
            return data >= DataInicioVigencia && data <= DataFimVigencia;
        }

        //Altera o valor da hora inicial
        public void AlterarValorDaHoraInicial(double novoValor)
        {
            if (novoValor >= 0)
            {
                ValorDaHoraInicial = novoValor;
                Console.WriteLine($"Alterado o valor da hora inicial para: ${novoValor}");
            }
            else
            {
                Console.WriteLine("Valor não pode ser negativo");
            }
        }

        //Altera o valor da hora adicional
        public void AlterarValorDaHoraAdicional(double novoValor)
        {
            if (novoValor >= 0)
            {
                ValorDaHoraAdicional = novoValor;
                Console.WriteLine($"Alterado o valor da hora adicional para: ${novoValor}");
            }
            else
            {
                Console.WriteLine("Valor não pode ser negativo");
            }
        }

        //Exibe a tabela de valores tanto inicial quanto adicional
        public void ExibirTabelaDePreco()
        {
            Console.WriteLine($"Tabela de preço Hora Inicial: {ValorDaHoraInicial}");
            Console.WriteLine($"Tabela de preço Hora Inicial: {ValorDaHoraAdicional}");
        }


        //Faz o calculo baseado no tempo que ficou no estacionamento
        public double CalcularValor(double minutos)
        {
            if (minutos < 30)
                return ValorDaHoraInicial / 2;

            //Converter para hora cheia e minutos
            int horasCheia = (int)minutos / 60;
            int minutosRestante = (int)minutos % 60;

            //Cobrança de horas adicionais
            double total = ValorDaHoraInicial;
            if (horasCheia > 0)
                total += (horasCheia - 1) * ValorDaHoraAdicional;

            //Cobrança relacionada aos minutos
            if (minutosRestante > 10)
                total += ValorDaHoraAdicional;
            return total;
        }
    }
}
