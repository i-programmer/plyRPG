using UnityEngine;
using System.Collections;

// Quest arrow follows a player
public class NavArrowFollow : MonoBehaviour {

    GameObject go;   
    public float _offset = 0;


    void LateUpdate() {
        go = GameObject.FindGameObjectWithTag("Player");
        if (go != null)
            transform.position = new Vector3(go.transform.position.x, go.transform.position.y + _offset, go.transform.position.z);
    }
}
