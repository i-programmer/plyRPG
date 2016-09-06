using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

    private KGFMapSystem itsKGFMapSystem;

    private GameObject _player;
    private GameObject _tempCamera;
    private GameObject _enemies;

    public Texture2D _radarMain;
    public Texture2D _radarLoading;

    private bool _tmpCameraVisible = true;
    private bool _mapIsLoaded = false;
   
    public void Awake() {
        
    }

    public void Start() {
        itsKGFMapSystem = KGFAccessor.GetObject<KGFMapSystem>();    //get the KGFMapSystem by using the KGFAccessor class
        
        _player = GameObject.FindGameObjectWithTag("Player");
        if (itsKGFMapSystem != null && _player != null) {
            itsKGFMapSystem.SetTarget(_player);
        }
    }


    public void Update() {
        if (itsKGFMapSystem.tempCameraStatus == 1) {
            if (_tmpCameraVisible) {
                _tempCamera = GameObject.Find("TempCamera");
                if (_tempCamera != null) {
                    if (!_mapIsLoaded) {
                       // Debug.Log("Here need to show label 'loading' on map");
                    }
                } else {
                    UISprite radar = GameObject.Find("KGFMapSystemNGUI/Camera/Anchor_minimap/Panel/Sprite").GetComponent<UISprite>();
                    radar.spriteName = "RadarAll2";
                    _tmpCameraVisible = false;
                    _player = GameObject.FindGameObjectWithTag("Player");
                    if (itsKGFMapSystem != null && _player != null) {
                        itsKGFMapSystem.SetTarget(_player);
                    }                   
                }
            }
        }
    }
}
