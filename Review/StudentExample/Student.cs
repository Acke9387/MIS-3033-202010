using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExample
{
    class Student
    {
        //Write on multiple lines
        //hold ALT + SHIFT then use the arrow keys to select 
        //which lines you want to edit and then release keys and time
        public int SoonerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsOnProbation { get; set; }
        public double GPA { get; set; }

        private double BursarBalance;

        /// <summary>
        /// Default/Empty Constructor for the Student
        /// </summary>
        public Student()
        {
            SoonerID = -1;
            FirstName = string.Empty;
            LastName = "";
            IsOnProbation = false;
            GPA = 0;
            BursarBalance = 1000;
        }

        /// <summary>
        /// Overloaded constructor that will set the default values of soonerid, firstname, lastname and bursar balance to known values
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="BursarBalance"></param>
        public Student(int id, string fName, string lName, double BursarBalance)
        {
            SoonerID = id;
            FirstName = fName;
            LastName = lName;
            IsOnProbation = false;
            GPA = 0;
            this.BursarBalance = BursarBalance;
        }

        /// <summary>
        /// Make a payment on your bursar balance
        /// </summary>
        /// <param name="amount">A non-negative value to reduce your bursar balance by</param>
        public void MakePayment(double amount)
        {
            //BursarBalance = BursarBalance - amount;
            if (amount > 0)
            {
                BursarBalance -= amount;
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// The current state of your bursar account
        /// </summary>
        /// <returns>How much you owe the Bursar</returns>
        public double CheckBalance()
        {
            return BursarBalance;
        }

        /// <summary>
        /// Create a string representation of our instance of the class
        /// </summary>
        /// <returns>The current state of the Student</returns>
        public override string ToString()
        {
            string output = $"{FirstName} {LastName } ({SoonerID})";
            if (IsOnProbation == true)
            {
                output += " is on probation.\n";
            }
            else
            {
                output += "is not on probation.\n";
            }
            output += $"They have a {GPA.ToString("N2")} GPA" +
                      $" and they owe {BursarBalance.ToString("C2")}";


            return output;
        }
    }
}
