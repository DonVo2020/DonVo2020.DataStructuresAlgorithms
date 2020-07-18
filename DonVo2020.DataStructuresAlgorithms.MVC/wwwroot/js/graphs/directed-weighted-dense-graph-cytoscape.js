$(function () {
    var cy = window.cy = cytoscape({
        container: document.getElementById('cy'),
        boxSelectionEnabled: false,
        autounselectify: true,
        layout: {
            name: 'breadthfirst',
            fit: true
        },
        style: [
            {
                selector: 'node',
                style: {
                    'content': 'data(id)',
                    'text-opacity': 0.5,
                    'text-valign': 'center',
                    'color': 'white',
                    'width': 50,
                    'height': 50,
                    //'text-halign': 'top',
                    'background-color': '#11479e'
                    //'background-color': 'green',
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

                { data: { id: 'a' } },
                { data: { id: 'z' } },
                { data: { id: 's' } },
                { data: { id: 'x' } },
                { data: { id: 'd' } },
                { data: { id: 'c' } },
                { data: { id: 'f' } },
                { data: { id: 'v' } }
            ],
            edges: [
                { data: { source: 'a', target: 'z', weight: 2 } },
                { data: { source: 'a', target: 's', weight: 1 } },
                { data: { source: 's', target: 'x', weight: 3 } },
                { data: { source: 'x', target: 'a', weight: 3 } },
                { data: { source: 'x', target: 'd', weight: 1 } },
                { data: { source: 'x', target: 'c', weight: 2 } },
                { data: { source: 'd', target: 's', weight: 3 } },
                { data: { source: 'd', target: 'c' , weight: 2} },
                { data: { source: 'd', target: 'f', weight: 1 } },
                { data: { source: 'c', target: 'd', weight: 3 } },
                { data: { source: 'c', target: 'f' , weight: 1} },
                { data: { source: 'c', target: 'v' , weight: 2} },
                { data: { source: 'f', target: 'c' , weight: 2} },
                { data: { source: 'v', target: 'f', weight: 1 } }
            ]
        }
    });
});
