$(function () {
    var cy = window.cy = cytoscape({
        container: document.getElementById('cy'),
        boxSelectionEnabled: false,
        autounselectify: true,
        layout: {
            name: 'dagre',
            //name: 'breadthfirst',
            fit: true
        },
        style: [
            {
                selector: 'node',
                style: {
                    'content': 'data(id)',
                    'text-opacity': 0.8,
                    'text-valign': 'center',
                    'color': 'white',
                    'width': 20,
                    'height': 20,
                    //'text-halign': 'top',
                    'background-color': '#11479e'
                    //'background-color': 'green',
                }
            },
            {
                selector: 'edge',
                style: {
                    'width': 2,
                    //'target-arrow-shape': 'triangle',
                    'line-color': '#9dbaea',
                    //'target-arrow-color': '#9dbaea',
                    'curve-style': 'bezier'
                }
            }
        ],
        elements: {
            nodes: [

                { data: { id: 'a' } },
                { data: { id: 'b' } },
                { data: { id: 'c' } },
                { data: { id: 'd' } },
                { data: { id: 'e' } },
                { data: { id: 'f' } },
                { data: { id: 's' } },
                { data: { id: 'v' } },
                { data: { id: 'x' } },
                { data: { id: 'y' } },
                { data: { id: 'z' } }
            ],
            edges: [
                { data: { source: 'a', target: 's' } },
                { data: { source: 'a', target: 'd' } },
                { data: { source: 'b', target: 'c' } },
                { data: { source: 'b', target: 'v' } },
                { data: { source: 'b', target: 'f' } },
                //{ data: { source: 'c', target: 'b' } },
                { data: { source: 'c', target: 'f' } },
                { data: { source: 'c', target: 'v' } },
                //{ data: { source: 'd', target: 'a' } },
                { data: { source: 'd', target: 'x' } },
                { data: { source: 'e', target: 'e' } },
                //{ data: { source: 'f', target: 'c' } },
                //{ data: { source: 'f', target: 'b' } },
                //{ data: { source: 's', target: 'a' } },
                { data: { source: 's', target: 'x' } },
                //{ data: { source: 'v', target: 'b' } },
                //{ data: { source: 'v', target: 'c' } },
                //{ data: { source: 'x', target: 's' } },
                //{ data: { source: 'x', target: 'd' } },
                { data: { source: 'y', target: 'z' } },
                //{ data: { source: 'z', target: 'y' } }
            ]
        }
    });
});
