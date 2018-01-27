using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drive : MonoBehaviour 
{
    [Range(0, 10)]
    public float _dump;
    [Range(0, 10)]
    public float _aDump;

    public GameObject gObj;
    CameraController cameraLerp;

    void Awake()
    {
        cameraLerp  = new CameraController();
    }

    //So easy peasy :))
	void Update()
    {
        CameraController.dump = _dump;
        CameraController.aDump = _aDump;

        if(gObj != null)
            cameraLerp.CameraLerp(gObj.transform);
    }
}
