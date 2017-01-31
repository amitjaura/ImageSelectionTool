angular.module('traverseImage', [])
    .controller('traverseImageController', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {
        if ($rootScope.loggedIn!=undefined && $rootScope.loggedIn == false) window.location = '#/signin';
        $scope.imageSelected = false;

        $scope.getImage = function () {
            $http.get('/api/WS_TraverseImage/GetRandomImage')
            .success(function (data, status, headers, config) {
                $scope.imageSelected = true;;
                $scope.imageUrl = data.ImagePath;
                $scope.imageName = data.ImageName;
                $scope.btnDisable = true;
                resetPreferenceIcon();
            });
        }

        $scope.savePreference = function (isLikeDislike) {
            data = {
                ImagePreference: isLikeDislike,
                ImageName: $scope.imageName
            }
            $http.post('/api/WS_TraverseImage/SavePreference', data)
            .success(function (data, status, headers, config) {
                resetPreferenceIcon();
                if (isLikeDislike) $scope.like = "/img/liked.png";
                else $scope.dislike = "/img/disliked.png";
            });
        };

        function resetPreferenceIcon() {
            $scope.like = "/img/like.png";
            $scope.dislike = "/img/dislike.png";
        }

        $scope.imageUrl = '/img/noimage.jpg';
    }]);