using UnityEngine;
using System.Collections;

public class StageC : MonoBehaviour {													// Atrelado ao Spawn&Destroy
    // Declarações
    public GameMotor engine;                                                            // Chama o script Game Motor

    public GameObject[] obstacles, trash;                                              	// Listas de Prefabs

    int[] itensPos = new int[3] { -10, 0, 10 };                                         // Posições Primárias

    float timeElapsed = 0;                                                              // Tempo Decorrido
	bool spawnLixo = true;                                                              // Condição de Spawn de Lixo                                      

    // Métodos

    void Update ()
    {
        if (Time.timeScale == 1)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        float cycle = engine.LevelControl();

        timeElapsed += Time.deltaTime;                                                  // Faz o Tempo Correr
        int randomP = itensPos[Random.Range(0, itensPos.Length)];                       // Randomiza entre as Posições
        
        if (timeElapsed > cycle)                                                        // Se o Tempo Decorrido for maior que o Ciclo de SPAWN
        {
			GameObject tempObjectC;                                                     // Instancia Temporária

			if (spawnLixo)                                                              // Se for hora de Sapwnar Lixo
			{
				int randomColl = Random.Range(0, trash.Length);                       	// Randomiza o que será Spawnado na Lista de Itens Coletáveis (Lixo)
				tempObjectC = (GameObject)Instantiate(trash[randomColl]);             	// Coloca o Lixo na Instancia Temporária                  
				tempObjectC.transform.position = new Vector3(randomP, -0.50f, 150);     // Gera a posição do Spawn do Prefab
			}

			else                                                                        // Caso contrário é hora de Spawnar Obstáculos
			{
				int randomObs = Random.Range(0, obstacles.Length);                      // Randomiza o que será Spawnado na Lista de Itens Coletáveis (Lixo)
				tempObjectC = (GameObject)Instantiate(obstacles[randomObs]);            // Coloca o Obstáculo na Instancia Temporária                      
				tempObjectC.transform.position = new Vector3(randomP, 0, 150);     		// Spawna o Obstaculo com a posição do Prefab Exceto em X
			}

            timeElapsed -= cycle;                                                       // Remove do Tempo Decorrido o Ciclo
            spawnLixo = !spawnLixo;                                                     // Reverte a Ordem de Spawn (Troca entre Verdadeiro e Falso)
        }
    }

    void OnTriggerEnter(Collider col)                                                   // Colisão
    {
		if (col.gameObject.CompareTag("Lixo")|| col.gameObject.CompareTag("Obstacle"))  // Se os Objetos colidirem com o Limite
        {
            Destroy(col.gameObject);                                                    // São Destruídos               (Optimização)
        }
    }
}