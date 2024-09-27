using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider HPSlider;
    public Enemy Boss;


    private void Awake()
    {


    }

    // Start is called before the first frame update
    void Start()
    {
        HPSlider.maxValue = Boss.EnemyHealth._currentMaxHealth;
        HPSlider.value = Boss.EnemyHealth._currentMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeValue()
    {
        HPSlider.value = Boss.EnemyHealth._currentHealth;
    }
}
