
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PlayerScript : MonoBehaviour
    {
        // Изменение скорости перемещения героя
        public float spaceshipSpeed = 2.0f;
        
        private float currentSpeed = 0.0f;

        // Создание переменных для кнопок
        public List<KeyCode> upButton;
        public List<KeyCode> dowButton;
        public List<KeyCode> leftButton;
        public List<KeyCode> rightButton;

        
        private Vector3 lastMovement = new Vector3();

        // Update is called once per frame
        void Update()
        {
            // Поворот героя к мышке
            Rotation();
            // Перемещение героя
            Movement();
        }
        void Rotation()
        {
            
            Vector3 worldPos = Input.mousePosition;
            worldPos = Camera.main.ScreenToWorldPoint(worldPos);
            // Сохраняем координаты указателя мыши
            float dx = this.transform.position.x - worldPos.x;
            float dy = this.transform.position.y - worldPos.y;
            
            float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
            
            Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle + 90));
            // Изменяем поворот героя
            this.transform.rotation = rot;
        }

        
        void Movement()
        {
            
            Vector3 movement = new Vector3();
            // Проверка нажатых клавиш
            movement += MoveIfPressed(upButton, Vector3.up);
            movement += MoveIfPressed(dowButton, Vector3.down);
            movement += MoveIfPressed(leftButton, Vector3.left);
            movement += MoveIfPressed(rightButton, Vector3.right);
           
            movement.Normalize();
            // Проверка нажатия кнопки
            if (movement.magnitude > 0)
            {
                // После нажатия двигаемся в этом направлении
                currentSpeed = spaceshipSpeed;
                this.transform.Translate(movement * Time.deltaTime * spaceshipSpeed, Space.World);
                lastMovement = movement;
            }
            else
            {
                // Если ничего не нажато
                this.transform.Translate(lastMovement * Time.deltaTime * currentSpeed, Space.World);
                // Замедление со временем
                currentSpeed *= 0.9f;
            }
        }

        // Возвращает движение, если нажата кнопка
        Vector3 MoveIfPressed(List<KeyCode> keyList, Vector3 Movement)
        {
            // Проверяем кнопки из списка
            foreach (KeyCode element in keyList)
            {
                
                if (Input.GetKey(element))
                {
                    return Movement;
                }
            }
            
            return Vector3.zero;
        }

    }


