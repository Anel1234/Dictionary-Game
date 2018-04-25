var app = angular.module("WordApp", []);
var x;

app.controller("wordController", function ($scope, $http, $timeout) {

    //function somefunc() {
    //    $("#wordInput").val("");
    //    $scope.firstWord();
    //    $("#icon").css("display", "none");
    //}

    //function instant() {
    //    $("#icon").css("display", "inline-block");
    //    //$("#wordInput").keyup("false");;
    //}
    $scope.somefunc = function () {
        alert("hello");
    }

    $scope.firstWord = function () {
        $http.get("http://localhost:51037/api/Words/5").then(function (response) {
            //alert(data.dictionary.word);
            //$scope.worddata = data.dictionary;
            $scope.dictionary = response.data;
            x = response.data.Word;
            
        });
    };
    $scope.updateWord = function () {
        if ($("#wordInput").val().toLowerCase() == x) {
            //alert($("#wordInput").val())
            $("#wordInput").blur();
            $("#wordInput").attr("readonly", "readonly");
            $("#icon").show();
            $("#swap").hide();
            //instant();
            $timeout(function () {
                $scope.firstWord();
                $("#wordInput").val("");
                setTimeout(function () { $("#wordInput").focus(); }, 10); //Delay is included so focus works with IE
                $("#wordInput").removeAttr("readonly");
                $("#icon").hide();
                $("#swap").show();
            }, 2000);
            //setTimeout(somefunc, 1000);
            //$("#wordInput").val("");
            //$scope.firstWord();
            //$("#inputbox").value = "";
            //$http.get("http://localhost:51037/api/Words/5").then(function (response) {
            //    $scope.dictionary = response.data;
        };
    };
    $scope.skipWord = function () {
        $("#wordInput").val("");
        $scope.firstWord();
    }
});

//var word = "Reggae";

//$(document).ready(function () {
//    $(".test").on("click", (function () {
//        $(".test").hide();
//    }));
//});

////$('.test').hide();

//$(document).ready(function () {
//    $("button").click(function () {
//        $("p").hide();
//    });
//});

//$(document).ready(function () {
//    $("#wordInput").keyup(function () {
//        if ($(this).val() == $("#word1").text()) {
//            instant();
//            setTimeout(somefunc, 1000);         
//            //angular.element('#wordInfo').scope().AngularFunction();
//            //$("#icon").css("display", "inline-block");
//            //$(this).val('');
//        };
//        //console.log("hello");
//    });
//});



//function MyController($scope, $http) {

//    $scope.items = [];
//    $scope.getItems = function () {

//        $http({ method: 'GET', url: 'api/Words'})
//            .success(function (data, status) {
//                $scope.items = data;
//            })
//            .error(function (data, status) {
//                alert("Error");
//            });
//    };
//}

//app.controller('APIController', function ($scope, APIService) {
//    getAll();

//    function getAll() {
//        var servCall = APIService.getSubs();
//        servCall.then(function (d) {
//            $scope.subscriber = d.data;
//        }, function (error) {
//                $log.error('Oops! Something went wrong while fetching the data.')
//            })
//    }
//})

//var app = angular.module("WordApp", []);

//app.controller("WordCtrl", function ($scope, $http) {
//    $scope.NewDefinition = function () {
//        $http.get('http://localhost:51037/api/Words')
//            .then(function (response) {
//                $scope.words = response.data;
//            })
//    };
//});

//app.controller("WordCtrl2", function ($scope, $http) {
//    $scope.AngularFunction = function () {
//        $http.get('http://localhost:51037/api/Words/1')
//            .then(function (response) {
//                $scope.words = response.data;
//            });
//    };
//});