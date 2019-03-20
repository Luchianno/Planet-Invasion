using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Windows.Speech;
using static UnityEngine.Windows.Speech.PhraseRecognizer;
using System.Linq;

namespace Luchianno.Speech
{
    public class SpeechController
    {
        Stack<Pair> stack = new Stack<Pair>();

        public void PushCommands(List<ISpeechCommand> commands)
        {
            if (stack.Count != 0)
                stack.Peek().Recognizer.Stop();
            // TODO pooling
            var dict = new Dictionary<string, PhraseRecognizedDelegate>();
            foreach (var command in commands)
            {
                foreach (var alias in command.Keywords)
                {
                    dict.Add(alias, command.OnPhraseRecognized);
                }
            }

            var recognizer = new KeywordRecognizer(dict.Keys.ToArray());
            recognizer.OnPhraseRecognized += PhraseRecognized;
            stack.Push(new Pair(recognizer, dict));
            recognizer.Start();

            Debug.Log($"Pushed commands: {string.Join(",", dict.Keys)}");
        }

        private void PhraseRecognized(PhraseRecognizedEventArgs args)
        {
            Debug.Log($"Speech Recognized: {args.text}");
            stack.Peek().Bindings[args.text].Invoke(args);
        }

        public void Pop()
        {
            if (stack.Count == 0)
            {
                return;
            }
            var temp = stack.Pop();
            temp.Recognizer.Stop();
            temp.Recognizer.Dispose();
        }

        class Pair
        {
            public Pair(KeywordRecognizer recognizer, Dictionary<string, PhraseRecognizedDelegate> dict)
            {
                this.Recognizer = recognizer;
                this.Bindings = dict;
            }
            public KeywordRecognizer Recognizer { get; private set; }
            public Dictionary<string, PhraseRecognizedDelegate> Bindings { get; private set; }
        }

        // TODO https://stackoverflow.com/questions/11496514/speech-recognition-dictation-of-numbers-only-c-sharp
        // readonly string[] numbers = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
    }
}