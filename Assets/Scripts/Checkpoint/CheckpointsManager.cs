﻿using UnityEngine;

public class CheckpointsManager
{
    public TypesHolder.OnCheckpointActivatedDelegate OnCheckpointActivated;

    private GameObject CheckpointsContainerObject;



    public CheckpointsManager()
    {
        CheckpointsContainerObject = MonoBehaviour.Instantiate(new GameObject("Checkpoints"));
    }

    public void GenerateCheckpoints(int count, float startScore, float interval)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject checkpointObj = InstantiatePrefab("Checkpoint");
            checkpointObj.transform.position = new Vector3(i * interval + startScore, 0, 0);
            checkpointObj.GetComponent<Checkpoint>().OnActivated += OnCheckpointActivated;
        }
    }



    private GameObject InstantiatePrefab(string path)
    {
        GameObject obj = MonoBehaviour.Instantiate(Resources.Load(path)) as GameObject;
        obj.transform.SetParent(CheckpointsContainerObject.transform, false);
        return obj;
    }
}
