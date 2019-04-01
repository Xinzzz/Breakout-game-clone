using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OpScreen : MonoBehaviour
{
    IEnumerator opLoadLevel;
    IEnumerator fade;
    public GameObject image;
    bool startFading = false;
    private void Start()
    {
        opLoadLevel = OpLoad(5f);
        StartCoroutine(opLoadLevel);
        fade = Fade(4f);
        StartCoroutine(fade);
    }
    private IEnumerator OpLoad(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Level1");
    }
    private IEnumerator Fade(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        startFading = true;
    }
    private void Update()
    {
        if(startFading)
        {
            FadeOut();
        }

    }
    void FadeOut()
    {
        Color temp = image.GetComponent<SpriteRenderer>().color;
        temp.a += Time.deltaTime;
        image.GetComponent<SpriteRenderer>().color = temp;
    }
}
