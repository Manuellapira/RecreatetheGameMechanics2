using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class coliter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            // Collect the item, increase score, and destroy collectible
            GameController.Instance.score += 1;
            GameController.Instance.UpdateScore();
            Destroy(other.gameObject);  // Remove collectible from the scene
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            // Trigger Game Over
            GameController.Instance.GameOver();
        }
    }
}
