using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    
        public class EnemyMovement : MonoBehaviour
        {
            // Переменная для координат объекта player
            private Transform player;

            // Скорость движения врага
            public float speed = 0.5f;

            // Use this for initialization
            void Start()
            {
            //находим объект «Корабль» и записываем его в переменную 
            player = GameObject.Find("playerShip").transform;
            }

            // Update is called once per frame
            void Update()
            {
            //считывание нового положения корабля и вычисление разницы между вражеским объектом и кораблем
                Vector3 delta = player.position - transform.position;
                delta.Normalize();
                float moveSpeed = speed * Time.deltaTime;
                transform.position = transform.position + (delta * moveSpeed);
            }
        }
    

