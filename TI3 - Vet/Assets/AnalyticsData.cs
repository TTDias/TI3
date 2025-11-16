using System;

[Serializable]
public class AnalyticsData
{
    public float time; //Tempo de jogo
    public string sender; //Quem envia
    public string track; //Evento rastreado
    public string value; //valor do evento
    
    public AnalyticsData(float time, string sender, string track, string value)
    {
        this.time = time;
        this.sender = sender;
        this.track = track;
        this.value = value;
    }
    
}

[Serializable]
public class AnalyticsFile
{
    public AnalyticsData[] data; //Lista de todos os daddos
}

/*
 * Eventos rastreaveis:
 * 
 * Quantas vezes o gato fugiu
 * Qual item fez o gato fugir
 * Quantas caixas posicionou
 * Quantos itens consertou
 * Número de plays
 * Vitorias e derrotas
 * Pontuação final
 * 
 */