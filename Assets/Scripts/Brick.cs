using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public AudioClip crack;
    public AudioClip death;
    public GameObject smoke;

    private bool isBreakable;
    private int timesHit;
    private LevelManager lm;
	// Use this for initialization
	void Start () {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableCount++;
        }
        timesHit = 0;
        lm = GameObject.FindObjectOfType<LevelManager>();
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isBreakable)
        {
            handleHits();
        }
        
        
    }

    void particleExplosion()
    {
        GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);         //does particle effects

        ParticleSystem ps = smokePuff.GetComponent<ParticleSystem>();
        var main = ps.main;

        main.startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void handleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            lm.BrickDestroyed();
            Destroy(gameObject);
            particleExplosion();
            AudioSource.PlayClipAtPoint(death, transform.position, 3f);
        }
        else
        {
            AudioSource.PlayClipAtPoint(crack, transform.position);
            LoadSprites();
        }
    }

    void LoadSprites()
    {
        int i = timesHit - 1;
        if(hitSprites[i] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[i];
        }
        else
        {
            Debug.LogError("Brick sprite missing");
        }
        
    }
}
