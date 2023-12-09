using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject waterPrefab;
    [SerializeField] GameObject hanabira1Prefab;
    public GameObject ScoreCount;
    public GameManager gameManager;
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
        if (!isStartedGame()) return;
        if (!isClosed)
        {
            isClosed = true;
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.sprite = closeImage;

            // 水しぶきを追加します。
            GameObject water = Instantiate(waterPrefab);
            Transform tf = GetComponent<Transform>();
            water.transform.SetParent(tf, false);

            // 花びらを追加します。1つめ
            GameObject bira1 = Instantiate(hanabira1Prefab);
            bira1.transform.SetParent(tf, false);
            Hanabira1 obj1 = bira1.GetComponent<Hanabira1>();
            obj1.speedX = 0.025f;
            obj1.speedY = -0.025f;
            obj1.rotateZ = -70.0f;

            // 花びらを追加します。2つめ
            GameObject bira2 = Instantiate(hanabira1Prefab);
            bira2.transform.SetParent(tf, false);
            Hanabira1 obj2 = bira2.GetComponent<Hanabira1>();
            obj2.speedX = 0.025f;
            obj2.speedY = 0.025f;
            obj2.rotateZ = 0.0f;

            // 花びらを追加します。3つめ
            GameObject bira3 = Instantiate(hanabira1Prefab);
            bira3.transform.SetParent(tf, false);
            Hanabira1 obj3 = bira3.GetComponent<Hanabira1>();
            obj3.speedX = -0.01f;
            obj3.speedY = 0.02f;
            obj3.rotateZ = -273.0f;

            // 花びらを追加します。4つめ
            GameObject bira4 = Instantiate(hanabira1Prefab);
            bira4.transform.SetParent(tf, false);
            Hanabira1 obj4 = bira4.GetComponent<Hanabira1>();
            obj4.speedX = -0.025f;
            obj4.speedY = 0.01f;
            obj4.rotateZ = 110.0f;

            // 花びらを追加します。5つめ
            GameObject bira5 = Instantiate(hanabira1Prefab);
            bira5.transform.SetParent(tf, false);
            Hanabira1 obj5 = bira5.GetComponent<Hanabira1>();
            obj5.speedX = -0.01f;
            obj5.speedY = -0.01f;
            obj5.rotateZ = -173.0f;

            AddPoint();
        }
    }

    bool isStartedGame()
    {
        return gameManager.isStartedGame();
    }

    void AddPoint()
    {
        Text t = ScoreCount.GetComponent<Text>();
        int currentPoint = int.Parse(t.text);
        currentPoint++;
        t.text = currentPoint.ToString();
    }
}
