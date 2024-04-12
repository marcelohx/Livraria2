using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria2
{
    class Pessoa
    {
        //Encapsulamento = Deixar as variaveis privadas
        private long CPF;
        private string nome;
        private string endereco;
        private string telefone;
        private DateTime dtNascimento;
        private string login;
        private string senha;
        private string situacao;//Ativo ou inativo
        private string posicao;//Atendente ou Administrador ou Cliente

        //Método construtor = para instanciar as variaveis
        public Pessoa()
        {
            ModificarCPF = 0;
            ModificarNome = "";
            ModificarEndereco = "";
            ModificarTelefone = "";
            ModificarDtNascimento = new DateTime();//"00/00/0000 00:00:00"
            ModificarLogin = "";
            ModificarSenha = "";
            ModificarSituacao = "";
            ModificarPosicao = "";
        }//Fim do construtor

        //Método modificador = Gets e Sets (Para modificar as variaveis com segurança)
        public long ModificarCPF
        {
            get { return this.CPF; }
            set { this.CPF = value; }
        }//fim do modificador

        public string ModificarNome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public string ModificarEndereco
        {
            get { return this.endereco; }
            set { this.endereco = value; }
        }

        public string ModificarTelefone
        {
            get { return this.telefone; }
            set { this.telefone = value; }
        }

        public DateTime ModificarDtNascimento
        {
            get { return this.dtNascimento; }
            set { this.dtNascimento = value; }
        }
        public string ModificarLogin
        {
            get { return this.login; }
            set { this.login = value; }
        }

        public string ModificarSenha
        {
            get { return this.senha; }
            set { this.senha = value; }
        }

        public string ModificarSituacao
        {
            get { return this.situacao; }
            set { this.situacao = value; }
        }

        public string ModificarPosicao
        {
            get { return this.posicao; }
            set { this.posicao = value; }
        }

        //Metodo - CRUD
        public void Cadastrar(long CPF, string nome, string telefone, string endereco, DateTime dtNascimento, string login, string senha, string posicao)
        {
            ModificarCPF = CPF;
            ModificarNome = nome;
            ModificarTelefone = telefone;
            ModificarEndereco = endereco;
            ModificarDtNascimento = dtNascimento;
            ModificarLogin = login;
            ModificarSenha = senha;
            ModificarSituacao = "Ativo";
            ModificarPosicao = posicao;
        }//fim do metodo
        public string ConsultarIndividual(long CPF)
        {
            string consulta = "";
            if (ModificarCPF == CPF)
            {
                consulta = "\nNome: " + ModificarNome +
                           "\nTelefone: " + ModificarTelefone +
                           "\nEndereço: " + ModificarEndereco +
                           "\nData de Nascimento: " + ModificarDtNascimento +
                           "\nLogin: " + ModificarLogin +
                           "\nSenha: " + ModificarSenha +
                           "\nSituação: " + ModificarSituacao +
                           "\nPosição: " + ModificarPosicao;
            }
            else
            {
                consulta = "Número de CPF não é válido!";
            }
            return consulta;
        }//fim do metodo

        public void AtualizarNome(long CPF, string Nome)
        {
            if (ModificarCPF == CPF)
            {
                ModificarNome = Nome;
            }
        }//fim do metodo

        public void AtualizarTelefone(long CPF, string telefone)
        {
            if (ModificarCPF == CPF)
            {
                ModificarTelefone = telefone;
            }
        }//fim do metodo

        public void AtualizarEndereco(long CPF, string endereco)
        {
            if (ModificarCPF == CPF)
            {
                ModificarEndereco = endereco;
            }
        }//fim do metodo

        public void AtualizarDtNascimento(long CPF, DateTime dtNascimento)
        {
            if (ModificarCPF == CPF)
            {
                ModificarDtNascimento = dtNascimento;
            }
        }//fim do metodo

        public void AtualizarSenha(long CPF, string senha)
        {
            if (ModificarCPF == CPF)
            {
                ModificarSenha = senha;
            }
        }//fim do metodo

        public void AtualizarSituacao(long CPF, string Situacao)
        {
            if (ModificarCPF == CPF)
            {
                ModificarSituacao = Situacao;
            }
        }//fim do metodo

        public void AtualizarPosicao(long CPF, string Posicao)
        {
            if (ModificarCPF == CPF)
            {
                ModificarPosicao = Posicao;
            }
        }//fim do metodo

        public void Excluir(long CPF)
        {
            if (ModificarCPF == CPF)
            {
                ModificarSituacao = "Inativo";
            }
        }//fim do metodo


    }//fim da classe
}//fim do projeto
