using UnityEngine;
using System.Collections;

public class Cursor_old : MonoBehaviour {

    public Texture2D mouseTexture;    

    void OnGUI() {
        Vector2 m = Event.current.mousePosition;
        GUI.depth = 0;
        GUI.Label(new Rect(m.x, m.y, mouseTexture.width, mouseTexture.height), mouseTexture);
    }
}
