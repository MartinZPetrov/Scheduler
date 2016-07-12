using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Scheduler
{
    public class ScheduleToValueConverter : IValueConverter
    {

        private SchedulerContext db = new SchedulerContext();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string val = value.ToString().Trim();
            string returnString = string.Empty;
            string[] splitString = val.Split(new[] { ' ' });
           
            if (string.IsNullOrEmpty(val))
            {
                return returnString;
            }

            if (splitString.Count() == 1)
            {
                return string.Empty;
            }

            if (splitString.Count() == 2)
            {
                int userRef;
                bool isOk = int.TryParse(splitString[0], out userRef);
                if (isOk)
                {
                    User usr = db.Users.FirstOrDefault(e => e.User_ref == userRef);
                    if (usr != null)
                    {
                        returnString += usr.FirstName + " ";
                    }
                    returnString += splitString[1] + " ";
                }
            }

            if(splitString.Count() == 4)
            {
                int userRef1 = int.Parse(splitString[0]);
                
                User usr = db.Users.FirstOrDefault(e => e.User_ref == userRef1);
                if (usr != null)
                {
                    returnString += usr.FirstName + " ";
                }
            
                returnString += splitString[1] + " ";

                int userRef2 = int.Parse(splitString[2]);
                User secondUsr = db.Users.FirstOrDefault(e => e.User_ref == userRef2);
                if (secondUsr != null)
                {
                    returnString += secondUsr.FirstName + " ";
                }
         
                returnString += splitString[3] + " ";
            }

            return returnString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int UserRef = 0;
            int UserRef2 = 0;
            string val = value.ToString().Trim();
            string returnString = string.Empty;

            if(string.IsNullOrEmpty(val))
            {
                return returnString;
            }

            bool isCorrectString = false;
            string[] splitString = val.Split(new[] { ' ' });

            if (splitString.Count() == 1)
            {
                return string.Empty;
            }

            if(splitString.Count() == 2)
            {
                isCorrectString =  int.TryParse(splitString[0], out UserRef);
                if (!Helper.SelectedEmployeesCollection.Any(e => e.User_ref == UserRef)) 
                {
                    isCorrectString = false;
                }

                switch (splitString[1])
                {
                    case "1":
                        isCorrectString = true;
                        break;
                    case "+30":
                        isCorrectString = true;
                        break;
                    case "+45":
                        isCorrectString = true;
                        break;
                    case "-30":
                        isCorrectString = true;
                        break;
                    case "-45":
                        isCorrectString = true;
                        break;
                    default:
                        isCorrectString = false;
                        break;

                }

            
                if(isCorrectString)
                {
                    returnString  = splitString[0] + " " + splitString[1]; 
                }
                else
                {
                    returnString = string.Empty;
                }
            }
            
            if(splitString.Count() == 4)
            {

                isCorrectString = int.TryParse(splitString[0], out UserRef);

                switch (splitString[1])
                {
                    case "1":
                        isCorrectString = true;
                        break;
                    case "+30":
                        isCorrectString = true;
                        break;
                    case "+45":
                        isCorrectString = true;
                        break;
                    case "-30":
                        isCorrectString = true;
                        break;
                    case "-45":
                        isCorrectString = true;
                        break;

                }

                if(!Helper.SelectedEmployeesCollection.Any(e => e.User_ref == UserRef))
                {
                    isCorrectString = false;
                }

                isCorrectString = int.TryParse(splitString[2], out UserRef2);


                switch (splitString[3])
                {
                    case "1":
                        isCorrectString = true;
                        break;
                    case "+30":
                        isCorrectString = true;
                        break;
                    case "+45":
                        isCorrectString = true;
                        break;
                    case "-30":
                        isCorrectString = true;
                        break;
                    case "-45":
                        isCorrectString = true;
                        break;

                }

                if(!Helper.SelectedEmployeesCollection.Any(e => e.User_ref == UserRef2))
                {
                    isCorrectString = false;
                }
                if (isCorrectString)
                {
                    returnString = val;
                }
            }
            return returnString;
        }
    }
}
