using UnityEngine;

public class HiddenExit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneController.instance.HiddenScreen();
        }
    }
}
