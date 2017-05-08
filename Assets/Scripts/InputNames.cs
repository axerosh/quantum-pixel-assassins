using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputNames {

    private static Dictionary<string, string> inputNames = new Dictionary<string, string>();
    private static bool initialized = false;

    public static string GetName(string abbreviation)
    {
        if (!initialized)
        {
            InputNames.Init();
        }
        return inputNames[abbreviation];
    }

    private static void Init()
    {
        inputNames.Add("accept", "Continue");
        inputNames.Add("cancel", "Back");
        inputNames.Add("menu", "Menu");
        inputNames.Add("green", "Turn Green");
        inputNames.Add("red", "Turn Red");

        inputNames.Add("p1 interact key", "P1: Interact/Erase (Key/Button)");
        inputNames.Add("p1 horizontal key", "P1: Move X (Key/Button)");
        inputNames.Add("p1 vertical key", "P1: Move Y (Key/Button)");
        inputNames.Add("p1 interact axis", "P1: Interact/Erase (Analog)");
        inputNames.Add("p1 horizontal axis", "P1: Move X (Analog)");
        inputNames.Add("p1 vertical axis", "P1: Move Y (Analog)");

        inputNames.Add("p2 interact key", "P2: Interact/Erase (Key/Button)");
        inputNames.Add("p2 horizontal key", "P2: Move X (Key/Button)");
        inputNames.Add("p2 vertical key", "P2: Move Y (Key/Button)");
        inputNames.Add("p2 interact axis", "P2: Interact/Erase (Analog)");
        inputNames.Add("p2 horizontal axis", "P2: Move X (Analog)");
        inputNames.Add("p2 vertical axis", "P2: Move Y (Analog)");

        initialized = true;
    }
}
