using System;
using System.IO;

namespace matriz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            string[,] matrizNome = new string[2, 3];

            while (opcao != 7)
            {
                Console.WriteLine("1-Ler os nomes da Matriz");
                Console.WriteLine("2-Imprimir os nomes de forma completa");
                Console.WriteLine("3-Imprimir os nomes de uma determinada linha");
                Console.WriteLine("4-Imprimir os nomes de uuma determinada coluna");
                Console.WriteLine("5-Procurar um nome");
                Console.WriteLine("6-Ordenar os nomes dentro de cada linha");
                Console.WriteLine("7-Gravar dados de um arquivo");
                Console.WriteLine("8-Ler dados de um arquivo");
                Console.WriteLine("9-Sair");
                opcao = int.Parse(Console.ReadLine());

                if (opcao == 1)
                {
                    for (int linha = 0; linha < matrizNome.GetLength(0); linha++)
                    {
                        for (int coluna = 0; coluna < matrizNome.GetLength(1); coluna++)
                        {
                            Console.WriteLine("Digite um nome:");
                            matrizNome[linha, coluna] = Console.ReadLine();
                            Console.WriteLine($"Matriz [{linha}, {coluna}] = {matrizNome[linha, coluna]}");
                        }
                    }
                }
                else if (opcao == 2)
                {
                    for (int linha = 0; linha < matrizNome.GetLength(0); linha++)
                    {
                        for (int coluna = 0; coluna < matrizNome.GetLength(1); coluna++)
                        {
                            Console.WriteLine($"Matriz [{linha}, {coluna}] = {matrizNome[linha, coluna]}");
                        }
                    }
                }
                else if (opcao == 3)
                {
                    Console.Write("Digite a linha que deseja imprimir (1, 2 ou 3): ");
                    int linha = int.Parse(Console.ReadLine()) - 1;

                    if (linha < matrizNome.GetLength(0))
                    {
                        Console.WriteLine($"Exibindo a linha {linha + 1}");

                        for (int coluna = 0; coluna < matrizNome.GetLength(1); coluna++)
                        {
                            Console.WriteLine($"{matrizNome[linha, coluna]}");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Linha não encontrada");
                    }

                }
                else if (opcao == 4)
                {
                    Console.Write("Digite a coluna que deseja imprimir (1, 2 ou 3): ");
                    int c = int.Parse(Console.ReadLine());
                    bool entrou = false;
                    for (int coluna = 0; coluna < matrizNome.GetLength(1); coluna++)
                    {
                        if (c - 1 == coluna)
                        {
                            Console.WriteLine($"Exibindo a coluna {c}");
                            entrou = true;
                            for (int linha = 0; linha < matrizNome.GetLength(0); linha++)
                            {
                                Console.WriteLine($"{matrizNome[linha, coluna]}");
                            }
                        }
                    }
                    if (!entrou)
                    {
                        Console.WriteLine("Linha não encontrada");
                    }
                }
                else if (opcao == 5)
                {
                    Console.WriteLine("digite o nome que deseja encontrar: ");
                    string nome = Console.ReadLine();
                    bool entrou = false;
                    for (int linha = 0; linha < matrizNome.GetLength(0); linha++)
                    {
                        for (int coluna = 0; coluna < matrizNome.GetLength(1); coluna++)
                        {
                            if (nome == matrizNome[linha, coluna])
                            {
                                Console.WriteLine($"Matriz [{linha}, {coluna}] = {nome}");
                                entrou = true;
                            }
                        }
                    }
                    if (!entrou)
                    {
                        Console.WriteLine("Nome não encontrado na matriz");
                    }
                }
                else if (opcao == 6)
                {
                    Console.Write("Digite a linha que deseja ordenar (1, 2 ou 3): ");
                    int linha = int.Parse(Console.ReadLine()) - 1;

                    if (linha < matrizNome.GetLength(0))
                    {

                        for (int coluna = 0; coluna < matrizNome.GetLength(1); coluna++)
                        {
                            Console.WriteLine($"{matrizNome[linha, coluna]}");
                        }
                    }
                }
                else if (opcao == 7)
                {
                    try
                    {
                        StreamWriter sw = new StreamWriter("C:\\5by5\\matrizNome.txt");
                        for (int linha = 0; linha < matrizNome.GetLength(0); linha++)
                        {
                            for (int coluna = 0; coluna < matrizNome.GetLength(1); coluna++)
                            {
                                sw.WriteLine(matrizNome[linha, coluna]);
                            }
                        }
                        sw.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                        Console.ReadLine();
                    }
                    finally
                    {
                        Console.WriteLine("Arquivo gravado com sucesso");
                        Console.ReadLine();
                    }
                }
                else if (opcao == 8)
                {
                    string line;
                    try
                    {
                        StreamReader sr = new StreamReader("C:\\5by5\\matrizNome.txt");
                        line = sr.ReadLine();
                        while (line != null)
                        {
                            for (int linha = 0; linha < matrizNome.GetLength(0); linha++)
                            {
                                for (int coluna = 0; coluna < matrizNome.GetLength(1); coluna++)
                                {
                                    matrizNome[linha, coluna] = line;
                                    line = sr.ReadLine();
                                }
                            }
                        }
                        sr.Close();
                    }
                    catch (Exception e)
                    {
                        Console.Write("Exception: " + e.Message);
                        Console.ReadLine();
                    }
                    finally
                    {
                        Console.WriteLine("Leitura do Arquivo realizada com sucesso");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
