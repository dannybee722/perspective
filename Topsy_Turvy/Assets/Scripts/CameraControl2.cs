using UnityEngine;
using System.Collections;

public class CameraControl2 : MonoBehaviour {

    //establishes three cameras and a fourth for the movement transition
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    private Camera transCam;
    public GameObject centerObj;

    private Camera startCam;
    private Camera current;
    private Camera target;
    private Vector3 center; 

    private bool isMoving = false;

    //slerp stuff
    public float journeyTime = 1.0f;

    void Awake()
    {
        center = centerObj.transform.position;
        transCam = gameObject.GetComponent<Camera>();

        transCam.transform.rotation = cam1.transform.rotation;
        transCam.transform.position = cam1.transform.position;
        transCam.orthographicSize = cam1.orthographicSize;

        cam1.enabled = false;
        cam2.enabled = false;
        cam3.enabled = false;
        transCam.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && transCam.transform.position != cam1.transform.position)
            {
                StartCoroutine(cameraTransition(cam1));
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && transCam.transform.position != cam2.transform.position)
            {
                StartCoroutine(cameraTransition(cam2));
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && transCam.transform.position != cam3.transform.position)
            {
                StartCoroutine(cameraTransition(cam3));
            }
        }
    }

    IEnumerator cameraTransition(Camera target)
    {
        isMoving = true;
        float startTime = Time.time;

        Vector3 startCenter = transCam.transform.position;
        float startSize = transCam.orthographicSize;
        Vector3 endCenter = target.transform.position;

        //move transcam between initial and target
        while (Time.time - startTime <= journeyTime)
        {
            float fracComplete = (Time.time - startTime) / journeyTime;
            transCam.transform.position = Vector3.Slerp(startCenter, endCenter, fracComplete);
            transCam.transform.LookAt(center);
            transCam.orthographicSize = Mathf.Lerp(startSize, target.orthographicSize, fracComplete);
            yield return new WaitForEndOfFrame();
        }
        transCam.transform.position = target.transform.position;
        transCam.transform.LookAt(center);

        isMoving = false;
    }
}
