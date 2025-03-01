"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/dataHub").build();

$(function () {
	connection.start().then(function () {
		InvokeSales();
	}).catch(function (err) {
		return console.error(err.toString());
	});
});
function InvokeSales() {
	connection.invoke("Sendline1003").catch(function (err) {
		return console.error(err.toString());
	});
}
connection.on("ReceivedLine1003ForGraph", function (salesForGraph) {
	BindSalesToGraph(salesForGraph);
});
function BindSalesToGraph(salesForGraph) {
    var labels = [];
    var data = [];

    // Log the data for debugging
    console.log("Sales Data Received:", salesForGraph);

    $.each(salesForGraph, function (index, item) {
        console.log("Item:", item); // Log the entire item to inspect its structure

        // Access the properties using the correct casing
        const timestamp = item.cpkLin3We3Timestamp; // Access the property with the correct casing
        const value = item.cpkLin3We3Value; // Access the property with the correct casing

        // Log the values being pushed to labels and data
        console.log("Timestamp:", timestamp);
        console.log("Value:", value);

        // Check if the timestamp is valid
        if (timestamp) {
            const date = new Date(timestamp);
            if (!isNaN(date.getTime())) { // Check if the date is valid
                labels.push(date); // Use Date object directly
                data.push(value); // Y-axis: Sales value
            } else {
                console.warn("Invalid timestamp:", timestamp);
            }
        } else {
            console.warn("Timestamp is null or undefined for item:", item);
        }
    });

    console.log("Labels:", labels);
    console.log("Data:", data);

    // Prevent empty chart rendering
    if (labels.length === 0 || data.length === 0) {
        console.warn("Chart data is empty! Check SignalR response.");
        return;
    }

    DestroyCanvasIfExists('canvasSales');

    const context = document.getElementById('canvasSales').getContext('2d');

    const myChart = new Chart(context, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Sales Over Time',
                data: data,
                backgroundColor: 'rgba(54, 162, 235, 0.2)', // Light blue
                borderColor: 'rgba(54, 162, 235, 1)', // Dark blue
                borderWidth: 2,
                fill: false,
                tension: 0.1
            }]
        },
        options: {
            responsive: true,
            scales: {
                x: {
                    type: 'time', // Ensure time scale is used
                    time: {
                        unit: 'minute'
                    },
                    title: {
                        display: true,
                        text: 'Timestamp'
                    }
                },
                y: {
                    beginAtZero: true,
                    title: {
                        display: true,
                        text: 'Sales Value'
                    }
                }
            }
        }
    });
}

// supporting functions for Graphs
function DestroyCanvasIfExists(canvasId) {
	let chartStatus = Chart.getChart(canvasId);
	if (chartStatus != undefined) {
		chartStatus.destroy();
	}
}

var backgroundColors = [
	'rgba(255, 99, 132, 0.2)',
	'rgba(54, 162, 235, 0.2)',
	'rgba(255, 206, 86, 0.2)',
	'rgba(75, 192, 192, 0.2)',
	'rgba(153, 102, 255, 0.2)',
	'rgba(255, 159, 64, 0.2)'
];
var borderColors = [
	'rgba(255, 99, 132, 1)',
	'rgba(54, 162, 235, 1)',
	'rgba(255, 206, 86, 1)',
	'rgba(75, 192, 192, 1)',
	'rgba(153, 102, 255, 1)',
	'rgba(255, 159, 64, 1)'
];