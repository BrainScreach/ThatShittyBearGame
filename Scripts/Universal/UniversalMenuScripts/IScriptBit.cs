using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatShittyBearGame.Scripts.Universal.UniversalMenuScripts
{
    public interface IControlScriptBit
    {
        public bool Process(double delta, Control target);
    }

    public interface IControlScriptManager
    {
        public IEnumerable<IControlScriptBit> ScriptBits { get; }
        public void Start();
        public bool Process(double delta, Control target);
    }
}
