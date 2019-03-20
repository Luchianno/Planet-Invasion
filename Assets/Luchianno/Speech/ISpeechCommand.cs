using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Windows.Speech.PhraseRecognizer;

namespace Luchianno.Speech
{
    public interface ISpeechCommand
    {
        PhraseRecognizedDelegate OnPhraseRecognized { get; }
        List<string> Keywords { get; }
    }
}