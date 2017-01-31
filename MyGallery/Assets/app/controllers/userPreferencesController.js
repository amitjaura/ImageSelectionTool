angular.module('userPreferences', [])
    .controller('userPreferencesController', ['$scope', '$http', '$timeout', function ($scope, $http, $timeout) {
        var self = this;
        var preferenceFilter='';

        $scope.like = "/img/liked.png";
        $scope.dislike = "/img/disliked.png";
        $scope.isWaitOver = false;
        function getPreferences(preferenceFilter) {
            $http.get('/api/WS_UserImagePreference/GetUserPreferences', {
                params: { preference: preferenceFilter }
            })
                .success(function (data, status, headers, config) {
                    $scope.preferences = data;
                    $timeout(function () { $scope.isWaitOver = true }, 3000);
                });
        }

        $scope.onChangeFilter = function () {
            getPreferences($scope.ImagePreference);
        }

        getPreferences('');
    }]);