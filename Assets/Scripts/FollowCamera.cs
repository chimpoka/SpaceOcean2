using UnityEngine;

public class FollowCamera
{
    public GameObject FollowObject;
    private Camera cam;

    public FollowCamera(GameObject followObject)
    {
        cam = Camera.main;
        FollowObject = followObject;
    }

    public void Update()
    {
        cam.transform.position = FollowObject.transform.position;
        cam.transform.Translate(0, 0, -10);
    }
}