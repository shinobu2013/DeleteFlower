using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject waterPrefab;
    [SerializeField] GameObject ScoreCount, StartButton, RestartButton;
    public Sprite openImage, closeImage;
    bool isClosed = false;
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = openImage;
        isClosed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTapped()
    {
        if( !isStartedGame() ) return;
        if (!isClosed)
        {
            isClosed = true;
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.sprite = closeImage;

            GameObject water = Instantiate(waterPrefab);
            Transform tf = GetComponent<Transform>();
            water.transform.SetParent( tf, false );
            AddPoint();
        }
    }

    bool isStartedGame()
    {
        if( StartButton.activeSelf ) return false;
        if( RestartButton.activeSelf ) return false;
        return true;
    }

    void AddPoint()
    {
        Text t = ScoreCount.GetComponent<Text>();
        int currentPoint = int.Parse(t.text);
        currentPoint++;
        t.text = currentPoint.ToString();
    }
}
