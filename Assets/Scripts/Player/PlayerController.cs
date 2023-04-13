using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5f;
    float movingSidesSpeed = 0.2f;
    Vector3 firstPos;
    Vector3 lastPos;
    float maxXPosition = 4.35f;
    bool isPlayerMoving;
    float maxPlayerScale = 2.2f;
    float minPlayerScale = 0.6f;
    float diamondValue = 0.2f;
    float obstacleDamageValue = 0.3f;
    public GameObject diamondPartical;
    public GameObject obstaclePartical;
    private Animator playerAC;
    public AudioSource playerAudioSource;
    public AudioClip obstacleClip, diamondClip, congratsClip, failedClip;
    void Start()
    {
        playerAC = GetComponent<Animator>();
    }

    void Update()
    {
        if (isPlayerMoving == false)
        {
            return;
        }

        float xValue =0;
        if (Input.GetMouseButtonDown(0)) 
        {
            firstPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            lastPos = Input.mousePosition;
            float differences = lastPos.x - firstPos.x;
            xValue = differences * movingSidesSpeed;
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            firstPos = Vector3.zero;
            lastPos = Vector3.zero;
            xValue = 0;
        }
        transform.Translate(xValue * Time.deltaTime, 0, playerSpeed * Time.deltaTime);

        float newXValue = Mathf.Clamp(transform.position.x, -maxXPosition, maxXPosition);
        transform.position = new Vector3(newXValue, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinishLine")
        {
            isPlayerMoving = false;
            Debug.Log("touched to finishline");
            StartIdleAnimation();
            GameManager.Instance.ShowSuccessMenuPanel();
            PlayAudio(congratsClip);
        }

        if(other.tag == "CannonBall")
        {
            if(isPlayerMoving == true)
            {
                PlayerGotHurt();
                Destroy(other.gameObject);
            }
            
        }
    }

    public void TouchedToDiamond()
    {
        Vector3 effectPosition = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z + 1.5f);
        GameObject partical = Instantiate(diamondPartical,effectPosition,Quaternion.identity);
        Destroy(partical, 2f);
        GetBigger();
        PlayAudio(diamondClip);
    }


    public void TouchedToObstacle()
    {
        PlayerGotHurt();
    }

    private void PlayerGotHurt()
    {
        Vector3 obstacleEffectPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f);
        GameObject partical = Instantiate(obstaclePartical, obstacleEffectPos, Quaternion.identity);
        Destroy(partical, 2f);
        GetSmaller();
        PlayAudio(obstacleClip);

    }

    public void GetSmaller()
    {
        transform.localScale = new Vector3(transform.localScale.x - obstacleDamageValue,
                                           transform.localScale.y - obstacleDamageValue, 
                                           transform.localScale.z - obstacleDamageValue);
        if (transform.localScale.x < minPlayerScale)
        {
            transform.localScale = new Vector3(minPlayerScale, minPlayerScale, minPlayerScale);
            GameManager.Instance.ShowFailedMenuPanel();
            PlayAudio(failedClip);
            StartIdleAnimation();
        }
    }
    private void GetBigger()
    {
        transform.localScale = new Vector3(transform.localScale.x + diamondValue, transform.localScale.y + diamondValue, transform.localScale.z + diamondValue);

        if (transform.localScale.x > maxPlayerScale)
        {
            transform.localScale = new Vector3(maxPlayerScale, maxPlayerScale, maxPlayerScale);
        }
    }

    public void StartPlayerMoving()
    {
        isPlayerMoving = true;
        StartRunAnimation();
    }

    private void StopPlayerMoving()
    {
        isPlayerMoving=false;
        StartIdleAnimation();
    }

    private void StartRunAnimation()
    {
        playerAC.SetBool("isPlayerRunning", true);
    }

    private void StartIdleAnimation()
    {
        playerAC.SetBool("isPlayerRunning", false);
    }

    private void PlayAudio(AudioClip audioClip)
    {
        if (playerAudioSource != null) 
        {
            playerAudioSource.PlayOneShot(audioClip, 1);
        }
    }
   

}
