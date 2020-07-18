$(function () {
    var cy = window.cy = cytoscape({
        container: document.getElementById('cy'),
        boxSelectionEnabled: false,
        autounselectify: true,
        layout: {
            //name: 'dagre'
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
                { data: { source: 'a', target: 'z' } },
                { data: { source: 'a', target: 's' } },
                { data: { source: 's', target: 'x' } },
                { data: { source: 'x', target: 'a' } },
                { data: { source: 'x', target: 'd' } },
                { data: { source: 'x', target: 'c' } },
                { data: { source: 'd', target: 's' } },
                { data: { source: 'd', target: 'c' } },
                { data: { source: 'd', target: 'f' } },
                { data: { source: 'c', target: 'd' } },
                { data: { source: 'c', target: 'f' } },
                { data: { source: 'c', target: 'v' } },
                { data: { source: 'f', target: 'c' } },
                { data: { source: 'v', target: 'f' } }
            ]
        }
    });
});
