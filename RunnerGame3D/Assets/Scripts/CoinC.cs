using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinC : MonoBehaviour
{
    public int score;
    public int maxScore=10;
    public TextMeshProUGUI scoreText;
    private PlayerController _playerController;

    public Animator playerAnim;
    public GameObject thisPlayer;
    
    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        playerAnim = thisPlayer.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("End"))
        {
            _playerController.Speed = 0f;
            transform.Rotate(transform.rotation.x,180,transform.rotation.z,Space.Self);
            if (score >= maxScore)
            {
                playerAnim.SetBool("Win",true);
                StartCoroutine(RestartSceneAfterDelay(10f));
            }
            else
            {
                playerAnim.SetBool("Lose",true);
                StartCoroutine(RestartSceneAfterDelay(5f));
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddCoin()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    IEnumerator RestartSceneAfterDelay(float delay)
    {
        
        yield return new WaitForSeconds(delay);

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
