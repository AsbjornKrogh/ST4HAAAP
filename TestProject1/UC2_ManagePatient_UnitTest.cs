using System;
using System.Collections.Generic;
using System.Text;
using BLL_Clinician;
using CoreEFTest.Models;
using DLL_Clinician;
using DLL_Clinician.RegionsDatabase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NUnit.Framework;


namespace Clinician_HearingAidApp.Test.Unit
{
    public class UC2_ManagePatient_UnitTest
    {

        private UC2_ManagePatient uut;
        private IClinicDatabase clinicDatabase;
        private IRegionDatabase regionDatabase;
        private FakePatient patient;

        [SetUp]
        public void Setup()
        {
            clinicDatabase = Substitute.For<IClinicDatabase>();
            uut = new UC2_ManagePatient(clinicDatabase, regionDatabase);
            patient = new FakePatient();
        }

        [Test]
        public void SaveUpdates_ExpectedResult_CallDatabaseUpdate()
        {
            uut.SaveUpdates(patient);
            clinicDatabase.Received(1).UpdatePatient(patient);
        }

        [Test]
        public void SavePatient_ExpectedResult_CallDatabaseUpdate()
        {
            uut.SavePatient(patient);

            clinicDatabase.Received(1).CreatePatient(patient);
        }

        [TestCase("123456-7890")]
        public void GetPatientInformation_ExpectedResult_CallGetPatient(string cpr)
        {
            uut.GetPatientInformation(cpr);

            clinicDatabase.Received(1).GetPatient(cpr);
        }
    }

    public class FakePatient : Patient
    {
        public string CPR { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
    }


}
