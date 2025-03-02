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

            double sommeMoyennes = 0;
            // Affichage des étudiants triés par NO
            Console.WriteLine("\nListe des étudiants :");
            foreach (DictionaryEntry entry in lstEtudiants)
            {
                Etudiant etudiant = (Etudiant)entry.Value;
                double moyenneEtudiant = Moyenne(etudiant.NoteCC, etudiant.NoteDevoir);
                Console.WriteLine($"NO: {etudiant.NO}, Prénom: {etudiant.Prenom}, Nom: {etudiant.Nom}, NoteCC: {etudiant.NoteCC}, NoteDevoir: {etudiant.NoteDevoir}, Moyenne: {moyenneEtudiant}");
                sommeMoyennes += moyenneEtudiant;
            }
            double moyenneClasse = sommeMoyennes / nombreEtudiants;
            Console.WriteLine($"\nMoyenne classe : {moyenneClasse}");

            Console.ReadLine();
        }

        static double Moyenne(double noteCC, double noteDS)
        {
            return (noteCC * 0.33) + (noteDS * 0.67);
        }
    }
}
