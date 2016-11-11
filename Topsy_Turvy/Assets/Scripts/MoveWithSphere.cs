using UnityEngine;
using System.Collections;

public class MoveWithSphere : MonoBehaviour {
    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void Update () {
        if (Camera.allCameras[0].tag.Equals("Cam1") && gameObject.tag.Equals("Plat1"))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.transform.Translate(Vector3.left * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.transform.Translate(Vector3.right * Time.deltaTime);
            }
        }
        if (Camera.allCameras[0].tag.Equals("Cam2") && gameObject.tag.Equals("Plat2"))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.transform.Translate(Vector3.back * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
            }
        }
    }
    
    void OnCollisionStay(Collision other)
    {
        if(Camera.allCameras[0].tag.Equals("Cam1") && other.gameObject.CompareTag("Sphere"))
        {
            Vector3 newPos = new Vector3(gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
            other.gameObject.transform.position = newPos;
        }
        if (Camera.allCameras[0].tag.Equals("Cam2") && other.gameObject.CompareTag("Sphere"))
        {
            Vector3 newPos = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, gameObject.transform.position.z);
            other.gameObject.transform.position = newPos;
        }

    }
}
