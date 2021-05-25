﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
using CoreEFTest.Context;
using CoreEFTest.Models;
using DLL_Clinician;
using Microsoft.EntityFrameworkCore;
using Presentation_ShowProcess;

namespace Presentation_Clinician
{
   /// <summary>
   /// Interaction logic for ClinicianMainWindow.xaml
   /// </summary>
   public partial class ClinicianMainWindow : Window
   {


       UC2_ManagePatient _managePatient = new UC2_ManagePatient(new ClinicDatabase(), new RegionDatabase());
       UC3_ManageHA _manageHA = new UC3_ManageHA(new ClinicDatabase());

       private ClinicDBContext context = new ClinicDBContext();
       private UC6_showProcess showProcess;
       private HomeWindow homeWindow;

       public bool LoginOK { get; set; }
       public bool RegionLoginOK { get; set; }
       public int StaffID { get; set; }
       public StaffLogin clinician { set; get; }

       public Patient Patient;

       Color color1 = Color.FromRgb(237, 246, 253);
       Color color2 = Color.FromRgb(226, 230, 230);


      public ClinicianMainWindow()
      {
         InitializeComponent();
         homeWindow = new HomeWindow(this, _managePatient);
         clinician = new StaffLogin();
         Patient = new Patient();
      }
      public void Window_Loaded(object sender, RoutedEventArgs e)
      {
         StaffID = clinician.StaffID;
          Hide();
          CheckPatientCPR();
      }

        private void BtnPatient_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PatientPage(this, _managePatient);
            BtnPatient.Background = new SolidColorBrush(color1);
            BtnStart.Background = new SolidColorBrush(color2);
            BtnHearingAid.Background = new SolidColorBrush(color2);
            BtnProces.Background = new SolidColorBrush(color2);
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            CheckPatientCPR();

            BtnPatient.Background = new SolidColorBrush(color2);
            BtnStart.Background = new SolidColorBrush(color1);
            BtnHearingAid.Background = new SolidColorBrush(color2);
            BtnProces.Background = new SolidColorBrush(color2);

        }

        private void BtnHearingAid_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ManageHAPage(this, _manageHA);
            BtnPatient.Background = new SolidColorBrush(color2);
            BtnStart.Background = new SolidColorBrush(color2);
            BtnHearingAid.Background = new SolidColorBrush(color1);
            BtnProces.Background = new SolidColorBrush(color2);
        }

        private void BtnProces_Click(object sender, RoutedEventArgs e)
        {
     
            BtnPatient.Background = new SolidColorBrush(color2);
            BtnStart.Background = new SolidColorBrush(color2);
            BtnHearingAid.Background = new SolidColorBrush(color2);
            BtnProces.Background = new SolidColorBrush(color1);

            showProcess = new UC6_showProcess(context, clinician);
            Main.Content = showProcess;

        }

        public void CheckPatientCPR()
        {
            Hide();
            homeWindow = new HomeWindow(this, _managePatient);
            homeWindow.ShowDialog();
            homeWindow.TbCPRnumber.Clear();

            if (LoginOK || RegionLoginOK)
            {
                BtnPatient.Background = new SolidColorBrush(color1);
                BtnStart.Background = new SolidColorBrush(color2);
                BtnHearingAid.Background = new SolidColorBrush(color2);
                BtnProces.Background = new SolidColorBrush(color2);

                Main.Content = new PatientPage(this, _managePatient);
                ShowDialog();
            }
            else
            {
                Close();
            }
        }
   }
}
