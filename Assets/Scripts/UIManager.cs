using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;
    public static UIManager Instance => instance;


    [SerializeField] private GameManager gm;
    [SerializeField] private CharacterControler cc;
    [SerializeField] private TextMeshProUGUI HPtext;
    [SerializeField] private TextMeshProUGUI manaText;
    [SerializeField] private TextMeshProUGUI weaponText;
    [SerializeField] private TextMeshProUGUI waveText;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else instance = this;
    }

    private void Start()
    {
        HPtext.text = "HPs = " + cc.GetHPs()+" / "+cc.GetMaxHPs();
        manaText.text = "Mana = " + cc.GetMana()+ " / "+cc.GetMaxMana();
        weaponText.text = "Weapon = " + cc.GetWeapon();
        waveText.text = "Wave = " + gm.GetWave();
    }

    public void UpdateBoard()
    {
        HPtext.text = "HPs = " + cc.GetHPs() + " / " + cc.GetMaxHPs();
        manaText.text = "Mana = " + cc.GetMana() + " / " + cc.GetMaxMana();
        weaponText.text = "Weapon = " + cc.GetWeapon();
        waveText.text = "Wave = " + gm.GetWave();
    }

}
