using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estacionamentoBenner
{
    internal class Veiculo
    {
        public string Placa { get; private set; }
        public DateTime Entrada { get; private set; }
        public DateTime? Saida { get; private set; }

        public Veiculo(string placa)
        {
            Placa = placa;
            Entrada = DateTime.Now;
            Saida = null;
        }

        //Registra a entrada quando inserida
        public void RegistrarSaida()
        {
            Saida = DateTime.Now;
        }

        //Calcula o tempo que ficou no estacionamento
        public double CalcularTempo()
        {
            if (!Saida.HasValue)
            {
                throw new InvalidOperationException("A saída ainda não foi registrada para este veículo.");
            }

            return Math.Round((Saida.Value - Entrada).TotalMinutes, 2);
        }
    }
}
