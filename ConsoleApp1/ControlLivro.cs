using Livraria2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria2
{
    class ControlLivro
    {
        Livro model;//Conectar com a classe livro
        private int opcao;
        public ControlLivro()
        {
            model = new Livro();
            opcao = 0;
        }//Fim do construtor
        public int ModificarOpcao
        {
            get { return opcao; }
            set { opcao = value; }
        }//Fim do ModificarOpcao
        public void Menu()
        {
            Console.WriteLine("Menu - Livro" +
                              "\nEscolha uma das opções abaixo: " +
                              "\n1. Cadastrar Livro" +
                              "\n2. Consultar Livro" +
                              "\n3. Atualizar Titulo" +
                              "\n4. Atualizar Autor" +
                              "\n5. Atualizar Editora" +
                              "\n6. Atualizar Genero" +
                              "\n7. Atualizar ISBN" +
                              "\n8. Atualizar Situação" +
                              "\n9. Atualizar Quantidade" +
                              "\n10. Atualizar Preço" +
                              "\n11. Excluir");
            ModificarOpcao = Convert.ToInt32(Console.ReadLine());
        }//Fim do Menu
        public void Operacao()
        {
            Menu();
            switch (ModificarOpcao)
            {
                case 1:
                    Console.WriteLine("Informe o codigo do Livro: ");
                    long codigo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Informe o titulo do Livro: ");
                    string titulo = Console.ReadLine();

                    Console.WriteLine("Informe o autor do Livro: ");
                    string autor = Console.ReadLine();

                    Console.WriteLine("Informe a editora do Livro: ");
                    string editora = Console.ReadLine();

                    Console.WriteLine("Informe o genêro do Livro: ");
                    string genero = Console.ReadLine();

                    Console.WriteLine("Informe o ISBN do Livro: ");
                    long ISBN = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Informe a quantidade em estoque do Livro: ");
                    int quantidade = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Informe o preço do Livro: ");
                    double preco = Convert.ToDouble(Console.ReadLine());

                    //chamar o metodo cadastrar

                    model.CadastrarLivro(codigo, titulo, autor, editora, genero, ISBN, quantidade, preco);
                    break;
                case 2:
                    Console.WriteLine("Informe o Codigo do Livro que deseja consultar: ");
                    codigo = Convert.ToInt64(Console.ReadLine());
                    //Mostrar o ConsultarLivro
                    Console.WriteLine(model.ConsultarLivro(codigo));
                    break;
                case 3:
                    Console.WriteLine("Informe o Codigo do Livro: ");
                    codigo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Insira o novo titulo do Livro: ");
                    titulo = Console.ReadLine();

                    model.AtualizarTitulo(codigo, titulo);
                    break;
                case 4:
                    Console.WriteLine("Informe o Codigo do Livro: ");
                    codigo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Insira o novo Autor do Livro: ");
                    autor = Console.ReadLine();

                    model.AtualizarAutor(codigo, autor);
                    break;
                case 5:
                    Console.WriteLine("Informe o Codigo do Livro: ");
                    codigo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Insira a nova editora do Livro: ");
                    editora = Console.ReadLine();

                    model.AtualizarEditora(codigo, editora);
                    break;
                case 6:
                    Console.WriteLine("Informe o Codigo do Livro: ");
                    codigo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Insira a nova genero do Livro: ");
                    genero = Console.ReadLine();

                    model.AtualizarGenero(codigo, genero);
                    break;
                case 7:
                    Console.WriteLine("Informe o Codigo do Livro: ");
                    codigo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Insira o novo ISBN do Livro: ");
                    ISBN = Convert.ToInt64(Console.ReadLine());

                    model.AtualizarISBN(codigo, ISBN);
                    break;
                case 8:
                    Console.WriteLine("Informe o Codigo do Livro: ");
                    codigo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Insira a nova editora do Livro: ");
                    editora = Console.ReadLine();

                    model.AtualizarEditora(codigo, editora);
                    break;
                case 9:
                    Console.WriteLine("Informe o Codigo do Livro: ");
                    codigo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Insira a nova quantidade que possui do Livro: ");
                    quantidade = Convert.ToInt32(Console.ReadLine());

                    model.AtualizarQuantidade(codigo, quantidade);
                    break;
                case 10:
                    Console.WriteLine("Informe o Codigo do Livro: ");
                    codigo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Insira o novo valor do preço do Livro: ");
                    preco = Convert.ToDouble(Console.ReadLine());

                    model.AtualizarPreco(codigo, preco);
                    break;
                case 11:
                    Console.WriteLine("Informe o Codigo do Livro: ");
                    codigo = Convert.ToInt64(Console.ReadLine());
                    //Excluir
                    model.Excluir(codigo);
                    break;
                default:
                    Console.WriteLine("Escolha uma opção válida!");
                    break;
            }//Fim do switch
        }//Fim da operacao
    }//Fim da class
}//Fim do projeto