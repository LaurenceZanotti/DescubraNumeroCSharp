namespace DescubraNumero
{
    class Program
    {
        static void Main(string[] args)
        {
            // Mostrar informações do app
            getAppInfo();

            // Obter o nome do jogador
            Console.WriteLine("Qual o seu nome?");
            string name = Console.ReadLine();
            
            // Iniciar jogo
            Console.WriteLine("Oi {0}, vamos jogar um jogo? Tente descobrir qual é o número de 0 a 10.", name);

            // Obter número aleatório para adivinhar
            Random random = new Random();
            int number = random.Next(0, 10);
            int guess = -1;

            while (true)
            {
                // Obter tentativa de número do jogador
                Console.WriteLine("Digite o número: ");
                string inputGuess = Console.ReadLine();

                // Verificar se é realmente um número
                if (!int.TryParse(inputGuess, out guess))
                {
                    // Se não for, pedir para usar apenas números
                    PrintColoredMessage(ConsoleColor.Red, "Por favor use um número");
                    continue;
                }

                // Converter string para int
                guess = Int32.Parse(inputGuess);

                if (guess > number)
                {
                    PrintColoredMessage(ConsoleColor.Yellow, "Tente um número menor");
                } 
                else if (guess < number)
                {
                    PrintColoredMessage(ConsoleColor.Yellow, "Tente um número maior");
                } 
                // Caso valor não seja menor e nem maior, então o jogador descobriu o número e venceu o jogo
                else
                {
                    PrintColoredMessage(ConsoleColor.Green, "PARABÊNS!!! " + guess + " está correto!");

                    PrintColoredMessage(ConsoleColor.Yellow, "Quer jogar novamente? [Y ou N]");
                    string playAgain = Console.ReadLine().ToUpper();

                    // Verificar se jogador quer tentar novamente
                    if (playAgain == "Y")
                    {
                        // Obter novo número aleatório para o próximo jogo
                        number = random.Next(0, 10);
                        continue;
                    }
                    else if (playAgain == "N")
                    {
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        // Mostrar informações do app (cabeçalho)
        static void getAppInfo()
        {
            string appName = "Descubra o Número";
            string appVersion = "1.0.0";
            string appAuthor = "Laurence Zanotti";

            // Console.ForegroundColor = ConsoleColor.Blue;
            // Console.WriteLine("{0} versão {1} feito por {2}", appName, appVersion, appAuthor);
            // Console.ResetColor();

            PrintColoredMessage(ConsoleColor.Blue, appName + " versão " + appVersion + " feito por " + appAuthor);
        }

        static void PrintColoredMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}