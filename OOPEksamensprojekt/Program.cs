using System;
using OOPEksamensprojekt.Controller;
using OOPEksamensprojekt.Core;
using OOPEksamensprojekt.UI;

namespace OOPEksamensprojekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Stregsystem stregsystem = new Stregsystem();
            StregsystemCLI ui = new StregsystemCLI(stregsystem);
            StregsystemController controller = new StregsystemController(stregsystem, ui);
            ui.Start();
            
        }
    }
}