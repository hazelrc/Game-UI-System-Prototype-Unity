using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button Button;
    private Spawnmanager spawnmanager;

    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        spawnmanager = GameObject.Find("SpawnManager").gameObject.GetComponent<Spawnmanager>();
        Button = GetComponent<Button>();
        Button.onClick.AddListener(SetDifficulty);
    }

    public void SetDifficulty() {
        spawnmanager.StartGame(difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
