using System;
using System.Collections.Generic;
using System.Text;

namespace ED1l4
{
    class classVenda
    {
        private int quantidade;
        private double valor;

        public double Valor { get => valor; set => valor = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }

        public classVenda(int quantidade, double valor)
        {
            this.quantidade = quantidade;
            this.valor = valor;
        }
        public classVenda()
            : this(0, 0.00)
        {
        }
        
        public double valorMedio()
        {
            return valor / quantidade;
        }

    }
}
