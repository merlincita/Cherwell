using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometricLayouts.Controllers;
using GeometricLayouts.Models;
using System.Linq;

namespace GeometricLayouts.Tests
{
    [TestClass]
    public class UnitTestGeoCtrlr
    {
        [TestMethod]
        public void TestCalculationTriangleCoordinates()
        {
            var item = new Item { Column = 8, Row = 3 }; // row = C
            var controller = new GeometryController();
            var result = controller.CalculateTriangleCoordinates(item);
            Assert.AreEqual(result.Count, 3);
            Assert.IsTrue(result.Any(obj => obj.X == 30 && obj.Y == -20));
            Assert.IsTrue(result.Any(obj => obj.X == 40 && obj.Y == -20));
            Assert.IsTrue(result.Any(obj => obj.X == 40 && obj.Y == -30));
        }

        [TestMethod]
        public void TestCalculationRowColumn()
        {
            var v1 = new Coordinate { X = 30, Y = -20 };
            var v2 = new Coordinate { X = 40, Y = -20 };
            var v3 = new Coordinate { X = 40, Y = -30 };
            var controller = new GeometryController();
            var result = controller.CalculateRowColumn(new System.Collections.Generic.List<Coordinate> { v1, v2, v3 });
            Assert.AreEqual(result.Column, 8);
            Assert.AreEqual(result.Row, 3);
        }
    }
}