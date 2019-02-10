using System.Web.Http;
using Newtonsoft.Json.Linq;

using RBoggleAPI.Boards;

namespace RBoggleAPI.Controllers
{

    public class BoggleController : ApiController
    {      

        [HttpPost]
        public IHttpActionResult Solve(BoardProperties boardProperties)
        {
            if (boardProperties == null)
            {
                return BadRequest("Invalid Request Object");
            }               

            if (boardProperties.Letters.Length != (int) boardProperties.Style)
            {
                return BadRequest("Invalid Letter Count " + boardProperties.Letters.Length + ". Must use " + (int) boardProperties.Style + " letters. ");
            }

            var board = BoardFactory.CreateBoard(boardProperties.Style, boardProperties.Dictionary, boardProperties.Board, boardProperties.Letters);                                                                  
            var json = JToken.FromObject(board.Solve());
            return Ok(json);
        }      
    }
}
