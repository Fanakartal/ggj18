using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController {

    private Camera cam;
    public static float dump = 1 ,aDump = 1;
    float aLerpAxisY;
    float lerpAxisX;

    public void CameraLerp(Transform gameObject)
    {
        cam = Camera.main;

        if (cam.transform.position.x + 5 != gameObject.transform.position.x) ;
            lerpAxisX = Mathf.Lerp(cam.transform.position.x, gameObject.transform.position.x, dump * Time.deltaTime);

        cam.transform.position = new Vector3(lerpAxisX+1, cam.transform.position.y , cam.transform.position.z);


        //cam.transform.position = Vector3.Lerp(cam.transform.position, gameObject.transform.position, dump * Time.deltaTime);
        //cam.transform.position = new Vector3(cam.transform.position.x, 
        //                                     cam.transform.position.y,
        //                                     gameObject.transform.position.z - 100);
       // Debug.Log(cam.name.ToString())

        //cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, gameObject.transform.rotation, aDump*0.1f * Time.deltaTime);
        
        //if(cam.transform.rotation.y != gameObject.transform.rotation.y)
        //    aLerpAxisY = Mathf.Lerp(cam.transform.rotation.y , gameObject.transform.rotation.y , aDump * Time.deltaTime);

        //cam.transform.rotation = new Quaternion(cam.transform.rotation.x, aLerpAxisY, cam.transform.rotation.z, cam.transform.rotation.w);

    }



}
