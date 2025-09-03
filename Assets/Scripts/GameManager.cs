using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
      public static GameManager Instance;

    public bool shouldPlayerMove = true;

    [Header("Panels & objects")]

    public GameObject bowlSelectPanel;
    public bool foodHasSpawned = false;

    [Header("Managers")]
    public RoundManager roundController;
    public FoodManager foodManager;

    [Header("Player & Camera")]

    public PlayerInteraction playerInteraction;

    public int PlayerCoins = 2; // bani jucător

    public CameraMove cameraMove;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        //if (roundController != null)
        //{
        //    roundController.StartRound(); // începe prima rundă
        //}
        //else
        //{
        //    Debug.LogError("RoundController nu este setat în GameManager!");
        //}
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F1))
        {
            // Reload scena curentă
            Scene currentScene = SceneManager.GetActiveScene(); // preluăm scena activă
            SceneManager.LoadScene(currentScene.name);           // încărcăm din nou scena
        }

        if (Input.GetKeyDown(KeyCode.Space)) // exemplu pentru testDa
        {
            Debug.Log("CameraFalse");
            cameraMove.CameraEnterSelectMode();
        }

        if (Input.GetKeyDown(KeyCode.Return)) // exemplu pentru test
        {
            Debug.Log("CameraTrue");
            cameraMove.CameraExitSelectMode();
        }
    }
    public void SetPlayerControl(bool canMove)
    {
        shouldPlayerMove = canMove;

        // Blocăm sau deblocăm camera
        if (cameraMove != null)
        {
            if (canMove)
                cameraMove.CameraExitSelectMode();  // player poate roti camera și cursorul e blocat
            else
                cameraMove.CameraEnterSelectMode(); // player nu poate roti camera și cursorul e vizibil
        }

        // Dacă mai ai alte sisteme de blocat, le poți adăuga aici
        // ex: block player movement scripts, UI input etc.
    }

    public void UpdateBowlPanel()
    {
        if (bowlSelectPanel != null && playerInteraction != null)
            bowlSelectPanel.SetActive(playerInteraction.activateBowlPanel);
    }

    public void FoodHasSpawned()
    {
        if (!foodHasSpawned) // să nu spawnăm de 2 ori
        {
            foodManager.SpawnFoods(3, new List<PerkData>()); // 3 ingrediente random
            foodHasSpawned = true;
        }
    }

}