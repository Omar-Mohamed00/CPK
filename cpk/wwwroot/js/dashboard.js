"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/dataHub").build();
$(function () {
	connection.start().then(function () {
		InvokeSales();
        InvokeSales1010();
        InvokeSales1011();
        InvokeSales10113();
        InvokeSales1013();
        InvokeSales1014();
	}).catch(function (err) {
        return console.error("SignalR Connection Error:", err.toString());
	});
});
function InvokeSales1010() {
    connection.invoke("Sendline1010").catch(function (err) {
        return console.error(err.toString());
    });
}
function InvokeSales1011()
{
    connection.invoke("Sendline1011").catch(function (err) {
        return console.error(err.toString());
    });
}
function InvokeSales10113() {
    connection.invoke("Sendline10113").catch(function (err) {
        return console.error(err.toString());
    });
}
function InvokeSales1013() {
    connection.invoke("Sendline1013").catch(function (err) {
        return console.error(err.toString());
    });
}
function InvokeSales1014() {
    connection.invoke("Sendline1014").catch(function (err) {
        return console.error(err.toString());
    });
}
function InvokeSales() {
	connection.invoke("Sendline1003").catch(function (err) {
		return console.error(err.toString());
    });
}
connection.on("ReceivedLine1003ForGraph", function (Line1003ForGraph) {
    console.log("New real-time data received:", Line1003ForGraph);
    BindLine1003ToGraph(Line1003ForGraph);
});
connection.on("ReceivedLine1010ForGraph", function (Line1010ForGraph) {
    console.log("New real-time data received:", Line1010ForGraph);

    BindLine1010ToGraph1010(Line1010ForGraph);
});
connection.on("ReceivedLine1011ForGraph", function (Line1011ForGraph) {
    console.log("New real-time data received:", Line1011ForGraph);

    BindLine1011ToGraph1011(Line1011ForGraph);
});
connection.on("ReceivedLine10113ForGraph", function (Line10113ForGraph) {
    console.log("New real-time data received:", Line10113ForGraph);

    BindLine10113ToGraph10113(Line10113ForGraph);
});
connection.on("ReceivedLine1013ForGraph", function (Line1013ForGraph) {
    console.log("New real-time data received:", Line1013ForGraph);

    BindLine1013ToGraph1013(Line1013ForGraph);
});
connection.on("ReceivedLine1014ForGraph", function (Line1014ForGraph) {
    console.log("New real-time data received:", Line1014ForGraph);
    BindLine1014ToGraph1014(Line1014ForGraph);
});
function BindLine1003ToGraph(Line1003ForGraph) {
    if (!window.myCharts) {
        window.myCharts = {};
    }

    if (!window.myCharts['canvasLine1003']) {
        // Create the chart if it doesn't exist
        const context = document.getElementById('canvasLine1003').getContext('2d');

        window.myCharts['canvasLine1003'] = new Chart(context, {
            type: 'line',
            data: {
                labels: [],
                datasets: [{
                    label: 'Values Over Time',
                    data: [],
                    backgroundColor: 'rgba(54, 162, 235, 0.2)',
                    borderColor: 'rgba(54, 162, 235, 1)',
                    borderWidth: 2,
                    fill: false,
                    tension: 0.1
                }]
            },
            options: {
                responsive: true,
                scales: {
                    x: {
                        display: true,
                        title: {
                            display: true,
                            text: 'Timestamp'
                        }
                    },
                    y: {
                        beginAtZero: true,
                        title: {
                            display: true,
                            text: 'Values'
                        }
                    }
                }
            }
        });
    }

    // Get the existing chart
    const myChart = window.myCharts['canvasLine1003'];

    Line1003ForGraph.forEach(item => {
        const timestamp = item.cpkLin3We3Timestamp;
        const value = item.cpkLin3We3Value;

        if (timestamp) {
            const date = new Date(timestamp);
            if (!isNaN(date.getTime())) {
                // Append new data
                myChart.data.labels.push(date.toISOString());
                myChart.data.datasets[0].data.push(value);
            } else {
                console.warn("Invalid timestamp:", timestamp);
            }
        }
    });

    // ✅ Update chart without recreating it
    myChart.update();
}

//function BindLine1003ToGraph(Line1003ForGraph) {
//    var labels = [];
//    var data = [];

//    // Log the data for debugging
//    console.log("Sales Data Received:", Line1003ForGraph);

//    $.each(Line1003ForGraph, function (index, item) {
//        console.log("Item:", item); // Log the entire item to inspect its structure

//        // Access the properties using the correct casing
//        const timestamp = item.cpkLin3We3Timestamp; // Access the property with the correct casing
//        const value = item.cpkLin3We3Value; // Access the property with the correct casing

//        // Log the values being pushed to labels and data
//        console.log("Timestamp:", timestamp);
//        console.log("Value:", value);

//        // Check if the timestamp is valid
//        if (timestamp) {
//            const date = new Date(timestamp);
//            if (!isNaN(date.getTime())) { // Check if the date is valid
//                labels.push(date); // Use Date object directly
//                data.push(value); // Y-axis: Sales value
//            } else {
//                console.warn("Invalid timestamp:", timestamp);
//            }
//        } else {
//            console.warn("Timestamp is null or undefined for item:", item);
//        }
//    });

//    console.log("Labels:", labels);
//    console.log("Data:", data);

//    // Prevent empty chart rendering
//    if (labels.length === 0 || data.length === 0) {
//        console.warn("Chart data is empty! Check SignalR response.");
//        return;
//    }

//    DestroyCanvasIfExists('canvasLine1003');

//    const context = document.getElementById('canvasLine1003').getContext('2d');

//    const myChart = new Chart(context, {
//        type: 'line',
//        data: {
//            labels: labels,
//            datasets: [{
//                label: 'Values Over Time',
//                data: data,
//                backgroundColor: 'rgba(54, 162, 235, 0.2)', // Light blue
//                borderColor: 'rgba(54, 162, 235, 1)', // Dark blue
//                borderWidth: 2,
//                fill: false,
//                tension: 0.1
//            }]
//        },
//        options: {
//            responsive: true,
//            scales: {
//                x: {
//                    type: 'time', // Ensure time scale is used
//                    time: {
//                        unit: 'minute'
//                    },
//                    title: {
//                        display: true,
//                        text: 'Timestamp'
//                    }
//                },
//                y: {
//                    beginAtZero: true,
//                    title: {
//                        display: true,
//                        text: 'Values Value'
//                    }
//                }
//            }
//        }
//    });
//}
//function BindLine1010ToGraph1010(Line1010ForGraph) {
//    if (!window.myCharts) {
//        window.myCharts = {};
//    }

//    if (!window.myCharts['canvasLine1010']) {
//        // Create the chart if it doesn't exist
//        const context = document.getElementById('canvasLine1010').getContext('2d');

//        window.myCharts['canvasLine1010'] = new Chart(context, {
//            type: 'line',
//            data: {
//                labels: [],
//                datasets: [{
//                    label: 'Values Over Time',
//                    data: [],
//                    backgroundColor: 'rgba(54, 162, 235, 0.2)',
//                    borderColor: 'rgba(54, 162, 235, 1)',
//                    borderWidth: 2,
//                    fill: false,
//                    tension: 0.1
//                }]
//            },
//            options: {
//                responsive: true,
//                scales: {
//                    x: {
//                        type: 'time',
//                        time: {
//                            unit: 'minute'
//                        },
//                        title: {
//                            display: true,
//                            text: 'Timestamp'
//                        }
//                    },
//                    y: {
//                        beginAtZero: true,
//                        title: {
//                            display: true,
//                            text: 'Values'
//                        }
//                    }
//                }
//            }
//        });
//    }

//    // Get the existing chart
//    const myChart = window.myCharts['canvasLine1010'];

//    Line1003ForGraph.forEach(item => {
//        const timestamp = item.cpkLin10We10Timestamp;
//        const value = item.cpkLin10We10Value;

//        if (timestamp) {
//            const date = new Date(timestamp);
//            if (!isNaN(date.getTime())) {
//                // Append new data
//                myChart.data.labels.push(date.toISOString());
//                myChart.data.datasets[0].data.push(value);
//            } else {
//                console.warn("Invalid timestamp:", timestamp);
//            }
//        }
//    });

//    // ✅ Update chart without recreating it
//    myChart.update();
//}

function BindLine1010ToGraph1010(Line1010ForGraph) {
    var labels = [];
    var data = [];

    // Log the data for debugging
    console.log("Sales Data Received:", Line1010ForGraph);

    $.each(Line1010ForGraph, function (index, item) {
        console.log("Item:", item); // Log the entire item to inspect its structure

        // Access the properties using the correct casing
        const timestamp = item.cpkLin10We10Timestamp; // Access the property with the correct casing
        const value = item.cpkLin10We10Value; // Access the property with the correct casing

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

    DestroyCanvasIfExists('canvasLine1010');

    const context = document.getElementById('canvasLine1010').getContext('2d');

    const myChart = new Chart(context, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Values Over Time',
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
                        text: 'Values Value'
                    }
                }
            }
        }
    });
}

function BindLine1011ToGraph1011(Line1011ForGraph) {
    var labels = [];
    var data = [];

    // Log the data for debugging
    console.log("Sales Data Received:", Line1011ForGraph);

    $.each(Line1011ForGraph, function (index, item) {
        console.log("Item:", item); // Log the entire item to inspect its structure

        // Access the properties using the correct casing
        const timestamp = item.cpkLin11We11Timestamp; // Access the property with the correct casing
        const value = item.cpkLin11We11Value; // Access the property with the correct casing

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

    DestroyCanvasIfExists('canvasLine1011');

    const context = document.getElementById('canvasLine1011').getContext('2d');

    const myChart = new Chart(context, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Values Over Time',
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
                        text: 'Values Value'
                    }
                }
            }
        }
    });
}
function BindLine10113ToGraph10113(Line10113ForGraph) {
    if (!window.myCharts) {
        window.myCharts = {};
    }

    if (!window.myCharts['canvasLine10113']) {
        // Create the chart if it doesn't exist
        const context = document.getElementById('canvasLine10113').getContext('2d');

        window.myCharts['canvasLine10113'] = new Chart(context, {
            type: 'line',
            data: {
                labels: [],
                datasets: [{
                    label: 'Values Over Time',
                    data: [],
                    backgroundColor: 'rgba(54, 162, 235, 0.2)',
                    borderColor: 'rgba(54, 162, 235, 1)',
                    borderWidth: 2,
                    fill: false,
                    tension: 0.1
                }]
            },
            options: {
                responsive: true,
                scales: {
                    x: {
                        type: 'time',
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
                            text: 'Values'
                        }
                    }
                }
            }
        });
    }

    // Get the existing chart
    const myChart = window.myCharts['canvasLine10113'];

    Line1003ForGraph.forEach(item => {
        const timestamp = item.cpkLin3We3Timestamp;
        const value = item.cpkLin3We3Value;

        if (timestamp) {
            const date = new Date(timestamp);
            if (!isNaN(date.getTime())) {
                // Append new data
                myChart.data.labels.push(date.toISOString());
                myChart.data.datasets[0].data.push(value);
            } else {
                console.warn("Invalid timestamp:", timestamp);
            }
        }
    });

    // ✅ Update chart without recreating it
    myChart.update();
}
//function BindLine10113ToGraph10113(Line10113ForGraph) {
//    var labels = [];
//    var data = [];

//    // Log the data for debugging
//    console.log("Sales Data Received:", Line10113ForGraph);

//    $.each(Line10113ForGraph, function (index, item) {
//        console.log("Item:", item); // Log the entire item to inspect its structure

//        // Access the properties using the correct casing
//        const timestamp = item.cpkLin3We3Timestamp; // Access the property with the correct casing
//        const value = item.cpkLin3We3Value; // Access the property with the correct casing

//        // Log the values being pushed to labels and data
//        console.log("Timestamp:", timestamp);
//        console.log("Value:", value);

//        // Check if the timestamp is valid
//        if (timestamp) {
//            const date = new Date(timestamp);
//            if (!isNaN(date.getTime())) { // Check if the date is valid
//                labels.push(date); // Use Date object directly
//                data.push(value); // Y-axis: Sales value
//            } else {
//                console.warn("Invalid timestamp:", timestamp);
//            }
//        } else {
//            console.warn("Timestamp is null or undefined for item:", item);
//        }
//    });

//    console.log("Labels:", labels);
//    console.log("Data:", data);

//    // Prevent empty chart rendering
//    if (labels.length === 0 || data.length === 0) {
//        console.warn("Chart data is empty! Check SignalR response.");
//        return;
//    }

//    DestroyCanvasIfExists('canvasLine10113');

//    const context = document.getElementById('canvasLine10113').getContext('2d');

//    const myChart = new Chart(context, {
//        type: 'line',
//        data: {
//            labels: labels,
//            datasets: [{
//                label: 'Values Over Time',
//                data: data,
//                backgroundColor: 'rgba(54, 162, 235, 0.2)', // Light blue
//                borderColor: 'rgba(54, 162, 235, 1)', // Dark blue
//                borderWidth: 2,
//                fill: false,
//                tension: 0.1
//            }]
//        },
//        options: {
//            responsive: true,
//            scales: {
//                x: {
//                    type: 'time', // Ensure time scale is used
//                    time: {
//                        unit: 'minute'
//                    },
//                    title: {
//                        display: true,
//                        text: 'Timestamp'
//                    }
//                },
//                y: {
//                    beginAtZero: true,
//                    title: {
//                        display: true,
//                        text: 'Values Value'
//                    }
//                }
//            }
//        }
//    });
//}
function BindLine1013ToGraph1013(Line1013ForGraph) {
    if (!window.myCharts) {
        window.myCharts = {};
    }

    if (!window.myCharts['canvasLine1013']) {
        // Create the chart if it doesn't exist
        const context = document.getElementById('canvasLine1013').getContext('2d');

        window.myCharts['canvasLine1013'] = new Chart(context, {
            type: 'line',
            data: {
                labels: [],
                datasets: [{
                    label: 'Values Over Time',
                    data: [],
                    backgroundColor: 'rgba(54, 162, 235, 0.2)',
                    borderColor: 'rgba(54, 162, 235, 1)',
                    borderWidth: 2,
                    fill: false,
                    tension: 0.1
                }]
            },
            options: {
                responsive: true,
                scales: {
                    x: {
                        type: 'time',
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
                            text: 'Values'
                        }
                    }
                }
            }
        });
    }

    // Get the existing chart
    const myChart = window.myCharts['canvasLine1013'];

    Line1003ForGraph.forEach(item => {
        const timestamp = item.cpkLine13Wei13Timestamp;
        const value = item.cpkLine13Wei13Value;

        if (timestamp) {
            const date = new Date(timestamp);
            if (!isNaN(date.getTime())) {
                // Append new data
                myChart.data.labels.push(date.toISOString());
                myChart.data.datasets[0].data.push(value);
            } else {
                console.warn("Invalid timestamp:", timestamp);
            }
        }
    });

    // ✅ Update chart without recreating it
    myChart.update();
}
//function BindLine1013ToGraph1013(Line1013ForGraph) {
//    var labels = [];
//    var data = [];

//    console.log("Sales Data Received:", Line1013ForGraph);

//    $.each(Line1013ForGraph, function (index, item) {
//        console.log("Item:", item);

//        // ✅ Correct property name
//        const timestamp = item.cpkLine13Wei13Timestamp;
//        const value = item.cpkLine13Wei13Value;

//        // ✅ Ensure timestamp exists before proceeding
//        if (!timestamp || timestamp === "null") {
//            console.warn("Skipping item with null or undefined timestamp:", item);
//            return; // Skip this item
//        }

//        // ✅ Ensure timestamp is correctly parsed
//        const date = new Date(timestamp);
//        if (isNaN(date.getTime())) {
//            console.warn("Invalid timestamp format:", timestamp);
//            return; // Skip invalid timestamps
//        }

//        labels.push(date.toISOString());
//        console.log("Parsed Date:", date.toISOString());

//        data.push(value);
//    });

//    console.log("Labels:", labels);
//    console.log("Data:", data);

//    if (labels.length === 0 || data.length === 0) {
//        console.warn("Chart data is empty! Check SignalR response.");
//        return;
//    }

//    // ✅ Sort data by timestamp
//    let sortedData = labels.map((label, index) => ({ label, value: data[index] }));
//    sortedData.sort((a, b) => a.label - b.label);
//    labels = sortedData.map(d => d.label);
//    data = sortedData.map(d => d.value);

//    if (!window.myCharts) {
//        window.myCharts = {};
//    }

//    if (window.myCharts['canvasLine1013']) {
//        window.myCharts['canvasLine1013'].destroy();
//    }

//    const context = document.getElementById('canvasLine1013').getContext('2d');

//    window.myCharts['canvasLine1013'] = new Chart(context, {
//        type: 'line',
//        data: {
//            labels: labels,
//            datasets: [{
//                label: 'Values Over Time',
//                data: data,
//                backgroundColor: 'rgba(54, 162, 235, 0.2)',
//                borderColor: 'rgba(54, 162, 235, 1)',
//                borderWidth: 2,
//                fill: false,
//                tension: 0.1
//            }]
//        },
//        options: {
//            responsive: true,
//            scales: {
//                x: {
//                    type: 'time',
//                    time: {
//                        unit: labels.length > 10 ? 'hour' : 'minute',
//                        tooltipFormat: 'yyyy-MM-dd HH:mm:ss',
//                        displayFormats: {
//                            minute: 'HH:mm',
//                            hour: 'MMM dd, HH:mm'
//                        }
//                    },
//                    title: {
//                        display: true,
//                        text: 'Timestamp'
//                    }
//                },
//                y: {
//                    beginAtZero: true,
//                    title: {
//                        display: true,
//                        text: 'Values'
//                    }
//                }
//            }
//        }
//    });
//}
function BindLine1014ToGraph1014(Line1014ForGraph) {
    if (!window.myCharts) {
        window.myCharts = {};
    }

    if (!window.myCharts['canvasLine1014']) {
        // Create the chart if it doesn't exist
        const context = document.getElementById('canvasLine1014').getContext('2d');

        window.myCharts['canvasLine1014'] = new Chart(context, {
            type: 'line',
            data: {
                labels: [],
                datasets: [{
                    label: 'Values Over Time',
                    data: [],
                    backgroundColor: 'rgba(54, 162, 235, 0.2)',
                    borderColor: 'rgba(54, 162, 235, 1)',
                    borderWidth: 2,
                    fill: false,
                    tension: 0.1
                }]
            },
            options: {
                responsive: true,
                scales: {
                    x: {
                        type: 'time',
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
                            text: 'Values'
                        }
                    }
                }
            }
        });
    }

    // Get the existing chart
    const myChart = window.myCharts['canvasLine1014'];

    Line1003ForGraph.forEach(item => {
        const timestamp = item.cpkLine14We14Timestamp;
        const value = item.cpkLine14We14Value;

        if (timestamp) {
            const date = new Date(timestamp);
            if (!isNaN(date.getTime())) {
                // Append new data
                myChart.data.labels.push(date.toISOString());
                myChart.data.datasets[0].data.push(value);
            } else {
                console.warn("Invalid timestamp:", timestamp);
            }
        }
    });

    // ✅ Update chart without recreating it
    myChart.update();
}
//function BindLine1014ToGraph1014(Line1014ForGraph) {
//    var labels = [];
//    var data = [];

//    console.log("Sales Data Received:", Line1014ForGraph);

//    $.each(Line1014ForGraph, function (index, item) {
//        console.log("Item:", item);

//        const timestamp = item.cpkLine14We14Timestamp;
//        const value = item.cpkLine14We14Value;

//        console.log("Timestamp:", timestamp);
//        console.log("Value:", value);

//        if (timestamp) {
//            const date = new Date(timestamp.replace(" ", "T")); // Fix timestamp parsing

//            if (!isNaN(date.getTime())) {
//                labels.push(date);
//                data.push(value);
//            } else {
//                console.warn("Invalid timestamp:", timestamp);
//            }
//        } else {
//            console.warn("Timestamp is null or undefined for item:", item);
//        }
//    });

//    console.log("Labels:", labels);
//    console.log("Data:", data);

//    if (labels.length === 0 || data.length === 0) {
//        console.warn("Chart data is empty! Check SignalR response.");
//        return;
//    }

//    // Sort data by timestamp
//    let sortedData = labels.map((label, index) => ({ label, value: data[index] }));
//    sortedData.sort((a, b) => a.label - b.label);
//    labels = sortedData.map(d => d.label);
//    data = sortedData.map(d => d.value);

//    // Destroy previous chart if exists
//    if (window.myChart) {
//        window.myChart.destroy();
//    }

//    const context = document.getElementById('canvasLine1014').getContext('2d');

//    window.myChart = new Chart(context, {
//        type: 'line',
//        data: {
//            labels: labels,
//            datasets: [{
//                label: 'Values Over Time',
//                data: data,
//                backgroundColor: 'rgba(54, 162, 235, 0.2)',
//                borderColor: 'rgba(54, 162, 235, 1)',
//                borderWidth: 2,
//                fill: false,
//                tension: 0.1
//            }]
//        },
//        options: {
//            responsive: true,
//            scales: {
//                x: {
//                    type: 'time',
//                    time: {
//                        unit: labels.length > 10 ? 'hour' : 'minute',
//                        tooltipFormat: 'yyyy-MM-dd HH:mm:ss',
//                        displayFormats: {
//                            minute: 'HH:mm',
//                            hour: 'MMM dd, HH:mm'
//                        }
//                    },
//                    title: {
//                        display: true,
//                        text: 'Timestamp'
//                    }
//                },
//                y: {
//                    beginAtZero: true,
//                    title: {
//                        display: true,
//                        text: 'Values'
//                    }
//                }
//            }
//        }
//    });
//}
function DestroyCanvasIfExists(canvasId) {
    const canvas = document.getElementById(canvasId);
    if (canvas) {
        const parent = canvas.parentNode;
        parent.removeChild(canvas); // Remove old canvas
        const newCanvas = document.createElement("canvas");
        newCanvas.id = canvasId;
        parent.appendChild(newCanvas);
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
