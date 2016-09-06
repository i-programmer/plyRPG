using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

    public RenderTexture minimapTexture;
    public Material minimapMaterial;
    private float _offset;

	// Use this for initialization
	void Awake() {
        _offset = 10;
	}
	
	// Update is called once per frame
	void OnGUI() {
       // GUI.depth = 2;

        if (Event.current.type == EventType.Repaint) {
            Graphics.DrawTexture(new Rect(Screen.width - 150 - _offset, _offset, 150, 150), minimapTexture, minimapMaterial);
        }
	}
}
