using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class healthandwinloss : MonoBehaviour {

    public Text healthText;
    public Text endText;
    public Text scoreText;
    public int health;

    public int score;
    public FirstPersonController player;
    public AudioSource m_startup;
    public AudioSource m_dead;
    public AudioSource m_collect;
    public AudioSource m_damage;
    private AudioSource source;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        health = 100;
        healthText.text = "Health: " + health;
        endText.text = "";
        scoreText.text = "Score: " + score;
        source = GetComponent<AudioSource>();
        source = m_startup;
        source.Play();
	}
	
	// Update is called once per frame
	void Update () {
        CheckLose();
	}

    void CheckLose()
    {
        healthText.text = "Health: " + health;
        if (health == 0)
        {
            Time.timeScale = 0;
            endText.text = "You have lost all your health! Press R to Restart!";
            source = m_dead;
            source.Play();
        }
        if(player.transform.position.y <= -1){
            Time.timeScale = 0;
            endText.text = "You have fallen out of the map! Press R to Restart!";
            health = 0;
            source = m_dead;
            source.Play();
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("coin")){
            other.gameObject.SetActive(false);
            source = m_collect;
            source.Play();
            score = score + 100;
            scoreText.text = "Score: " + score;
        }

        if (other.gameObject.CompareTag("spike"))
        {
            if (health > 0)
            {
                source = m_damage;
                source.Play();
                health = health - 5;
                healthText.text = "Health: " + health;
            }
        }
        if (other.gameObject.CompareTag("end"))
        {
            Time.timeScale = 0;
            endText.text = "You win! Score: " + score + " Health: " + health + " Press R to Restart or Q to Quit!";
        }
        if (other.gameObject.CompareTag("box"))
        {
            health = health - 50;
            Destroy(other);
        }
    }

}