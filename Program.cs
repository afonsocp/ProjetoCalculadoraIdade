using System;

namespace CalculadoraIdade
{
    struct Pessoa
    {
        public string NomeCompleto;
        public DateTime DataNascimento;
        public int CalcularIdade()
        {
            var hoje = DateTime.Now;
            var idade = hoje.Year - DataNascimento.Year;
            if (DataNascimento > hoje.AddYears(-idade))
                idade--;
            return idade;
        }
        public bool PodeTirarCNH()
        {
            return CalcularIdade() >= 18;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo à Calculadora de Idade!\n");
            Console.WriteLine("Desenvolvido por:\n");
            Console.WriteLine("• Afonso Correia Pereira (RM: 557863)");
            Console.WriteLine("• Adel Mouhaidly (RM: 557705)");
            Console.WriteLine("• Felipe Horta Gresele (RM: 556955)");
            Console.WriteLine("• Tiago Augusto Desiderato (RM: 558485)");
            Console.WriteLine("• Arthur (RM: 550615)");
            Console.WriteLine("• João Henrique (RM: 556221)\n");
            Console.WriteLine("Vamos descobrir sua idade?\n");

            var pessoa = new Pessoa();

            Console.Write("Por favor, digite seu nome completo: ");
            pessoa.NomeCompleto = Console.ReadLine();

            Console.Write("Digite sua data de nascimento (dd/MM/yyyy): ");
            DateTime dataNascimento;
            while (!DateTime.TryParse(Console.ReadLine(), out dataNascimento))
            {
                Console.WriteLine("\nFormato de data incorreto! Vamos tentar novamente?");
                Console.Write("Digite sua data de nascimento (exemplo: 01/01/2000): ");
            }

            if (dataNascimento > DateTime.Now)
            {
                Console.WriteLine("\nData inválida! A data de nascimento não pode ser no futuro.");
                Console.WriteLine("Por favor, digite uma data de nascimento válida.");
                return;
            }

            pessoa.DataNascimento = dataNascimento;
            int idade = pessoa.CalcularIdade();

            Console.WriteLine("\nResultado\n");
            Console.WriteLine($"Nome: {pessoa.NomeCompleto}");
            Console.WriteLine($"Data de Nascimento: {dataNascimento:dd/MM/yyyy}");
            Console.WriteLine($"Idade: {idade} anos");

            if (pessoa.PodeTirarCNH())
            {
                Console.WriteLine("\nParabéns! Você já pode tirar sua carteira de habilitação!");
                Console.WriteLine("Dirija com responsabilidade e aproveite essa nova fase!");
            }
            else
            {
                int anosRestantes = 18 - idade;
                Console.WriteLine($"\nFaltam {anosRestantes} {(anosRestantes == 1 ? "ano" : "anos")} para você poder tirar sua carteira!");
                Console.WriteLine("Continue se preparando para esse momento especial!");
            }
            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}