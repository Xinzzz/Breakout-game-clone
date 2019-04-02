using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EdScreen : MonoBehaviour
{
    public GameObject image;
    bool fadeInOver = false;

    

    private void Update()
    {
        if (!fadeInOver)
        {

            FadeIn();
        }     
    }

    void FadeIn()
    {
        Color temp = image.GetComponent<SpriteRenderer>().color;
        temp.a -= Time.deltaTime;
        image.GetComponent<SpriteRenderer>().color = temp;
        if (image.GetComponent<SpriteRenderer>().color.a <= 0)
        {
            fadeInOver = true;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
