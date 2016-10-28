using UnityEngine;
using System.Collections;
using System;

public class CameraControl : MonoBehaviour {
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Camera transCam;

    public float speed;

    private Vector3 camTrans;
    private Quaternion camRot;
    private Camera target;
    private int startSwitch = 1;
    private int onSwitch;

    // Use this for initialization
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
        transCam.enabled = false;
    }

    // Update is called once per frame
    void Update ()
    {
        cameraSelect();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(cameraTransition(1));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(cameraTransition(2));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(cameraTransition(3));
        }
    }

    void cameraSelect()
    {
        //if user presses 1, set camera 1 to active
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("key1");
            //if camera one isn't enabled
            if (cam1.enabled != true)
            {
                //if cam2 enabled
                if (cam2.enabled == true)
                {
                    print("cam2 disabled");
                    //set transCam equal to current camera, disable current
                    transCam.transform.rotation = cam2.transform.rotation;
                    transCam.transform.position = cam2.transform.position;
                    cam2.enabled = false;
                    startSwitch = 2;
                }
                //if cam3 is enabled
                else if (cam3.enabled == true)
                {
                    print("cam3 disabled");
                    //set transCam equal to current camera, disable current
                    transCam.transform.rotation = cam3.transform.rotation;
                    transCam.transform.position = cam3.transform.position;
                    cam3.enabled = false;
                    startSwitch = 3;
                }
                //enable transCam
                transCam.enabled = true;
                print("transcam enabled");
                //cam1.enabled = true;
                //set OnSwitch to 1 to be turned on later
                onSwitch = 1;
            }
        }
        //if user presses 2, set camera 2 to active
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("key2");
            //if cam2 isn't enabled
            if (cam2.enabled != true)
            {
                //if cam1 is enabled
                if (cam1.enabled == true)
                {
                    print("cam1 disabled");
                    //set transCam equal to current camera, disable current
                    transCam.transform.rotation = cam1.transform.rotation;
                    transCam.transform.position = cam1.transform.position;
                    cam1.enabled = false;
                    startSwitch = 1;
                }
                //if cam3 is enabled
                else if (cam3.enabled == true)
                {
                    print("cam3 disabled");
                    //set transCam equal to current camera, disable current
                    transCam.transform.rotation = cam3.transform.rotation;
                    transCam.transform.position = cam3.transform.position;
                    cam3.enabled = false;
                    startSwitch = 3;
                }
                //enable transCam
                transCam.enabled = true;
                print("transcam enabled");
                //cam2.enabled = true;
                //set OnSwitch to 2 to be turned on later
                onSwitch = 2;
            }
        }
        //if user presses 3, set camera 3 to active
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("key3");
            //if cam3 is not enabled
            if (cam3.enabled != true)
            {
                //if cam1 is enabled
                if (cam1.enabled == true)
                {
                    print("cam1 disabled");
                    //set transCam equal to current camera, disable current
                    transCam.transform.rotation = cam1.transform.rotation;
                    transCam.transform.position = cam1.transform.position;
                    cam1.enabled = false;
                    startSwitch = 1;
                }
                //is cam2 is enabled
                else if (cam2.enabled == true)
                {
                    print("cam2 disabled");
                    //set transCam equal to current camera, disable current
                    transCam.transform.rotation = cam2.transform.rotation;
                    transCam.transform.position = cam2.transform.position;
                    cam2.enabled = false;
                    startSwitch = 2;
                }
                // enable transCam
                transCam.enabled = true;
                print("transcam enabled");
                //cam3.enabled = true;
                //set OnSwitch to 3 to be turned on later
                onSwitch = 3;
            }
        }
    }

    IEnumerator cameraTransition(int Switch)
    {
        print("camera Transition");
        if (startSwitch == 1)
        {
            if (Switch == 2)
            {
                print("1to2");
                //move transcam between initial and target
                while (transCam.transform.rotation.y < cam2.transform.rotation.y)
                {
                    transCam.transform.RotateAround(Vector3.zero, Vector3.up, 1 * Time.deltaTime * speed);
                    yield return new WaitForSeconds(.03f);
                }
            }
            if (Switch == 3)
            {
                print("1to3");
                while ((transCam.transform.rotation.x <  cam3.transform.rotation.x)
                    && (transCam.transform.rotation.y < cam3.transform.rotation.y))
                {
                    transCam.transform.RotateAround(Vector3.zero, Vector3.left, -1 * Time.deltaTime * speed);
                    transCam.transform.Rotate(Vector3.back * Time.deltaTime * speed);
                    yield return new WaitForSeconds(.03f);
                    print(transCam.transform.rotation.x);
                }
            }
        }
        else if (startSwitch == 2)
        {
            if (Switch == 1)
            {
                print("2to1");
                //move transcam between initial and target
                while (transCam.transform.rotation.y > cam1.transform.rotation.y)
                {
                    transCam.transform.RotateAround(Vector3.zero, Vector3.down, 1 * Time.deltaTime * speed);
                    yield return new WaitForSeconds(.03f);
                }
            }
            if (Switch == 3)
            {
                print("2to3");
                while ((transCam.transform.rotation.x < cam3.transform.rotation.x))
                {
                    transCam.transform.RotateAround(Vector3.zero, Vector3.back, 1 * Time.deltaTime * speed);
                    yield return new WaitForSeconds(.03f);
                }
            }
        }
        else if (startSwitch == 3)
        {
            if (Switch == 2)
            {
                print("3to2");
                //move transcam between initial and target
                while ((transCam.transform.rotation.x > cam2.transform.rotation.x))
                {
                    transCam.transform.RotateAround(Vector3.zero, Vector3.forward, 1 * Time.deltaTime * speed);
                    yield return new WaitForSeconds(.03f);
                }
            }
            if (Switch == 1)
            {
                print("3to1");
                while ((transCam.transform.rotation.x > cam1.transform.rotation.x)
                    && (transCam.transform.rotation.y > cam1.transform.rotation.y))
                {
                    transCam.transform.RotateAround(Vector3.zero, Vector3.left, 1 * Time.deltaTime * speed);
                    transCam.transform.Rotate(Vector3.forward * Time.deltaTime * speed);
                    yield return new WaitForSeconds(.03f);
                }
            }
        }
        //turn off transcam
        transCam.enabled = false;

        //turn on respective destination camera based on onSwitch

        if (Switch == 1)
        {
            cam1.enabled = true;
            print("cam 1 enabled");
        }
        else if (Switch == 2)
        {
            cam2.enabled = true;
            print("cam 2 enabled");
        }
        else if (Switch == 3)
        {
            cam3.enabled = true;
            print("cam 3 enabled");
        }
        yield return null;
    }
}
