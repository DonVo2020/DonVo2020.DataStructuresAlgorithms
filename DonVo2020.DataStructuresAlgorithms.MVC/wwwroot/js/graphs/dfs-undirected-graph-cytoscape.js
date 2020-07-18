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
                    'color': 'green',
                    'width': 50,
                    'height': 50,
                    //'text-halign': 'top',
                    //'background-color': '#11479e'
                    'background-color': 'pink',
                }
            },
            {
                selector: 'edge',
                style: {
                    'width': 2,
                    'line-color': '#9dbaea',
                    'curve-style': 'bezier'
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
                { data: { source: 's', target: 'a' } },
                { data: { source: 's', target: 'x' } },
                { data: { source: 'a', target: 'z' } },
                { data: { source: 'x', target: 'c' } },
                { data: { source: 'c', target: 'v' } },
                { data: { source: 'f', target: 'v' } },
                { data: { source: 'f', target: 'd' } },
            ]
        }
    });
});

