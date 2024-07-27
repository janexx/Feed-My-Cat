using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private Animator enemyAnimator;
    private ParticleSystem explosionParticles;
    private AudioSource enemyAudio;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
        explosionParticles = GameObject.FindGameObjectWithTag("CrashFX").GetComponent<ParticleSystem>();
        enemyAudio = GetComponent<AudioSource>();
    }

    // On collision of the enemy with the player a sound and fighting particles gets played
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyAnimator.Play("Bark");
            enemyAudio.Play();
            explosionParticles.transform.position = transform.position;
            explosionParticles.Play();
            StartCoroutine(WaitForGameOver());            
        }
    }

    IEnumerator WaitForGameOver()
    {
        Debug.Log("Starting WaitForGameOver coroutine");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Loading Gameover scene");
        SceneManager.LoadScene("Gameover");
    }

}
