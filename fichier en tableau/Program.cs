using classereleve;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.SqlConn;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace lire_dans_un_fichier
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 - Rentrer un nouveau capteur\n" +
               "2 - Utiliser le dossier spécifique et séparer les mots de chaque ligne\n" +
               "3 - Utiliser le dossier spécifique et séparer les mots dans un tableau\n"+
               "4 - Utiliser le dossier spécifique et séparer les mots dans un tableau\n"
               );

                int choix = Convert.ToInt32(Console.ReadLine()); // Toint32 retranscrit les choix en int

                switch (choix)
                {
                    case 1:

                        
                        Console.WriteLine("Saisissez le numéro de série de votre nouveau capteur = ");
                        string num_serie = Console.ReadLine(); //capt.n_serie, capt.nom_ville
                        Console.WriteLine("Saisissez la ville de votre capteur = ");
                        string name_ville = Console.ReadLine();
                        Console.WriteLine("Voici votre nouveau capteur numéro de série: " + num_serie + " et ville: " + name_ville);
                        Console.ReadLine();
                        SqlConnection connection = DBUtils.GetDBConnection();
                        connection.Open();
                        try
                        {
                            // La commande Insert.
                            string sql = "Insert into capteur (n_serie, nom_ville) "
                                                             + " values (@n_serie, @nom_ville) ";

                            SqlCommand cmd = connection.CreateCommand();
                            cmd.CommandText = sql;

                            // Créez un objet Parameter.
                            SqlParameter n_serie = new SqlParameter("@n_serie", SqlDbType.VarChar)
                            {
                                Value = num_serie
                            };
                            cmd.Parameters.Add(n_serie);

                          
                            SqlParameter nom_villeParam = cmd.Parameters.Add("@nom_ville", SqlDbType.VarChar);
                            nom_villeParam.Value = name_ville;

                            

                            // Exécutez Command (Pour supprimer (delete), insérer (insert), mettre à jour (update)).
                            int rowCount = cmd.ExecuteNonQuery();

                            Console.WriteLine("Le capteur vient d'être ajouté = " + rowCount);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: " + e);
                            Console.WriteLine(e.StackTrace);
                        }
                        finally
                        {
                            connection.Close();
                            connection.Dispose();
                            connection = null;
                        }

                        Console.Read();

                        break;

                    case 2:
                        string[] lines2 = File.ReadAllLines("D:/cesi/c sharp/projet4/releve.txt");// lire les lignes du fichier
                        foreach (string line in lines2)//lire chaque ligne du fichier
                        {
                            string[] words = line.Split(' ');// Séparer chaque mot d'une phrase quand on trouve un espace
                            foreach (var word in words)// lire chaque mot

                                System.Console.WriteLine($"<{word}>");
                        }



                        break;

                    case 3:

                     



                            break;
                    case 4:
                      
       
            
           
                List<string[]> list = null;
                using (StreamReader streamReader = new StreamReader("D:/cesi/c sharp/projet4/releve.txt"))
                {
                    list = new List<string[]>();
                    while (!streamReader.EndOfStream)
                    {
                        string[] line = streamReader.ReadLine().Split(';');
                        list.Add(line);
                    }
                }

                // Affichage du résultat
                foreach (string[] line in list)
                {
                    foreach (string s in line)
                    {
                        Console.Write("{0}\t", s);
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
         
        
  
   
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

