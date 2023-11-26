using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject flowerPrefab;
    public GameObject ScoreLabel, ScoreCount, TimeLabel1, TimeLabel2, TimeCount;
    public GameObject StartButton, RestartButton;
    public int FlowerCount = 100;
    public int MaxRetryCount = 50;
    public float flowerWidth = 1.0f; // 97.0f
    public float flowerHeight = 1.0f; //133.0f
    public float flowerScale = 0.5f;
    public float randomRangeWidth = 10.0f;
    public float randomRangeHeight = 10.0f;
    public float LimitTime = 10.0f;
    List<Vector3> flowerPositions;
    List<GameObject> flowerObjects;
    float startTime;
    bool isStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        isStarted = false;
        SetPoint(0);
        flowerPositions = new List<Vector3>();
        flowerObjects = new List<GameObject>();
        StartButton.SetActive(true);
        RestartButton.SetActive(false);
        SetVisibleStatus(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStarted) return;
        float elapsed = Time.time - startTime;
        float remainTime = LimitTime - elapsed;
        if (remainTime > 0)
        {
            Text t = TimeCount.GetComponent<Text>();
            t.text = remainTime.ToString("F0");
        }
        else
        {
            StopGame();
        }

    }

    public void OnStartButton()
    {
        StartGame();
    }
    public void OnRestartButton()
    {
        StartGame();
    }

    void SetPoint(int p)
    {
        Text t = ScoreCount.GetComponent<Text>();
        t.text = p.ToString();
    }
    void StartGame()
    {
        SetPoint(0);
        SetVisibleStatus(true);
        StartButton.SetActive(false);
        RestartButton.SetActive(false);
        InitializeFlowers();
        StartTimer();
    }
    void StopGame()
    {
        StopTimer();
        StartButton.SetActive(false);
        RestartButton.SetActive(true);
    }
    public bool isStartedGame()
    {
        return isStarted;
    }
    void SetVisibleStatus(bool isOn)
    {
        ScoreLabel.SetActive(isOn);
        ScoreCount.SetActive(isOn);
        TimeLabel1.SetActive(isOn);
        TimeLabel2.SetActive(isOn);
        TimeCount.SetActive(isOn);
    }
    void StartTimer()
    {
        isStarted = true;
        startTime = Time.time;
    }
    void StopTimer()
    {
        isStarted = false;
    }

    void InitializeFlowers()
    {
        DeleteAllFlowers();
        for (int i = 0; i < FlowerCount; ++i)
        {
            GameObject flower = Instantiate(flowerPrefab);
            Flower obj = flower.GetComponent<Flower>();
            obj.gameManager = this;
            obj.ScoreCount = ScoreCount;
            // Vector3 originalPos = flower.transform.position;
            Vector3 originalPos = new Vector3(0f, 0f, 0f);
            int retryCount = 0;
            for (; retryCount < MaxRetryCount; ++retryCount)
            {
                float addX = Random.Range(-randomRangeWidth, randomRangeWidth);
                float addY = Random.Range(-randomRangeHeight, randomRangeHeight);
                Vector3 newPos = new Vector3(addX, addY, 0f);
                newPos.x += originalPos.x;
                newPos.y += originalPos.y;
                bool isWrapped = false;
                foreach (var pos in flowerPositions)
                {
                    if ((pos.x - (flowerWidth) <= newPos.x && newPos.x <= pos.x + (flowerWidth)) &&
                        (pos.y - (flowerHeight) <= newPos.y && newPos.y <= pos.y + (flowerHeight)))
                    {
                        isWrapped = true;
                        break;
                    }
                }
                if (isWrapped) { continue; }
                flower.transform.position = new Vector3(newPos.x, newPos.y, 0f);
                flowerPositions.Add(newPos);
                break;
            }
            if (retryCount >= MaxRetryCount)
            {
                Destroy(flower);
            }
            else
            {
                flowerObjects.Add(flower);
            }
        }
    }
    void DeleteAllFlowers()
    {
        foreach (var flower in flowerObjects)
        {
            Destroy(flower);
        }
        flowerPositions.Clear();
        flowerObjects.Clear();
    }
}
