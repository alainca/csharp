using Libraryreleve.Service;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Controls;

using System.Linq;





using Tutorial.SqlConn;
using Libraryreleve.Data;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Releves> releves2;
        public MainWindow()
        {
            InitializeComponent();

            myContext context = new myContext();
            
            releves2 = (from r in context.Releves select r).ToList();

            Selec_capteurs.ItemsSource = (from c in context.capteur select c).ToList();
            Selec_capteurs.DisplayMemberPath = "nom_ville";




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ajout_capteur_Click(object sender, RoutedEventArgs e)
        {
            services_capteurs.AddCapteur(nom_ville.Text, identifiant.Text);
            Confirmation.Content = "Le capteur vient d'être ajouté";
            identifiant.Text = " ";
            nom_ville.Text = " ";

        }

        private void captout(object sender, RoutedEventArgs e)
        {
            
            Confirmation.Content = "";
            

        }


        private void Button_win2(object sender, RoutedEventArgs e)
        {

            Window1 myForm = new Window1(releves2);
            myForm.Show();
            this.Close();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
       
        private void click_bdd(object sender, RoutedEventArgs e)
        {
            myContext context = new myContext();
            // string contenu = from c in context.Releves where c capt == c.nom_ville select c.id_capteur;
            var capt = Selec_capteurs.SelectedItem as capteur;
            var contenu = (from cap in context.capteur
                           where capt.nom_ville == cap.nom_ville
                           select cap).FirstOrDefault();
            //string contenu = tbidcapt.Text;

            servicesreleves.Addbdd(contenu.id_capteur.ToString());
            bddin.Content = "Le relevé vient d'être archivé";
        }
        private void bddout(object sender, RoutedEventArgs e)
        {

            bddin.Content = "";
        }

        private void chercher_fichier(object sender, RoutedEventArgs e)
        {
        }

        private void Exporterexcell(object sender, RoutedEventArgs e)
        {
            servicesreleves.Exporterexcell();
        }

        public void Button_Click_4(object sender, RoutedEventArgs e)
        {


            Stream myStream;
            OpenFileDialog ofc = new OpenFileDialog();
            ofc.RestoreDirectory = true;
            ofc.InitialDirectory = @"D:\cesi\c sharp";  //Chemin dossier à importer
            if (ofc.ShowDialog() == true)
            {

                if ((myStream = ofc.OpenFile()) != null)
                {
                    string str = ofc.FileName; 

                    //envois du repertoire:



                    string filetxt = File.ReadAllText(str); //recupération du contenue du fichier TXT

                    try
                    {

                        try
                        {
                            
                            string[] lines = File.ReadAllLines(str);
                            foreach (string line in lines)
                            {
                                listereleve.Items.Add(line); //Conversion TEXT en LIST


                            }
                        }
                        catch { }
                    }
                    catch { }
                   
                }
            }
            


        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged()
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void bcapt_Click(object sender, RoutedEventArgs e)
        {
            gridd.ItemsSource = new myContext().capteur.ToList();//Get Capteur ID from BDD

            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void identifiant_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void nom_ville_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

       
    }
    
    

