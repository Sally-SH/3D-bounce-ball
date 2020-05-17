using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    public int totalstar;
    public int level;
    public Text totalstarcount;
    public Text getstarcount;
    public Text stage;
    public GameObject Menulist;

    void Awake()
    {
        if (level != 0)
        {
            totalstarcount.text = "/" + totalstar;
            stage.text = level.ToString();
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(Menulist.activeSelf)
                Menulist.SetActive(false);
            else
                Menulist.SetActive(true);
        }
    }
    public void AddCount(int count)
    {
        getstarcount.text = count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            SceneManager.LoadScene("Level" + level);
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Onmenu()
    {
        Menulist.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level"+level);
    }
    public void Select()
    {
        SceneManager.LoadScene("SelectLevel");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
