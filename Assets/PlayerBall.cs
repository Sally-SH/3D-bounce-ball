using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigid;
    bool isJump;
    public int starcount;
    AudioSource audio;
    public GameManager manager;
    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        starcount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")&&!isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, 30, 0), ForceMode.Impulse);
            audio = GetComponent<AudioSource>();
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Map")
        {
            isJump = false;
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("Level" + manager.level);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Star")
        {
            starcount++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.AddCount(starcount);
        }
        else if(other.tag == "Finish")
        {
            if(starcount == manager.totalstar)
            {
                if (manager.level == 2)
                {
                    SceneManager.LoadScene("SelectLevel");
                }
                else
                {
                    SceneManager.LoadScene("Level" + (manager.level + 1));
                }
            }
            else
            {
                SceneManager.LoadScene("Level"+manager.level);
            }
        }
    }
}
