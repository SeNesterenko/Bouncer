using UnityEngine;

public class RecoloringTarget : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Renderer>().material = GetComponent<Renderer>().material;
        Destroy(gameObject);
    }
}
