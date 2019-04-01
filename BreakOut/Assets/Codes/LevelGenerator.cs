using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [System.Serializable]
    public class ColorToPrefab
    {
        public Color color;
        public GameObject prefab;
    }

    public Texture2D map;
    public float offsetX;
    public float offsetY;
    public float objectX;
    public float objectY;
    public float spacingX;
    public float spacingY;
    public float setParentXScaleFix = 5f;
    public float setParentYScaleFix = 5f;

    public Room room;
    public GameManager gm;
    public ColorToPrefab[] colorMappings;
    public GameObject ball;

    private IEnumerator Iball;
    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
        Iball = Ball(gm.opAnim.length - 0.5f);
        StartCoroutine(Iball);
    }

    private IEnumerator Ball(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        ball.SetActive(true);
    }

    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTiles(x, y);
            }

        }
    }

    void GenerateTiles(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            return;
        }
        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                //prefab's sclae is 0.6 0.4
                Vector2 pos = new Vector2(x * (objectX + spacingX) + offsetX, y * (objectY + spacingY) + offsetY);

                //To fix parent - child scale and position problem.
                GameObject brick = Instantiate(colorMapping.prefab, pos, Quaternion.identity);
                brick.transform.SetParent(room.transform, false);
                Transform oldParent = brick.transform.parent;
                brick.transform.parent = null;

                Vector3 tempBrickScale = brick.transform.localScale;
                tempBrickScale.x /= setParentXScaleFix;
                tempBrickScale.y /= setParentYScaleFix;
                brick.transform.localScale = tempBrickScale;

                brick.transform.position = new Vector2(brick.transform.position.x / setParentXScaleFix, brick.transform.position.y / setParentYScaleFix);
                brick.transform.parent = oldParent;

                if (colorMapping.color.Equals(Color.green))
                {
                    gm.greenBricks.Add(brick);
                }
            }
        }

    }
}

