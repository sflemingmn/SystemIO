using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemIO.Data;
using SystemIO.Helpers;
using SystemIO.Models;

namespace SystemIO.Workflows
{
    public class RemoveStudentWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Remove Student");

            StudentRepository repo = new StudentRepository(Settings.FilePath);
            List<Student> students = repo.List();

            ConsoleIO.PrintPickListOfStudents(students);
            Console.WriteLine();

            int index = ConsoleIO.GetStudentIndexFormUser("Which student would you like to delete? ", students.Count());
            index--;

            string answer = ConsoleIO.GetYesNoAnswerFromUser($"Are you sure you want to remove {students[index].FirstName} {students[index].LastName}. Press Y or N to proceed.");

            if (answer == "Y")
            {
                repo.Delete(index);
                Console.WriteLine("Student Removed");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            else
            {
                Console.WriteLine("Removed Cancelled");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
