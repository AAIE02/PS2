using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Bar : MonoBehaviour
{
    Slider Hp_bar;

    public void Start()
    {
        Hp_bar = GetComponent<Slider>();
    }
    public void ChangeValueMax(float HPTotal)
    {
        Hp_bar.maxValue = HPTotal;
    }
    public void ChangeCurrentHP(float cantidadHP)
    {
        Hp_bar.value = cantidadHP;
    }
    public void BarraDeVida(float cantidadHP)
    {
        ChangeValueMax(cantidadHP);
        ChangeCurrentHP(cantidadHP);
    }
}