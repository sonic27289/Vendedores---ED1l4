using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ED1l4
{
    class classVendendor
    {
        private int ID;
        private string nome;
        private double percComissao;
        private classVenda[] asVendas;

        public int ID1 { get => ID; set => ID = value; }
        public string Nome { get => nome; set => nome = value; }
        public double PercComissao { get => percComissao; set => percComissao = value; }
        public classVenda[] AsVendas { get => asVendas; }

        public classVendendor(int ID, string nome, double percComissao)
        {
            this.ID = ID;
            this.nome = nome;
            this.percComissao = percComissao;
            this.asVendas = new classVenda[31];
            for (int i = 0; i < 31; ++i)
            {
                this.asVendas[i] = new classVenda();
            }
        }
        public classVendendor() : this(0, " ", 0.00)
        { }


        public void registrarVenda(int dia, classVenda venda)
        {
            this.asVendas[dia - 1] = venda;
        }
        public double valorVendas()
        {
            double totVendas = 0;
            foreach (classVenda v in this.asVendas)
                totVendas += v.Valor;
            return totVendas;
        }
        public double valorComissao()
        {
            return this.valorVendas() * (this.percComissao / 100);
        }
        public override bool Equals(object obj)
        {
            return this.ID.Equals(((classVendendor)obj).ID);
        }

    }
}
