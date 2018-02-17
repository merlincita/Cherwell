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
        public List<Coordinate> CalculateTriangleCoordinates(GridItem rc)
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
        /// <param name="vertexs">list of the triangle coordinates</param>
        /// <returns>column and row of that triangle in the square</returns>
        [HttpPost]
        [Route("api/Geometry/CalculateRowColumn")]
        public GridItem CalculateRowColumn(List<Coordinate> vertexs)
        {
            var min = vertexs.Select(obj => obj.Y).Min();
            
            var orderedVertexs = vertexs.OrderBy(obj => obj.X).ThenBy(obj => obj.Y).ToList();
            int col;
            if (orderedVertexs[0].X == orderedVertexs[1].X)
                col = orderedVertexs[1].X / 10 * 2 + 1;
            else col = orderedVertexs[1].X / 10 * 2; // orderedVertexs[0].Y = orderedVertexs[1].Y

            return new GridItem { Row = -min / 10, Column = col };
        }
    }
}