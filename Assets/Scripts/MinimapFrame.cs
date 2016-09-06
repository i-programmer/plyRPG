using UnityEngine;
using System.Collections;

public class MinimapFrame : MonoBehaviour {
   
    public Texture texture;
    public Material textureGUI;
    private float _offset;
    
    void Awake() {
        _offset = 10;
    }

    
    void OnGUI() {
       // GUI.depth = 1;

        if (Event.current.type == EventType.Repaint) {
            Graphics.DrawTexture(new Rect(Screen.width - 150 - _offset, _offset, 150, 150), texture, textureGUI);
        }
    }
}
