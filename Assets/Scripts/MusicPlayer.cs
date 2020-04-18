using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    private static MusicPlayer instance = null;
	// Use this for initialization
	void Start () {
        Debug.Log("Music player start " + GetInstanceID());
	}

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            print("Duplicate music player self-destructing");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
