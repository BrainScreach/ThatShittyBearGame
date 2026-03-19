using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace ThatShittyBearGame.ResourceCode
{
    [GlobalClass]
    public partial class DialogLine : Resource
    {
        [Export]
        public string Actor { get; set; }
        [Export]
        public string ActorName { get; set; }
        [Export(PropertyHint.MultilineText)]
        public string Line { get; set; }

        public DialogLine() : this(string.Empty, string.Empty, string.Empty) { }
        public DialogLine(string actor, string actorName, string line)
        {
            Actor = actor;
            ActorName = actorName;
            Line = line;
        }
    }
}
