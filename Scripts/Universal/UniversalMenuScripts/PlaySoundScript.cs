using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatShittyBearGame.Scripts.Universal.UniversalMenuScripts
{
    [GlobalClass]
    public partial class PlaySoundScript : ControlScriptBit
    {
        [Export]
        public string SoundPlayerName { get; set; }

        private AudioStreamPlayer2D _audioPlayer;

        public override bool Process(double delta, Control target)
        {
            if(State == GenericScriptState.Initial)
            {
                _audioPlayer = target.GetChildren().OfType<AudioStreamPlayer2D>().FirstOrDefault(p => p.Name == SoundPlayerName);
                _audioPlayer?.Play();
                State = GenericScriptState.Running;
            }
            bool ended = _audioPlayer == null ? true : !_audioPlayer.Playing;
            if (ended)
                State = GenericScriptState.Initial;
            return ended;
        }
    }
}
