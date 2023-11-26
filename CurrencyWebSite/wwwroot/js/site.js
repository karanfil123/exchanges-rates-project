$(document).ready(function () {
    var myChart = null;

    $.get(`https://localhost:5000/api/Currency/addCurrencyData`, function (data) {
        console.log(data)
    })


    $('#searchBtn').click(function () {
        const rateCode = $('#rateInput').val();      


        $.get(`https://localhost:5001/api/ExchageRate/rates/${rateCode}`, function (data) {
            if (myChart !== null) {
                myChart.destroy(); 
            }
            drawLineChart(data); 
        }).fail(function () {
            alert("Değer girmeniz gerekiyor");
        });
    });

    function drawLineChart(data) {
        const ctx = document.getElementById('chart');
        var dates = data.map(function (item) {
            return item.date;
        });
        var forexBuyingValues = data.map(function (item) {
            return item.forexBuying;
        });
        var forexSellingValues = data.map(function (item) {
            return item.forexSelling;
        });

        myChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: dates,
                datasets: [{
                    data: forexBuyingValues,
                    borderColor: 'blue',
                    label: 'Döviz Kuru Alış',
                    borderWidth: 1,
                    fill: false
                }, {
                    data: forexSellingValues,
                    borderColor: 'red',
                    label: 'Döviz Kuru Satış', 
                    borderWidth: 1,
                    fill: false
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
});
