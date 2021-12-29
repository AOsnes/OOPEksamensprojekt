using OOPEksamensprojekt.Core;
using OOPEksamensprojekt.UI;

namespace OOPEksamensprojekt.Controller
{
    public class StregsystemController
    {
        private IStregsystemUI _ui;
        private IStregsystem _stregsystem;
        public CommandParser Parser { get; }

        public StregsystemController(IStregsystem stregsystem, IStregsystemUI ui)
        {
            _stregsystem = stregsystem;
            _ui = ui;

            Parser = new CommandParser(_stregsystem, _ui);

            _ui.CommandEntered += Parser.ParseInput;
        }


        
        
        
        
        
        
    }
}