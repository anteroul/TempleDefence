using UnityEngine;
using System.Collections;
using System;

public interface IGameManager
{
    public static string GetType(int lvl)
    {
        switch(lvl)
        {
            case 1: return "Purepechka";
            case 2: return "Beasts";
            case 3: return "Purepechka";
            case 4: return "Aztecs";
            case 5: return "Conquistadors";
            case 6: return "Aztecs";
            case 7: return "Conquistadors";
            case 8: return "Conquistadors";
            case 9: return "Conquistadors";
            case 10: return "Alies";
            default: break;
        }

        Console.WriteLine("ERROR: Invalid level of " + lvl);
        Console.WriteLine("Game will close now.");
        return "EXIT";
    }
}