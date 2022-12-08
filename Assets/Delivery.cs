using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackagecolor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackagecolor = new Color32(1, 1, 1, 1);

    [SerializeField] float destroyDelay = 0.4f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void OnCollisionEnter2D(Collider2D other)
    {
        Debug.Log("auch!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            spriteRenderer.color = hasPackagecolor;
            Destroy(other.gameObject, destroyDelay);
        }

        if (hasPackage is true)
        {
            if (other.tag == "Customer")
            {
                Debug.Log("Package has delivered");
                hasPackage = false;
                spriteRenderer.color = noPackagecolor;
            }
        }
        
        
    }
}
