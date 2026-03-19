using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatShittyBearGame.ResourceCode
{
    [GlobalClass]
    public partial class DialogTable : Resource
    {
        [Export]
        public Godot.Collections.Array<DialogLine> Dialogs { get; set; } = new Godot.Collections.Array<DialogLine>();

        public DialogTable()
        {
        }
    }
}
