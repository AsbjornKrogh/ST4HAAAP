using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLL_Clinician;

namespace Presentation_Clinician
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        private UC2_ManagePatient _uc2ManagePatient;
        private ClinicianMainWindow _clinicianMainWindow;

        public HomeWindow(ClinicianMainWindow clinicianMainWindow, UC2_ManagePatient managePatient)
        {
            InitializeComponent();

            _clinicianMainWindow = clinicianMainWindow;
            _uc2ManagePatient = managePatient;

            TbCPRnumber.Focus();
        }

        private void BtOK_Click(object sender, RoutedEventArgs e)
        {
            string cpr = TbCPRnumber.Text;
            _clinicianMainWindow.LoginOK = false;
            _clinicianMainWindow.RegionLoginOK = false;

            if (true)//(TbCPRnumber.Text.Length == 11 && TbCPRnumber.Text != "           ")
            {
                if (_uc2ManagePatient.CheckCPRClinicDatabase(cpr))
                {
                    _clinicianMainWindow.LoginOK = true;
                    Close();
                    _clinicianMainWindow.Patient.CPR = cpr;

                }
                else if (_uc2ManagePatient.GetPatientInformationRegionsDatabase(cpr) != null)
                {
                    _clinicianMainWindow.RegionLoginOK = true;
                    Close();
                    _clinicianMainWindow.Patient.CPR = cpr;
                }
                else
                {
                    _clinicianMainWindow.LoginOK = false;
                    _clinicianMainWindow.RegionLoginOK = false;
                    string message = "Ugyldigt CPR";
                    string title = "Fejl";
                    MessageBoxImage error = MessageBoxImage.Error;
                    MessageBox.Show(message, title, MessageBoxButton.OK, error);
                }
            }
            else
            {
                string message = "Ugyldigt PCPR";
                string title = "Fejl";
                MessageBoxImage error = MessageBoxImage.Error;
                MessageBox.Show(message, title, MessageBoxButton.OK, error);
            }

        }
    }
}
