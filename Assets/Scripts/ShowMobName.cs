using UnityEngine;
using System.Collections;

public class ShowMobName : MonoBehaviour {

    void OnTriggerEnter(Collider collision) {
        if (collision.tag == "GirlNPC" || collision.tag == "EnemyNPC") {
            collision.gameObject.GetComponent<objText>().ShowName(true);
        }
	}


    void OnTriggerStay(Collider collision) {
        if (collision.tag == "GirlNPC" || collision.tag == "EnemyNPC") {
            collision.gameObject.GetComponent<objText>().ShowName(true);
        }
    }

    void OnTriggerExit(Collider collision) {
        if (collision.tag == "GirlNPC" || collision.tag == "EnemyNPC") {
            collision.gameObject.GetComponent<objText>().ShowName(false);
        }
    }
}
