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
                    'text-opacity': 0.9,
                    'text-valign': 'center',
                    'color': 'blue',
                    'width': 50,
                    'height': 50,
                    //'text-halign': 'top',
                    //'background-color': '#11479e'
                    'background-color': 'orange'
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
                { data: { id: 'root', name: 'Root' } },
                { data: { id: 'a', name: 'a' } },
                { data: { id: 'b', name: 'b' } },
                { data: { id: 'b2', name: 'b' } },
                { data: { id: 'd', name: 'd' } },
                { data: { id: 'd2', name: 'd' } },
                { data: { id: 'e', name: 'e' } },
                { data: { id: 'n', name: 'n' } },
                { data: { id: 'p', name: 'p' } },
                { data: { id: 's', name: 's' } },
                { data: { id: 't', name: 't' } },
                { data: { id: 'n2', name: 'n' } },
                { data: { id: 'n3', name: 'n' } },
                { data: { id: 'n4', name: 'n' } },
                { data: { id: 'n5', name: 'n' } },
                { data: { id: 'n6', name: 'n' } },
                { data: { id: 'n7', name: 'n' } },
                { data: { id: 'n8', name: 'n' } },
                { data: { id: 'n9', name: 'n' } },
                { data: { id: 'n10', name: 'n' } },
                { data: { id: 'a2', name: 'a' } },
                { data: { id: 'a3', name: 'a' } },
                { data: { id: 'a4', name: 'a' } },
                { data: { id: 'a5', name: 'a' } },
                { data: { id: 'a6', name: 'a' } },
                { data: { id: 'a7', name: 'a' } },
                { data: { id: 'a8', name: 'a' } },
                { data: { id: 'a9', name: 'a' } },
                { data: { id: 'a10', name: 'a' } },
                { data: { id: 'a11', name: 'a' } },
                { data: { id: 'a12', name: 'a' } }
            ],
            edges: [
                // banana
                { data: { source: 'root', target: 'b' } },
                { data: { source: 'b', target: 'a' } },
                { data: { source: 'a', target: 'n' } },
                { data: { source: 'n', target: 'a2' } },
                { data: { source: 'a2', target: 'n2' } },
                { data: { source: 'n2', target: 'a3' } },

                // pan
                { data: { source: 'root', target: 'p' } },
                { data: { source: 'p', target: 'a4' } },
                { data: { source: 'a4', target: 'n3' } },

                // and
                { data: { source: 'root', target: 'a5' } },
                { data: { source: 'a5', target: 'n4' } },
                { data: { source: 'n4', target: 'd' } },

                // nab
                { data: { source: 'root', target: 'n5' } },
                { data: { source: 'n5', target: 'a6' } },
                { data: { source: 'a6', target: 'b2' } },

                // antenna
                { data: { source: 'n4', target: 't' } },
                { data: { source: 't', target: 'e' } },
                { data: { source: 'e', target: 'n6' } },
                { data: { source: 'n6', target: 'n7' } },
                { data: { source: 'n7', target: 'a7' } },

                 // bandana
                { data: { source: 'n', target: 'd2' } },
                { data: { source: 'd2', target: 'a8' } },
                { data: { source: 'a8', target: 'n8' } },
                { data: { source: 'n8', target: 'a9' } },

                 // ananas
                { data: { source: 'n4', target: 'a10' } },
                { data: { source: 'a10', target: 'n9' } },
                { data: { source: 'n9', target: 'a11' } },
                { data: { source: 'a11', target: 's' } },  

                // nana
                { data: { source: 'a6', target: 'n10' } },
                { data: { source: 'n10', target: 'a12' } }
            ]
        }
    });
});

