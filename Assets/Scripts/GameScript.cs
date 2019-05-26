using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public int score;

    public int rows = 2;
    public int cols = 8;

    public TextMeshProUGUI Countdown;
    public float currCountdownValue;

    [SerializeField] private AudioClip[] AcertouClips;
    [SerializeField] private AudioClip[] ErrouClips;
    [SerializeField] private AudioClip[] GanhouClips;
    private AudioSource audioSource;
    void Start()
    {
        score = 0;

        Countdown = GameObject.FindGameObjectWithTag("Countdown").GetComponent<TextMeshProUGUI>();

        //TODO: se for nível médio deve fazer em 60 segundos
        if (true)
        {
            StartCoroutine(StartCountdown(60));
        } else if (true) //TODO: se for nível difícil deve fazer em 30 segundos
        {
            StartCoroutine(StartCountdown(30));
        }
    }

    public void AddScore()
    {
        PlaySound(AcertouClips);
        score++;
        ScoreText.text = "Score: " + score;
    }

    void PlaySound(AudioClip[] clips)
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clips[Random.Range(0, clips.Length)];
        audioSource.volume = 0.5f;
        audioSource.Play();
    }

    public void ErrouSound()
    {
        PlaySound(ErrouClips);
    }

    public void CheckGame()
    {
        if (score == (int)(rows * cols / 2))
        {
            StartCoroutine(PlayerWon());
        }
    }

    private IEnumerator PlayerWon()
    {
        PlaySound(GanhouClips);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("WonGameScene");
    }

    public IEnumerator StartCountdown(float countdownValue)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue >= 0)
        {
            Countdown.GetComponent<TextMeshProUGUI>().text = "Countdown: " + currCountdownValue;
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;

            if (currCountdownValue == 0)
            {
                SceneManager.LoadScene("LostGameScene");
            }
        }
    }

}
