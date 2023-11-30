using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static List<char> GerarCaracteres()
    {
        List<char> chars = new List<char>();
        for (int i = 97; i <= 122; i++)
        {
            chars.Add((char)i);
        }
        for (int i = 65; i <= 90; i++)
        {
            chars.Add((char)i);
        }
        for (int i = 48; i <= 57; i++)
        {
            chars.Add((char)i);
        }

        return chars;
    }
    static string Forcabruta(List<char> chars, string senha, int lenSenha)
    {
        int tentativa = 0;
        foreach (var comb in Product(chars, lenSenha))
        {

            string combina = new string(comb.ToArray());
            tentativa++;
            if (tentativa % 500000 == 0)
            {
                Console.WriteLine($"{tentativa,10} --> {combina}");
            }
            if (senha == combina)
            {
                return $"Senha encontrada é \"{combina}\", após {tentativa} tentativas.";
            }

        }
        return "senha não encontrada";


    }


    static IEnumerable<List<T>> Product<T>(List<T> list, int repeat)
    {
        if (repeat == 1)
        {
            foreach (var item in list)
            {
                yield return new List<T> { item };

            }


        }
        else
        {
            foreach (var item in list)
            {
                foreach (var rest in Product(list, repeat - 1))
                {
                    rest.Insert(0, item);
                    yield return rest;
                }
            }


        }

    }
    static void ForcaBrutaRecursiva(List<char> chars, string senha, int lenSenha, string combAnterios = ""){
        int tentativa = 0;
        foreach (char letra in chars)
        {
            string combina = combAnterios + letra;
            tentativa++;


            if (tentativa % 500000 == 0)
            {
                Console.WriteLine($"{tentativa,10} --> {combina}");
            }
            if (senha == combina)
            {
                Console.WriteLine($"Senha encontrada é \"{combina}\", após {tentativa} tentativas.");
                return;
            }
            if(lenSenha != 1)
            {
                ForcaBrutaRecursiva(chars, senha, lenSenha - 1, combina);
            }
        }
    }

    static void Main()
    {
        List<char> chars = GerarCaracteres();
        string senha = "gato"; // <- Coloque a senha que deseja que o softere quebre aqui
        Console.WriteLine((Forcabruta(chars, senha, 4)));
        Console.WriteLine("*******************************");
        ForcaBrutaRecursiva(chars, senha, senha.Length);
        Console.WriteLine("*******************************");
        ForcaBrutaRecursiva(chars, "cabo", 4);
        Console.WriteLine("*******************************");
        ForcaBrutaRecursiva(chars, "cabo", 5);
    }


}
