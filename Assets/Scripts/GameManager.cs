using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Canvas mainMenuCanvas;
    [SerializeField] private Canvas arMenuCanvas;
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Canvas winCanvas;
    [SerializeField] private Canvas planeHUDCanvas;

    [SerializeField] private ARSession arSession;
    [SerializeField] private GameObject arOrigin;
    [SerializeField] private PrefabController prefabController;
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private RaycastManager raycastManager;
    [SerializeField] private GameObject defaultPlane;
    [SerializeField] private Camera mainCamera;

    [SerializeField] private AudioClip startSFX;
    [SerializeField] private AudioClip restartSFX;
    [SerializeField] private AudioClip winSFX;
    [SerializeField] private AudioClip gameOverSFX;

    #region Singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        EventManager.GameOver += GameOver;
        EventManager.ShowARMenu += ShowARMenu;
        EventManager.HideARMenu += HideARMenu;
    }

    private void OnDisable()
    {
        EventManager.GameOver -= GameOver;
        EventManager.ShowARMenu -= ShowARMenu;
        EventManager.HideARMenu -= HideARMenu;
    }

    public void StartGame()
    {
        Time.timeScale = 1;

        AudioManager.instance.PlaySFX(startSFX);

        arSession.Reset();

        mainMenuCanvas.enabled = false;
        arOrigin.SetActive(true);
        prefabController.enabled = true;
        mainCamera.enabled = true;
        ShowARMenu();
        EventManager.Restart += StopImageTracking;
    }
    public void StartPlaneDetection()
    {
        Time.timeScale = 0.6f;

        AudioManager.instance.PlaySFX(startSFX);

        arSession.Reset();

        mainMenuCanvas.enabled = false;
        planeHUDCanvas.enabled = true;
        arOrigin.SetActive(true);
        planeManager.enabled = true;
        defaultPlane.SetActive(true);
        raycastManager.enabled = true;
        mainCamera.enabled = true;
        EventManager.Restart += StopPlaneDetection;
    }

    public void Restart()
    {
        EventManager.RestartEvent();
    }

    public void GameOver()
    {
        AudioManager.instance.PlaySFX(gameOverSFX);
        gameOverCanvas.enabled = true;
        mainCamera.enabled = false;
    }

    public void Win()
    {
        AudioManager.instance.PlaySFX(winSFX);
        winCanvas.enabled = true;
        mainCamera.enabled = false;
    }

    public void ShowARMenu()
    {
        arMenuCanvas.enabled = true;
    }

    public void HideARMenu()
    {
        arMenuCanvas.enabled = false;
    }

    public void StopPlaneDetection()
    {
        AudioManager.instance.PlaySFX(restartSFX);
        raycastManager.StopPlaneDetection();

        defaultPlane.SetActive(false);
        planeManager.enabled = false;
        planeHUDCanvas.enabled = false;
        raycastManager.enabled = false;
        mainMenuCanvas.enabled = true;
        winCanvas.enabled = false;
        gameOverCanvas.enabled = false;

        mainCamera.enabled = false;

        AudioManager.instance.audioSource.Stop();
        
        EventManager.Restart -= StopPlaneDetection;
        EventManager.StopPlaneEvent();
    }

    public void StopImageTracking()
    {
        AudioManager.instance.PlaySFX(restartSFX);
        prefabController.RestartPrefab();
        EventManager.Restart -= StopImageTracking;
        SceneManager.LoadScene(0);
    }
}
