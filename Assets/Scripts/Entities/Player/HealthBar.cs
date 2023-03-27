using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image barImage;
    public Player player;
    public void UpdateBar()
    {
        Debug.Log("Update health bar");
        Debug.Log(player.health);
        barImage.fillAmount = Mathf.Clamp(player.health / 100, 0, 1f);
    }
}
