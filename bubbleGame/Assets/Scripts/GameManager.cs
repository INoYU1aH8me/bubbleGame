using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Color> colors;

    // Start is called before the first frame update
    void Start()
    {
        PaintBalls();   
    }

    void PaintBalls()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Ball>().SetColor(getRandomColor());
            //transform.GetChild(i).GetComponent<Ball>().Paint();
        }
    }

    public Color getRandomColor()
    {
        return colors[Random.Range(0, colors.Count)];
    }

}
