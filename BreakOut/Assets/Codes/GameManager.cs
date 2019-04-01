using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //level7 special
    public GameObject text;

    public Animator roomAnim;
    public AnimationClip opAnim;
    public AnimationClip edAnim;
    public AnimationClip overAnim;
    
    [SerializeField]
    private static int deathCount = 0;

    public List <GameObject> greenBricks = new List<GameObject>();
    

    public bool gameOver = false;
    public bool finished = false;
    public bool okToDrag = false;
    public bool gameOverRefresh = true;

    private IEnumerator Iop;
    private IEnumerator Ied;
    private IEnumerator Iover;

    private int currentScene;
    private int nextScene;

    public Room room;
    public SpriteRenderer roomColor;
    // Start is called before the first frame update
    void Start()
    {
        Iop = OpAnim(opAnim.length);
        StartCoroutine(Iop);
        currentScene = SceneManager.GetActiveScene().buildIndex;
        nextScene = currentScene + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(finished)
        {
            roomColor.color = new Color(0.576f,0.725f,0.517f,0.9f);
            roomAnim.SetBool("Finished", true);
            Ied = EdAnim(edAnim.length);
            StartCoroutine(Ied);          
        }
        else if(gameOver)
        {
            if(gameOverRefresh)
            {
                deathCount++;
                gameOverRefresh = false;
            }
            roomColor.color = new Color(0.541f, 0.298f, 0.309f, 0.9f);
            roomAnim.SetBool("GameOver", true);
            Iover = OverAnim(overAnim.length);
            StartCoroutine(Iover);
        }

        //Level7 special
        if(currentScene == 7 && deathCount >= 5)
        {
            text.SetActive(true);
        }

    }

    private IEnumerator OpAnim(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        okToDrag = true;
    }

    private IEnumerator EdAnim(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(nextScene);
        deathCount = 0;
    }

    private IEnumerator OverAnim(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(currentScene);
    }


    public void CountGreenBrick()
    {
        if(greenBricks.Count == 0)
        {
            AudioManager.instance.Play("compeleted", 0.5f);
            finished = true;
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(currentScene);
    }
}
