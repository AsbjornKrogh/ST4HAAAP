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
using CoreEFTest.Models;
using DLL_Clinician;

namespace Presentation_Clinician
{
    /// <summary>
    /// Interaction logic for HAInformationWindow.xaml
    /// </summary>
    public partial class HAInformationWindow : Window
    {
        UC3_ManageHA _manageHA = new UC3_ManageHA(new ClinicDatabase());

        private ClinicianMainWindow _clinicianMain;

        private GeneralSpec generalSpec;
        private List<GeneralSpec> listGeneralSpecs;
        private List<GeneralSpec> listGeneralSpecsRight;
        private List<GeneralSpec> listGeneralSpecsLeft;



        public HAInformationWindow(ClinicianMainWindow clinicianMainWindow, UC3_ManageHA manageHa)
        {
            InitializeComponent();
            _clinicianMain = clinicianMainWindow;
            _manageHA = manageHa;

        }

        private void HAInformationWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            listGeneralSpecs = _manageHA.GetAllHA(_clinicianMain.Patient.PatientId);
            listGeneralSpecsRight = new List<GeneralSpec>();
            listGeneralSpecsLeft = new List<GeneralSpec>();

            foreach (var clinicianSpec in listGeneralSpecs)
            {
                if (clinicianSpec.EarSide == Ear.Right)
                {
                    Lb_OldHearingRight.Items.Add("Dato " + clinicianSpec.CreateDate);
                    listGeneralSpecsRight.Add(clinicianSpec);

                }
                else if (clinicianSpec.EarSide == Ear.Left)
                {
                    Lb_OldHearingLeft.Items.Add("Dato: " + clinicianSpec.CreateDate);
                    listGeneralSpecsLeft.Add(clinicianSpec);
                }
            }
        }


        private void btn_ShowOldAid_Click(object sender, RoutedEventArgs e)
        {

            if (Lb_OldHearingRight.SelectedIndex >= 0)
            {
                generalSpec = listGeneralSpecsRight[Lb_OldHearingRight.SelectedIndex];

                Tb_EarSide.Text = Convert.ToString(generalSpec.EarSide);
                Tb_Type.Text = Convert.ToString(generalSpec.Type);
                Tb_Color.Text = Convert.ToString(generalSpec.Color);
                Tb_ID.Text = Convert.ToString(generalSpec.HAGeneralSpecID);
                Tb_CreateDate.Text = Convert.ToString(generalSpec.CreateDate);
                Tb_StaffID.Text = Convert.ToString(generalSpec.StaffLoginFK);

                Lb_OldHearingRight.SelectedIndex = -1;

            }
            else if (Lb_OldHearingLeft.SelectedIndex >= 0)
            {
                generalSpec = listGeneralSpecsLeft[Lb_OldHearingLeft.SelectedIndex];

                Tb_EarSide.Text = Convert.ToString(generalSpec.EarSide);
                Tb_Type.Text = Convert.ToString(generalSpec.Type);
                Tb_Color.Text = Convert.ToString(generalSpec.Color);
                Tb_ID.Text = Convert.ToString(generalSpec.HAGeneralSpecID);
                Tb_CreateDate.Text = Convert.ToString(generalSpec.CreateDate);
                Tb_StaffID.Text = Convert.ToString(generalSpec.StaffLoginFK);

                Lb_OldHearingLeft.SelectedIndex = -1;

            }
            else
            {
                MessageBox.Show("Vælg et høreapparat");
            }
        }
    }
}

