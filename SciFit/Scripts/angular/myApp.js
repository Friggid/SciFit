var app = angular.module('myApp', ['ui.calendar']);
app.controller('myNgController', ['$scope', '$http', 'uiCalendarConfig', '$timeout', function ($scope, $http, uiCalendarConfig, $timeout) {

    $scope.SelectedEvent = null;
    var isFirstTime = true;

    $scope.events = [];
    $scope.eventSources = [$scope.events];


    //Load events from server
    $http.get('/Sport/GetPlans', {
        cache: true,
        params: {}
    }).then(function (data) {
        $scope.events.slice(0, $scope.events.length);
        angular.forEach(data.data, function (value) {
            $scope.events.push({
                title: value.Name,
                description: value.Instructions,
                start: new Date(parseInt(value.StartDate.substr(6))),
                end: new Date(parseInt(value.EndDate.substr(6))),
                allDay: false,
                stick: true,
                done: value.Done
            });
        });

        for (var i = 0; i < $scope.events.length; i++) {

            if ($scope.events[i].done) {
                $scope.events[i].className = 'customDone';
            }
        }
    });

    //configure calendar
    $timeout(function() {
        $scope.uiConfig = {
            calendar: {
                height: 450,
                editable: true,
                displayEventTime: false,
                header: {
                    left: 'month basicWeek basicDay',
                    center: 'title',
                    right: 'today prev,next'
                },
                eventClick: function (event) {
                    $scope.SelectedEvent = event;
                },
                eventAfterAllRender: function () {
                    if (isFirstTime) {//$scope.events.length > 0 && 
                        //Focus first event
                       
                        uiCalendarConfig.calendars.myCalendar.fullCalendar('gotoDate', $scope.events[0].start);
                        isFirstTime = false;
                    }
                }
            }
        };
    }, 3000);
}])