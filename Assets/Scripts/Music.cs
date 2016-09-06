using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour 
{

    public AudioClip[] audioFiles;
    public bool DestroyOnLoad = false;
    public KeyCode changeSongKey;
    public int StartUpSong = -1;

    private bool waited = true;
    private int songPlaying = 0;

	private void Start ()
    {
        if (!DestroyOnLoad)
            DontDestroyOnLoad(gameObject);

        gameObject.AddComponent<AudioSource>();
        audio.playOnAwake = false;
        audio.volume = 0.3f;
        if (StartUpSong != -1)
        {
            audio.clip = audioFiles[StartUpSong];
            audio.Play();
            songPlaying = StartUpSong;
        }
	}
	

	private void Update ()
    {
	    if(!audio.isPlaying && audioFiles.Length > 0)
        {
            //int rand = UnityEngine.Random.Range(0,audioFiles.Length);
            audio.clip = audioFiles[songPlaying];
           // songPlaying = rand;
            audio.Play();
            songPlaying++;
            if (songPlaying > audioFiles.Length - 1) {
                songPlaying = 0;
            }
        }

        if (Input.GetKey(changeSongKey) && waited)
        {
            audio.Stop();

            if (audio.clip == audioFiles[audioFiles.Length])
            {
                audio.clip = audioFiles[1];
                songPlaying = 1;
            }
            else
            {
                songPlaying++;
                audio.clip = audioFiles[songPlaying];
            }

            audio.Play();

            waited = false;
            Invoke("waiting" , 0.3f);
        }
	}

    private void waiting()
    {
        waited = true;
    }


    public void StartMusic() {
        audio.Play();
    }

    public void StopMusic() {
        audio.Stop();
    }
}
