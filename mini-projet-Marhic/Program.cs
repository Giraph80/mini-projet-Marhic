using System;
using System.Xml.Linq;

class miniProjetMarhic
{
    public static void push(List<string>pile, string valeur)
    {
        pile.Add(valeur);
    }

    public static string top(List<string> pile)
    {
        return pile[pile.Count()-1];
    }

    public static string pop(List<string> pile)
    {
        string val = top(pile);
        pile.RemoveAt(pile.Count() - 1);
        return val;
    }

    public static List<string> getCalcul()
    { 
        List<string> expression = new List<string>();

     
            Console.WriteLine("Entrez le calcul : \n");
           string calcul = Console.ReadLine();


        List<String> list = calcul.Split(' ').ToList();

        for(int i = 0; i < list.Count; i++)
        {
            push(expression, list[i]);
        }

        //foreach(char element in calcul)
        //{
        //    Console.WriteLine(element);
        //}
        return expression;
    }

    public static int Calcul(List<string> expression)
    {
        List<string> pile = new List<string>();
        int somme = 0;
        foreach(string element in expression)
        {
            //if(element == '+')
            switch (element)
            {
                case "+":
                    int premiereValeur = Convert.ToInt32(pop(pile));
                    Console.WriteLine("Premiere valeur :" + premiereValeur);
                    int deuxiemeValeur = Convert.ToInt32(pop(pile));
                    Console.WriteLine("deuxieme valeur :" + deuxiemeValeur);
                    somme += premiereValeur + deuxiemeValeur;

                    break;
                case "-":
                    
                    break;
                case "/":
                    
                    break;
                case "*":
                    
                    break;
                default:
                    push(pile, element);
                    break;


            }
        }
        return somme;
    }

    static void Main()
    {
        int somme = Calcul(getCalcul());
        Console.WriteLine(somme);
    }


}



