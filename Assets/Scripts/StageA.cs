using UnityEngine;
using System.Collections;

public class StageA : MonoBehaviour {													// Atrelado ao Spawn&Destroy
    // Declarações
    public GameMotor engine;                                                            // Chama o script Game Motor

    public GameObject[] obstacles, trash;                                              	// Listas de Prefabs de Objetos
	int[] itensPos = new int[3] { -10, 0, 10 };                                         // Posições Primárias

    public GameObject smoke;                                                            // Prefab de Nuvens
	int[] cloudPosX = new int[6] { -30, -20, -15, 15, 20, 30};                          // Posições em X
	int[] cloudPosY = new int[3] { 10, 15, 20 };                            // Posições em Y

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
        timeElapsed += Time.deltaTime;                                         			// Faz o Tempo Correr

        int randomP = itensPos[Random.Range(0, itensPos.Length)];                       // Randomiza entre as Posições
		int cloudX = cloudPosX[Random.Range(0, cloudPosX.Length)];                      // Randomiza entre as Posições das Nuvens
		int cloudY = cloudPosY[Random.Range(0, cloudPosY.Length)];
        
        if (timeElapsed > cycle)                                                        // Se o Tempo Decorrido for maior que o Ciclo de SPAWN
        {
			GameObject tempCloud;                                                     	// Instancia Temporária de Nuvens

			tempCloud = (GameObject)Instantiate(smoke);                                 // Coloca o Lixo na Instancia Temporária                  
			tempCloud.transform.position = new Vector3(cloudX, cloudY, 200);            // Gera a posição do Spawn do Prefab

            GameObject tempObjectA;                                                     // Instancia Temporária de Objetos

            if (spawnLixo)                                                              // Se for hora de Sapwnar Lixo
            {
                int randomColl = Random.Range(0, trash.Length);                       	// Randomiza o que será Spawnado na Lista de Itens Coletáveis (Lixo)
				tempObjectA = (GameObject)Instantiate(trash[randomColl]);             	// Coloca o Lixo na Instancia Temporária                  
				tempObjectA.transform.position = new Vector3(randomP, -0.50f, 200);     // Gera a posição do Spawn do Prefab
            }

            else                                                                        // Caso contrário é hora de Spawnar Obstáculos
            {
                int randomObs = Random.Range(0, obstacles.Length);                      // Randomiza o que será Spawnado na Lista de Itens Coletáveis (Lixo)
				tempObjectA = (GameObject)Instantiate(obstacles[randomObs]);            // Coloca o Obstáculo na Instancia Temporária                      
				tempObjectA.transform.position = new Vector3(randomP, -0.50f, 200);     // Spawna o Obstaculo com a posição do Prefab Exceto em X
            }

            timeElapsed -= cycle;                                                       // Remove do Tempo Decorrido o Ciclo
            spawnLixo = !spawnLixo;                                                     // Reverte a Ordem de Spawn (Troca entre Verdadeiro e Falso)
        }
    }

	void OnTriggerEnter(Collider col)                                                   // Se os Objetos colidirem com o Limite
    {
        if (col.gameObject.CompareTag("Lixo") || col.gameObject.CompareTag("Obstacle") || col.gameObject.CompareTag("Cloud"))                                          // Se os Objetos colidirem com o Player
        {
            Destroy(col.gameObject);                                                    // São Destruídos               (Optimização)
        }
    }
}