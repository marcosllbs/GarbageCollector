using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMoveScript : MonoBehaviour
{
    private float moveSpeed = 10f; // Velocidade de movimento
    private float minX = -1f; // Limite mínimo no eixo X
    private float maxX = 1f; // Limite máximo no eixo X

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        // Controle por Mouse no Editor ou PC
        if (Input.GetMouseButton(0)) // Detecta se o botão esquerdo do mouse está pressionado
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToViewportPoint(mousePosition); // Obtém a posição do mouse na viewport (0 a 1)
            float targetX = Mathf.Lerp(minX, maxX, mousePosition.x); // Mapeia a posição da viewport para o intervalo de -1 a 1
            Vector3 targetPosition = new Vector3(targetX, transform.localPosition.y, transform.localPosition.z); // Apenas move no eixo X
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, moveSpeed * Time.deltaTime);
        }
#endif

#if UNITY_IOS || UNITY_ANDROID
        // Controle por toque em dispositivos móveis
        if (Input.touchCount > 0) // Verifica se há toque na tela
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToViewportPoint(touch.position); // Obtém a posição do toque na viewport (0 a 1)
            float targetX = Mathf.Lerp(minX, maxX, touchPosition.x); // Mapeia a posição da viewport para o intervalo de -1 a 1
            Vector3 targetPosition = new Vector3(targetX, transform.localPosition.y, transform.localPosition.z); // Apenas move no eixo X
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, moveSpeed * Time.deltaTime);
        }
#endif
    }
}

