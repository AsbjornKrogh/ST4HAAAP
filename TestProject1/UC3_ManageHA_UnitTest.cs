using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using BLL_Clinician;
using BLL_Technician;
using CoreEFTest.Models;
using DLL_Clinician;
using DLL_Technician;
using NSubstitute;
using NUnit.Framework;

namespace Clinician_HearingAidApp.Test.Unit
{
    public class UC3_ManageHA_UnitTest
    {
        private UC3_ManageHA uut;
        private IClinicDatabase db;
        private FakeGeneralSpec generalSpec;
        private FakeEarCast earCast;

        [SetUp]
        public void Setup()
        {
            db = Substitute.For<IClinicDatabase>();
            uut = new UC3_ManageHA(db);
            generalSpec = new FakeGeneralSpec();
            earCast = new FakeEarCast();

        }


        [Test]
        public void GetHA_ExpectedResult_CallGetLatestGeneralSpecs()
        {
            uut.GetHA(1234);

            db.Received(1).GetLatestGeneralSpecs(1234);

        }

        [Test]
        public void CreateHA_ExpectedResult_CallCreateNewGeneralSpec()
        {
            uut.CreateHA(generalSpec);

            db.Received(1).CreateNewGeneralSpec(generalSpec);
        }

        [Test]
        public void GetAllHA_ExpectedResult_CallCreateNewGeneralSpec()
        {
            uut.GetAllHA("1234");

            db.Received(1).GetAllGeneralSpecs(1234);
        }

        [Test]
        public void CreateEC_ExpectedResult_CreateEarCast()
        {
            uut.createEC(earCast);

            db.Received(1).CreateEarCast(earCast);
        }

    }

    public class FakeGeneralSpec : GeneralSpec
    {
        public Material type { get; set; }

        public PlugColor Color { get; set; }

    }

    public class FakeEarCast : EarCast
    {
        public int EarCastID { get; set; }
        public Ear EarSide { get; set; }
    }


}