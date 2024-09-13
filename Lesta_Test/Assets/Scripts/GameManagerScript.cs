using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private Character characterPrefab;
    [SerializeField] private UiManager uiManager;

    private Character character;
    private float startTime;

    private void Start()
    {
        Vector3 startPos = new Vector3(0, 1.5f, -4.5f);
        character = Instantiate(characterPrefab, startPos, characterPrefab.transform.rotation);
        uiManager.Init(character, Restart);
        character.Init(StartTimer, EndGame);
    }

    private void StartTimer()
    {
        startTime = Time.time;
    }

    private void EndGame(bool isWin)
    {
        if(isWin)
        {
            uiManager.ShowWinScreen(Time.time - startTime);
        }
        else
        {
            uiManager.ShowLoseScreen();
        }
        Destroy(character.gameObject);
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
