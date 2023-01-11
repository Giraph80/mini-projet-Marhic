using System;
using System.Diagnostics;
using System.Xml.Linq;

class miniProjetMarhic
{
    /// <summary>
    /// ajoute un string à une liste, en suivant le principe d'une pile.
    /// </summary>
    /// <param name="pile">Liste de string, représentant une pile.</param>
    /// <param name="valeur">valeur à ajouter dans la pile.</param>
    public static void Push(ref string pile, string valeur)
    {
        if (pile == null)
        {
            throw new ArgumentNullException("l'élément est nul.");
        }
        if (valeur == null)
        {
            throw new ArgumentNullException("la pile est nulle.");
        }
        pile+=valeur;
    }

    /// <summary>
    /// récupère l'élèment au dessus de la pile.
    /// </summary>
    /// <param name="pile">Liste de string, représentant une pile.</param>
    /// <returns>retourne la dernière valeur de la liste.</returns>
    public static string Top(string pile)
    {
        if (pile == "")
        {
            throw new ArgumentNullException("La pille est nulle.");
        }
        
        return pile[pile.Length-1].ToString();

    }

    /// <summary>
    /// Enlève le dernier élément et le renvoie.
    /// </summary>
    /// <param name="pile">La liste de string, représentant une pile.</param>
    /// <returns>retourne la valeur supprimée.</returns>
    public static string Pop(ref string pile)
    {
        string dernierElement = Top(pile);
        string pileConcatenee = "";
        if (pile == "")
        {
            throw new ArgumentNullException("La pile est nulle.");
        }
        
        for (int i = 0;i<=pile.Length-2;i++)
        {//Suppression du dernier élément de la liste.
            pileConcatenee+= pile[i].ToString();
        }
        pile = pileConcatenee;
        return dernierElement;
    }

    static string Split(string expressionNonFormatee)
    {
        string expression = "";
        foreach (char element in expressionNonFormatee)
        {
            if (element != ' ')
            {
                expression += element;
            }
        }
        return expression;
    }

    /// <summary>
    /// Récupère le calcul de l'utilisateur (input)
    /// </summary>
    /// <returns>retourne l'expression entrée.</returns>
    public static string getCalcul()
    { 
        string expression = ""; //Déclaration d'une nouvelle liste qui contiendra l'expression
        Console.WriteLine("Entrez le calcul : \n");
        string calcul = Console.ReadLine(); //Entrée utilisateur.
        if (calcul == null)
        {
            throw new ArgumentNullException("le calcul entré est nul");
        }
        
        expression += Split(calcul); //Enlève les espaces de l'expression.
        //for(int i = 0; i < calcul.Length-1; i++) //parcours l'expression.
        //{
        //    push(expression, calcul[i]);// ajout de chaque élément de l'expression à une 
        //}
        return expression;
    }

    /// <summary>
    /// affecte les valeurs de l'expression à partir de la pile.
    /// </summary>
    /// <param name="premiereValeur">premiere valeur de l'expression</param>
    /// <param name="deuxiemeValeur">deuxieme valeur de l'expression</param>
    /// <param name="pile">pile contenant les nombres de l'expression</param>
    /// <exception cref="Exception"></exception>
    public static void affectationEtVerification(ref float premiereValeur, ref float deuxiemeValeur,ref string pile)
    {
        deuxiemeValeur = float.Parse(Pop(ref pile));//la valeur en haut de la pile devient la deuxième valeur de l'opération
        premiereValeur = float.Parse(Pop(ref pile));
        if (premiereValeur < 0 || deuxiemeValeur < 0)//vérifie qu'aucune valeur n'est négative
        { 
            throw new Exception("Erreur : Valeurs négatives interdites.");
        }
    }

    /// <summary>
    /// Effectue le calcul à partir de l'expression donnée.
    /// </summary>
    /// <param name="expression">Expression entrée par l'utilisateur.</param>
    /// <returns>Retourne la somme finale.</returns>
    public static float Calcul(string expression)
    {
        string pile = "";
        float somme = 0;
        float premiereValeur = 0;
        float deuxiemeValeur = 0;
        foreach (char element in expression) //Parcours tous les éléments de l'expression
        {
            try //Utilisé pour throw une exception si il y a une erreur.
            {
                switch (element) //Utilisé pour chaque opérateur.
                {
                    
                    case '+': //gestion de l'addition.
                        affectationEtVerification(ref deuxiemeValeur, ref premiereValeur,ref pile);
           
                        somme = premiereValeur + deuxiemeValeur;
                        Push(ref pile, somme.ToString());
                        break;
                    case '-':
                        affectationEtVerification(ref deuxiemeValeur, ref premiereValeur, ref pile);
                        somme = premiereValeur - deuxiemeValeur;
                        Push(ref pile, somme.ToString());
                        break;
                    case '/':
                        affectationEtVerification(ref deuxiemeValeur, ref premiereValeur,ref pile);
                        if(premiereValeur == 0)
                        {
                            throw new DivideByZeroException("Valeurs entrées incorrectes : division par zéro");
                        }
                        else
                        {
                            somme = premiereValeur / deuxiemeValeur;
                            Push(ref pile, somme.ToString());
                        }
                        break;
                    case '*':
                        affectationEtVerification(ref deuxiemeValeur, ref premiereValeur,ref pile);
                        somme = premiereValeur * deuxiemeValeur;
                        Push(ref pile, somme.ToString());
                        break;
                    default: //si l'element n'est pas un opérateur, c'est donc un nombre, on l'ajoute à la pile.
                        Push(ref pile, element.ToString());
                        break;
                }
            }
            catch
            {
                throw (new Exception("Erreur : Calcul infaisable; ressaisir. \n"));
            }
            
        }
        return somme;
    }

    /// <summary>
    /// Boucle pour l'execution apres chaque calcul, appel la fonction.
    /// </summary>
    static void Main()
    {
        bool programRunning = true;
        do
        {
            Console.WriteLine( Calcul(getCalcul()));
            //Console.WriteLine(somme);

        } while (programRunning);
        
    }


}



