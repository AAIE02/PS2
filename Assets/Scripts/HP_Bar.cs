using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Bar : MonoBehaviour
{
    private Slider Hp_bar;

    private void Start()
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


//Bug de lanzamiento 
/*-----------------------------------------------------------------------*/
//Puntuacion--Monedas
//Vida de personaje--recibir damage de enmigos y obstaculos
/*-----------------------------------------------------------------------*/
//MainMenu
//Win condition-- MENU
//Lose condition-- MENU
/*-----------------------------------------------------------------------*/
//Subir a tienda