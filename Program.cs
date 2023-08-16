using System;
using System.IO;
namespace TextEditor
{
    class Program
    {
        static void Main(string[]
        args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir Arquivo");
            Console.WriteLine("2 - Criar Novo Arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }

        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");
            string path = Console.ReadLine();
            //sempre que a gente vai ler ou salvar o arquivo chamamos o using
            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd(); //vai ler o arquivo até o final
                Console.WriteLine(text); //exibir o arquivo na tela
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu(); //voltar para o menu para que o usuário não se perca

        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("-------------------"); //armazenar incluindo os enters e depois salvar no arquivo de texto 
                                                      //ler o que digita e depois sair (para execução)
            string text = "";
            //sempre armazenas algo antes de executar o while, usa-se o do
            //do é -fazer algo até que- ou seja: faça isso (do) até que o usuário não tecle esc (while)
            do
            {
                //tudo que já tem no texto + o que o usuário digitou de novo (+=)
                text += Environment.NewLine; //quebrando linha no fim de cada leitura
            }

            while (Console.ReadKey().Key != ConsoleKey.Escape); //se a tecla for diferente de ConsoleKey.Escape (ESC) vai continuar no laço de repetição que é igual pensar: enquanto o usuário não pressionar esc, ele não sai da estrutura de repetição
                                                                //Console.Read - read somente não é infinito. 
            Salvar(text);                                                   //quebra de linha em arquivos texto fica 'por baixo dos panos'
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho para salvar o arquivo");
            var path = Console.ReadLine(); //path é caminho - o que o usuário colocar vai ser usado
                                           //toda vez que trabalhamos com arquivos, devemos abrir e fechar o arquivo. SEMPRE lembrar de que quando abre um arquivo, tem que fechar ele

            using (var file = new StreamWriter(path)) //garante que vai abrir e fechar streamwriter (é um fluxo de bytes/escrita, qualquer arquivo)
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");

            Console.ReadLine();

            Menu();
        }
    }
}

//Ao executar o dotnet run:
//O que você deseja fazer?
//1 - Abrir Arquivo
//2 - Criar Novo Arquivo
//0 - Sair

//**Digitar opção 1
//**Qual o caminho do arquivo?
//C:\dev\teste.txt
//Olá, sou Sara
//Se dar Enter, volta pro Menu incial

//**Digitar opção 2 (Criar Novo Arquivo)
//Digite seu texto abaixo (ESC para sair)
//-------------------
//**Digitar texto
//**Pressionar ESC para salvar
//Qual o caminho para salvar o arquivo
//**Colocar o caminho 'C:\pasta\nomedoarquivo.txt'
//C:\dev\testezinho.txt (exemplo)
//Arquivo C:\dev\testezinho.txt salvo com sucesso!
//**Ir até a pasta e abrir o arquivo de texto.