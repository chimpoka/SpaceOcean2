using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudBase : MonoBehaviour
{
    private static HudBase instance = null;
    public static HudBase Instance
    {
        get
        {
            if (!instance)
            {
                print("Hud do not exist on scene");
                return null;
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }
}
