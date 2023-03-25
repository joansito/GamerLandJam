using UnityEngine;
using UnityEngine.UI;

public class SatisfactionBar : MonoBehaviour
{
    public Image barImage;
    public Player player;
    public void UpdateBar()
    {
        barImage.fillAmount = Mathf.Clamp(player.satisfaction / 100, 0, 1f);
    }
}
