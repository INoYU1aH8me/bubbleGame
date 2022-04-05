using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Color> colors;
    [SerializeField] bool isRandomGame;

    // Start is called before the first frame update
    void Start()
    {
        PaintBalls();   
    }

    void PaintBalls()
    {
        if (isRandomGame)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<Ball>().SetColor(getRandomColor());
            }
        }
    }

    public Color getRandomColor()
    {
        return colors[Random.Range(0, colors.Count)];
    }

}
