using UnityEngine;
using Zenject;

namespace Luchianno.Speech
{
    public class SpeechInstaller : MonoInstaller<SpeechInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<SpeechController>().AsSingle();
        }
    }
}