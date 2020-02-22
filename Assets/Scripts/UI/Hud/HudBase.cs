﻿using UnityEngine;

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



    public GameObject InstantiateUIPrefab(string path)
    {
        GameObject obj = Instantiate(Resources.Load(path)) as GameObject;
        obj.transform.SetParent(gameObject.transform, false);
        return obj;
    }

    public GameObject InstantiateUIPrefab(GameObject prefab, Transform parent)
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.SetParent(parent, false);
        return obj;
    }
}
