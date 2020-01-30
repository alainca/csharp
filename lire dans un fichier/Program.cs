using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace lire_dans_un_fichier
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 - Rentrer le chemin de votre fichier de relevé\n" +
               "2 - Utiliser le dossier spécifique\n" +
               "3 - inclure dans un tableau\n" +
               "4 - encours\n" +
               "5 - encours\n" +
               "6 - en cours\n");

                int choix = Convert.ToInt32(Console.ReadLine()); // Toint32 retranscrit les choix en int

                switch (choix)
                {
                    case 1:
                        Console.WriteLine("Inscrire le chemin pour atteindre votre fichier:");
                        string chemin = Console.ReadLine();
                        Console.WriteLine(chemin);
                        Console.WriteLine("lire le contenu de votre fichier:");
                        string[] lines = File.ReadAllLines(chemin);

                        // parcours l'ensemble du fichier
                        Console.WriteLine("Voici vos relevés de températures et humidité = ");
                        foreach (string line in lines)
                        {
                            // Ajoute un retour à la ligne .
                            Console.WriteLine("\t" + line);
                        }
                        break;

                    case 2:
                        Console.WriteLine("lire le contenu de votre fichier:");
                        string[] lines2 = File.ReadAllLines("D:/cesi/c sharp/projet4/releve.txt");

                        
                        System.Console.WriteLine("Voici vos relevés de températures et humidité = ");
                        foreach (string line in lines2)
                        {
                            
                            Console.WriteLine("\t" + line);
                        }





                        break;

                    case 3:

                        string[] tab;
                        string ligne = null;
                        ArrayList donnees = new ArrayList();
                        char[] sep = { ':' };
                        

                        StreamReader fluxInfos = null;
                        try
                        {
                            using (fluxInfos = new StreamReader(@"D:/cesi/c sharp/projet4/releve.txt"))
                            {
                                ligne = fluxInfos.ReadLine();

                                while (ligne != null)
                                {

                                    tab = ligne.Split(sep);
                                    donnees.Add(tab[1].Trim());
                                }
                                fluxInfos.Close();
                                // Affichage du fichier texte
                                while (ligne != null) 
                                {
                                Console.WriteLine(ligne);
                                ligne = fluxInfos.ReadLine();

                                }
                                System.Console.ReadKey();
                                Console.WriteLine(fluxInfos);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("L'erreur suivante s'est produite : " + e.Message);
                        }

                            break;
                    case 4:

                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
            }


        }
    }
}

