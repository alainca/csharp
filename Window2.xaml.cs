using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.IO;

using Libraryreleve.Data;
using System.Text.RegularExpressions;
using Libraryreleve;
using SelectPdf;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public readonly List<Releves> _modelList;

        public Window2(List<Releves> modelList)
        {
            InitializeComponent();
            _modelList = modelList;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// pdf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*string content = "<style>" 
                + "td{ padding: 10px; }"
                + "table{ border: 1px solid gray; }"
                + "</style>";

            string test = "Rapport";
            content += string.Format("<h1>{0}</h1>", test);

            content += "<table>";
            foreach (var item in _modelList)
            {
                content += string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}°</td><td>{3}%</td></tr>", item.id_capteur, item.date_heure_releve, Math.Round((double)item.temperature,2), item.humidite);

            }
            content += "</table>";

            HtmlToPdf converter = new HtmlToPdf();
            converter.Options.MarginTop = 25;
            converter.Options.MarginBottom = 25;
            converter.Options.MarginLeft = 25;
            converter.Options.MarginRight = 25;


            PdfDocument doc = converter.ConvertHtmlString(content);

            doc.Save(string.Format("C:\\Users\\predi\\source\\repos\\rapport-{0}.pdf", DateTime.Now.ToString("yyyyMMddHms")));
            doc.Close();*/
        }
    }
}
