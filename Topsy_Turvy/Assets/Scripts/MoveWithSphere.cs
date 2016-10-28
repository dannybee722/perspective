using UnityEngine;
using System.Collections;

public class MoveWithSphere : MonoBehaviour {

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
       
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Sphere")
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                other.rigidbody.AddForce(Vector3.up * 100);
                this.gameObject.transform.Translate(Vector3.up * Time.deltaTime);
            }
        }
        
    }
}
