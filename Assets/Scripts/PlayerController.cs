using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float speed;
    public int successCount;
    private Rigidbody2D rb2d;
	public AudioClip musicClip;
	public AudioSource musicSource;
    public AudioClip soundClip;
    public AudioSource soundSource;

    private KeyCode lastPressed = KeyCode.W;
    private int aCount;
    private int dCount;

    void Start(){
		musicSource.clip = musicClip;
        soundSource.clip = soundClip;
        if(Manager.Instance.music) musicSource.Play();
		rb2d = GetComponent<Rigidbody2D>();
        aCount = dCount = 0;
        Manager.Instance.activeMiniGame = Random.Range(0, Constants.miniGameCount);
    }

    void Update(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.velocity = movement*speed;

        if(ReadMashedKeys(successCount)){
            Manager.Instance.successCurrentGame = 1;
        }
        else if(Manager.Instance.counter >= Constants.timeForGame){
            SceneManager.LoadScene("GameOver");
        }
    }

    bool ReadMashedKeys(int targetPresses) {
        if (Input.GetKeyDown(KeyCode.A) && lastPressed != KeyCode.A) {
            aCount++;
            if (Manager.Instance.sound) soundSource.Play();
            Debug.Log("A " + aCount);
            lastPressed = KeyCode.A;
        }
        else if(Input.GetKeyDown(KeyCode.D) && lastPressed != KeyCode.D) {
            dCount++;
			if (Manager.Instance.sound)
				soundSource.Play();
            Debug.Log("D " + dCount);
            lastPressed = KeyCode.D;
        } else if (Input.GetKeyDown(KeyCode.W)) {
            aCount++;
        }

        if(aCount + dCount >= targetPresses){
            return true;
        }
        return false;
    } 
}
