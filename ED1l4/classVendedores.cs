using System;
using System.Collections.Generic;
using System.Text;

namespace ED1l4
{
    class classVendedores
    {
        private classVendendor[] osVendedores;
        private int max;
        private int quantidade;

        public int Max { get => max; }
        public int Quantidade { get => quantidade; }
        internal classVendendor[] OsVendedores { get => osVendedores; }

        public classVendedores()
        {
            this.max = 10;
            this.quantidade = 0;
            this.osVendedores = new classVendendor[this.max];
            for(int i = 0; i < this.max; i++)
            {
                this.osVendedores[i] = new classVendendor();
            }
        }


        public double valorVendas()
        {
            double totalVendas = 0;
            foreach (classVendendor v in this.osVendedores)
                totalVendas += v.valorVendas();
            return totalVendas;
        }

        public double valorComissao()
        {
            double totalComissoes = 0;
            foreach (classVendendor v in this.osVendedores)
                totalComissoes += v.valorComissao();
            return totalComissoes;
        }

        public bool addVendedor(classVendendor vendedor)
        {
            bool podeAdd = (this.quantidade < this.max);
            if (podeAdd)
            {
                this.osVendedores[this.quantidade] = vendedor;
                this.quantidade++;
            }
            return podeAdd;
        }

        public bool delVendedor(classVendendor v)
        {
            bool vendedorDeletado = false;
            int i = 0;

            foreach(classVendendor vendedor in osVendedores)
            {
                if(vendedorDeletado)
                {
                    if (!osVendedores[i].Equals(osVendedores[i - 1]))
                    {
                        classVendendor aux = osVendedores[i - 1];
                        osVendedores[i - 1] = osVendedores[i];
                        osVendedores[i] = aux;
                    }
                }
                if(vendedor.Equals(v) && vendedor.valorVendas() == 0)
                {
                    vendedor.ID1 = -1;
                    vendedor.Nome = " ";
                    vendedor.PercComissao = 0;
                    vendedorDeletado = true;
                    quantidade--;
                }
                i++;
            }
            return vendedorDeletado;
        }

        public classVendendor procurarVendedor(classVendendor v)
        {
            classVendendor vendedorAchado = new classVendendor();
            int i = 0;
            while(i < max && !osVendedores[i].Equals(v))
            {
                i++;
            }
            if(i < max)
            {
                vendedorAchado = osVendedores[i];
            }
            return vendedorAchado;
        }

        public override string ToString()
        {
            string dados = " ";
            foreach (classVendendor v in this.osVendedores)
                dados += v.ToString();
            dados += "---------------------";
            return dados;
        }
    }
}
