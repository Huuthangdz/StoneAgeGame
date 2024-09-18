using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading.Tasks;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private RectTransform pausePanelRect, pauseButtonRect, healthBarRect ;
    [SerializeField] private float topPosY, middlePosY;
    [SerializeField] private float tweenDurantion;
    [SerializeField] private CanvasGroup canvasGroup;

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Restart()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        PausePanelIntro();
    }
    public async void Resume()
    {
        await PausePanelOuttro();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void PausePanelIntro()
    {
        canvasGroup.DOFade(1, tweenDurantion).SetUpdate(true);
        pausePanelRect.DOAnchorPosY(middlePosY, tweenDurantion).SetUpdate(true);
        pauseButtonRect.DOAnchorPosX(130, tweenDurantion).SetUpdate(true);
        healthBarRect.DOAnchorPosY(400, tweenDurantion).SetUpdate(true);
    }
    async Task PausePanelOuttro()
    {
        canvasGroup.DOFade(0, tweenDurantion).SetUpdate(true);
        await pausePanelRect.DOAnchorPosY(topPosY, tweenDurantion).SetUpdate(true).AsyncWaitForCompletion();
        pauseButtonRect.DOAnchorPosX(-15, tweenDurantion).SetUpdate(true);
        healthBarRect.DOAnchorPosY(320, tweenDurantion).SetUpdate(true);
    }
}
