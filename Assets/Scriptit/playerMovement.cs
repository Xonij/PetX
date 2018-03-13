using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour {

    public float speed,speedDefault = 2.7f;
    public GameObject skin;
    public Sprite[] playerSprites;
    Animator animator;

	void Start () {
        animator = GetComponent<Animator>();
	}
	void Update () {

        if (Input.GetButton("run"))
        {
            speed = speedDefault * 2f;
        }
        else { speed = speedDefault; }

        moving(); 	
	}
    public void moving()
    {
        if (GetComponent<playerAttacking>().atkAllow == true)
        {
            if (Input.GetButton("up") || Input.GetKey(KeyCode.UpArrow))
            {  
                //skin.GetComponent<SpriteRenderer>().sprite = playerSprites[0];
                GetComponent<playerAttacking>().DirectionFacing = directionFacing.up;
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            if (Input.GetButton("down") || Input.GetKey(KeyCode.DownArrow))
            {
                //skin.GetComponent<SpriteRenderer>().sprite = playerSprites[1];
                GetComponent<playerAttacking>().DirectionFacing = directionFacing.down;
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            if (Input.GetButton("left") || Input.GetKey(KeyCode.LeftArrow))
            {
                //skin.GetComponent<SpriteRenderer>().sprite = playerSprites[2];
                GetComponent<playerAttacking>().DirectionFacing = directionFacing.left;
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetButton("right") || Input.GetKey(KeyCode.RightArrow))
            {
                //skin.GetComponent<SpriteRenderer>().sprite = playerSprites[3];
                GetComponent<playerAttacking>().DirectionFacing = directionFacing.right;
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

            if (Input.GetButton("up") || Input.GetKey(KeyCode.UpArrow)) { animator.SetInteger("dirInt", 1); }
            else if (Input.GetButton("down") || Input.GetKey(KeyCode.DownArrow)) { animator.SetInteger("dirInt", 2); }
            else if (Input.GetButton("left") || Input.GetKey(KeyCode.LeftArrow)) { animator.SetInteger("dirInt", 3); }
            else if (Input.GetButton("right") || Input.GetKey(KeyCode.RightArrow)) { animator.SetInteger("dirInt", 4); }
            else { animator.SetInteger("dirInt", 0); }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "wall")
        {
            Debug.Log("dfghjkl");
        }
        if (other.gameObject.tag == "Enemy")
        {
           // this.gameObject.GetComponent<playerAttacking>().playerHealth--;
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy"&&GetComponent<playerAttacking>().playerHealth>0)
        {
            this.gameObject.GetComponent<playerAttacking>().playerHealth--;
        }
    }
}
