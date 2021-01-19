using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{

    Text healthText;
    Player player;
    Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();

        player = FindObjectOfType<Player>();

        healthSlider = FindObjectOfType<Slider>();
        healthSlider.maxValue = player.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = player.GetHealth().ToString();

        healthSlider.value = player.GetHealth();
    }
}
