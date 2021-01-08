using System;
using BCrypt;

namespace Hasher
{
    class Program
    {
        /***********************************************************************************************************************************************************
         * This Program is to test the the implementation of the BCrypt hashing algorithm as well to test the ability to test passwords against previous hashings. *
         * Created by Tyler Nowak                                                                                                                                  *
         ***********************************************************************************************************************************************************/

        static void Main(string[] args)
        {
            //Strings for user input and the final hashed password
            string userIn = "";
            string hashedPword = "";


            //User input and writing to choice
            Console.WriteLine("Enter 1 for new Hash or Anything for Compareing an old Hash");
            string choice =  Console.ReadLine();


            //Check to see if input is one
            if (choice == "1")
            {
                //User input for password to be hashed
                Console.WriteLine("Enter Password to be hashed: ");
                userIn = Console.ReadLine();

                //Hashing the password using BCrypt with a salt of 12
                hashedPword = BCrypt.Net.BCrypt.HashPassword(userIn, workFactor: 12);

                //Program output of original password and the password's hash
                Console.WriteLine("Password: " + userIn);
                Console.WriteLine("Hashed Password: " + hashedPword);
            }//if
            else
            {
                //User input of the old password hash
                Console.WriteLine("Enter Old Hash: ");
                string oldHash = Console.ReadLine();

                //User input of the supposed password to the old hash
                Console.WriteLine("Enter Password before Hash: ");
                userIn = Console.ReadLine();

                //Uses BCrypt to confirm or deny that the password hash matches the password
                Console.WriteLine("Does Hash match old Password: " + BCrypt.Net.BCrypt.Verify(userIn, oldHash));

            }//else
        }//main
    }//class
}//namespace
