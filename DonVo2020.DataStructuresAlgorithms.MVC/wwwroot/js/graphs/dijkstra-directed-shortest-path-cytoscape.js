$(function () {
    var cy = window.cy = cytoscape({
        container: document.getElementById('cy'),
        boxSelectionEnabled: false,
        autounselectify: true,
        layout: {
            name: 'random',
            fit: true
        },
        style: [
            {
                selector: 'node',
                style: {
                    'content': 'data(id)',
                    'text-opacity': 0.5,
                    'text-valign': 'center',
                    'color': 'yellow',
                    'width': 50,
                    'height': 50,
                    'text-halign': 'top',
                    //'background-color': '#11479e'
                    'background-color': 'green',
                }
            },
            {
                selector: 'edge',
                style: {
                    'width': 2,
                    'target-arrow-shape': 'triangle',
                    'line-color': '#9dbaea',
                    'target-arrow-color': '#9dbaea',
                    'curve-style': 'bezier',
                    'content': 'data(weight)',
                }
            }
        ],
        elements: {
            nodes: [

                { data: { id: 'r' } },
                { data: { id: 's' } },
                { data: { id: 't' } },
                { data: { id: 'x' } },
                { data: { id: 'y' } },
                { data: { id: 'z' } }
            ],
            edges: [
               { data: { source: 'r', target: 's', weight: 7 } },
               { data: { source: 'r', target: 't', weight: 6 } },
               { data: { source: 's', target: 't', weight: 5 } },
               { data: { source: 's', target: 'x', weight: 9 } },
               { data: { source: 't', target: 'x', weight: 10 } },
               { data: { source: 't', target: 'y', weight: 7 } },
               { data: { source: 't', target: 'z', weight: 5 } },
               { data: { source: 'x', target: 'y', weight: 2 } },
               { data: { source: 'x', target: 'z', weight: 4 } },
               { data: { source: 'y', target: '1', weight: 1 } }
            ]
        }
    });
});
