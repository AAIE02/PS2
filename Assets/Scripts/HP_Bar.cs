using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HP_Bar : MonoBehaviour
{
    private Slider Hp_bar;
    private void Start()
    {
        Hp_bar = GetComponent<Slider>();
    }

    public void ChangeValueMax(float HPTotal)
    {
        Hp_bar.maxvalue = HPTotal;
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


//Bug de lanzamiento 
//Puntuacion
//Vida de personaje
/*-----------------------------------------------------------------------*/
//Win condition
//Lose condition
//Subir a tienda