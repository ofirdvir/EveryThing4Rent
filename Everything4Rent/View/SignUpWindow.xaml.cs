using Everything4Rent.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace Everything4Rent
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        Controller _controller;
        public SignUpWindow(Controller c)
        {
            InitializeComponent();
            _controller = c;
        }
        /// <summary>
        /// Validates mandotary field
        /// shows the invalid fields to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmintRequeast_Click(object sender, RoutedEventArgs e)
        {
            bool ans = checkIfValidAndAddToDB();
            if (ans)
            {
                sendEmail();
                UserMenagment win2 = new UserMenagment(_controller);
                win2.Show();
                Close();
            }
            
        }

        private void sendEmail()
        {
            string userMail = txtEmail.Text;
            var fromAddress = new MailAddress("everyhing4rent@gmail.com", "Everything For Rent");
            var toAddress = new MailAddress(userMail, "To Name");
            const string fromPassword = "forrent1234";
            string subject = "Hi, " + txtFirstName.Text+   " Welcome to everyhing4Rent" ;
            string body = "Thank you for joining our amazing app have a nice day!!";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

        }

        private bool MailValidaion(string mail)
        {
            if (!_controller.checkMail(mail))
            {
                MessageBox.Show("Mail is not unique!", "Error");
                return false;
            }
            try
            {
                var address = new System.Net.Mail.MailAddress(mail);
                return address.Address == mail;
            }
            catch
            {
                MessageBox.Show("Not Valid Mail", "Error");
                return false;
            }

        }
        private bool checkIfValidAndAddToDB()
        {
            //  שם מלא, גיל, מין, כתובת מייל, פרטי חשבון PAY PAL. 
            int age = 0;
            if (txtLastName.Text == "" || txtUserName.Text == "" || txtPassword.Password == "" || txtFirstName.Text == "" || txtAge.Text == "" || ((ComboBoxItem)boxGender.SelectedItem).Content as string == "" || txtEmail.Text == "" || txtPayPalUseName.Text == "" || txtPayPalPassword.Password == "")
            {
                MessageBox.Show("Please Insert all the Mandatory Fields", "Error");
                txtLastName.BorderThickness = new Thickness(1);
                txtLastName.BorderBrush = new SolidColorBrush(Colors.Red);
                txtFirstName.BorderThickness = new Thickness(1);
                txtFirstName.BorderBrush = new SolidColorBrush(Colors.Red);
                txtAge.BorderThickness = new Thickness(1);
                txtAge.BorderBrush = new SolidColorBrush(Colors.Red);
                boxGender.BorderThickness = new Thickness(1);
                boxGender.BorderBrush = new SolidColorBrush(Colors.Red);
                txtEmail.BorderThickness = new Thickness(1);
                txtEmail.BorderBrush = new SolidColorBrush(Colors.Red);
                txtPayPalUseName.BorderThickness = new Thickness(1);
                txtPayPalUseName.BorderBrush = new SolidColorBrush(Colors.Red);
                txtPayPalPassword.BorderThickness = new Thickness(1);
                txtPayPalPassword.BorderBrush = new SolidColorBrush(Colors.Red);

                txtPassword.BorderThickness = new Thickness(1);
                txtPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                txtUserName.BorderThickness = new Thickness(1);
                txtUserName.BorderBrush = new SolidColorBrush(Colors.Red);

                return false;
            }
            else if (!MailValidaion(txtEmail.Text))
            {
              
                return false;
            }

            else if (!int.TryParse(txtAge.Text, out age))
            {
                System.Windows.Forms.MessageBox.Show("Age not valid");
                return false;
            }
            else
            {

                //_controller.AddUserToDB(txtFullName.Text, txtAge.Text, ((ComboBoxItem)boxGender.SelectedItem).Content as string, txtEmail.Text, txtPayPalUseName.Text, txtPayPalPassword.Text);
                string userName = txtUserName.Text;
                string Password = txtPassword.Password;
                _controller.AddUserToDB(txtFirstName.Text, txtLastName.Text, userName, Password, txtAge.Text, ((ComboBoxItem)boxGender.SelectedItem).Content as string, txtEmail.Text, txtPayPalUseName.Text, txtPayPalPassword.Password);
                return true;
            }
        }

        private void PhotoUpload_Click(object sender, RoutedEventArgs e)
        {
            string ImagePath;
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                ImagePath = new BitmapImage(new Uri(op.FileName)).ToString() ;
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Item_Operations win2 = new Item_Operations(_controller);
            win2.Show();
            Close();
        }
    }
}
