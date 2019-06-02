using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public ParticleSystem shineEffect;

    public AudioClip collectedClip;


    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                //Personal addition to make a particle effect play when collected
                shineEffect.transform.parent = null;
                shineEffect.Play();
                controller.ChangeHealth(1);
                Destroy(gameObject);
                controller.PlaySound(collectedClip);
            }
        }
    }
}
