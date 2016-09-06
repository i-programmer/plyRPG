using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// enemies highlighting
public class OnMouseAction : MonoBehaviour {

    public GameObject go;    
    Shader _shader_1, _shader_2, goShader;
    bool playerIsInstantiated = false;
    bool isFocused = false;

    Cursors _playerCursors;
    

	void Start () {            
        goShader = Resources.Load("DiffuseRim") as Shader;
	}
	
	
	void Update() {
        if (!playerIsInstantiated) {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) {
                playerIsInstantiated = true;
                _shader_1 = go.renderer.sharedMaterial.shader;
            }
        }
    }


    void OnMouseOver() {        
        if (this.tag == "EnemyNPC")
            GameObject.FindGameObjectWithTag("Player").GetComponent<Cursors>().SetCursor(CursorList.Attack);

        go.renderer.material.shader = goShader;
        go.renderer.material.SetColor("_Color", new Color(0.47f, 0.47f, 0.47f));
        
        GetComponent<objText>().ShowNameIco(true);
    }


    void OnMouseExit() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Cursors>().SetCursor(CursorList.Default);
        go.renderer.material.shader = _shader_1;
        go.renderer.material.SetColor("_Color", new Color(1, 1, 1));

        if (!isFocused) {
            GetComponent<objText>().ShowNameIco(false);
        }
        
    }


    public void SetFocus(bool flag) {
        isFocused = flag;
    }    
}
