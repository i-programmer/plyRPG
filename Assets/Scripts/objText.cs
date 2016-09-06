using UnityEngine;
using System.Collections;

// Mobs name showing depend on distance 
public class objText : MonoBehaviour {    
    public string objectName;
    public Texture aTexture;

    public Transform target;
    public Vector3 screenPos;
    public int guiDepth = 1;
    
    private bool _showName = false;
    private bool _showNameIco = false;

    public void Awake() {
        // если имя не указано, то отображаем имя объекта сцены
        if (string.IsNullOrEmpty(objectName)) {
            objectName = name.Replace("(Clone)", "");            
        }
    }


    void Update() {     
        // позиция относительно камеры
        Vector3 cameraRelative = Camera.main.transform.InverseTransformPoint(transform.position);
        // если z>0, то точка находится перед камерой
        if (cameraRelative.z > 0) {
            screenPos = Camera.main.WorldToScreenPoint(target.position);
        }
    }


    void OnGUI() {
        if (_showName && guiDepth > 0) {
            GUI.depth = guiDepth;

            GUIStyle style = new GUIStyle();
            style.fontSize = 11;
            style.normal.textColor = Color.white;
            style.alignment = TextAnchor.MiddleCenter;

            GUI.Label(new Rect(screenPos.x, Screen.height - screenPos.y, 10, 10), objectName, style);
            if (_showNameIco) {
                GUI.DrawTexture(new Rect(screenPos.x - 44, Screen.height - screenPos.y - 3, 100, 16), aTexture, ScaleMode.ScaleToFit);
            }
        }
    }


    public void ShowName(bool flag) {
        _showName = flag;
    }


    public void ShowNameIco(bool flag) {
        _showNameIco = flag;
    }
}

