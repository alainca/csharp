using Libraryreleve.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.IO;
using SelectPdf;

//using DocumentFormat.OpenXml.Spreadsheet;
//using Moq;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : System.Windows.Window
    {
        
        public Window1(List<Releves> modelList)
        {
            InitializeComponent();
      

            // tableau.ItemsSource = new myContext().Releves.ToList(); 
            myContext context = new myContext();
            tableau.ItemsSource = (from r in context.Releves select r).ToList();
            //MessageBox.Show(releves2.ToString());

            capteurs.ItemsSource = (from c in context.capteur select c).ToList();
            capteurs.DisplayMemberPath = "nom_ville";


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var csv = new StringBuilder();

            var filteredTable = tableau.ItemsSource as List<Releves>;

            var header = string.Format("{0};{1};{2};{3};{4}{5}",
                   "Nom du capteur",
                    "Date heure relevé",
                    "Température",
                    "Humidité",
                    "Identifiant capteur",
                    Environment.NewLine
                );
            csv.Append(header);

            foreach (var item in filteredTable)
            {
                var newline = string.Format("{0};{1};{2};{3};{4}{5}",
                    item.capteur.nom_ville,
                    item.date_heure_releve,
                    item.temperature,
                    item.humidite,
                    item.id_capteur,
                    Environment.NewLine
                );
                csv.Append(newline);
            }
            



            File.WriteAllText(string.Format("C:\\Users\\predi\\source\\repos\\releves-{0}.csv", DateTime.Now.ToString("yyyyMMddHms")), csv.ToString());

            /*
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < tableau.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = tableau.Columns[j].Header;
            }
            for (int i = 0; i < tableau.Columns.Count; i++)
            {
                for (int j = 0; j < tableau.Items.Count; j++)
                {
                    TextBlock b = tableau.Columns[i].GetCellContent(tableau.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];

                }
            }*/
        }

        void tableau_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void Button_valider(object sender, RoutedEventArgs e)
        {
            myContext context = new myContext();

            //MessageBox.Show(cap.nom_ville);
            //var cap2 = from c2 in context.capteur where cap = c2.nom_ville select c2.id_capteur;

            // variables et requête pour filtrer les relevés avec l'id capteur sélectionné dans la combox
            //var NomVilleSelect = capteurs.SelectedItem;
            //tableau.ItemsSource = (from c in context.capteur where c.nom_ville == NomVilleSelect select c.id_capteur).ToList();

            var cap = capteurs.SelectedItem as capteur;
            var dateEntree = date_entree.SelectedDate;
            var dateFin = date_fin.SelectedDate;

            if (cap == null || dateEntree == null || dateFin == null)
            {
                MessageBox.Show("Merci de bien renseigner les trois critères");
                return;
            }

            tableau.ItemsSource = (from r in context.Releves 
                                   where r.date_heure_releve >= dateEntree && r.date_heure_releve <= dateFin && r.id_capteur == cap.id_capteur
                                   select r).ToList();

           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
                
        }

        private void reinit_Click(object sender, RoutedEventArgs e)

        {
            date_entree.SelectedDate = null;
            date_fin.SelectedDate = null;
        }

        private void exp_pdf(object sender, RoutedEventArgs e)
        {
            //Window2 myForm = new Window2(releves2);
            //myForm.Show();

            string content = "<style>"
                + "td{ padding: 10px; }"
                + "table{ border: 1px solid gray; }"
                + "</style>";

            string titre = "Data Rapport";
            content += string.Format("<h1>{0}</h1>", titre);
            content += "<table>" +
                "<tr><td>N° de série</td><td></td></tr>";
            content += "</table>";
            content += "<table>";

            var filteredTable = tableau.ItemsSource as List<Releves>;
            foreach (var item in filteredTable)
            {
                content += string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}°</td><td>{3}%</td></tr>", item.id_capteur, item.date_heure_releve, Math.Round((double)item.temperature, 2), item.humidite);

            }
            content += "</table>";

            HtmlToPdf converter = new HtmlToPdf();
            converter.Options.MarginTop = 25;
            converter.Options.MarginBottom = 25;
            converter.Options.MarginLeft = 25;
            converter.Options.MarginRight = 25;


            PdfDocument doc = converter.ConvertHtmlString(content);

            string adress = (string.Format("C:\\Users\\predi\\source\\repos\\rapport-{0}.pdf", DateTime.Now.ToString("yyyyMMddHms")));
            Service.Class1.GlobalPath = adress;

            doc.Save(string.Format("C:\\Users\\predi\\source\\repos\\rapport-{0}.pdf", DateTime.Now.ToString("yyyyMMddHms")));
            doc.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            mail mail = new mail();
            mail.Show();
            this.Close();
        }
    }
}
