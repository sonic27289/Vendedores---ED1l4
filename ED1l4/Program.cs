using System;

namespace ED1l4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sair = false;
            int opcao;

            classVendedores vendedores = new classVendedores();

            while(!sair)
            {
                Console.WriteLine("\n0 - Sair \n1 - Cadastrar vendedor \n2 - Consultar vendedor \n3 - Excluir vendedor \n4 - Registrar venda \n5 - Listar vendedores");
                opcao = int.Parse(Console.ReadLine());

                switch(opcao)
                {
                    case 0:
                        sair = true;
                        break;
                    case 1:
                        cadastrarVendedor(vendedores);
                        break;
                    case 2:
                        consultarVendedor(vendedores);
                        break;
                    case 3:
                        excluirVendedor(vendedores);
                        break;
                    case 4:
                        registrarVenda(vendedores);
                        break;
                    case 5:
                        listarVendedores(vendedores);
                        break;
                    default:
                        Console.WriteLine("Digite uma opção válida !");
                        break;
                }
            }

            void cadastrarVendedor(classVendedores vendedores)
            {
                Console.WriteLine("\nID do vendedor: ");
                int ID = int.Parse(Console.ReadLine());

                Console.WriteLine("Nome do vendedor: ");
                string nome = Console.ReadLine();

                Console.WriteLine("Percentual de comissão do vendedor (0-100)%: ");
                double percComissao = double.Parse(Console.ReadLine());

                Console.WriteLine(vendedores.addVendedor(new classVendendor(ID, nome, percComissao)) ? "Vendedor Adicionado !" : "Não foi possível adicionar o Vendedor, limite de vendedores atingido.");
            }

            void consultarVendedor(classVendedores vendedores)
            {
                Console.WriteLine("\nDigite o ID do vendedor para fazer a busca: ");
                int ID = int.Parse(Console.ReadLine());

                classVendendor vAchado = vendedores.procurarVendedor(new classVendendor(ID, "", 0));

                if (vAchado.ID1 == -1)
                {
                    Console.WriteLine("O Vendedor não foi achado ! ");
                    return;
                }

                Console.WriteLine($"\nID: {vAchado.ID1} \nNome: {vAchado.Nome} \nValor total das vendas: R$ {vAchado.valorVendas()} \nValor da comissão: R$ {vAchado.valorComissao()}");
                Console.WriteLine("Valor médio das vendas diárias: ");
                int dia = 1;
                foreach (classVenda venda in vAchado.AsVendas)
                {
                    if (venda.Valor > 0)
                    {
                        Console.WriteLine($"{dia}° dia: {venda.valorMedio()}");
                    }
                    dia++;
                }
            }

            void excluirVendedor(classVendedores vendedores)
            {
                Console.WriteLine("\nDigite o ID do vendedor para ser deletado: ");
                int ID = int.Parse(Console.ReadLine());

                Console.WriteLine(vendedores.delVendedor(new classVendendor(ID, "", 0)) ? "Vendedor deletado !" : "Não foi possível excluir o vendedor. ");
            }

            void registrarVenda(classVendedores vendedores)
            {
                int dia;

                Console.WriteLine("\nDigite o ID do vendedor: ");
                int ID = int.Parse(Console.ReadLine());
                do
                {
                    Console.WriteLine("Digite o dia (1-31): ");
                    dia = int.Parse(Console.ReadLine());
                } while (dia < 1 || dia > 31);

                Console.WriteLine("Digite a quantidade de vendas: ");
                int quantidade = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o valor de venda do dia: ");
                double valor = double.Parse(Console.ReadLine());

                classVendendor v = vendedores.procurarVendedor(new classVendendor(ID, "", 0));
                if (v.ID1 == -1)
                {
                    Console.WriteLine("Vendedor não encontrado !");
                    return;
                }

                v.registrarVenda(dia, new classVenda(quantidade, valor));
                Console.WriteLine("Venda registrada com sucesso.");
            }

            void listarVendedores(classVendedores vendedores)
            {
                foreach (classVendendor v in vendedores.OsVendedores)
                {
                    if (v.ID1 != -1)
                    {
                        Console.WriteLine($"\nID: {v.ID1} \nNome: {v.Nome} \nValor total das vendas: R$ {v.valorVendas()} \nValor da comissão: R$ {v.valorComissao()}");
                    }
                }

                Console.WriteLine($"\nValor total das vendas de todos os vendedores: {vendedores.valorVendas()}");
                Console.WriteLine($"Valor total das comissões de todos os vendedores: {vendedores.valorComissao()}");
            }
        }
    }
}
