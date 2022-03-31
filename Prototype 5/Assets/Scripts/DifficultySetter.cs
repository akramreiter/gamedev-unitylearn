using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySetter : MonoBehaviour
{
    private Button button;
    private GameManager manager;
    public float difficulty = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        manager.AdjustSpawnRate(difficulty);
        manager.StartGame();
    }
}
