using System;
using System.Collections.Generic;

namespace Composite 
{
    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }
}










using System;
using System.Collections.Generic;

// Interface pour les composants (Entreprise et Filiale)
public interface IComponent
{
    void DisplayInfo();
}

// Classe représentant une entreprise
public class Entreprise : IComponent
{
    private string nom;
    private List<IComponent> filiales = new List<IComponent>();

    public Entreprise(string nom)
    {
        this.nom = nom;
    }

    public void AjouterFiliale(IComponent filiale)
    {
        filiales.Add(filiale);
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Entreprise: {nom}");
        Console.WriteLine("Filiales:");
        foreach (var filiale in filiales)
        {
            filiale.DisplayInfo();
        }
        Console.WriteLine();
    }
}

// Classe représentant une filiale
public class Filiale : IComponent
{
    private string nom;

    public Filiale(string nom)
    {
        this.nom = nom;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"- Filiale: {nom}");
    }
}

class Program
{
    static void Main()
    {
        // Création d'une entreprise principale
        Entreprise entreprisePrincipale = new Entreprise("Entreprise Principale");

        // Création de filiales
        Filiale filiale1 = new Filiale("Filiaire 1");
        Filiale filiale2 = new Filiale("Filiaire 2");

        // Ajout des filiales à l'entreprise principale
        entreprisePrincipale.AjouterFiliale(filiale1);
        entreprisePrincipale.AjouterFiliale(filiale2);

        // Création de filiales pour la filiale 1
        Filiale filiale1_1 = new Filiale("Filiaire 1.1");
        Filiale filiale1_2 = new Filiale("Filiaire 1.2");

        // Ajout des filiales à la filiale 1
        filiale1.AjouterFiliale(filiale1_1);
        filiale1.AjouterFiliale(filiale1_2);

        Console.ReadLine();
    }
}