using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Variables
    string[] questions = { "adivinanza 1", "adivinanza 2", "adivinanza 3" };
    string[] answers = { "Respuesta 1", "Respuesta 2", "Respuesta 3" };

    int currentQuestion = 0;
    //Referencia publica pra enfviar el texto del array
    public Text questionText, answerText;
    //Se guarda la respuesta del jugador
    string userAnswer;

    public GameObject StarGamePanel, GameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        StarGamePanel.SetActive(true); //activa el panel para que se vea en pantalla 
    }

    // Update is called once per frame
    void Update()
    {
        ShowQuestion();
        SaveUserAnswer();
    }


    void ShowQuestion()
    {
        //mandar a llamar el texto de la adivinanza del array question en base a la posicion de currentQuestion
        questionText.text = questions[currentQuestion];
    }

    void SaveUserAnswer()
    {
        //Siempre que la caja de texto no este vasio , el jugador a escrito algo y se guarda
        if(answerText.text != "")
        {
            userAnswer = answerText.text;
            Debug.Log(userAnswer);
        }
    }

    public void ValidateUserAnswer() // Para validar si es correcta la respuesta
    {
        string correctAnswer = answers[currentQuestion].ToUpper();  //se guarda la resuesta de la adivinanza // .ToUpper()PARA PONER TODA LA RESPUESTA EN MAYUSCULAS
        string currentUserAnswer = userAnswer.ToUpper();  // respuesta del jugador

        if(currentUserAnswer == correctAnswer)
        {
            Debug.Log("Correcto");
            //si es correcto se manda a llamar a la funcion NextQuestion()
            NextQuestion();
        }
        else
        {
            Debug.Log("Incorrecto");
        }
    }
    //funcion para pasar a la siguiente pregunta
    public void NextQuestion()
    {
        //Se agrega logica para no pasarnos del array establecido array[p1, p2] -> 0,1 tamaÑo total 2
        if(currentQuestion+1 >questions.Length-1)
        {
            currentQuestion = 0;
            GameOverPanel.SetActive(true);
        } else
        {
            currentQuestion++;
        }
        
    }
    //Para el inicio del juego y como reinicio
    public void StarTheGame()
    {
        if (StarGamePanel.activeInHierarchy == true) // Si esta activo el panel de inicio de juego se desactiva ese
        {
            StarGamePanel.SetActive(false);
        }
        if (GameOverPanel.activeInHierarchy == true)// Si esta activo el panel de gameover de juego se desactiva ese
        {
            GameOverPanel.SetActive(false);
        }
    }

    //Para salir del juego
    public void QuiTheGame()
    {
        Application.Quit();
    }

}
