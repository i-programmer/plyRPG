using UnityEngine;
using System.Collections;

public class ReplaceMouseActions : MonoBehaviour {

    public GameObject hoveredGO;

    void Update() {
        RaycastHit hitInfo = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // OnMouseDown
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hitInfo)) {
                hitInfo.collider.SendMessage("OnMouseDown", SendMessageOptions.DontRequireReceiver);
            }
        }

        // OnMouseUp
        if (Input.GetMouseButtonUp(0)) {
            if (Physics.Raycast(ray, out hitInfo)) {
                hitInfo.collider.SendMessage("OnMouseUp", SendMessageOptions.DontRequireReceiver);
            }
        }

        // OnMouseOver
        if (Physics.Raycast(ray, out hitInfo)) {            
            hitInfo.collider.SendMessage("OnMouseOver", SendMessageOptions.DontRequireReceiver);
        }

        // OnMouseEnter
        if (Physics.Raycast(ray, out hitInfo)) {
            if (hitInfo.collider.gameObject != hoveredGO) {
                if (hoveredGO != null) {
                    hoveredGO.SendMessage("OnMouseExit", SendMessageOptions.DontRequireReceiver);
                }
                hitInfo.collider.SendMessage("OnMouseEnter", SendMessageOptions.DontRequireReceiver);
                hoveredGO = hitInfo.collider.gameObject;
            }
        }
    }
}
