namespace CorrigirValores
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "C:\\Users\\faris\\Documents\\Dados.txt"; // Substitua pelo caminho do arquivo de entrada
            string outputPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\output.txt"; // Substitua pelo caminho do arquivo de saída
            List<string> output = new List<string>();

            if (File.Exists(inputPath))
            {
                using (StreamReader reader = new StreamReader(inputPath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string formattedLine = FormatLine(line);
                        output.Add(formattedLine);
                    }
                }
            }
            else
            {
                Console.WriteLine("Arquivo de entrada não encontrado.");
                return;
            }

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (string line in output)
                {
                    writer.WriteLine(line); // Escreve cada linha formatada no arquivo de saída
                }
            }

            Console.WriteLine("Arquivo de saída gerado com sucesso em: " + outputPath);
        }

        static string FormatLine(string input)
        {
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    output += input[i];
                }
                else if (input[i] == '.')
                {
                    output += ".";
                    i++;
                    int count = 0;
                    while (i < input.Length && Char.IsDigit(input[i]))
                    {
                        output += input[i];
                        i++;
                        count++;
                        if (count == 2) break;
                    }
                    break;
                }
            }

            return output;
        }
    }
}