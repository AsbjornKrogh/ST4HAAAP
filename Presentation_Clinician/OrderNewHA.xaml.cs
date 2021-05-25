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
using CoreEFTest.Models;
using BLL_Clinician;
using DLL_Clinician;

namespace Presentation_Clinician
{
   /// <summary>
   /// Interaction logic for OrderNewHA.xaml
   /// </summary>
   public partial class OrderNewHA : Window
   {
       UC3_ManageHA _manageHA = new UC3_ManageHA(new ClinicDatabase());

       private ClinicianMainWindow _clinicianMainWindow;
       private GeneralSpec generalSpec;
       private EarCast earCast;

        public OrderNewHA(ClinicianMainWindow clinicianMainWindow, UC3_ManageHA manageHa)
      {
          InitializeComponent();

          _clinicianMainWindow = clinicianMainWindow;
          _manageHA = manageHa;

      }

      private void BtnSave_Click(object sender, RoutedEventArgs e)
      {
         generalSpec = new GeneralSpec();
         earCast = new EarCast();

         if (Cb_LeftEar.IsChecked == true && Cb_RightEar.IsChecked == true)
         {
             MessageBox.Show("Vælg kun ét øre");
             Cb_LeftEar.IsChecked = false;
             Cb_RightEar.IsChecked = false;
         }
         else
         {

             if (Cb_LeftEar.IsChecked == true)
             {
                 generalSpec.EarSide = Ear.Left;
                 earCast.EarSide = Ear.Left;
             }
             else if (Cb_RightEar.IsChecked == true)
             {
                 generalSpec.EarSide = Ear.Right;
                 earCast.EarSide = Ear.Right;

             }

             generalSpec.PatientFK = _clinicianMainWindow.Patient.PatientId;
             generalSpec.CreateDate = DateTime.Now;
             generalSpec.StaffLoginFK = _clinicianMainWindow.clinician.StaffID;

             generalSpec.Color = (PlugColor) CbNewColor.SelectionBoxItem;
             generalSpec.Type = (Material) CbNewType.SelectionBoxItem;

             earCast.CastDate = DateTime.Now;
             earCast.PatientFK = _clinicianMainWindow.Patient.PatientId;

             _manageHA.CreateHA(generalSpec);

             _manageHA.createEC(earCast);

             CbNewType.SelectedIndex = -1;
             CbNewColor.SelectedIndex = -1;
             Cb_LeftEar.IsChecked = false;
             Cb_RightEar.IsChecked = false;

             MessageBox.Show("Høreapparatet er bestilt", "Bekræftigelse", MessageBoxButton.OK,
                 MessageBoxImage.Information);
         }
      }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var types in Enum.GetValues(typeof(Material)))
            {
                CbNewType.Items.Add(types);
            }

            foreach (var colors in Enum.GetValues(typeof(PlugColor)))
            {
                CbNewColor.Items.Add(colors);
            }
        }
    }
}
