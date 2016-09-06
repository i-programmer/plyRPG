using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	private NavMeshAgent _agent;
	private Vector3 _target;
	private bool _b_target = false;
	
	public AnimationClip a_Idle;
	public float a_IdleSpeed = 1;
	public AnimationClip a_Walk;
	public float a_WalkSpeed = 2;

	void Start () {
		_agent = gameObject.GetComponent<NavMeshAgent>();
		
		animation[a_Idle.name].speed = a_IdleSpeed;
		animation[a_Walk.name].speed = a_WalkSpeed;
		animation.CrossFade(a_Idle.name);
	}
	

	void Update () {
        if (Input.GetMouseButtonDown(0)) {            
            Ray _ray;
            RaycastHit _hit;

            _ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit, 10000.0f)) {
                _target = _hit.point;
                _b_target = true;
            }
        }
		
		if(_b_target) {            
			if(Vector3.Distance(_target, transform.position) > 1.5f) {
                GetComponent<plyGame.PlayerTopDownController>().enabled = false;
				_agent.SetDestination(_target);
				animation.CrossFade(a_Walk.name);
			} else {
				_agent.Stop();
                
				animation.CrossFade(a_Idle.name);
				_b_target = false;
			}
        }
	}
}
