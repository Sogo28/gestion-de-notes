using System;
using System.Collections;

namespace UsageCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList lstEtudiants = new SortedList();

            Console.Write("Combien d'étudiants voulez-vous ajouter ? ");
            int nombreEtudiants;
            while (!int.TryParse(Console.ReadLine(), out nombreEtudiants) || nombreEtudiants <= 0)
            {
                Console.Write("Veuillez entrer un nombre d'étudiants valide (un nombre entier positif) : ");
            }

            for (int i = 0; i < nombreEtudiants; i++)
            {
                Console.WriteLine($"\nSaisie de l'étudiant {i + 1}:");

                int no;
                Console.Write("Numéro d'ordre (NO) : ");
                while (!int.TryParse(Console.ReadLine(), out no) || no <= 0)
                {
                    Console.Write("Veuillez entrer un numéro d'ordre valide (un nombre entier positif) : ");
                }

                Console.Write("Prénom : ");
                string prenom = Console.ReadLine();

                Console.Write("Nom : ");
                string nom = Console.ReadLine();

                double noteCC;
                Console.Write("Note de Contrôle Continu : ");
                while (!double.TryParse(Console.ReadLine(), out noteCC) || noteCC < 0 || noteCC > 20)
                {
                    Console.Write("Veuillez entrer une note de contrôle continu valide (0 à 20) : ");
                }

                double noteDevoir;
                Console.Write("Note de Devoir : ");
                while (!double.TryParse(Console.ReadLine(), out noteDevoir) || noteDevoir < 0 || noteDevoir > 20)
                {
                    Console.Write("Veuillez entrer une note de devoir valide (0 à 20) : ");
                }

                lstEtudiants.Add(no, new Etudiant { NO = no, Prenom = prenom, Nom = nom, NoteCC = noteCC, NoteDevoir = noteDevoir });
            }

            Console.Write("\nChoisissez le nombre d'étudiants à afficher par page (1-15) : ");
            int lignesParPage;
            while (!int.TryParse(Console.ReadLine(), out lignesParPage) || lignesParPage < 1 || lignesParPage > 15)
            {
                Console.Write("Valeur invalide. Entrez un nombre entre 1 et 15 : ");
            }

            double sommeMoyennes = 0;
            int totalEtudiants = lstEtudiants.Count;
            int totalPages = (int)Math.Ceiling((double)totalEtudiants / lignesParPage);
            int pageActuelle = 1;

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\nPage {pageActuelle}/{totalPages}");

                int debut = (pageActuelle - 1) * lignesParPage;
                int fin = Math.Min(debut + lignesParPage, totalEtudiants);

                int index = 0;
                foreach (DictionaryEntry entry in lstEtudiants)
                {
                    if (index >= debut && index < fin)
                    {
                        Etudiant etudiant = (Etudiant)entry.Value;
                        double moyenneEtudiant = Moyenne(etudiant.NoteCC, etudiant.NoteDevoir);
                        Console.WriteLine($"NO: {etudiant.NO}, Prénom: {etudiant.Prenom}, Nom: {etudiant.Nom}, NoteCC: {etudiant.NoteCC}, NoteDevoir: {etudiant.NoteDevoir}, Moyenne: {moyenneEtudiant:F2}");
                        sommeMoyennes += moyenneEtudiant;
                    }
                    index++;
                }

                double moyenneClasse = sommeMoyennes / totalEtudiants;
                Console.WriteLine($"\nMoyenne de la classe : {moyenneClasse:F2}");

                Console.WriteLine("\n(N) Page suivante | (P) Page précédente | (Q) Quitter le programme");
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.N && pageActuelle < totalPages) pageActuelle++;
                else if (key == ConsoleKey.P && pageActuelle > 1) pageActuelle--;
                else if (key == ConsoleKey.Q) break;
            }
        }

        static double Moyenne(double noteCC, double noteDS)
        {
            return (noteCC * 0.33) + (noteDS * 0.67);
        }
    }
}
