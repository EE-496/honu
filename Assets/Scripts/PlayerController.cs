using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(Manager.Instance.music)
            musicSource.Play();
		rb2d = GetComponent<Rigidbody2D>();
        aCount = dCount = 0;
        Debug.Log(Manager.Instance.myGlobalVar);
    }

    void Update(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.velocity = movement*speed;

        if(ReadMashedKeys(successCount)){
            Manager.Instance.successCurrentGame = 1;
        }
        else if(Manager.Instance.counter >= 10){
            Debug.Log("You Lose!");
        }
    }

    bool ReadMashedKeys(int targetPresses) {
        if (Input.GetKeyDown(KeyCode.A) && lastPressed != KeyCode.A) {
            aCount++;
            if (Manager.Instance.sound)
                soundSource.Play();
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
            Game.current.highScore++;
            Debug.Log("Highscore: " + Game.current.highScore);
        } else if (Input.GetKeyDown(KeyCode.Escape)) {
            SaveLoad.Save();
            Debug.Log("Saved! ");
        }

        if(aCount + dCount >= targetPresses){
            return true;
        }
        return false;
    } 
}
