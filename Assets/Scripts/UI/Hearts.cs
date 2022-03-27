using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    [SerializeField] Image mask;
    [SerializeField] GameObject playerObj;

    PlayerHealth playerProperties;

    float maxHealth = 6;

    // Start is called before the first frame update
    void Start()
    {
        playerProperties = playerObj.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        float fillAmount = (float)playerProperties.GetHealth() / (float)maxHealth;

        mask.fillAmount = fillAmount;
    }
}
