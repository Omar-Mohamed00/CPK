"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/dataHub").build();

if (!window.myCharts) {
    window.myCharts = {};
}

// Event handlers for receiving real-time data
const updateWeightField = (line, elementId, valueKey) => {
    console.log(`Received Data for ${elementId}:`, line);
    let element = document.getElementById(elementId);
    if (element) element.textContent = line[valueKey] || "N/A";
};

connection.on("ReceivedLine1003", (data) => updateWeightField(data, "line1003Weight", "cpkLin3We3Value"));
connection.on("ReceivedLine1010", (data) => updateWeightField(data, "line1010Weight", "cpkLin10We10Value"));
connection.on("ReceivedLine1011", (data) => updateWeightField(data, "line1011Weight", "cpkLin11We11Value"));
connection.on("ReceivedLine10113", (data) => updateWeightField(data, "line10113Weight", "cpkLin3We3Value"));
connection.on("ReceivedLine1013", (data) => updateWeightField(data, "line1013Weight", "cpkLine13Wei13Value"));
connection.on("ReceivedLine1014", (data) => updateWeightField(data, "line1014Weight", "cpkLine14We14Value"));

// Event handlers for receiving average values
const updateAverageField = (avgValue, elementId) => {
    console.log(`Received Average Value for ${elementId}:`, avgValue);
    let element = document.getElementById(elementId);
    if (element) element.textContent = avgValue;
};

connection.on("ReceivedAvgValue", (avgValue) => updateAverageField(avgValue, "line1003Average"));
connection.on("ReceivedAvgValueLine1010", (avgValue) => updateAverageField(avgValue, "line1010Average"));
connection.on("ReceivedAvgValueLine1011", (avgValue) => updateAverageField(avgValue, "line1011Average"));
connection.on("ReceivedAvgValueLine1013", (avgValue) => updateAverageField(avgValue, "line1013Average"));
connection.on("ReceivedAvgValueLine1014", (avgValue) => updateAverageField(avgValue, "line1014Average"));
connection.on("ReceivedAvgValueLine10113", (avgValue) => updateAverageField(avgValue, "line10113Average"));

// Start SignalR connection
$(function () {
    connection.start().then(() => {
        console.log("SignalR Connected!");
        InvokeSales();
    }).catch(err => console.error("SignalR Connection Error:", err.toString()));
});

// Invoke methods to request real-time data
function InvokeSales() {
    ["Sendline1003", "Sendline1010", "Sendline1011", "Sendline10113", "Sendline1013", "Sendline1014"].forEach(line => {
        connection.invoke(line)
            .then(() => console.log(`Successfully invoked ${line}`))
            .catch(err => console.error(`Error invoking ${line}:`, err.toString()));
    });
}

// Bind individual graph functions
function BindLine1003ToGraph(data) { BindDataToGraph("canvasLine1003", data, "Values Over Time", "cpkLin3We3Timestamp", "cpkLin3We3Value"); }
function BindLine1010ToGraph(data) { BindDataToGraph("canvasLine1010", data, "Values Over Time", "cpkLin10We10Timestamp", "cpkLin10We10Value"); }
function BindLine1011ToGraph(data) { BindDataToGraph("canvasLine1011", data, "Values Over Time", "cpkLin11We11Timestamp", "cpkLin11We11Value"); }
function BindLine10113ToGraph(data) { BindDataToGraph("canvasLine10113", data, "Values Over Time", "cpkLin3We3Timestamp", "cpkLin3We3Value"); }
function BindLine1013ToGraph(data) { BindDataToGraph("canvasLine1013", data, "Values Over Time", "cpkLine13Wei13Timestamp", "cpkLine13Wei13Value"); }
function BindLine1014ToGraph(data) { BindDataToGraph("canvasLine1014", data, "Values Over Time", "cpkLine14We14Timestamp", "cpkLine14We14Value"); }

// SignalR real-time updates for graphs
connection.on("ReceivedLine1003ForGraph", BindLine1003ToGraph);
connection.on("ReceivedLine1010ForGraph", BindLine1010ToGraph);
connection.on("ReceivedLine1011ForGraph", BindLine1011ToGraph);
connection.on("ReceivedLine10113ForGraph", BindLine10113ToGraph);
connection.on("ReceivedLine1013ForGraph", BindLine1013ToGraph);
connection.on("ReceivedLine1014ForGraph", BindLine1014ToGraph);

// Bind received data to respective graphs
function BindDataToGraph(chartId, data, label, timestampKey, valueKey) {
    const canvas = document.getElementById(chartId);
    if (!canvas) {
        console.error(`Canvas element '${chartId}' not found!`);
        return;
    }

    if (!window.myCharts[chartId]) {
        const ctx = canvas.getContext('2d');
        window.myCharts[chartId] = new Chart(ctx, {
            type: 'line',
            data: { labels: [], datasets: createDatasets(label) },
            options: createChartOptions()
        });
    }

    const myChart = window.myCharts[chartId];
    if (!Array.isArray(data) || data.length === 0) {
        console.warn(`No data received for ${chartId}`);
        return;
    }

    console.log(`Updating ${chartId} with new data...`);

    // Extract LTL and RTL values specific to each chart
    let ltl = parseFloat(localStorage.getItem(`LTL_${chartId}`)) || 0;
    let rtl = parseFloat(localStorage.getItem(`RTL_${chartId}`)) || 0;

    myChart.data.labels = data.map(item => new Date(item[timestampKey] || item.timestamp).toLocaleTimeString());
    myChart.data.datasets[0].data = data.map(item => item[valueKey] || item.value);
    myChart.data.datasets[1].data = new Array(myChart.data.labels.length).fill(ltl);
    myChart.data.datasets[2].data = new Array(myChart.data.labels.length).fill(rtl);

    myChart.update();
    console.log(`Chart '${chartId}' successfully updated.`);
}

// Helper functions for chart datasets and options
function createDatasets(label) {
    return [
        { label: label, data: [], backgroundColor: 'rgba(54, 162, 235, 0.2)', pointRadius: 1.7, borderColor: 'rgba(54, 162, 235, 1)', borderWidth: 1, fill: true, tension: 0.1 },
        { label: "LTL", data: [], borderColor: "red", borderWidth: 1, pointRadius: 1.7, borderDash: [1, 1], fill: false },
        { label: "RTL", data: [], borderColor: "green", borderWidth: 1, pointRadius: 1.7, borderDash: [1, 1], fill: false }
    ];
}

function createChartOptions() {
    return {
        responsive: true,
        scales: {
            x: { display: true, title: { display: true, text: 'Timestamp' } },
            y: { beginAtZero: true, title: { display: true, text: 'Values' } }
        }
    };
}

// Save and update LTL/RTL limits per chart
function saveLimits(chartId) {
    let ltl = parseFloat(document.getElementById(`ltlInput_${chartId}`).value) || 0;
    let rtl = parseFloat(document.getElementById(`rtlInput_${chartId}`).value) || 0;

    localStorage.setItem(`LTL_${chartId}`, ltl);
    localStorage.setItem(`RTL_${chartId}`, rtl);

    BindDataToGraph(chartId, [], "Updated Values", "", "");
    location.reload();
}

// Load LTL/RTL values on page load for each chart
window.onload = function () {
    ["canvasLine1003", "canvasLine1010", "canvasLine1011", "canvasLine1013", "canvasLine1014", "canvasLine10113"].forEach(chartId => {
        let ltlInput = document.getElementById(`ltlInput_${chartId}`);
        let rtlInput = document.getElementById(`rtlInput_${chartId}`);

        if (ltlInput) ltlInput.value = localStorage.getItem(`LTL_${chartId}`) || 0;
        if (rtlInput) rtlInput.value = localStorage.getItem(`RTL_${chartId}`) || 0;
    });
};
