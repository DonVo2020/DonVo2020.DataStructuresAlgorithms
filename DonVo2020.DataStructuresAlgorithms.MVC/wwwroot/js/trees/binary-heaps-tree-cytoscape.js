$(function () {
    var cy = window.cy = cytoscape({
        container: document.getElementById('cy'),
        boxSelectionEnabled: false,
        autounselectify: true,
        layout: {
            name: 'dagre'
            //name: 'preset'
            //fit: true
        },
        style: [
            {
                selector: 'node',
                style: {
                    'content': 'data(name)',
                    'text-opacity': 0.99,
                    'text-valign': 'center',
                    'color': 'white',
                    'width': 30,
                    'height': 30,
                    'background-color': 'gray'
                }
            },
            {
                selector: 'edge',
                style: {
                    'width': 3,
                    'line-color': '#9dbaea',
                    'curve-style': 'bezier'
                }
            }
        ],
        elements: {
            nodes: [
                { data: { id: 'max', name: '93' } },
                { data: { id: 'A1', name: '55' } },
                { data: { id: 'A2', name: '27' } },
                { data: { id: 'A3', name: '42' } },
                { data: { id: 'A4', name: '34' } },
                { data: { id: 'A5', name: '23' } },
                { data: { id: 'A6', name: '15' } },
                { data: { id: 'A7', name: '8' } },
                { data: { id: 'A8', name: '4' } },
                { data: { id: 'A9', name: '12' } },
                { data: { id: 'A10', name: '16' } },
                { data: { id: 'A11', name: '2' } },
                { data: { id: 'A12', name: '9' } },
                { data: { id: 'A13', name: '0' } },
                { data: { id: 'A14', name: '14' } },

                { data: { id: 'min', name: '0' } },
                { data: { id: 'B1', name: '4' } },
                { data: { id: 'B2', name: '2' } },
                { data: { id: 'B3', name: '8' } },
                { data: { id: 'B4', name: '12' } },
                { data: { id: 'B5', name: '9' } },
                { data: { id: 'B6', name: '14' } },
                { data: { id: 'B7', name: '55' } },
                { data: { id: 'B8', name: '42' } },
                { data: { id: 'B9', name: '34' } },
                { data: { id: 'B10', name: '16' } },
                { data: { id: 'B11', name: '23' } },
                { data: { id: 'B12', name: '93' } },
                { data: { id: 'B13', name: '15' } },
                { data: { id: 'B14', name: '27' } }
            ],
            edges: [
                { data: { source: 'max', target: 'A1' } },
                { data: { source: 'max', target: 'A2' } },
                { data: { source: 'A1', target: 'A3' } },
                { data: { source: 'A1', target: 'A4' } },
                { data: { source: 'A3', target: 'A7' } },
                { data: { source: 'A3', target: 'A8' } },
                { data: { source: 'A4', target: 'A9' } },
                { data: { source: 'A4', target: 'A10' } },
                { data: { source: 'A2', target: 'A5' } },
                { data: { source: 'A2', target: 'A6' } },
                { data: { source: 'A5', target: 'A11' } },
                { data: { source: 'A5', target: 'A12' } },
                { data: { source: 'A6', target: 'A13' } },
                { data: { source: 'A6', target: 'A14' } },

                { data: { source: 'min', target: 'B1' } },
                { data: { source: 'min', target: 'B2' } },
                { data: { source: 'B1', target: 'B3' } },
                { data: { source: 'B1', target: 'B4' } },
                { data: { source: 'B3', target: 'B7' } },
                { data: { source: 'B3', target: 'B8' } },
                { data: { source: 'B4', target: 'B9' } },
                { data: { source: 'B4', target: 'B10' } },
                { data: { source: 'B2', target: 'B5' } },
                { data: { source: 'B2', target: 'B6' } },
                { data: { source: 'B5', target: 'B11' } },
                { data: { source: 'B5', target: 'B12' } },
                { data: { source: 'B6', target: 'B13' } },
                { data: { source: 'B6', target: 'B14' } },

            ]
        }
    });
});

