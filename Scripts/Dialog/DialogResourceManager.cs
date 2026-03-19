using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThatShittyBearGame.ResourceCode;
using Godot;

namespace ThatShittyBearGame.Scripts.Dialog
{
    public class DialogResourceManager
    {
        private static DialogResourceManager _instance;
        public static DialogResourceManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DialogResourceManager();
                return _instance;
            }
        }

        private DialogTable DialogTable { get; set; }

        public DialogResourceManager()
        {
            DialogTable = ResourceLoader.Load<DialogTable>("res://Resources/DialogTable.tres");
        }

        public DialogLine GetRandomLine(string actor)
        {
            var actorLines = DialogTable.Dialogs.Where(d => d.Actor == actor);
            int index = GD.RandRange(0, actorLines.Count() - 1);
            return actorLines.ElementAt(index);
        }
    }
}
