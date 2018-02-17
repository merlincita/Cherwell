(function () {
    'use strict';

    angular
        .module('app')
        .controller('GeoLayoutController', GeoLayoutController);

    GeoLayoutController.$inject = ['GeoLayoutService'];

    function GeoLayoutController(GeoLayoutService) {
       
        var vm = this;
        vm.calculateCoordinates = calculateCoordinates;
        vm.calculateRowColumn = calculateRowColumn;
        vm.coordinates = [];
        vm.row;
        vm.column;
        vm.rowcolumn = {};
        vm.v1 = {};
        vm.v1.X;
        vm.v1.Y;
        vm.v2 = {};
        vm.v2.X;
        vm.v2.Y;
        vm.v3 = {};
        vm.v3.X;
        vm.v3.Y;

        function calculateCoordinates() {
            var rowNumber = 1;
            switch (vm.row) {
                case 'A':
                    rowNumber = 1;
                    break;
                case 'B':
                    rowNumber = 2;
                    break;
                case 'C':
                    rowNumber = 3;
                    break;
                case 'D':
                    rowNumber = 4;
                    break;
                case 'E':
                    rowNumber = 5;
                    break;
                case 'F':
                    rowNumber = 6;
                    break;
            }
            GeoLayoutService.calculateTriangleCoordinates({Column: vm.column, Row: rowNumber})
            .then(function (res) {
                vm.coordinates = res.data;
            })
            .catch(function (err) {
                console.log(err);
            });
        }

        function calculateRowColumn() {
            var vertexs = [];
            vertexs.push(vm.v1);
            vertexs.push(vm.v2);
            vertexs.push(vm.v3);
            GeoLayoutService.calculateRowColumn(vertexs)
            .then(function (res) {
                vm.rowcolumn.Column = res.data.Column;
                switch (res.data.Row) {
                    case 1:
                        vm.rowcolumn.Row = 'A';
                        break;
                    case 2:
                        vm.rowcolumn.Row = 'B';
                        break;
                    case 3:
                        vm.rowcolumn.Row = 'C';
                        break;
                    case 4:
                        vm.rowcolumn.Row = 'D';
                        break;
                    case 5:
                        vm.rowcolumn.Row = 'E';
                        break;
                    case 6:
                        vm.rowcolumn.Row = 'F';
                        break;
                }
            })
            .catch(function (err) {
                console.log(err);
            });
        }
    }
})();
