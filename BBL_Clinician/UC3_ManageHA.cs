using System;
using System.Collections.Generic;
using CoreEFTest.Models;
using DLL_Clinician;

namespace BLL_Clinician
{
   public class UC3_ManageHA
   {
       private IClinicDatabase clinicDatabase;

       public UC3_ManageHA(IClinicDatabase _clinicDatabase)
       {
           clinicDatabase = _clinicDatabase;
       }

        public List<GeneralSpec> GetHA(int PatientId)
       {
           return clinicDatabase.GetLatestGeneralSpecs(Convert.ToInt32(PatientId));

       }

        public void CreateHA(GeneralSpec generalSpec)
        {
            clinicDatabase.CreateNewGeneralSpec(generalSpec);
        }

        public List<GeneralSpec> GetAllHA(int PatientID)
       {
          return clinicDatabase.GetAllGeneralSpecs(PatientID);
       }

        public void createEC(EarCast earCast)
        {
          clinicDatabase.CreateEarCast(earCast);
        }
   }
}
