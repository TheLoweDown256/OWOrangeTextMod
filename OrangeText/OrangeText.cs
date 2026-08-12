using System.Reflection;
using HarmonyLib;
using OWML.Common;
using OWML.ModHelper;

namespace OrangeText
{
    public class OrangeText : ModBehaviour
    {
        public static OrangeText Instance;

        public void Awake()
        {
            Instance = this;
            // You won't be able to access OWML's mod helper in Awake.
            // So you probably don't want to do anything here.
            // Use Start() instead.
        }

        public void Start()
        {
            // Starting here, you'll have access to OWML's mod helper.
            ModHelper.Console.WriteLine($"My mod {nameof(OrangeText)} is loaded!", MessageType.Success);

            new Harmony("TheLoweDown256.OrangeText").PatchAll(Assembly.GetExecutingAssembly());

        }




        public string ProcessText(string text)
        {


            string[] wordList = [
                "CLOCKWORK",
                "LAYERS","layered","layer","layering",

                "Bigger on the Inside",
                "Hidden in Plain Sight",

                "community","communities",

                "Escape","escaping",
                "Isolation","isolate","isolating",

                "miniature","miniaturize","miniaturizing",

                "Past",
                "Future"
            ];

            string prefix = "<color=orange>";
            string postfix = "</color>";


            for (int i = 0; i < wordList.Length; i++)
            {
                string word = wordList[i].ToLower();

                int nextStartIndex = 0;
                while (true)
                {

                    int index = text.IndexOf(word, nextStartIndex, System.StringComparison.InvariantCultureIgnoreCase);

                    if (index == -1) break;

                    string start = text.Substring(0, index);
                    string end = text.Substring(index + word.Length, text.Length-(index + word.Length));

                    string mid = text.Substring(index, word.Length); // to preserve capitalization

                    text = start + prefix + mid + postfix + end;

                    nextStartIndex = index + prefix.Length + word.Length + postfix.Length;
                }
            }


            return text;
        }
    }

}
