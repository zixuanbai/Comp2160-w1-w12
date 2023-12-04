using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Mole : MonoBehaviour
{
    private SpriteRenderer moleSprite;
    [SerializeField] private Color downState;
    [SerializeField] private Color upState;
    [SerializeField] private Color missedState;
    [SerializeField] private float missedTimeDelay;
    [SerializeField] private float upStateTimerDelay;
    private float timeDelay;
    private float timer;
    private float missedTimer;
    private float upStateTimer;

    // Start is called before the first frame update
    void Start()
    {

        moleSprite = GetComponent<SpriteRenderer>();
        moleSprite.color = downState;
        timeDelay = Random.Range(3.0f, 15.0f);
        timer = timeDelay;
        upStateTimer = upStateTimerDelay;
        missedTimer = missedTimeDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            moleSprite.color = upState;
        }
        if (moleSprite.color == upState)
        {
            upStateTimer -= Time.deltaTime;
        }
        if (upStateTimer <= 0)
        {
            moleSprite.color = missedState;
        }
        if (moleSprite.color == missedState)
        {
            missedTimer -= Time.deltaTime;
        }
        if (missedTimer <= 0)
        {
            moleSprite.color = downState;
            timeDelay= Random.Range(3.0f, 15f);
            timer = timeDelay;
            upStateTimer = upStateTimerDelay;
            missedTimer = missedTimeDelay;

        }
    }
     void OnMouseDown()
    {
        if (moleSprite.color != downState && moleSprite.color != missedState)
        {
            moleSprite.color = downState;
            timeDelay = Random.Range(3.0f, 15f);
            timer = timeDelay;
            upStateTimer = upStateTimerDelay;
            missedTimer = missedTimeDelay;
        }
    }
}
