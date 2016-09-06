using UnityEngine;
using System.Collections;

public class CameraFollowing : MonoBehaviour {

    GameObject go;
    Transform _transform;
	
	void Start () {
        go = GameObject.FindGameObjectWithTag("Player");
        _transform = transform;
	}
	
	
	void LateUpdate () {
        transform.position = new Vector3(go.transform.position.x, _transform.transform.position.y, go.transform.position.z);
	}
}
