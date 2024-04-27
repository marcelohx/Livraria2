using ConsoleApp1;
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
        DAOLivro book;
        Livro model;//Conectar com a classe livro
        private int opcao;
        public ControlLivro()
        {
            book = new DAOLivro();
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
                              "\n2. Consultar Todos os Livros" +
                              "\n3. Consultar Livros Individual" +
                              "\n4. Atualizar Titulo" +
                              "\n5. Atualizar Autor" +
                              "\n6. Atualizar Editora" +
                              "\n7. Atualizar Genero" +
                              "\n8. Atualizar ISBN" +
                              "\n9. Atualizar Situação" +
                              "\n10. Atualizar Quantidade" +
                              "\n11. Atualizar Preço" +
                              "\n12. Excluir");
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

                    book.InserirLivro(codigo, titulo, autor, editora, genero, ISBN, "ativo", quantidade, preco);
                    break;
                case 2:
                    //Mostrar o ConsultarLivro
                    Console.WriteLine(book.ConsultarTodosLivros());
                    break;
                case 3:
                    Console.WriteLine("Informe o Codigo do Livro que deseja consultar: ");
                    codigo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine(book.ConsultarLivroIndividual(codigo));
                    break;
                case 4:
                    Console.WriteLine("Informe o Codigo do Livro: ");
                    codigo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Insira o novo titulo do Livro: ");
                    titulo = Console.ReadLine();

                    Console.WriteLine(book.Atualizar(codigo, "titulo", titulo));
                    break;
                case 5:
                    Console.WriteLine("Informe o Codigo do Livro: ");
                    codigo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Insira o novo Autor do Livro: ");
                    autor = Console.ReadLine();

                    Console.WriteLine(book.Atualizar(codigo, "autor", autor));
                    break;
                case 6:
                    Console.WriteLine("Informe o Codigo do Livro: ");
                    codigo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Insira a nova editora do Livro: ");
                    editora = Console.ReadLine();

                    Console.WriteLine(book.Atualizar(codigo, "editora", editora));
                    break;
                case 7:
                    Console.WriteLine("Informe o Codigo do Livro: ");
                    codigo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Insira a nova genero do Livro: ");
                    genero = Console.ReadLine();

                    Console.WriteLine(book.Atualizar(codigo, "genero", genero));
                    break;
                case 8:
                    Console.WriteLine("Informe o Codigo do Livro: ");
                    codigo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Insira o novo ISBN do Livro: ");
                    ISBN = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine(book.Atualizar(codigo, "ISBN", ISBN));
                    break;
                case 9:
                    Console.WriteLine("Informe o Codigo do Livro: ");
                    codigo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Insira a nova quantidade que possui do Livro: ");
                    quantidade = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(book.Atualizar(codigo, "quantidade", quantidade));
                    break;
                case 10:
                    Console.WriteLine("Informe o Codigo do Livro: ");
                    codigo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Insira o novo valor do preço do Livro: ");
                    preco = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine(book.Atualizar(codigo, "preco", preco));
                    break;
                case 11:
                    Console.WriteLine("Informe o Codigo do Livro: ");
                    codigo = Convert.ToInt64(Console.ReadLine());
                    //Excluir
                    book.Excluir(codigo);
                    break;
                default:
                    Console.WriteLine("Escolha uma opção válida!");
                    break;
            }//Fim do switch
        }//Fim da operacao
    }//Fim da class
}//Fim do projeto