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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL_Clinician;
using CoreEFTest.Models;

namespace Presentation_Clinician
{
    /// <summary>
    /// Interaction logic for ManageHAPage.xaml
    /// </summary>
    public partial class ManageHAPage : Page
    {
        private UC3_ManageHA _manageHA;

        private ClinicianMainWindow _clinicianMainWindow;
        private HearingTestWindow _hearingTest;
        private OrderNewHA orderNewHa;
        private HAInformationWindow _haInformation;


        public ManageHAPage(ClinicianMainWindow clinicianMainWindow, UC3_ManageHA manageHA)
        {
            InitializeComponent();
            _clinicianMainWindow = clinicianMainWindow;
            _manageHA = manageHA;
        }


        private void BtnRetrieveHearingTest_Click(object sender, RoutedEventArgs e)
        {
            _hearingTest = new HearingTestWindow();
            _hearingTest.Show();
        }

        private void BtnFormerHearingAids_Click(object sender, RoutedEventArgs e)
        {
            _haInformation = new HAInformationWindow(_clinicianMainWindow, _manageHA);
            _haInformation.Show();
         //TbAllHA.Text = Convert.ToString(manageHA.GetAllHA(clinicianMainWindow.PCPR));
        }

        private void HA_Page_Loaded(object sender, RoutedEventArgs e)
        {
            var HA_GeneralSpec = _manageHA.GetHA(_clinicianMainWindow.Patient.PatientId);

            foreach (var generalSpec in HA_GeneralSpec)
            {
                if (generalSpec != null)
                {
                    if (generalSpec.EarSide == Ear.Left)
                    {
                        Tb_LeftEar_Color.Text = Convert.ToString(generalSpec.Color);
                        Tb_LeftEar_Type.Text = Convert.ToString(generalSpec.Type);
                        Tb_Left_HAID.Text = Convert.ToString(generalSpec.HAGeneralSpecID);
                        Tb_StaffID_Left.Text = Convert.ToString(generalSpec.StaffLoginFK);
                        Tb_Datetime_Left.Text = Convert.ToString(generalSpec.CreateDate);
                    }

                    if (generalSpec.EarSide == Ear.Right)
                    {
                        Tb_RightEar_Color.Text = Convert.ToString(generalSpec.Color);
                        Tb_RightEar_Type.Text = Convert.ToString(generalSpec.Type);
                        Tb_Right_HAID.Text = Convert.ToString(generalSpec.HAGeneralSpecID);
                        Tb_StaffID_Right.Text = Convert.ToString(generalSpec.StaffLoginFK);
                        Tb_Datetime_Right.Text = Convert.ToString(generalSpec.CreateDate);
                    }
                }
            }
        }

      

        private void BtnOrderHearingAids1_Click(object sender, RoutedEventArgs e)
        {
            orderNewHa = new OrderNewHA(_clinicianMainWindow, _manageHA);
            orderNewHa.Show();
        }
    }
}
