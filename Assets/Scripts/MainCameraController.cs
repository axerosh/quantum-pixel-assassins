using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCameraController : MonoBehaviour {

    public AudioClip[] sounds;
    private AudioSource soundPlayer;

    public AudioClip music;

    public float zoom = 0.8f;
    public float zoomRotation = 14;

    public float waitTime = 0.8f;

    public int zoomSteps = 3;

    public float musicVol = 1;
    public float effectVol = 1;

    Camera cameraComp;

    private bool inAnimation = false;

	// Use this for initialization
	void Start () {
        cameraComp = GetComponent<Camera>();
        soundPlayer = GetComponent<AudioSource>();

        soundPlayer.clip = music;
        soundPlayer.loop = true;
        soundPlayer.volume = musicVol;
        soundPlayer.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpotPlayer(GameObject player)
    {
        if (!inAnimation)
        {
            inAnimation = true;
            StartCoroutine(spotAnimation(player));
        }
    }

    public void stopMusic()
    {
        soundPlayer.Stop();
    }

    public IEnumerator spotAnimation(GameObject player)
    {
        //Stop music
        soundPlayer.Stop();
        soundPlayer.volume = effectVol;

        //Stop all players from moving
        foreach (GameObject playerInstance in GameObject.FindGameObjectsWithTag("Player"))
        {
            playerInstance.GetComponent<PlayerController>().preventMove();
        }

        for (int i = 0; i < zoomSteps; i++)
        {
            soundPlayer.PlayOneShot(sounds[i]);

            Vector3 diff = player.transform.position - transform.position;
            diff.z = 0;
            transform.SetPositionAndRotation(transform.position + (diff/2), transform.rotation);

            cameraComp.orthographicSize = cameraComp.orthographicSize*zoom;

            if (i == 0)
            {
                transform.Rotate(new Vector3(0, 0, zoomRotation));
            }
            else if(i % 2 == 0)
            {
                transform.Rotate(new Vector3(0, 0, 2*zoomRotation));
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, 2*zoomRotation) * -1);
            }

            yield return new WaitForSeconds(waitTime);
        }

        yield return new WaitForSeconds(2*waitTime);

        //Reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
