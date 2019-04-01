using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level7 : MonoBehaviour
{
    [SerializeField]
    private static int deathCount;

    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameOver == true)
        {
            deathCount++;
        }
    }
}
