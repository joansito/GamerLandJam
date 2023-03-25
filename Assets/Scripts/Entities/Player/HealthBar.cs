using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image barImage;
    public Player player;
    public void UpdateBar()
    {
        barImage.fillAmount = Mathf.Clamp(player.health / 100, 0, 1f);
    }
}
