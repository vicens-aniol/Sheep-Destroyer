using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed; // 1
    public float gotHayDestroyDelay; // 2
    private bool hitByHay; // 3

    public float dropDestroyDelay; // 1
    private Collider myCollider; // 2
    private Rigidbody myRigidbody; // 3
    
    public int sheepValue = 1; // Points awarded for catching this sheep
    public Color sheepColor = Color.white; // Default color for regular sheep
    private Renderer sheepRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
        
        // Get renderer and apply color
        sheepRenderer = GetComponentInChildren<Renderer>();
        if (sheepRenderer != null)
        {
            sheepRenderer.material.color = sheepColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    private void HitByHay()
    {
        hitByHay = true; // 1
        runSpeed = 0; // 2
        
        // Find the game controller and add score
        GameController gameController = FindObjectOfType<GameController>();
        if (gameController != null)
        {
            gameController.AddScore(sheepValue);
        }

        Destroy(gameObject, gotHayDestroyDelay); // 3
    }

    private void OnTriggerEnter(Collider other) // 1
    {
        
        if (other.CompareTag("Hay") && !hitByHay) // 2
        {
            Debug.Log("Sheep hit by hay");
            Destroy(other.gameObject); // 3
            HitByHay(); // 4
        }
        else if (other.CompareTag("DropSheep")) // 1
        {
            Debug.Log("Sheep dropped");
            Drop(); // 2
        }
    }

    private void Drop()
    {
        myRigidbody.isKinematic = false; // 1
        myCollider.isTrigger = false; // 2
        Destroy(gameObject, dropDestroyDelay); // 3
    }
}
