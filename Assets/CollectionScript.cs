using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.tag == "Collectible") {
            Destroy(other.gameObject);
        }
    }

}
