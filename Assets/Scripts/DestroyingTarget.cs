using UnityEngine;

public class DestroyingTarget : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Renderer>().material.color == GetComponent<Renderer>().material.color)
        {
            Destroy(gameObject);
        }
    }
}
