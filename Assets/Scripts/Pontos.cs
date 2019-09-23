using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pontos : MonoBehaviour
{   // Atributos
    public int garbage = 0, stageScore;                                         // Trocar stageScore por garbage caso não funcione ainda
    private float timeElapsed, calc;
    public Text textoColeta, textoPontos;
    //public AudioSource auScore, auEffect;

    // Métodos
    void Start()
    {
        stageScore = PlayerPrefs.GetInt("SCORE");                               // Trocar stageScore por garbage caso não funcione ainda
        PlayerPrefs.SetInt("SCORE", 0);
        textoPontos.text = "Score: " + stageScore;                              // Trocar stageScore por garbage caso não funcione ainda
    }

    void Update()
    {
        timeElapsed+=Time.deltaTime;                                            // Conta o Tempo
        calc = (garbage * 100) / timeElapsed;                                   // Divide Garbage pelo tempo
        stageScore = (int)calc;                                                 // Transforma FLOAT em INT
    }

    public void Collector(int collected)                                        // Controla o Placar recebendo os Pontos Coletados
    {
        garbage += collected;                                                   // Adiciona o ponto Coletado aos Total de Pontos
        textoColeta.text = (garbage + "/" + 50);                              // Altera o Texto de Lixo Coletados
        PlayerPrefs.SetInt("SCORE", stageScore);

        /*switch (garbage)
        {
            case 5: auEffect.Play();
                break;

            case 10: auScore.Play();
                break;

            case 15: auEffect.Play();
                break;

            case 20: auScore.Play();
                break;

            case 30: auScore.Play();
                break;

            case 40: auScore.Play();
                break;

            case 45: auEffect.Play();
                break;

            default:
                break;
        }*/

        if (garbage == 50)
        {
            SceneManager.LoadScene("NextStage2");

            /*
            
            Notas de Desenvolvimento:

            - Quando o jogador chegar a 50 pontos, o Objetivo é mostrado como completo
            - Uma barra inferior avisa que você pode continuar coletando pontos, antes de ir para o próximo estágio.
            - O jogador continua na fase fazendo mais pontos se quiser (Isso deixa o jogo mais competitivo, quem arriscar continuar e fazer + pontos ficara em primeiro no Ranking)
            - A Mensagem na Barra muda para: Pressione ESC para resumir o estágio
            - Ao pressionar ESC vc vai pro resumo da sua pontuação daquela fase, e vê também a pontuação total
            - Nessa mesma janela tem a opção de ir para a próxima fase

            */
        }
    }
}