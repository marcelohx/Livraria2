using ConsoleApp1;
using Livraria2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria2
{
    class ControlPessoa
    {
        DAOPessoa person;
        Pessoa model;//Conectar com a classe pessoa
        private int opcao;
        public ControlPessoa()
        {
            person = new DAOPessoa();
            model = new Pessoa();//Acesso todos os metodos da classe pessoa
            opcao = 0;
        }//Fim do construtor

        public int ModificarOpcao
        {
            get { return opcao; }
            set { opcao = value; }
        }//Fim do ModificarOpcao

        public void Menu()
        {
            Console.WriteLine("Menu - Pessoa" +
                              "\nEscolha uma das opções abaixo: " +
                              "\n1. Cadastrar Pessoa" +
                              "\n2. Consultar Pessoa" +
                              "\n3. Atualizar Nome" +
                              "\n4. Atualizar Telefone" +
                              "\n5. Atualizar Endereço" +
                              "\n6. Atualizar Data de Nascimento" +
                              "\n7. Atualizar Senha" +
                              "\n8. Atualizar Situação" +
                              "\n9. Excluir");
            ModificarOpcao = Convert.ToInt32(Console.ReadLine());
        }//Fim do menu

        public void Operacao()
        {
            Menu();//Mostrar o menu
            switch (ModificarOpcao)
            {
                case 1:
                    Console.WriteLine("Informe o CPF: ");
                    long CPF = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Informe seu nome: ");
                    string nome = Console.ReadLine();

                    Console.WriteLine("Informe seu Telefone: ");
                    string telefone = Console.ReadLine();

                    Console.WriteLine("Infome seu Endereço: ");
                    string endereco = Console.ReadLine();

                    Console.WriteLine("Informe sua data de nascimento: ");
                    DateTime data = Convert.ToDateTime(Console.ReadLine());

                    Console.WriteLine("Informe o seu login: ");
                    string login = Console.ReadLine();

                    Console.WriteLine("Informe a sua senha: ");
                    string senha = Console.ReadLine();

                    Console.WriteLine("Informe seu cargo: ");
                    string cargo = Console.ReadLine();

                    //Chamar o método cadastrar

                    person.Inserir(CPF, nome, telefone, endereco, data, login, senha, "Ativo", cargo);
                    break;
                case 2:
                    Console.WriteLine("Informe o CPF que deseja consultar: ");
                    CPF = Convert.ToInt64(Console.ReadLine());

                    //Mostrar os dados
                    Console.WriteLine(model.ConsultarIndividual(CPF));
                    break;
                case 3:
                    Console.WriteLine("Informe o CPF: ");
                    CPF = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Informe o novo nome: ");
                    nome = Console.ReadLine();

                    //Atualizar
                    model.AtualizarNome(CPF, nome);
                    break;
                case 4:
                    Console.WriteLine("Informe o CPF: ");
                    CPF = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Informe o novo telefone: ");
                    telefone = Console.ReadLine();

                    //Atualizar
                    model.AtualizarTelefone(CPF, telefone);
                    break;
                case 5:
                    Console.WriteLine("Informe o CPF: ");
                    CPF = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Informe o novo endereço: ");
                    endereco = Console.ReadLine();

                    //Atualizar
                    model.AtualizarEndereco(CPF, endereco);
                    break;
                case 6:
                    Console.WriteLine("Informe o CPF: ");
                    CPF = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Informe a nova data de nascimento: ");
                    data = Convert.ToDateTime(Console.ReadLine());

                    //Atualizar
                    model.AtualizarDtNascimento(CPF, data);
                    break;
                case 7:
                    Console.WriteLine("Informe o CPF: ");
                    CPF = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Informe a nova senha: ");
                    senha = Console.ReadLine();

                    //Atualizar
                    model.AtualizarSenha(CPF, senha);
                    break;
                case 8:
                    Console.WriteLine("Informe o CPF: ");
                    CPF = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Informe o cargo: ");
                    cargo = Console.ReadLine();

                    //Atualizar
                    model.AtualizarPosicao(CPF, cargo);
                    break;
                case 9:
                    Console.WriteLine("Informe o CPF: ");
                    CPF = Convert.ToInt64(Console.ReadLine());

                    //Excluir
                    model.Excluir(CPF);
                    break;
                default:
                    Console.WriteLine("Escolha uma opção válida!");
                    break;
            }//Fim do switch
        }//Fim da Operacao

    }//Fim da classe
}//fim do projeto
