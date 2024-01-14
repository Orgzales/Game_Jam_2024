using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Home; //where you want your camera to stay
    public Transform Target; //where you want your camera to go
    public Transform ViewTarget; //what you want your camera to keep looking at

    public Trader traderscript;
    bool IsLooking = false;
    Vector3 ViewPos;
    Vector3 CamPos;
    void Start()
    {
        ViewPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        CamPos = Vector3.MoveTowards(transform.position, ViewPos, 1f * Time.deltaTime);
        transform.position = CamPos;
        transform.LookAt(ViewTarget);
        Debug.Log(traderscript.CameraToWindow);

        if (traderscript.CameraToWindow) //from trader close window /open script
        {
            if (IsLooking == false)
            {
                IsLooking = true;
                ViewPos = Target.transform.position;
            }

        }
        if (!traderscript.CameraToWindow)
        {
            if (IsLooking == true)
            {
                IsLooking = false;
                ViewPos = Home.transform.position;
            }
        }


    }

}
