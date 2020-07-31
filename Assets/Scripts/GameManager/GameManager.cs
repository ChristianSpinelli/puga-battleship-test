using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Singleton")]
    public static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [Header("References")]
    public Transform pivotToRestart;
    public GameObject ship;

    [Header("Behaviour")]
    [HideInInspector] public float gameTime = 1;
    [HideInInspector] public bool endGame;
    [HideInInspector] public float timer;
    [HideInInspector] public bool winGame;
    [HideInInspector] public const float STAGETIME = 60;


    void Awake()
    {
        instance = this;
        timer = STAGETIME;
    }


    void Update()
    {
        if (Input.GetButton("Cancel") && endGame)
            RestartGame();

        //Calculate timer
        if (!endGame && timer>0)
            timer -= Time.deltaTime;

        //if the player doesnt die and the timer finish the player Win the game
        if (!endGame && timer <= 0)
            WinGame();
    }


    private void EndGame()
    {
        endGame = true;
        SpawnManager.Instance.spawnAble = false;
        gameTime = 0;
    }

    public void LoseGame()
    {
        EndGame();
        winGame = false;
    }


    public void WinGame()
    {
        EndGame();
        winGame = true;
    }

    public void RestartGame()
    {
        endGame = false;
        ship.transform.position = new Vector3(pivotToRestart.position.x, ship.transform.position.y, pivotToRestart.position.z);
        ship.GetComponent<ShipController>().allStatus[ship.GetComponent<ShipController>().healthLevel - 1].health = 250;
        ship.GetComponent<ShipController>().EnebleMesh(true);
        SpawnManager.Instance.DestroyerAllEnemy();
        SpawnManager.Instance.spawnAble = true;
        gameTime = 1;
        timer = STAGETIME;
    }
}
