using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;

    public GameObject creditsParent;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayGeneralSFX(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {

        StartCoroutine(StartRoutine());
    }

    public IEnumerator StartRoutine()
    {
        AudioManager.Instance.PlayUISFX(0);
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(1);
    }

    public void OpenCredits()
    {
        creditsParent.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsParent.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }


}
