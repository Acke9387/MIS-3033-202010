using System;

namespace StudentExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Student myStudent = new Student();
            Console.WriteLine(myStudent);
            myStudent.FirstName = "Adam";
            myStudent.LastName = "Ackerman";
            myStudent.IsOnProbation = true;
            myStudent.SoonerID = 5;
            Console.WriteLine(myStudent);
            Console.WriteLine();
            myStudent.MakePayment(500);
            Console.WriteLine(myStudent);
            myStudent.MakePayment(50);
            Console.WriteLine();
            Console.WriteLine(myStudent);

            try
            {
                myStudent.MakePayment(-500);
            }
            catch (Exception)
            {
                Console.WriteLine("INVALID PAYMENT");
                //throw;
            }
            
            Console.WriteLine();

            Console.WriteLine(myStudent);
        }
    }
}
