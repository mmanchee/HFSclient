using System.Net.Http;
using System;
using System.Threading.Tasks;
using HFSclient.Wrappers;
namespace HFSaclient.Models
{
  public class Player
  {
    public int PlayerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
 

    public static async Task<Player> GetPlayerFromApi( int PlayerId)
    {
      var url = "http://localhost:5003/api/player/" +  PlayerId ;

      using (var client = new HttpClient())
      {
          client.BaseAddress = new Uri(url);

          HttpResponseMessage response = await client.GetAsync(url);

          if (response.IsSuccessStatusCode)
          {
              Response<Player> game = await response.Content.ReadAsAsync<Response<Player>>();
              return game.Data;
          }
          else
          {
              return null;
          }
      }
    }
    public static async Task<List<Player>> SearchPlayer( string LastName)
    {
      var url = "http://localhost:5003/api/player/search?LastName=" +  LastName ;

      using (var client = new HttpClient())
      {
          client.BaseAddress = new Uri(url);

          HttpResponseMessage response = await client.GetAsync(url);

          if (response.IsSuccessStatusCode)
          {
              PagedResponse<List<Player>> game = await response.Content.ReadAsAsync<Response<Player>>();
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