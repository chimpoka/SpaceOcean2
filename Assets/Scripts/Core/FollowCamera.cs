using UnityEngine;

public class FollowCamera
{
    private GameObject FollowObject;
    private Config config;
    private Camera camera;

    public FollowCamera(GameObject followObject)
    {
        config = GameInstance.Instance.Config;

        camera = Camera.main;
        camera.transform.eulerAngles = config.CameraRotation;

        FollowObject = followObject;
    }

    public void Update()
    {
        camera.transform.position = FollowObject.transform.position + config.CameraOffset;
        //camera.transform.eulerAngles = config.CameraRotation;
    }
}