using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatLevel : MonoBehaviour 
{
    
    public GameObject Respawn;                                    // В этом GameObject мы сохраняем нашу точку возраждение 
    public void OnTriggerEnter2D(Collider2D other)               // При помощи OnTriggerEnter2D мы отслеживаем контакт с тригером (т.е коснулись ли мы платформы)
    {   
        if (other.tag == "Player")                                // Тут мы говорим что если значение other.tag равно значению нашего "Player" а после контакта с платформой это так т.е true 
        { 
          other.transform.position = Respawn.transform.position;  // Тут после выполнения условия приравниваем координаты Player к нашему Respawn    
        }
    }
}
