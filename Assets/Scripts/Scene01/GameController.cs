using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject block;
    public float maxX;
    public float y;
    public bool playing;
    //public TextMeshProUGUI score;
    //private float point;
    private float beginTime = 2;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        playing = false;
        //score.text = point.ToString();
        currentTime = beginTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            playing = false;
            InvokeRepeating(nameof(SpawnBlock), 0.5f, 3f);
            //InvokeRepeating(nameof(InscreasePoint), 0.5f, 3f);
        }

        //currentTime -= Time.deltaTime;
        //if (currentTime <= 0)
        //{
        //    currentTime = beginTime;
        //InscreasePoint();
        //}

    }

    //private void InscreasePoint()
    //{
    //    point += 1;
    //    score.text = point.ToString();
    //}

    private void SpawnBlock()
    {
        var positionX = Random.Range(-maxX, maxX);
        Vector3 position = new Vector3(positionX, y, 0);
        var oneBlock = Instantiate(block, position, Quaternion.identity);
        //Destroy(oneBlock, 2f);
    }
}
