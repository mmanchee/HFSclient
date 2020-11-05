
using System.Net.Http;
using System;
using System.Threading.Tasks;
using HFSclient.Wrappers;
namespace HFSclient.Models
{
  public class Game
  {
    public int GameId { get; set; }
    public int ScheduleId { get; set; }
    public int PlayerId { get; set; }
    public int Season { get; set; }
    public int Week { get; set; }
    public string Team { get; set; }
    public int PassYards { get; set; }
    public int RecYards { get; set; }
    public int RushYards { get; set; }
    public int Interceptions { get; set; }
    public int Fumbles { get; set; }
    public int Receptions { get; set; }
    public int PassTDs { get; set; }
    public int RushTDs { get; set; }
    public int RecTDs { get; set; }
    public Game()
    {
      
    }
    public int CalcScore() //to make a settings add a settings class and pass it through with all the point values set
    {
      int score = 0;
      score += this.PassYards / 25;
      score += this.PassTDs * 4;
      score += this.RecTDs * 6;
      score += this.RecYards / 10;
      score += this.RushTDs * 6;
      score += this.RushTDs / 10;
      score += this.Fumbles * -2;
      score += this.Interceptions * -2;
      return score;
    }

    public static async Task<Game> GetGameByWeek(int Week, int PlayerId)
    {
      var url = "http://localhost:5003/api/GetGame/" + Week + "/" + PlayerId ;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                Response<Game> game = await response.Content.ReadAsAsync<Response<Game>>();
                return game.Data;
            }
            else
            {
                return null;
            }
        }
    }
  }
}