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
                    'color': 'yellow',
                    //'text-halign': 'right',
                    //'background-color': '#11479e'
                    'background-color': 'black'
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
                { data: { id: '0' } },
                { data: { id: '1' } },
                { data: { id: '2' } },
                { data: { id: '3' } },             
                { data: { id: '4' } },
                { data: { id: '5' } },
                { data: { id: '6' } },
                { data: { id: '7' } },
                { data: { id: '8' } },
                { data: { id: '9' } },
                { data: { id: '10' } }
            ],
            edges: [
                { data: { source: '5', target: '2' } },
                { data: { source: '5', target: '7' } },
                { data: { source: '2', target: '1' } },
                { data: { source: '2', target: '4' } },
                { data: { source: '7', target: '6' } },
                { data: { source: '7', target: '9' } },
                { data: { source: '1', target: '0' } },
                { data: { source: '4', target: '3' } },
                { data: { source: '9', target: '8' } },
                { data: { source: '9', target: '10' } }
            ]
        },
    });
});
