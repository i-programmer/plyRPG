using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic; // Для возможности работы со списком (List)
using plyGame;

public class OpenWindow : MonoBehaviour {

    private GameObject go;
    private GameObject goMobInfo;
    private GameObject goMobInfoHP;
    private float mobHP;
    private string mobNameTemp;


	void Start () {
        go = GameObject.Find("/RPG_UI/MobInfo");

        goMobInfo = GameObject.Find("/RPG_UI/MobInfo/Name");
        goMobInfoHP = GameObject.Find("/RPG_UI/MobInfo/HP");
        go.SetActive(false);
    }
	

    void OnGUI() {
        if (Input.GetMouseButton(0)) {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10000.0f)) {
                if (hit.collider.tag == "EnemyNPC") {                    
                    goMobInfo.GetComponent<Text>().fontSize = 12;
                    mobNameTemp = hit.collider.name;                    
                    goMobInfo.GetComponent<Text>().text = mobNameTemp.Replace("(Clone)", "") + " (lvl " + hit.collider.gameObject.GetComponent<Actor>().startLevel + ")";
                    mobHP = hit.collider.gameObject.GetComponent<Actor>().actorClass.attributes[0].ConsumableValue / hit.collider.gameObject.GetComponent<Actor>().actorClass.attributes[0].Value;                                       
                    goMobInfoHP.GetComponent<Slider>().value = mobHP;                    
                    if (!go.activeSelf) {                      
                        go.SetActive(true);                       
                    }                                        
                }                
            }
        }
    }   
}
