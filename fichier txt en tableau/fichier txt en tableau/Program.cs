using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ClassLibrary1.classereleve;

namespace fichier_txt_en_tableau
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader reader = new StreamReader("D:/cesi/c sharp/projet4/releve.txt");

            string ligne;

            ligne = reader.ReadLine();
            for (int i = 0; ligne != null; i++)  // Pour chaque ligne
            {
                string[] sousTab = ligne.Split(' '); // On récupère les 4 éléments dans un tableau
                Releve rel = new Releve();
                rel.Number = sousTab[0];
                rel.Date = sousTab[1];
                rel.Heure = sousTab[2];
                rel.Temp = sousTab[3];
                rel.Hum = sousTab[4];
                List<Releve> releve = new List<Releve>();
                releve.Add(rel);
                ligne = reader.ReadLine(); // On passe à la ligne suivante

               

                /* public int Number
                        {
                            get { return _number; }
                            set { _number = value; }
                        }
                        */



                System.Console.WriteLine("Numero : " + rel.Number + ", Date : " + rel.Date + ", L'Heure : " + rel.Heure + ", La température : " + rel.Temp + "L'humidité : " + rel.Hum);

            }
            {
                Console.ReadLine();
            }
        }


    }
}
   