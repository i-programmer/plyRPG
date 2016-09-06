using UnityEngine;
using System.Collections;
using plyGame;

[RequireComponent(typeof(ParticleSystem))]
public class LevelUpFx : MonoBehaviour {
    public bool OnlyDeactivate;

    void OnGUI() {    
        if (Input.GetKeyUp(KeyCode.Z)) {
            particleSystem.Play();
        }
    }


    void showLvlAnim() {
        particleSystem.Play();
    }
}
