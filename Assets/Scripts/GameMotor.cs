using UnityEngine;

public class GameMotor : MonoBehaviour
{   // Atributos
    public Pontos score;                                                                // Chama o script de Pontos
    public int level, life = 3; float levelSpeed, objSpeed, renderSpeed;                // Variáveis de Controle de Velocidade
    public AudioSource auCollect, auMoving, auWarning;
    public Transform posLeft, posRight, StageController;                                // Limites em X e Controlador
    private GameObject[] lixoList, obstacleList, sceneList, renderList;                 // Listas de Lixos, Objetos, Cenários e Renders

    // Métodos
    void Update()
    {
        PlayerControl();                                                                // Realiza a Movimentação do Player
        ObjectControl();                                                                // Realiza a Movimentação dos Objetos da Scene
        LevelControl();                                                                 // Altera a velocidade do Jogo
    }
    
    void PlayerControl()
    {
        Quaternion main = Quaternion.Euler(0, 0, 0);                                    // Normaliza Inclinações do Player
        transform.rotation = Quaternion.Slerp
        (transform.rotation, main, Time.deltaTime * 5.0f);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetButton("LeftAnalog-PS3") || Input.GetButton("Left1-XBOX360") || Input.GetButton("Left2-XBOX360"))
        {
            auMoving.Play();
            Rotaciona();                                                                // Barco Inclina para Esquerda
            transform.position = Vector3.MoveTowards									
            (transform.position, posLeft.position, 35 * Time.deltaTime);                // Barco Move em direção ao limite Esquerdo
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetButton("RightAnalog-PS3") || Input.GetButton("Right1-XBOX360") || Input.GetButton("Right2-XBOX360"))
        {
            auMoving.Play();
            Rotaciona();                                                                // Barco Inclina para Direita
            transform.position = Vector3.MoveTowards
            (transform.position, posRight.position, 35 * Time.deltaTime);               // Barco Move em direção ao limite Direito
        }
    }

    void Rotaciona()
    {
        float tilt = Input.GetAxis("Horizontal") * 45.0f;
		Quaternion target = Quaternion.Euler(0, tilt, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5.0f);
    }

    void ObjectControl()
    {
        lixoList = GameObject.FindGameObjectsWithTag("Lixo");                          // Array de Lixos
        obstacleList = GameObject.FindGameObjectsWithTag("Obstacle");                  // Array de Obstaculos
        sceneList = GameObject.FindGameObjectsWithTag("Cloud");                        // Array de Objetos do Cenário
        renderList = GameObject.FindGameObjectsWithTag("Scene");                       // Array de Texturas

        foreach (GameObject lixo in lixoList)
        {
            lixo.transform.Translate(0, 0, objSpeed);
        }

        foreach (GameObject obstacle in obstacleList)
        {
            obstacle.transform.Translate(0, 0, objSpeed);
        }

        foreach (GameObject scene in sceneList)
        {
            scene.transform.Translate(0, 0, objSpeed * -1);
        }

        foreach (GameObject texture in renderList)
        {
            float offset = renderSpeed * Time.time;
            texture.GetComponent<Renderer>().material.SetTextureOffset                    
            ("_MainTex", new Vector2(-offset, 0));                                      // Controla o Offset da Renderização
        }
    }

    public float LevelControl()                                                         // Controlador de Velocidade
    {
        if (Time.timeScale == 0)
        {
            objSpeed = 0.0f; renderSpeed = 0.0f; levelSpeed = 0.0f;                     // Velocidade       0
        }
        else if (level < 5)
        {
            objSpeed = -0.5f; renderSpeed = 1.0f; levelSpeed = 0.75f;                   // Velocidade		Nivel 1     Noob
        }
        else if (level < 15)
        {
            objSpeed = -0.75f; renderSpeed = 1.5f; levelSpeed = 0.65f;                  // Velocidade		Nivel 2		(+ 10)  Iniciante
        }
        else if (level < 30)
        {
            objSpeed = -1.0f; renderSpeed = 2.0f; levelSpeed = 0.55f;                   // Velocidade		Nivel 3		(+ 15)  Intermediário
        }
        else if (level < 55)
        {
            objSpeed = -1.25f; renderSpeed = 2.5f; levelSpeed = 0.45f;                  // Velocidade		Nivel 4		(+ 20)  Bom
        }
        else if (level < 80)
        {
            objSpeed = -1.50f; renderSpeed = 3.0f; levelSpeed = 0.35f;                  // Velocidade		Nivel 5		(+ 25)  Expert
        }
        else
        {
            objSpeed = -1.75f; renderSpeed = 3.5f; levelSpeed = 0.25f;                  // Velocidade		Nivel 6		PRO
        }

        return levelSpeed;
    }

    void OnTriggerEnter(Collider col)                                                   // Colisão
    {
        if (col.gameObject.CompareTag("Lixo"))                                          // Se colidir com Lixo
        {
            auCollect.Play();
            score.Collector(1);                                                         // Player faz 1 Ponto
            Destroy(col.gameObject);                                                    // Lixo é Destruído
            level++;
        }

        if (col.gameObject.CompareTag("Obstacle"))                                      // Se o Player colidir com Obstáculo
        {
            life--;
            auWarning.Play();
        }
    }
}
