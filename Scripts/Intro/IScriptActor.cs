using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatShittyBearGame.Scripts.Intro
{
    public interface IScriptActor
    {
        bool InProgress { get; }

        void StartActorScript(string scriptName, Action scriptEndCallback);
    }
}
