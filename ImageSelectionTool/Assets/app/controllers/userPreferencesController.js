angular.module('userPreferences', [])
    .controller('userPreferencesController', ['$scope', '$http', '$timeout', function ($scope, $http, $timeout) {
        var self = this;
        var preferenceFilter='';

        $scope.like = "/img/liked.png";  //actually we can move this to less/css and make use of ng-class. would me a good choice though.
        $scope.dislike = "/img/disliked.png";
        $scope.isWaitOver = false;
        function getPreferences(preferenceFilter) {
            $http.get('/api/WS_UserImagePreference/GetUserPreferences', {
                params: { preference: preferenceFilter }
            })
                .success(function (data, status, headers, config) {
                    $scope.preferences = data;

                    //can find a better way to wait untill an Image is loaded fully, then only show like/dislike button
                    //for the time being just waiting for 1 sec..lets hope our image is not too large in size
                    $timeout(function () { $scope.isWaitOver = true }, 1000);
                });
        }

        $scope.onChangeFilter = function () {
            getPreferences($scope.ImagePreference);
        }

        getPreferences('');
    }]);