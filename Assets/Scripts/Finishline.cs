using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD36
{
    [RequireComponent(typeof(Collider2D))]
    public class Finishline : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerBase player = collision.gameObject.GetComponent<PlayerBase>();

            if (player != null)
            {
                GameManager.Get.End = true;
                GameManager.Get.winnerSprite = player.GetComponent<SpriteRenderer>().sprite;
                GameManager.Get.winnerId = player.playerDisplay.spriteId;
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
