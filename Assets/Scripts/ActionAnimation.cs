using UnityEngine;
using System.Collections;

public class ActionAnimation : MonoBehaviour {
	public Texture2D Static_cursor;
	public Texture2D[] Cursors;
	private int i;
	public float TimerChange;
	private Texture2D cur;
	public bool UseStaticCursor;
	private float TimerDown;

	void Start () {        
		TimerDown = TimerChange;
		if(!UseStaticCursor)
		cur = Cursors[i];
	}
	

	void Update () {
		if(i >= Cursors.Length)
		{
			i = 0;
			
		}
	}


    void SetTimerInterval(float timeChange) {
        TimerChange = timeChange;
        TimerDown = timeChange;
    }
	
	
	void OnGUI()
	{
		Vector2 MP = Input.mousePosition;
		MP.y = Screen.height - MP.y;
		MP.x -= 5;
		MP.y -= 5;
		if(UseStaticCursor)
		{
		GUI.DrawTexture(new Rect(MP.x,MP.y, 32,32), Static_cursor);	
		}
		else
		{
            UITexture texture = gameObject.GetComponent<UITexture>();
            texture.mainTexture = cur;

			TimerDown -= Time.deltaTime;
			if(TimerDown <= 0)
			{
                if (i == Cursors.Length - 1) {
                    texture.mainTexture = Cursors[Cursors.Length - 1];
                    enabled = false;                    
                }

				cur = Cursors[i];
				i++;
				TimerDown = TimerChange;
			}            
		}
	}
}
