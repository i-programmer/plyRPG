using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
    public float yOffset = 16;
    public Color textColor = Color.cyan;
    public int fontSize = 12;

    private void OnDrawGizmos()
    {
        GizmosUtils.DrawText(GUI.skin, "Custom text", transform.position, textColor, fontSize, yOffset);
    }
}
