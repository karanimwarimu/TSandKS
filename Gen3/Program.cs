/* 

using ControllerDEMO.logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RunAll
{
   public static void Main(string[] args) // Capital M
     {
         ControllerDemo logic = new ControllerDemo();
         string baseIDText = logic.generateCode(); // Correct method call

         Console.WriteLine("Generated ID: " + baseIDText);

        logic.saveLeaveTypeID(baseIDText);

         Console.WriteLine("Saved");

     }


   Application.Run(new LeaveTypeSetup());
}
*/

using System;
using System.Windows.Forms;
using ControllerDEMO.form; // This should match your form's namespace

namespace ControllerDEMO.run
{
    static class Program
    {
        [STAThread]
        static void Main() 
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new leaveTypeIDTest()); 
        }
    }
}
