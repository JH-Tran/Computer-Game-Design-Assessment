using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMachine : MonoBehaviour
{
    // Ball Machine UI
    [SerializeField] private Sprite ballImage;
    private Image currentFeatureIndicator;

    //Spawn Ball into Scene
    [SerializeField] private Transform launchTransform;
    [SerializeField] private GameObject ball;
    [SerializeField] private List<GameObject> ballList;
    private float launchVelocity = 20f;
    //Number of ball in the scene at one time is the value + 1
    private int numberOfBalls = 0;

    private float ballCooldown = 1f;
    private float ballCooldownCurrent;

    public AudioSource shootSound;

    private void Start()
    {
        currentFeatureIndicator = GameObject.Find("FeatureIcon").GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentFeatureIndicator.color != Color.white)
        {
            currentFeatureIndicator.color = Color.white;
        }
        if (ballCooldownCurrent > 0)
        {
            ballCooldownCurrent -= Time.deltaTime;
            currentFeatureIndicator.fillAmount = 1 - ballCooldownCurrent/ballCooldown;
        }
        else
        {
            currentFeatureIndicator.fillAmount = 1;
            ballCooldownCurrent = 0;
        }
    }

    public void initaliseBallUI()
    {
        currentFeatureIndicator.sprite = ballImage;
        currentFeatureIndicator.color = Color.white;
    }

    public void useBallMachine() {
        if (ballCooldownCurrent <= 0)
        {
            if (ballList.Count > numberOfBalls)
            {
                Destroy(ballList[0].gameObject);
                ballList.RemoveAt(0);
            }
            shootSound.Play();
            var prefabBall = Instantiate(ball, launchTransform.position, launchTransform.rotation);
            ballList.Add(prefabBall);
            prefabBall.GetComponent<Rigidbody>().velocity = launchTransform.forward * launchVelocity;
            ballCooldownCurrent = ballCooldown;
            currentFeatureIndicator.fillAmount = 0;
        }
    }
}
