using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDisabler : MonoBehaviour {

    public GameObject objectToDisable;

	void Start ()
    {
	}
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            objectToDisable.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            objectToDisable.SetActive(true);
        }
    }
}
