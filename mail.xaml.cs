using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour Mail.xaml
    /// </summary>
    public partial class mail : Window
    {
        public mail()
        {
            InitializeComponent();
        }

        private void Load(object sender, EventArgs e)
        {
            //version1

            string zone = Service.Class1.GlobalPath;
            //version1
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            MailAddress adresseMailEnvoyeur = new MailAddress("predicta.car@gmail.com");
            MailAddress Receveur = new MailAddress(TXTTo.Text);
            MailMessage ConfigMess = new MailMessage(adresseMailEnvoyeur, Receveur);
            Attachment PJ = new Attachment(zone);
            ConfigMess.Attachments.Add(PJ);
            ConfigMess.Body = "Voici le rapport PDF en ci joint :";
            ConfigMess.Subject = "Data Reporting";
            NetworkCredential user = new NetworkCredential("predicta.car@gmail.com", "meteor57");
            client.Credentials = user;
            client.Send(ConfigMess);


            MainWindow pdf = new MainWindow();
            pdf.Show();
            this.Close();

        }
    }
}