using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Shows enemy hp in realtime
public class OnSkillHit : MonoBehaviour {
    
    private GameObject goMobInfo;

	// Use this for initialization
	void Start () {
        goMobInfo = GameObject.Find("/RPG_UI/MobInfo/HP");
	}


    void MobHP(float dmg) {
        goMobInfo.GetComponent<Slider>().value = dmg;        
    }


    void OnMobsDeath() {
        GameObject go = GameObject.Find("/RPG_UI/MobInfo");
        go.SetActive(false);
    }
}
