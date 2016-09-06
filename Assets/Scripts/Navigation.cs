using UnityEngine;
using System.Collections;

// Quest arrow rotation depends on what enemies player should kill
public class Navigation : MonoBehaviour {

    private Transform target;
    private string targetName = "";
    private int minDistance = 50; // Минимальная дистанция, до которой можно приблизиться до игрока
    private int minDistanceBuff = 50;
    public int moveSpeed;
    public int rotationSpeed = 1;
    

    private Transform _eTransform;
    private Renderer _eRender;
    GameObject gObj;
    void Awake() {
        _eTransform = transform;
    }


    void Start() {       
        gObj = GameObject.Find("arrow(anoter_pivot_point)");
        gObj.SetActive(false);
    }


    void Update() {        
        // Поворот
        if (target != null) {
            _eTransform.rotation = Quaternion.Slerp(_eTransform.rotation, Quaternion.LookRotation(target.position - _eTransform.position), rotationSpeed * Time.deltaTime);
            // Если дистанция больше, чем нужно для нанесения удара, то двигаемся к цели
            if (Vector3.Distance(target.position, _eTransform.position) >= minDistance) {
                _eTransform.position += _eTransform.forward * moveSpeed * Time.deltaTime;
                gObj.SetActive(true);
            } else {
                gObj.SetActive(false);
            }
        } else {
            gObj.SetActive(false);
        }
    }


    void GetTarget() {

    }


    void SetTarget(string name) {
        targetName = name;
        if (targetName == "GirlNpc") {
            minDistance = 5;
        } else {
            minDistance = minDistanceBuff;
        }
        GameObject go = GameObject.Find(targetName);

        target = go.transform;
    }
}
