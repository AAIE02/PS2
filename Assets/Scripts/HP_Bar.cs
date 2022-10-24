using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HP_Bar : MonoBehaviour
{
    private Slider Hp_Bar;
    //private Slider

    private void Start()
    {
        Hp_Bar = GetComponent<Slider>();
    }

    public void ChangeValueMax(float HPTotal)
    {
        //Hp_Bar.maxValue = HPTotal;
    }

    public void ChangeCurrentHP(float cantidadHP)
    {
        Hp_Bar.value = cantidadHP;
    }

    public void BarraDeVida(float cantidadHP)
    {
        ChangeValueMax(cantidadHP);
        ChangeCurrentHP(cantidadHP);
    }
}
