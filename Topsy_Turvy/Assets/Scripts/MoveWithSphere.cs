using UnityEngine;
using System.Collections;

public class MoveWithSphere : MonoBehaviour {
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(Vector3.left * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime);
        }
    }
    
    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Sphere"))
        {
            Vector3 newPos = new Vector3(gameObject.transform.position.x, other.gameObject.transform.position.y, gameObject.transform.position.z);
            other.gameObject.transform.position = newPos;
        }
        
    }
}
