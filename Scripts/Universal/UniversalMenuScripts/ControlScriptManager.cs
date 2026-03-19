using System;
using Godot;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatShittyBearGame.Scripts.Universal.UniversalMenuScripts
{
    [GlobalClass]
    public partial class ControlScriptManager : Resource, IControlScriptManager
    {
        [Export]
        public Godot.Collections.Array<ControlScriptBit> Scripts { get; set; } = new Godot.Collections.Array<ControlScriptBit>();        
        public IEnumerable<IControlScriptBit> ScriptBits => Scripts;

        private int _currentScriptIndex = -1;
        private IControlScriptBit CurrentScript { get; set; }

        public ControlScriptManager()
        {
        }

        public void Start()
        {
            if (_currentScriptIndex != -1 || !Scripts.Any())
                return;
            _currentScriptIndex = 0;
            CurrentScript = Scripts.FirstOrDefault();
        }

        public bool Process(double delta, Control target)
        {
            if (CurrentScript == null)
                return false;
            bool scriptFinished = CurrentScript.Process(delta, target);
            if (scriptFinished)
            {
                _currentScriptIndex++;
                if (_currentScriptIndex >= Scripts.Count)
                {
                    CurrentScript = null;
                    _currentScriptIndex = -1;
                    return false;
                }
                CurrentScript = Scripts[_currentScriptIndex];               
            }

            return true;
        }
    }
}
