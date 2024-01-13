const VisitorsPerMonthChart = document.getElementById('visitors-per-month-chart');
const PageVisitsChart = document.getElementById('page-visits-chart');

//LOAD EVENT
$(document).ready(function () {

    // -- visitors-per-month-chart --

    //Setup request
    var xmlHttpRequestVisitorsPerMonthChart = new XMLHttpRequest();

    xmlHttpRequestVisitorsPerMonthChart.onload = function () {
        if (xmlHttpRequestVisitorsPerMonthChart.status >= 400) {
            //ERROR
            console.log(xmlHttpRequestVisitorsPerMonthChart);
            $.notify({ icon: "fas fa-exclamation-triangle", message: "There was an error while trying to get chart data" }, { type: "danger", placement: { from: "bottom", align: "center" } });
        }
        else {
            //SUCCESS
            let data = JSON.parse(xmlHttpRequestVisitorsPerMonthChart.response);

            let arrayMonth = new Array();
            let arrayCounterOfVisitors = new Array();

            for (var i = 0; i < Object.keys(data).length; i++) {
                arrayMonth.push(data[i].Month);
                arrayCounterOfVisitors.push(data[i].CounterOfVisitors);
            }

            new Chart(VisitorsPerMonthChart, {
                type: 'bar',
                data: {
                    labels: arrayMonth,
                    datasets: [{
                        label: 'Visitors per month',
                        data: arrayCounterOfVisitors,
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        }
    };
    //Open connection
    xmlHttpRequestVisitorsPerMonthChart.open("GET", "/api/BasicCore/VisitorCounter/1/SelectAllToVisitorsPerMonthChart", true);
    //Send request
    xmlHttpRequestVisitorsPerMonthChart.send(formData);

    // -- page-visits-chart --

    //Setup request
    var xmlHttpRequestPageVisitsChart = new XMLHttpRequest();

    xmlHttpRequestPageVisitsChart.onload = function () {
        if (xmlHttpRequestPageVisitsChart.status >= 400) {
            //ERROR
            console.log(xmlHttpRequestPageVisitsChart);
            $.notify({ icon: "fas fa-exclamation-triangle", message: "There was an error while trying to get chart data" }, { type: "danger", placement: { from: "bottom", align: "center" } });
        }
        else {
            //SUCCESS
            let data = JSON.parse(xmlHttpRequestPageVisitsChart.response);

            let arrayPage = new Array();
            let arrayCounterOfVisitors = new Array();

            for (var i = 0; i < Object.keys(data).length; i++) {
                arrayPage.push(data[i].Page);
                arrayCounterOfVisitors.push(data[i].CounterOfVisitors);
            }

            console.log(arrayPage);
            console.log(arrayCounterOfVisitors);

            new Chart(PageVisitsChart, {
                type: 'bar',
                data: {
                    labels: arrayPage,
                    datasets: [{
                        label: 'Page visits',
                        data: arrayCounterOfVisitors,
                        borderWidth: 1
                    }]
                },
                options: {
                    indexAxis: 'y',
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        }
    };
    //Open connection
    xmlHttpRequestPageVisitsChart.open("GET", "/api/BasicCore/VisitorCounter/1/SelectAllToVisitorsCounterPageChart", true);
    //Send request
    xmlHttpRequestPageVisitsChart.send(formData);


});