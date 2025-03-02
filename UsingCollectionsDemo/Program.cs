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
            int nombreEtudiants = int.Parse(Console.ReadLine());

            for (int i = 0; i < nombreEtudiants; i++)
            {
                Console.WriteLine($"\nSaisie de l'étudiant {i + 1}:");

                Console.Write("Numéro d'ordre (NO) : ");
                int no = int.Parse(Console.ReadLine());

                Console.Write("Prénom : ");
                string prenom = Console.ReadLine();

                Console.Write("Nom : ");
                string nom = Console.ReadLine();

                Console.Write("Note de Contrôle Continu : ");
                double noteCC = double.Parse(Console.ReadLine());

                Console.Write("Note de Devoir : ");
                double noteDevoir = double.Parse(Console.ReadLine());

                // Ajout dans la liste triée
                lstEtudiants.Add(no, new Etudiant { NO = no, Prenom = prenom, Nom = nom, NoteCC = noteCC, NoteDevoir = noteDevoir });
            }

            Console.WriteLine("\nAppuyez sur Entrée pour afficher la liste des étudiants...");
            Console.ReadLine();

            // Affichage des étudiants triés par NO
            Console.WriteLine("\nListe des étudiants :");
            foreach (DictionaryEntry entry in lstEtudiants)
            {
                Etudiant etudiant = (Etudiant)entry.Value;
                Console.WriteLine($"NO: {etudiant.NO}, Prénom: {etudiant.Prenom}, Nom: {etudiant.Nom}, NoteCC: {etudiant.NoteCC}, NoteDevoir: {etudiant.NoteDevoir}");
            }

            Console.ReadLine();
        }
    }
}
