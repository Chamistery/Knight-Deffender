using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class XPBar : MonoBehaviour
{
    public Image Bar;
    public Text TextValue;
    public Text WaveNumber;
    public static float coeff;
    private void Update()
    {
        WaveNumber.text = WaveSpawn.WaveCount.ToString();
        coeff = (float)MoveToWayPoints.Kills/(float)(WaveSpawn.WaveSize * 4);
        TextValue.text = MoveToWayPoints.Kills.ToString() + "/" + (WaveSpawn.WaveSize * 4).ToString();
        Bar.fillAmount = coeff;
    }
}
