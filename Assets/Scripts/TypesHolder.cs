public class TypesHolder
{
    public enum ControllerMode {Touchscreen, Accelerometer};
    public enum PlayMode { Normal, Tutorial};

    public delegate void OnCheckpointActivatedDelegate(Checkpoint checkpoint);
}
