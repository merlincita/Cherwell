using GeometricLayouts.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GeometricLayouts.Controllers
{
    public class GeometryController : ApiController
    {
        /// <summary>
        /// Problem 1A
        /// </summary>
        /// <param name="rc">defines the object with the attributes column and row</param>
        /// <returns>list of the triangle coordinates</returns>
        [HttpPost]
        [Route("api/Geometry/CalculateTriangleCoordinates")]
        public List<Coordinate> CalculateTriangleCoordinates(Item rc)
        {
            var list = new List<Coordinate>();
            var vertex1 = new Coordinate
            {
                X = rc.Column % 2 == 1 ? 10 * (int)(rc.Column / 2) : 10 * (int)((rc.Column - 1) / 2),
                Y = -(rc.Row - 1) * 10
            };
            list.Add(vertex1);

            var vertex2 = new Coordinate
            {
                X = vertex1.X + 10,
                Y = vertex1.Y - 10
            };
            list.Add(vertex2);

            var vertex3 = new Coordinate
            {
                X = rc.Column % 2 == 1 ? vertex1.X : vertex1.X + 10,
                Y = rc.Column % 2 == 1 ? vertex1.Y - 10 : vertex1.Y
            };
            list.Add(vertex3);

            return list;
        }


        /// <summary>
        /// Problem 1B
        /// </summary>
        /// <param name="vertexs"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Geometry/CalculateRowColumn")]
        public Item CalculateRowColumn(List<Coordinate> vertexs)
        {
            var min = vertexs.Select(obj => obj.Y).Min();

            Coordinate vertex;
            if (vertexs[0].X == vertexs[1].X)
            {
                vertex = vertexs[0];
            }
            /*else if (vertexs[2].X == vertexs[1].X)
            {
                vertex = vertexs[2];
            }*/
            else
            {
                vertex = vertexs[2];
            }

            var col = (vertex.X / 10) * 2 + (vertex.X / 10) % 2;
            return new Item { Row = -min / 10, Column = col };
        }
    }
}