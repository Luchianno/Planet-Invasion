using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Zenject;

namespace Luchianno.Speech
{
    public class SpeechScreen : MonoBehaviour
    {
        List<ISpeechCommand> bindings = new List<ISpeechCommand>();

        [Inject]
        SpeechController speechController;

        protected virtual void Awake()
        {
            bindings.AddRange(GetComponentsInChildren<KeywordBinder>(false));
        }

        public void Register()
        {
            speechController.PushCommands(bindings);
        }

        public void Unregister()
        {
            speechController.Pop();
        }
    }

}