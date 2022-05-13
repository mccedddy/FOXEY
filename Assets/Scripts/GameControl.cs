using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControl : MonoBehaviour
{
    public Animator animator;
    public GameObject canvasWin;
    public GameObject canvasLose;
    public TextMeshProUGUI stageName;
    public AudioSource sfx_cherryPop;
    public AudioSource sfx_jump;
    public AudioSource sfx_hit;
    public AudioSource sfx_shot;
    public static AudioSource sfx_staticJump;
    private bool scoreAdded = false;
    private void Start()
    {
        animator.SetBool("IsHurt", false);
        transform.position = new Vector3(-16, 7, 0);
        PlayerMovement.moveAllowed = true;
        canvasWin.gameObject.SetActive(false);
        canvasLose.gameObject.SetActive(false);
        stageName.text = "Stage " + SceneManager.GetActiveScene().name.Substring(5,1);
        sfx_staticJump = sfx_jump;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Death
        if (collision.name == "Damage")
            Hurt();
        // Win
        if (collision.name == "Goal")
        {
            PlayerMovement.moveAllowed = false;
            PlayerMovement.horizontalMove = 0f;
            canvasWin.gameObject.SetActive(true);
        }
        // Cherry
        if (collision.gameObject.CompareTag("Cherry"))
        {
            var cherryAnimator = collision.gameObject.GetComponent<Animator>();
            cherryAnimator.SetBool("IsPopped", true);
            sfx_cherryPop.Play();
            Score.AddScore(100);
            StartCoroutine(DestroyObject(collision.gameObject));   
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (animator.GetBool("IsJumping") == true)
            {
                var enemyAnimator = collision.gameObject.GetComponent<Animator>();
                enemyAnimator.SetBool("Dead", true);
                sfx_shot.Play();
                if (!scoreAdded)
                {
                    Score.AddScore(500);
                    scoreAdded = true;
                }
                StartCoroutine(DestroyObject(collision.gameObject)); }
            else
                Hurt();
        }
    }
    public void ResetLevel()
    {
        // Reload Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Hurt()
    {
        animator.SetBool("IsHurt", true);
        sfx_hit.Play();
        PlayerMovement.moveAllowed = false;
        PlayerMovement.horizontalMove = 0f;
        canvasLose.gameObject.SetActive(true);
    }
    IEnumerator DestroyObject(GameObject objectToDestroy)
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(objectToDestroy.gameObject);
        scoreAdded = false;
    }
}
