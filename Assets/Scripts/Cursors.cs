using UnityEngine;

// set cursor type: attack, default or other. depends on what it is looking
public class Cursors : MonoBehaviour {
    public Texture2D[] cursorTexture;
    int cursorId = 0;

    bool changeCursor = false;
    	
    void Start() {
        Screen.showCursor = true;
	}


    public void SetCursor(CursorList name) {
        if ((int)name == 0) {
            changeCursor = false;
            Screen.showCursor = true;            
        } else {
            cursorId = (int)name;
            changeCursor = true;
            Screen.showCursor = false;
        }
    }


    void OnGUI() {        
        if (changeCursor) {
            Vector2 m = Event.current.mousePosition;
            GUI.depth = 0;
            GUI.Label(new Rect(m.x, m.y, cursorTexture[cursorId].width, cursorTexture[cursorId].height), cursorTexture[cursorId]);
        }
         
    }
}

public enum CursorList { Default, Attack, Info, Grab }