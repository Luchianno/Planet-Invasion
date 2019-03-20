using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using static UnityEngine.Windows.Speech.PhraseRecognizer;

namespace Luchianno.Speech
{
    [RequireComponent(typeof(Button))]
    public class KeywordBinder : MonoBehaviour, ISpeechCommand
    {

        public PhraseRecognizedDelegate OnPhraseRecognized => OnRecognized;

        public List<string> Keywords { get { return keywords; } }


        [SerializeField]
        List<string> keywords;

        Button button;

        void Awake()
        {
            this.button = GetComponent<Button>();
        }

        public void OnRecognized(PhraseRecognizedEventArgs args)
        {
            if (button.isActiveAndEnabled)
                button.onClick.Invoke();
        }
    }
}
