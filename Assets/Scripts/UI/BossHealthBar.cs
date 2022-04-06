using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] Image mask;
    [SerializeField] GameObject bossObj;
    [SerializeField] GameObject roomTrigger;
    EnemyBase bossProperties;
    BossEnter _enterRoom;

    public float maxHealth = 30;

    private void OnEnable()
    {
        bossProperties = bossObj.GetComponent<EnemyBase>();
        _enterRoom = roomTrigger.GetComponent<BossEnter>();
    }
    
    // Update is called once per frame
    void Update()
    {
      float fillAmount = (float)bossProperties.GetHealth() / (float)maxHealth;
      mask.fillAmount = fillAmount;

      if (bossObj == null) //If boss dies, delete it's health bar
       {
           gameObject.SetActive(false);
       }
    }
}
