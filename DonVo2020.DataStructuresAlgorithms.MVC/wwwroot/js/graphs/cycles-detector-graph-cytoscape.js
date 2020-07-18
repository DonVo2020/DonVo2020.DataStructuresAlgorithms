$(function () {
    var cy = window.cy = cytoscape({
        container: document.getElementById('cy'),
        boxSelectionEnabled: false,
        autounselectify: true,
        layout: {
            name: 'dagre'
            //name: 'breadthfirst',
            //fit: true
        },
        style: [
            {
                selector: 'node',
                style: {
                    'content': 'data(id)',
                    'text-opacity': 0.9,
                    'text-valign': 'center',
                    'color': 'white',
                    'width': 30,
                    'height': 30,
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

                { data: { id: 'r' } },
                { data: { id: 's' } },
                { data: { id: 't' } },
                { data: { id: 'x' } },
                { data: { id: 'y' } },
                { data: { id: 'z' } },

                { data: { id: 'A' } },
                { data: { id: 'B' } },
                { data: { id: 'C' } },
                { data: { id: 'D' } },
                { data: { id: 'E' } },
                { data: { id: 'X' } }
            ],
            edges: [
                { data: { source: 'r', target: 's' } },
                { data: { source: 'r', target: 't' } },
                { data: { source: 's', target: 't' } },
                { data: { source: 's', target: 'x' } },
                { data: { source: 't', target: 'x' } },
                { data: { source: 't', target: 'y' } },
                { data: { source: 't', target: 'z' } },
                { data: { source: 'x', target: 'y' } },
                { data: { source: 'x', target: 'z' } },
                { data: { source: 'y', target: 'z' } },
                { data: { source: 'z', target: 'r' } },
                { data: { source: 'z', target: 's' } },

                //{ data: { source: 'A', target: 'C' } },
                //{ data: { source: 'A', target: 'B' } },
                //{ data: { source: 'B', target: 'A' } },
                //{ data: { source: 'B', target: 'C' } },
                //{ data: { source: 'B', target: 'D' } },
                //{ data: { source: 'C', target: 'A' } },
                //{ data: { source: 'C', target: 'B' } },
                //{ data: { source: 'C', target: 'E' } },
                //{ data: { source: 'C', target: 'D' } },
                //{ data: { source: 'D', target: 'C' } },
                //{ data: { source: 'D', target: 'B' } },
                //{ data: { source: 'D', target: 'E' } },
                //{ data: { source: 'E', target: 'C' } },
                //{ data: { source: 'E', target: 'D' } }



                { data: { source: 'A', target: 'B' } },
                { data: { source: 'A', target: 'X' } },
                { data: { source: 'B', target: 'C' } },
                { data: { source: 'C', target: 'D' } },
                { data: { source: 'D', target: 'E' } },
                { data: { source: 'E', target: 'X' } }

            ]
        }
    });
});
