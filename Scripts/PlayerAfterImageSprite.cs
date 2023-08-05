using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterImageSprite : MonoBehaviour
{

    private float activeTime = 0.1f;
    private float timeActivated;
    private float alpha;
    private float alphaSet = 0.8f;
    private float alphaMultiplier = 0.85f;
    private Transform player;
    private SpriteRenderer playerSprite;
    private SpriteRenderer sr;
    private Color color;
    
    private void OnEnable() 
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSprite = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;
        sr.sprite = playerSprite.sprite;
        
        if (player.localScale.x == -1) 
        {
            transform.position = player.position + new Vector3(0.15f, 0, 0);
        }
        else 
        {
            transform.position = player.position - new Vector3(0.15f, 0, 0);
        }
        transform.localScale = player.localScale;
        timeActivated = Time.time;
    }

    private void Update()
    {
        alpha *= alphaMultiplier;
        color = new Color(1f, 1f, 1f, alpha);

        if (Time.time + timeActivated > activeTime)
        {
            PlayerAfterImagePool.Instance.AddToPool(gameObject);
        }
    }

}
