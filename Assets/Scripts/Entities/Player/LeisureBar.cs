using UnityEngine;
using UnityEngine.UI;

public class LeisureBar : MonoBehaviour
{
    public Image barImage;
    public Player player;
    public void UpdateBar()
    {
        barImage.fillAmount = Mathf.Clamp(player.leisure / 100, 0, 1f);
    }
}
