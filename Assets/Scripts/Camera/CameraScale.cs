using UnityEngine;
using System.Collections;

public class CameraScale : MonoBehaviour {

    public int PixelsToUnits = 1;
    public int scale = 1;

    void Awake()
    {
        var camera = GetComponent<Camera>();
        scale = Screen.height / 480;
        PixelsToUnits *= scale;
        camera.orthographicSize = Screen.height / 2 / PixelsToUnits;
    }
}
