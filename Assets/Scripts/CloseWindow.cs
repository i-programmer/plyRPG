using UnityEngine;
using System.Collections;

// Closing "MobInfo" window
public class CloseWindow : MonoBehaviour {
    GameObject go;
    Transform target;
    public Camera cam;
    public float x;
    public float y;
    BoxCollider boxCollider;
	
	void Start () {
        go = GameObject.Find("/RPG_UI/MobInfo");
        boxCollider = gameObject.GetComponent<BoxCollider>();
	}
	
	
    void OnGUI() {
        if (Input.GetMouseButton(0)) {    
            x = boxCollider.size.x;
            y = boxCollider.size.y;            
            if (Input.mousePosition.x >= transform.position.x - x / 2 && Input.mousePosition.x < transform.position.x + x / 2 &&
                Input.mousePosition.y >= transform.position.y - y / 2 && Input.mousePosition.y < transform.position.y + y / 2) {
                go.SetActive(false);
            }
        }
    }
}
