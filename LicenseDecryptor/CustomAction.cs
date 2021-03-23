using Microsoft.Deployment.WindowsInstaller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LicenseDecryptor
{
    public class CustomActions
    {
        [CustomAction]

       

        public static ActionResult CheckMSILicense(Session session)
        {
            session.Log("Begin CustomAction1");

            //MessageBox.Show("please attach a debugger","AttachToProcess");


            bool firstVariable = false;
            bool secondVariable = false;

            //Get the data from MSI
            string data = session["CustomActionData"];
            //string data = "1461327229-1611100800";
            string[] tokens = data.Split('-');

            string dataMinus1 = tokens[0].Remove(tokens[0].Length - 1, 1);

            string testfirstline = AddCheckDigit(dataMinus1);

            if (String.Equals(testfirstline, tokens[0])) { firstVariable = true; }


            double doubleVal = Convert.ToDouble(tokens[1]);
            Random rnd = new Random();
                int month = rnd.Next(1, 364);
                DateTime dt = new DateTime(2021, 1, 1);
                DateTime newDate = dt.AddDays(month);
                System.DateTime dtDateTime = new DateTime(1970, 1, 1);
                dtDateTime = newDate.AddMilliseconds(doubleVal).ToLocalTime();
                int year = dtDateTime.Year;
                int year2 = 2021;
                if (String.Equals(year, year2))
                { secondVariable = true; }


            if (firstVariable && secondVariable) { 
                return ActionResult.Success; 
            }
            else
            {
                MessageBox.Show("Please input a correct License KEY", "Wrong License");
                return ActionResult.Failure;
            }
            
        }

        private static string AddCheckDigit(string number)
        {
            int Sum = 0;
            for (int i = number.Length - 1, Multiplier = 2; i >= 0; i--)
            {
                Sum += (int)char.GetNumericValue(number[i]) * Multiplier;

                if (++Multiplier == 8) Multiplier = 2;
            }
            string Validator = (11 - (Sum % 11)).ToString();

            if (Validator == "11") Validator = "0";
            else if (Validator == "10") Validator = "X";

            return number + Validator;
        }
    }
}
