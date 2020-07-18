$(function () {
    var cy = window.cy = cytoscape({
        container: document.getElementById('cy'),
        boxSelectionEnabled: false,
        autounselectify: true,
        layout: {
            name: 'dagre'
        },
        style: [
            {
                selector: 'node',
                style: {
                    'content': 'data(id)',
                    'text-opacity': 0.8,
                    'text-valign': 'center',
                    'color': 'pink',
                    //'text-halign': 'right',
                    'background-color': '#11479e'
                }
            },
            {
                selector: 'edge',
                style: {
                    'width': 4,
                    //'target-arrow-shape': 'triangle',
                    'line-color': '#9dbaea',
                    //'target-arrow-color': '#9dbaea',
                    'curve-style': 'bezier'
                }
            }
        ],
        elements: {
            nodes: [
                { data: { id: '15' } },
                { data: { id: '25' } },
                { data: { id: '5' } },
                { data: { id: '12' } },
                { data: { id: '1' } },
                { data: { id: '16' } },
                { data: { id: '20' } },
                { data: { id: '9' } },
                { data: { id: '19' } },
                { data: { id: '7' } },
                { data: { id: '4' } },
                { data: { id: '-1' } },
                { data: { id: '11' } },
                { data: { id: '29' } },
                { data: { id: '30' } },
                { data: { id: '8' } },
                { data: { id: '10' } },
                { data: { id: '13' } },
                { data: { id: '28' } },
                { data: { id: '39' } }
            ],
            edges: [
                { data: { source: '15', target: '9' } },
                { data: { source: '15', target: '20' } },
                { data: { source: '9', target: '5' } },
                { data: { source: '9', target: '11' } },
                { data: { source: '20', target: '16' } },
                { data: { source: '20', target: '29' } },
                { data: { source: '5', target: '1' } },
                { data: { source: '5', target: '7' } },
                { data: { source: '11', target: '10' } },
                { data: { source: '11', target: '12' } },
                { data: { source: '16', target: '19' } },
                { data: { source: '29', target: '25' } },
                { data: { source: '29', target: '30' } },
                { data: { source: '1', target: '-1' } },
                { data: { source: '1', target: '4' } },
                { data: { source: '7', target: '8' } },
                { data: { source: '12', target: '13' } },
                { data: { source: '25', target: '28' } },
                { data: { source: '30', target: '39' } }
            ]
        },
    });
});
